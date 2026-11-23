package com.plushcrush.unity.billing;

import android.app.Activity;

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

import org.json.JSONArray;
import org.json.JSONObject;

import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Google Play Billing (Billing Library 8) for one-time products, for the Unity app: the app's
 * android/app/src/main/java/com/plushcrush/app/billing/PlayBillingModule.java with its React promises as callbacks
 * (Backend/Billing.cs implements Callback and Listener with AndroidJavaProxy). Results are JSON text.
 *
 * As in the app, the device only launches purchases and lists them: granting, acknowledging and consuming happen in
 * the verifyPurchase Cloud Function, after it has checked the purchase token with the Play Developer API.
 */
public class PlayBilling implements PurchasesUpdatedListener {
    /** One answer: `json` on success, else `error` (a code: cancelled, already_owned, busy, network, ...) and `message`. */
    public interface Callback {
        void done(String json, String error, String message);
    }

    /** Purchases Play reports outside a purchase flow (a pending payment that cleared): a JSON array. */
    public interface Listener {
        void purchases(String json);
    }

    private final BillingClient client;
    private final Listener listener;
    private final Map<String, ProductDetails> details = new HashMap<>();
    private final List<Callback> connectWaiters = new ArrayList<>();
    private boolean connecting = false;
    private Callback pendingPurchase;

    public PlayBilling(Activity activity, Listener listener) {
        this.listener = listener;
        client = BillingClient.newBuilder(activity.getApplicationContext())
                .setListener(this)
                .enablePendingPurchases(PendingPurchasesParams.newBuilder().enableOneTimeProducts().build())
                .enableAutoServiceReconnection()
                .build();
    }

    // --- connection: "true" once connected, "false" if billing isn't available here --------------------------------
    public void connect(Callback cb) {
        if (client.isReady()) {
            cb.done("true", null, null);
            return;
        }
        synchronized (connectWaiters) {
            connectWaiters.add(cb);
            if (connecting) return;
            connecting = true;
        }
        client.startConnection(new BillingClientStateListener() {
            @Override
            public void onBillingSetupFinished(BillingResult result) {
                settleConnect(result.getResponseCode() == BillingClient.BillingResponseCode.OK);
            }

            @Override
            public void onBillingServiceDisconnected() {
                settleConnect(false);
            }
        });
    }

    private void settleConnect(boolean ok) {
        List<Callback> waiters;
        synchronized (connectWaiters) {
            waiters = new ArrayList<>(connectWaiters);
            connectWaiters.clear();
            connecting = false;
        }
        for (Callback c : waiters) c.done(ok ? "true" : "false", null, null);
    }

    // --- products: [{ id, title, price, priceMicros, currency }] for the ones in the Play Console ----------------------
    public void getProducts(String idsJson, Callback cb) {
        if (!client.isReady()) {
            cb.done(null, "not_connected", "Google Play billing isn't connected");
            return;
        }
        List<QueryProductDetailsParams.Product> products = new ArrayList<>();
        try {
            JSONArray ids = new JSONArray(idsJson);
            for (int i = 0; i < ids.length(); i++) {
                products.add(QueryProductDetailsParams.Product.newBuilder()
                        .setProductId(ids.getString(i))
                        .setProductType(BillingClient.ProductType.INAPP)
                        .build());
            }
        } catch (Exception e) {
            cb.done(null, "failed", e.getMessage());
            return;
        }
        if (products.isEmpty()) {
            cb.done("[]", null, null);
            return;
        }
        QueryProductDetailsParams params = QueryProductDetailsParams.newBuilder().setProductList(products).build();
        client.queryProductDetailsAsync(params, (result, found) -> {
            if (result.getResponseCode() != BillingClient.BillingResponseCode.OK) {
                cb.done(null, code(result), result.getDebugMessage());
                return;
            }
            JSONArray out = new JSONArray();
            try {
                for (ProductDetails d : found.getProductDetailsList()) {
                    details.put(d.getProductId(), d);
                    ProductDetails.OneTimePurchaseOfferDetails offer = d.getOneTimePurchaseOfferDetails();
                    JSONObject m = new JSONObject();
                    m.put("id", d.getProductId());
                    m.put("title", d.getName());
                    if (offer != null) {
                        m.put("price", offer.getFormattedPrice());
                        m.put("priceMicros", offer.getPriceAmountMicros());
                        m.put("currency", offer.getPriceCurrencyCode());
                    }
                    out.put(m);
                }
            } catch (Exception e) {
                cb.done(null, "failed", e.getMessage());
                return;
            }
            cb.done(out.toString(), null, null);
        });
    }

    // --- purchasing: Play's sheet; `uid` hashed into the obfuscated account id, `profileId` (a creature id or "") --------
    public void purchase(Activity activity, String productId, String uid, String profileId, Callback cb) {
        ProductDetails d = details.get(productId);
        if (activity == null) {
            cb.done(null, "no_activity", "The app isn't in the foreground");
            return;
        }
        if (d == null) {
            cb.done(null, "unknown_product", "Product not loaded: " + productId);
            return;
        }
        if (pendingPurchase != null) {
            cb.done(null, "busy", "Another purchase is in progress");
            return;
        }
        BillingFlowParams.ProductDetailsParams.Builder pdp = BillingFlowParams.ProductDetailsParams.newBuilder().setProductDetails(d);
        ProductDetails.OneTimePurchaseOfferDetails offer = d.getOneTimePurchaseOfferDetails();
        if (offer != null && offer.getOfferToken() != null) pdp.setOfferToken(offer.getOfferToken());
        BillingFlowParams.Builder flow = BillingFlowParams.newBuilder()
                .setProductDetailsParamsList(Collections.singletonList(pdp.build()))
                .setObfuscatedAccountId(sha256(uid));
        if (profileId != null && !profileId.isEmpty()) flow.setObfuscatedProfileId(profileId);
        pendingPurchase = cb;
        activity.runOnUiThread(() -> {
            BillingResult result = client.launchBillingFlow(activity, flow.build());
            if (result.getResponseCode() != BillingClient.BillingResponseCode.OK) {
                Callback c = pendingPurchase;
                pendingPurchase = null;
                if (c != null) c.done(null, code(result), result.getDebugMessage());
            }
        });
    }

    @Override
    public void onPurchasesUpdated(BillingResult result, List<Purchase> purchases) {
        Callback c = pendingPurchase;
        pendingPurchase = null;
        if (result.getResponseCode() == BillingClient.BillingResponseCode.OK) {
            String list = toJson(purchases);
            if (c != null) c.done(list, null, null);
            else if (listener != null) listener.purchases(list);
        } else if (c != null) {
            c.done(null, code(result), result.getDebugMessage());
        }
    }

    /** Every one-time purchase Play knows this account owns (unconsumed). */
    public void getPurchases(Callback cb) {
        if (!client.isReady()) {
            cb.done(null, "not_connected", "Google Play billing isn't connected");
            return;
        }
        QueryPurchasesParams params = QueryPurchasesParams.newBuilder().setProductType(BillingClient.ProductType.INAPP).build();
        client.queryPurchasesAsync(params, (result, purchases) -> {
            if (result.getResponseCode() != BillingClient.BillingResponseCode.OK) cb.done(null, code(result), result.getDebugMessage());
            else cb.done(toJson(purchases), null, null);
        });
    }

    // --- helpers -------------------------------------------------------------------------------------------------------
    private static String toJson(List<Purchase> purchases) {
        JSONArray out = new JSONArray();
        if (purchases == null) return out.toString();
        try {
            for (Purchase p : purchases) {
                JSONObject m = new JSONObject();
                JSONArray products = new JSONArray();
                for (String id : p.getProducts()) products.put(id);
                m.put("products", products);
                m.put("purchaseToken", p.getPurchaseToken());
                m.put("orderId", p.getOrderId());
                int state = p.getPurchaseState();
                m.put("state", state == Purchase.PurchaseState.PURCHASED ? "purchased" : state == Purchase.PurchaseState.PENDING ? "pending" : "unknown");
                m.put("acknowledged", p.isAcknowledged());
                AccountIdentifiers ids = p.getAccountIdentifiers();
                m.put("profileId", ids != null ? ids.getObfuscatedProfileId() : JSONObject.NULL);
                out.put(m);
            }
        } catch (Exception e) {
            // (org.json only throws on NaN keys)
        }
        return out.toString();
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
