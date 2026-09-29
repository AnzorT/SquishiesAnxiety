package com.plushcrush.app.billing;

import android.app.Activity;

import androidx.annotation.NonNull;

import com.android.billingclient.api.AccountIdentifiers;
import com.android.billingclient.api.BillingClient;
import com.android.billingclient.api.BillingClientStateListener;
import com.android.billingclient.api.BillingFlowParams;
import com.android.billingclient.api.BillingResult;
import com.android.billingclient.api.PendingPurchasesParams;
import com.android.billingclient.api.ProductDetails;
import com.android.billingclient.api.Purchase;
import com.android.billingclient.api.PurchasesUpdatedListener;
import com.android.billingclient.api.QueryProductDetailsParams;
import com.android.billingclient.api.QueryPurchasesParams;
import com.facebook.react.bridge.Arguments;
import com.facebook.react.bridge.Promise;
import com.facebook.react.bridge.ReactApplicationContext;
import com.facebook.react.bridge.ReactContextBaseJavaModule;
import com.facebook.react.bridge.ReactMethod;
import com.facebook.react.bridge.ReadableArray;
import com.facebook.react.bridge.WritableArray;
import com.facebook.react.bridge.WritableMap;
import com.facebook.react.modules.core.DeviceEventManagerModule;

import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Google Play Billing (Billing Library 8) for one-time products, exposed to
 * JS as NativeModules.PlayBilling — see src/billing/index.js.
 *
 * The app only ever launches purchases and lists them here. Granting,
 * acknowledging and consuming happen on the server (the verifyPurchase Cloud
 * Function checks each purchase token with the Play Developer API first), so
 * a purchase is never marked done on the device before it's been paid for.
 */
public class PlayBillingModule extends ReactContextBaseJavaModule implements PurchasesUpdatedListener {
    public static final String NAME = "PlayBilling";
    private static final String EVENT_PURCHASES = "PlayBillingPurchases";

    private final BillingClient client;
    private final Map<String, ProductDetails> details = new HashMap<>();
    private final List<Promise> connectWaiters = new ArrayList<>();
    private boolean connecting = false;
    // The purchase flow in progress, settled by onPurchasesUpdated.
    private Promise pendingPurchase;

    public PlayBillingModule(ReactApplicationContext context) {
        super(context);
        client = BillingClient.newBuilder(context)
                .setListener(this)
                .enablePendingPurchases(PendingPurchasesParams.newBuilder().enableOneTimeProducts().build())
                .enableAutoServiceReconnection()
                .build();
    }

    @NonNull
    @Override
    public String getName() {
        return NAME;
    }

    // --- connection ------------------------------------------------------

    /** Resolves true once connected to Google Play, false if billing isn't available here. */
    @ReactMethod
    public void connect(Promise promise) {
        if (client.isReady()) {
            promise.resolve(true);
            return;
        }
        synchronized (connectWaiters) {
            connectWaiters.add(promise);
            if (connecting) return;
            connecting = true;
        }
        client.startConnection(new BillingClientStateListener() {
            @Override
            public void onBillingSetupFinished(@NonNull BillingResult result) {
                settleConnect(result.getResponseCode() == BillingClient.BillingResponseCode.OK);
            }

            @Override
            public void onBillingServiceDisconnected() {
                settleConnect(false);
            }
        });
    }

    private void settleConnect(boolean ok) {
        List<Promise> waiters;
        synchronized (connectWaiters) {
            waiters = new ArrayList<>(connectWaiters);
            connectWaiters.clear();
            connecting = false;
        }
        for (Promise p : waiters) p.resolve(ok);
    }

    // --- products ----------------------------------------------------------

    /** [{ id, title, price, priceMicros, currency }] for the one-time products that exist in the Play Console. */
    @ReactMethod
    public void getProducts(ReadableArray ids, Promise promise) {
        if (!client.isReady()) {
            promise.reject("not_connected", "Google Play billing isn't connected");
            return;
        }
        List<QueryProductDetailsParams.Product> products = new ArrayList<>();
        for (int i = 0; i < ids.size(); i++) {
            products.add(QueryProductDetailsParams.Product.newBuilder()
                    .setProductId(ids.getString(i))
                    .setProductType(BillingClient.ProductType.INAPP)
                    .build());
        }
        if (products.isEmpty()) {
            promise.resolve(Arguments.createArray());
            return;
        }
        QueryProductDetailsParams params = QueryProductDetailsParams.newBuilder().setProductList(products).build();
        client.queryProductDetailsAsync(params, (result, found) -> {
            if (result.getResponseCode() != BillingClient.BillingResponseCode.OK) {
                promise.reject(code(result), result.getDebugMessage());
                return;
            }
            WritableArray out = Arguments.createArray();
            for (ProductDetails d : found.getProductDetailsList()) {
                details.put(d.getProductId(), d);
                ProductDetails.OneTimePurchaseOfferDetails offer = d.getOneTimePurchaseOfferDetails();
                WritableMap m = Arguments.createMap();
                m.putString("id", d.getProductId());
                m.putString("title", d.getName());
                if (offer != null) {
                    m.putString("price", offer.getFormattedPrice());
                    m.putDouble("priceMicros", offer.getPriceAmountMicros());
                    m.putString("currency", offer.getPriceCurrencyCode());
                }
                out.pushMap(m);
            }
            promise.resolve(out);
        });
    }

    // --- purchasing --------------------------------------------------------

    /**
     * Opens Google Play's purchase sheet. `uid` is hashed (SHA-256) into the
     * purchase's obfuscated account id so the server can check the purchase
     * belongs to the player sending it; `profileId` (a creature id, or "")
     * rides along as the obfuscated profile id. Resolves with the purchases
     * Play reports; rejects "cancelled", "already_owned" or another code.
     */
    @ReactMethod
    public void purchase(String productId, String uid, String profileId, Promise promise) {
        Activity activity = getCurrentActivity();
        ProductDetails d = details.get(productId);
        if (activity == null) {
            promise.reject("no_activity", "The app isn't in the foreground");
            return;
        }
        if (d == null) {
            promise.reject("unknown_product", "Product not loaded: " + productId);
            return;
        }
        if (pendingPurchase != null) {
            promise.reject("busy", "Another purchase is in progress");
            return;
        }
        BillingFlowParams.ProductDetailsParams.Builder pdp = BillingFlowParams.ProductDetailsParams.newBuilder().setProductDetails(d);
        ProductDetails.OneTimePurchaseOfferDetails offer = d.getOneTimePurchaseOfferDetails();
        if (offer != null && offer.getOfferToken() != null) pdp.setOfferToken(offer.getOfferToken());
        BillingFlowParams.Builder flow = BillingFlowParams.newBuilder()
                .setProductDetailsParamsList(Collections.singletonList(pdp.build()))
                .setObfuscatedAccountId(sha256(uid));
        if (profileId != null && !profileId.isEmpty()) flow.setObfuscatedProfileId(profileId);

        pendingPurchase = promise;
        BillingResult result = client.launchBillingFlow(activity, flow.build());
        if (result.getResponseCode() != BillingClient.BillingResponseCode.OK) {
            pendingPurchase = null;
            promise.reject(code(result), result.getDebugMessage());
        }
    }

    @Override
    public void onPurchasesUpdated(@NonNull BillingResult result, List<Purchase> purchases) {
        Promise p = pendingPurchase;
        pendingPurchase = null;
        int rc = result.getResponseCode();
        if (rc == BillingClient.BillingResponseCode.OK) {
            WritableArray list = toArray(purchases);
            if (p != null) p.resolve(list);
            else emit(toArray(purchases)); // e.g. a pending purchase that just cleared
        } else if (p != null) {
            p.reject(code(result), result.getDebugMessage());
        }
    }

    /** Every one-time purchase Play knows this account owns (unconsumed). */
    @ReactMethod
    public void getPurchases(Promise promise) {
        if (!client.isReady()) {
            promise.reject("not_connected", "Google Play billing isn't connected");
            return;
        }
        QueryPurchasesParams params = QueryPurchasesParams.newBuilder().setProductType(BillingClient.ProductType.INAPP).build();
        client.queryPurchasesAsync(params, (result, purchases) -> {
            if (result.getResponseCode() != BillingClient.BillingResponseCode.OK) promise.reject(code(result), result.getDebugMessage());
            else promise.resolve(toArray(purchases));
        });
    }

    // NativeEventEmitter bookkeeping (required on the old architecture).
    @ReactMethod
    public void addListener(String eventName) {}

    @ReactMethod
    public void removeListeners(double count) {}

    // --- helpers -----------------------------------------------------------

    private void emit(WritableArray purchases) {
        ReactApplicationContext ctx = getReactApplicationContext();
        if (!ctx.hasActiveReactInstance()) return;
        ctx.getJSModule(DeviceEventManagerModule.RCTDeviceEventEmitter.class).emit(EVENT_PURCHASES, purchases);
    }

    private static WritableArray toArray(List<Purchase> purchases) {
        WritableArray out = Arguments.createArray();
        if (purchases == null) return out;
        for (Purchase p : purchases) {
            WritableMap m = Arguments.createMap();
            WritableArray products = Arguments.createArray();
            for (String id : p.getProducts()) products.pushString(id);
            m.putArray("products", products);
            m.putString("purchaseToken", p.getPurchaseToken());
            m.putString("orderId", p.getOrderId());
            // PURCHASED / PENDING / UNSPECIFIED_STATE
            int state = p.getPurchaseState();
            m.putString("state", state == Purchase.PurchaseState.PURCHASED ? "purchased" : state == Purchase.PurchaseState.PENDING ? "pending" : "unknown");
            m.putBoolean("acknowledged", p.isAcknowledged());
            AccountIdentifiers ids = p.getAccountIdentifiers();
            m.putString("profileId", ids != null ? ids.getObfuscatedProfileId() : null);
            out.pushMap(m);
        }
        return out;
    }

    private static String code(BillingResult result) {
        switch (result.getResponseCode()) {
            case BillingClient.BillingResponseCode.USER_CANCELED:
                return "cancelled";
            case BillingClient.BillingResponseCode.ITEM_ALREADY_OWNED:
                return "already_owned";
            case BillingClient.BillingResponseCode.ITEM_UNAVAILABLE:
                return "unavailable";
            case BillingClient.BillingResponseCode.BILLING_UNAVAILABLE:
            case BillingClient.BillingResponseCode.SERVICE_UNAVAILABLE:
            case BillingClient.BillingResponseCode.SERVICE_DISCONNECTED:
                return "billing_unavailable";
            case BillingClient.BillingResponseCode.NETWORK_ERROR:
                return "network";
            default:
                return "error_" + result.getResponseCode();
        }
    }

    static String sha256(String s) {
        try {
            byte[] hash = MessageDigest.getInstance("SHA-256").digest((s == null ? "" : s).getBytes(StandardCharsets.UTF_8));
            StringBuilder hex = new StringBuilder();
            for (byte b : hash) hex.append(String.format("%02x", b));
            return hex.toString();
        } catch (Exception e) {
            return "";
        }
    }
}
