// squad-store.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_squad_store_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("[^a-z]", "g");
        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V SVGV_8 = default;
V CARD_9 = default;
V KEY_10 = default;
V RAR_11 = default;
V SETS_12 = default;
V HEROES_13 = default;
V ELEMENTAL_14 = default;
V SEASON_15 = default;
V R_16 = default;
V ART_17 = default;
V KEYOF_18 = default;
V ALIAS_19 = default;
V AK_20 = default;
V REWARD_21 = default;
V ROSTER_22 = default;
V STAR_PRICE_23 = default;
V COIN_PRICE_24 = default;
V DUPE_25 = default;
V FIN_26 = default;
V STAGES_27 = default;
V STAGE_FX_28 = default;
V CHESTS_29 = default;
double SET_BONUS_30 = 0;
V SEED_31 = default;
V S_32 = default;
V pend_33 = default;
V emit_34 = default;
V load_35 = default;
V save_36 = default;
V prof_37 = default;
V API_38 = default;
if (_self1.IsNullish) _self1 = GlobalV;
emit_34 = Fn((V _self39, int _argc40, V _a42, V _a43, V _a44, V _a45, V[] _rest41) => {
if (_self39.IsNullish) _self39 = GlobalV;
if (Truthy(pend_33)) {
return default;
}
pend_33 = (true ? V.True : V.False);
Call(G("setTimeout"), V.Undef, Fn((V _self39, int _argc52, V _a54, V _a55, V _a56, V _a57, V[] _rest53) => {
pend_33 = (false ? V.True : V.False);
Invoke(G("window"), "dispatchEvent", New(G("CustomEvent"), ((V)("squishsquad"))));
return default;
}, 0, "", true), ((V)(0D)));
return default;
}, 0, "emit", false);
load_35 = Fn((V _self58, int _argc59, V _a61, V _a62, V _a63, V _a64, V[] _rest60) => {
if (_self58.IsNullish) _self58 = GlobalV;
if (Truthy(S_32)) {
return S_32;
}
try {
S_32 = Invoke(G("JSON"), "parse", Invoke(G("localStorage"), "getItem", KEY_10));
} catch (System.Exception _ex65) {
V e_66 = default;
e_66 = Caught(_ex65);

}
if ((!(Truthy(S_32)) || !SEqN(Get(S_32, "v"), 1D))) {
S_32 = Call(SEED_31, V.Undef);
Call(save_36, V.Undef, (true ? V.True : V.False));
}
if (Truthy(Get(S_32, "col"))) {
Invoke(Object_keys(Get(S_32, "col")), "forEach", Fn((V _self58, int _argc67, V id_73, V _a70, V _a71, V _a72, V[] _rest68) => {
if (!(Truthy(GetIdx(ROSTER_22, ToNum(id_73))))) {
DeleteK(Get(S_32, "col"), id_73);
}
return default;
}, 1, "", true));
}
if (!(Truthy(Get(S_32, "fp11")))) {
if (Truthy(Get(S_32, "col"))) {
DeleteK(Get(S_32, "col"), ((V)(107D)));
}
Set(S_32, "fp11", ((V)(1D)));
Call(save_36, V.Undef, (true ? V.True : V.False));
}
return S_32;
return default;
}, 0, "load", false);
save_36 = Fn((V _self74, int _argc75, V silent_81, V _a78, V _a79, V _a80, V[] _rest76) => {
if (_self74.IsNullish) _self74 = GlobalV;
try {
Invoke(G("localStorage"), "setItem", KEY_10, Invoke(G("JSON"), "stringify", S_32));
} catch (System.Exception _ex82) {
V e_83 = default;
e_83 = Caught(_ex82);

}
if (!(Truthy(silent_81))) {
Call(emit_34, V.Undef);
}
return default;
}, 1, "save", false);
SVGV_8 = NewObj(44).Put("duchess", ((V)(4D))).Put("mittens", ((V)(2D))).Put("biscuit", ((V)(2D))).Put("truffle", ((V)(2D))).Put("waffles", ((V)(2D))).Put("scoop", ((V)(2D))).Put("teddy", ((V)(2D))).Put("hoot", ((V)(2D))).Put("leo", ((V)(2D))).Put("nibbles", ((V)(2D))).Put("quill", ((V)(2D))).Put("panko", ((V)(2D))).Put("boba", ((V)(2D))).Put("avo", ((V)(2D))).Put("ember", ((V)(2D))).Put("drako", ((V)(2D))).Put("twisty", ((V)(3D))).Put("crois", ((V)(3D))).Put("frankie", ((V)(3D))).Put("peppi", ((V)(3D))).Put("nori", ((V)(4D))).Put("sunny", ((V)(3D))).Put("churro", ((V)(3D))).Put("khinki", ((V)(4D))).Put("maki", ((V)(6D))).Put("pico", ((V)(4D))).Put("puddles", ((V)(5D))).Put("clover", ((V)(2D))).Put("chilla", ((V)(2D))).Put("mimi", ((V)(2D))).Put("zippy", ((V)(5D))).Put("bean", ((V)(4D))).Put("tilly", ((V)(3D))).Put("ribbit", ((V)(3D))).Put("plummy", ((V)(1D))).Put("corny", ((V)(2D))).Put("noodle", ((V)(2D))).Put("bing", ((V)(2D))).Put("clemmy", ((V)(2D))).Put("blueby", ((V)(2D))).Put("mangie", ((V)(2D))).Put("razzy", ((V)(2D))).Put("perry", ((V)(3D))).Put("coco", ((V)(3D))).V;
CARD_9 = NewObj(25).Put("quill", ((V)(2D))).Put("seaturtle", ((V)(2D))).Put("marina", ((V)(1D))).Put("shelly", ((V)(2D))).Put("puff", ((V)(1D))).Put("pearl", ((V)(1D))).Put("pina", ((V)(1D))).Put("moss", ((V)(1D))).Put("berri", ((V)(1D))).Put("lemmy", ((V)(1D))).Put("kiwi", ((V)(1D))).Put("peachy", ((V)(1D))).Put("melo", ((V)(1D))).Put("pitaya", ((V)(1D))).Put("tutti", ((V)(1D))).Put("hana", ((V)(1D))).Put("boo", ((V)(1D))).Put("pixie", ((V)(1D))).Put("floof", ((V)(1D))).Put("unibun", ((V)(1D))).Put("gumdrop", ((V)(1D))).Put("ember", ((V)(1D))).Put("drako", ((V)(1D))).Put("jinni", ((V)(1D))).Put("kiko", ((V)(1D))).V;
if (Truthy(Get(G("window"), "SquishSquad"))) {
return default;
}
KEY_10 = ((V)("squishsquad.collection.v1"));
RAR_11 = Arr(NewObj(7).Put("k", ((V)("Common"))).Put("label", ((V)("COMMON"))).Put("bg", ((V)("#d7f0ff"))).Put("dot", ((V)("#9fd8ff"))).Put("ink", ((V)("#2f7fd6"))).Put("card", ((V)("#e6f5ff"))).Put("lip", ((V)("#a9d2f2"))).V, NewObj(7).Put("k", ((V)("Rare"))).Put("label", ((V)("RARE"))).Put("bg", ((V)("#c9f7e1"))).Put("dot", ((V)("#7ee8b4"))).Put("ink", ((V)("#16a86a"))).Put("card", ((V)("#e2fbef"))).Put("lip", ((V)("#98dcbc"))).V, NewObj(7).Put("k", ((V)("Epic"))).Put("label", ((V)("EPIC"))).Put("bg", ((V)("#ead6ff"))).Put("dot", ((V)("#c89bff"))).Put("ink", ((V)("#8f3cf2"))).Put("card", ((V)("#f1e6ff"))).Put("lip", ((V)("#cdb0f2"))).V, NewObj(7).Put("k", ((V)("Legendary"))).Put("label", ((V)("LEGENDARY"))).Put("bg", ((V)("#ffdcb0"))).Put("dot", ((V)("#ffa94d"))).Put("ink", ((V)("#d9772f"))).Put("card", ((V)("#fff0dc"))).Put("lip", ((V)("#f2c98f"))).V, NewObj(7).Put("k", ((V)("Rainbow"))).Put("label", ((V)("RAINBOW"))).Put("bg", ((V)("#ffe0f3"))).Put("dot", ((V)("#ff8fd3"))).Put("ink", ((V)("#d3179a"))).Put("card", ((V)("#ffe9f6"))).Put("lip", ((V)("#f0a8d8"))).V);
SETS_12 = Arr(NewObj(7).Put("key", ((V)("snack"))).Put("name", ((V)("Snack Shack"))).Put("vibe", ((V)("Street-food buddies"))).Put("tint", ((V)("#fff0e2"))).Put("lip", ((V)("#f2c7a0"))).Put("ink", ((V)("#c4651f"))).Put("perk", ((V)("Unlocks the Snack Shack kitchen theme"))).V, NewObj(7).Put("key", ((V)("fruit"))).Put("name", ((V)("Fruit Patch"))).Put("vibe", ((V)("Juicy and bright"))).Put("tint", ((V)("#fff6d6"))).Put("lip", ((V)("#ecd078"))).Put("ink", ((V)("#b88a00"))).Put("perk", ((V)("Unlocks a fruit-stand furniture set"))).V, NewObj(7).Put("key", ((V)("ocean"))).Put("name", ((V)("Ocean Pals"))).Put("vibe", ((V)("Splashy and squishy"))).Put("tint", ((V)("#e4f3ff"))).Put("lip", ((V)("#a9d2f2"))).Put("ink", ((V)("#2f7fd6"))).Put("perk", ((V)("Unlocks the aquarium wall"))).V, NewObj(7).Put("key", ((V)("pet"))).Put("name", ((V)("Pet Shop"))).Put("vibe", ((V)("Furry best friends"))).Put("tint", ((V)("#ffe9f6"))).Put("lip", ((V)("#f0a8d8"))).Put("ink", ((V)("#c0268f"))).Put("perk", ((V)("Unlocks the pet bed set"))).V, NewObj(7).Put("key", ((V)("forest"))).Put("name", ((V)("Forest Friends"))).Put("vibe", ((V)("Cozy woodland"))).Put("tint", ((V)("#e2fbef"))).Put("lip", ((V)("#98dcbc"))).Put("ink", ((V)("#16a86a"))).Put("perk", ((V)("Unlocks the forest room theme"))).V, NewObj(7).Put("key", ((V)("sky"))).Put("name", ((V)("Sky & Stars"))).Put("vibe", ((V)("Dreamy night sky"))).Put("tint", ((V)("#ece6ff"))).Put("lip", ((V)("#c3b0f2"))).Put("ink", ((V)("#5a3ad0"))).Put("perk", ((V)("Unlocks the starry ceiling"))).V, NewObj(7).Put("key", ((V)("dream"))).Put("name", ((V)("Dreamland"))).Put("vibe", ((V)("Fantasy and magic"))).Put("tint", ((V)("#f6e3ff"))).Put("lip", ((V)("#d9a8f0"))).Put("ink", ((V)("#9a2fc8"))).Put("perk", ((V)("Unlocks the castle bed"))).V, NewObj(7).Put("key", ((V)("bakery"))).Put("name", ((V)("Sweet Bakery"))).Put("vibe", ((V)("Fresh from the oven"))).Put("tint", ((V)("#fff0e6"))).Put("lip", ((V)("#f2b8a0"))).Put("ink", ((V)("#c2502a"))).Put("perk", ((V)("Unlocks the bakery kitchen"))).V);
HEROES_13 = NewObj(6).Put("key", ((V)("heroes"))).Put("name", ((V)("Masked Heroes"))).Put("vibe", ((V)("Cheeky caped troublemakers"))).Put("tint", ((V)("#ffe4e6"))).Put("lip", ((V)("#f2a0aa"))).Put("ink", ((V)("#c0182e"))).V;
ELEMENTAL_14 = NewObj(6).Put("key", ((V)("elemental"))).Put("name", ((V)("Elemental Heroes"))).Put("vibe", ((V)("Super-powered squishies"))).Put("tint", ((V)("#e8eeff"))).Put("lip", ((V)("#a9b8f0"))).Put("ink", ((V)("#3a3ab0"))).V;
SEASON_15 = NewObj(7).Put("key", ((V)("spooky"))).Put("name", ((V)("Spooky Squish"))).Put("label", ((V)("SEASON 1 \u00b7 OCTOBER"))).Put("ends", Invoke(New(G("Date"), ((V)(2026D)), ((V)(9D)), ((V)(31D)), ((V)(23D)), ((V)(59D))), "getTime")).Put("tint", ((V)("#ffe6cc"))).Put("lip", ((V)("#e0a070"))).Put("ink", ((V)("#7a2a00"))).V;
R_16 = Arr(Arr(((V)(0D)), ((V)("Nimbo")), ((V)("sky")), ((V)(0D)), ((V)("Sleepy cloud that drizzles")), ((V)("rain patter")), ((V)("Cloud Sway")), ((V)("sway"))), Arr(((V)(1D)), ((V)("Mittens")), ((V)("pet")), ((V)(0D)), ((V)("Ginger kitten")), ((V)("purr")), ((V)("Kitty Wiggle")), ((V)("wiggle"))), Arr(((V)(2D)), ((V)("Mallow")), ((V)("snack")), ((V)(3D)), ((V)("Marshmallow")), ((V)("slow-rise memory foam")), ((V)("Toasty Twirl")), ((V)("jelly"))), Arr(((V)(3D)), ((V)("Bao")), ((V)("snack")), ((V)(1D)), ((V)("Steamed bun with a soft puff of steam")), ((V)("pillowy thump")), ((V)("Steamer Shuffle")), ((V)("bounce"))), Arr(((V)(4D)), ((V)("Dunkie")), ((V)("snack")), ((V)(0D)), ((V)("Sprinkle donut with one bite missing")), ((V)("sugary crunch")), ((V)("Sprinkle Roll")), ((V)("bounce"))), Arr(((V)(5D)), ((V)("Frybo")), ((V)("snack")), ((V)(0D)), ((V)("Box of fries")), ((V)("crispy rustle")), ((V)("Fry Shuffle")), ((V)("shuffle"))), Arr(((V)(6D)), ((V)("Pip")), ((V)("ocean")), ((V)(0D)), ((V)("Tiny penguin with a big waddle")), ((V)("icy slide")), ((V)("Waddle Wobble")), ((V)("shuffle"))), Arr(((V)(7D)), ((V)("Bunbun")), ((V)("snack")), ((V)(3D)), ((V)("Stacked burger")), ((V)("squeaky cheese squish")), ((V)("Bunny Hop")), ((V)("hop"))), Arr(((V)(8D)), ((V)("Jelli")), ((V)("ocean")), ((V)(2D)), ((V)("Wobbly jellyfish")), ((V)("world-class wobble")), ((V)("Jelly Jive")), ((V)("twist"))), Arr(((V)(9D)), ((V)("Pina")), ((V)("fruit")), ((V)(2D)), ((V)("Pineapple with a spiky crown")), ((V)("fizzy squish")), ((V)("Tropical Sway")), ((V)("sway"))), Arr(((V)(10D)), ((V)("Finn")), ((V)("ocean")), ((V)(0D)), ((V)("Baby dolphin")), ((V)("splash")), ((V)("Splash Dance")), ((V)("leap"))), Arr(((V)(11D)), ((V)("Sealy")), ((V)("ocean")), ((V)(1D)), ((V)("Fluffy baby seal")), ((V)("pure squish")), ((V)("Seal Slide")), ((V)("slide"))), Arr(((V)(12D)), ((V)("Biscuit")), ((V)("pet")), ((V)(0D)), ((V)("Floppy-eared puppy")), ((V)("tail thump")), ((V)("Biscuit Bot")), ((V)("robot"))), Arr(((V)(13D)), ((V)("Hana")), ((V)("dream")), ((V)(0D)), ((V)("Kid in a cozy bunny suit")), ((V)("zipper hoodie squish")), ((V)("Binky Bounce")), ((V)("twist"))), Arr(((V)(14D)), ((V)("Choco")), ((V)("snack")), ((V)(3D)), ((V)("Chocolate bar that melts your heart")), ((V)("snap then gooey")), ((V)("Choco Pop")), ((V)("pop"))), Arr(((V)(15D)), ((V)("Truffle")), ((V)("pet")), ((V)(2D)), ((V)("Pink piglet with a curly tail")), ((V)("soft oink squish")), ((V)("Piggy Wiggle")), ((V)("wiggle"))), Arr(((V)(16D)), ((V)("Lumi")), ((V)("sky")), ((V)(3D)), ((V)("Moon bunny with a lantern")), ((V)("soft bell")), ((V)("Moonwalk")), ((V)("slide"))), Arr(((V)(17D)), ((V)("Kiko")), ((V)("forest")), ((V)(3D)), ((V)("Petal-maned pony")), ((V)("flower chime")), ((V)("Kiko Leap")), ((V)("leap"))), Arr(((V)(18D)), ((V)("Bubbly")), ((V)("sky")), ((V)(1D)), ((V)("Iridescent bubble that never pops")), ((V)("glassy wobble")), ((V)("Bubble Wiggle")), ((V)("wiggle"))), Arr(((V)(19D)), ((V)("Twinkle")), ((V)("sky")), ((V)(2D)), ((V)("Sleepy star in a nightcap")), ((V)("twinkle chime")), ((V)("Star Hop")), ((V)("hop"))), Arr(((V)(20D)), ((V)("Zappi")), ((V)("sky")), ((V)(1D)), ((V)("Static spark")), ((V)("crackle")), ((V)("Static Robot")), ((V)("robot"))), Arr(((V)(21D)), ((V)("Scoop")), ((V)("snack")), ((V)(2D)), ((V)("Strawberry ice cream that never melts")), ((V)("cold crackle")), ((V)("Scoop Swirl")), ((V)("twist"))), Arr(((V)(22D)), ((V)("Teddy")), ((V)("forest")), ((V)(0D)), ((V)("Huggable bear")), ((V)("deep plush hug")), ((V)("Bear Hug Sway")), ((V)("sway"))), Arr(((V)(23D)), ((V)("Hoot")), ((V)("forest")), ((V)(1D)), ((V)("Wise little owl")), ((V)("feather fluff")), ((V)("Hoot Owl Hustle")), ((V)("bounce"))), Arr(((V)(24D)), ((V)("Leo")), ((V)("forest")), ((V)(2D)), ((V)("Lion cub with a fluffy mane")), ((V)("tiny roar")), ((V)("Mane Event")), ((V)("pop"))), Arr(((V)(25D)), ((V)("Nibbles")), ((V)("pet")), ((V)(3D)), ((V)("Hamster with stuffed cheeks")), ((V)("seed crunch")), ((V)("Cheek Wiggle")), ((V)("wiggle"))), Arr(((V)(26D)), ((V)("Quill")), ((V)("pet")), ((V)(1D)), ((V)("Shy hedgehog")), ((V)("soft spike brush")), ((V)("Spike Shuffle")), ((V)("shuffle"))), Arr(((V)(27D)), ((V)("Panko")), ((V)("forest")), ((V)(1D)), ((V)("Baby panda")), ((V)("bamboo creak")), ((V)("Panda Roll")), ((V)("jelly"))), Arr(((V)(28D)), ((V)("Boba")), ((V)("snack")), ((V)(3D)), ((V)("Bubble tea full of pearls")), ((V)("pearls popping")), ((V)("Tapioca Shake")), ((V)("bounce"))), Arr(((V)(29D)), ((V)("Avo")), ((V)("fruit")), ((V)(4D)), ((V)("Baby avocado with a pit belly")), ((V)("buttery squish")), ((V)("Pit Hop")), ((V)("hop"))), Arr(((V)(30D)), ((V)("Berri")), ((V)("fruit")), ((V)(3D)), ((V)("Strawberry with seed freckles")), ((V)("juicy pop")), ((V)("Berry Bop")), ((V)("bounce"))), Arr(((V)(31D)), ((V)("Lemmy")), ((V)("fruit")), ((V)(3D)), ((V)("Sour-faced lemon")), ((V)("zesty squeak")), ((V)("Sour Shuffle")), ((V)("shuffle"))), Arr(((V)(32D)), ((V)("Kiwi")), ((V)("fruit")), ((V)(3D)), ((V)("Fuzzy kiwi")), ((V)("velvet brush")), ((V)("Kiwi Bird Strut")), ((V)("wiggle"))), Arr(((V)(33D)), ((V)("Melo")), ((V)("fruit")), ((V)(2D)), ((V)("Watermelon slice")), ((V)("watery slosh")), ((V)("Summer Surf")), ((V)("slide"))), Arr(((V)(34D)), ((V)("Peachy")), ((V)("fruit")), ((V)(2D)), ((V)("Blushing peach")), ((V)("soft fuzz and sigh")), ((V)("Orchard Drop")), ((V)("twist"))), Arr(((V)(35D)), ((V)("Pitaya")), ((V)("fruit")), ((V)(3D)), ((V)("Dragonfruit with leafy wings")), ((V)("crunchy seeds")), ((V)("Dragon Leap")), ((V)("leap"))), Arr(((V)(36D)), ((V)("Tutti")), ((V)("fruit")), ((V)(4D)), ((V)("Fruit-basket fairy")), ((V)("basket rustle")), ((V)("Fruit Salad Sway")), ((V)("sway"))), Arr(((V)(37D)), ((V)("Puff")), ((V)("ocean")), ((V)(0D)), ((V)("Pufferfish that inflates on squeeze")), ((V)("balloon stretch")), ((V)("Puff Pop")), ((V)("pop"))), Arr(((V)(38D)), ((V)("Sea Turtle")), ((V)("ocean")), ((V)(0D)), ((V)("Real sea turtle who glides on big flippers")), ((V)("flipper swoosh")), ((V)("Ocean Glide")), ((V)("sway"))), Arr(((V)(39D)), ((V)("Octo")), ((V)("ocean")), ((V)(1D)), ((V)("Octopus with suction-cup feet")), ((V)("tiny pops")), ((V)("Tentacle Tango")), ((V)("twist"))), Arr(((V)(40D)), ((V)("Marina")), ((V)("ocean")), ((V)(3D)), ((V)("Baby mermaid with a pearl")), ((V)("bubbles and chimes")), ((V)("Mermaid Splash")), ((V)("twist"))), Arr(((V)(41D)), ((V)("Pearl")), ((V)("ocean")), ((V)(4D)), ((V)("Narwhal with a glowing horn")), ((V)("whale song hum")), ((V)("Tusk Twirl")), ((V)("leap"))), Arr(((V)(42D)), ((V)("Waffles")), ((V)("pet")), ((V)(3D)), ((V)("Corgi loaf")), ((V)("bread-dough squish")), ((V)("Loaf Hop")), ((V)("hop"))), Arr(((V)(43D)), ((V)("Poppy")), ((V)("pet")), ((V)(2D)), ((V)("Guinea pig")), ((V)("wheek squeak")), ((V)("Popcorn Bounce")), ((V)("bounce"))), Arr(((V)(44D)), ((V)("Duchess")), ((V)("pet")), ((V)(4D)), ((V)("Fluffy Persian cat with a pink bow")), ((V)("velvet purr")), ((V)("Royal Sway")), ((V)("sway"))), Arr(((V)(45D)), ((V)("Mama Paws")), ((V)("pet")), ((V)(1D)), ((V)("Big cuddly dog carrying a pup")), ((V)("double tail wag")), ((V)("Puppy Pile Jelly")), ((V)("jelly"))), Arr(((V)(46D)), ((V)("Acorn")), ((V)("forest")), ((V)(0D)), ((V)("Squirrel in an acorn cap")), ((V)("nutty click")), ((V)("Nutty Scurry")), ((V)("hop"))), Arr(((V)(47D)), ((V)("Fawn")), ((V)("forest")), ((V)(0D)), ((V)("Spotted baby deer")), ((V)("leaf rustle")), ((V)("Fawn Prance")), ((V)("leap"))), Arr(((V)(48D)), ((V)("Moss")), ((V)("forest")), ((V)(0D)), ((V)("Mushroom sprite")), ((V)("spongy press")), ((V)("Spore Bounce")), ((V)("wiggle"))), Arr(((V)(49D)), ((V)("Sprout")), ((V)("forest")), ((V)(4D)), ((V)("Tree spirit with a sapling on its head")), ((V)("creaky branch")), ((V)("Bloom Boogie")), ((V)("sway"))), Arr(((V)(50D)), ((V)("Plip")), ((V)("sky")), ((V)(0D)), ((V)("Raindrop")), ((V)("water drip")), ((V)("Drip Drop")), ((V)("bounce"))), Arr(((V)(51D)), ((V)("Breeze")), ((V)("sky")), ((V)(0D)), ((V)("Kite-tailed wind puff")), ((V)("whoosh")), ((V)("Gust Slide")), ((V)("slide"))), Arr(((V)(52D)), ((V)("Dusty")), ((V)("sky")), ((V)(0D)), ((V)("Fuzzy moth")), ((V)("powder flutter")), ((V)("Moth Twist")), ((V)("twist"))), Arr(((V)(53D)), ((V)("Aurora")), ((V)("sky")), ((V)(4D)), ((V)("Color-shifting sky whale")), ((V)("deep shimmer")), ((V)("Sky Swim")), ((V)("sway"))), Arr(((V)(54D)), ((V)("Boo")), ((V)("dream")), ((V)(0D)), ((V)("Shy ghost")), ((V)("cool marshmallow")), ((V)("Peekaboo Float")), ((V)("slide"))), Arr(((V)(55D)), ((V)("Pixie")), ((V)("dream")), ((V)(0D)), ((V)("Tiny fairy")), ((V)("wing buzz")), ((V)("Pixie Jig")), ((V)("hop"))), Arr(((V)(56D)), ((V)("Floof")), ((V)("dream")), ((V)(0D)), ((V)("Baby yeti")), ((V)("snow crunch")), ((V)("Yeti Stomp")), ((V)("shuffle"))), Arr(((V)(57D)), ((V)("Unibun")), ((V)("dream")), ((V)(1D)), ((V)("Unicorn bunny")), ((V)("sparkle squeak")), ((V)("Rainbow Prance")), ((V)("twist"))), Arr(((V)(58D)), ((V)("Gumdrop")), ((V)("dream")), ((V)(1D)), ((V)("Gummy bear")), ((V)("jelly bounce")), ((V)("Gummy Wiggle")), ((V)("jelly"))), Arr(((V)(59D)), ((V)("Flicker")), ((V)("dream")), ((V)(2D)), ((V)("Phoenix chick")), ((V)("warm crackle")), ((V)("Phoenix Inferno")), ((V)("pop"))), Arr(((V)(60D)), ((V)("Drako")), ((V)("dream")), ((V)(3D)), ((V)("Baby dragon with tiny wings")), ((V)("puff of smoke")), ((V)("Rawr Rumble")), ((V)("robot"))), Arr(((V)(61D)), ((V)("Jinni")), ((V)("dream")), ((V)(3D)), ((V)("Tiny genie who floats out of a golden lamp")), ((V)("magic lamp chime")), ((V)("Wish Whirl")), ((V)("sway"))), Arr(((V)(62D)), ((V)("Cuppy")), ((V)("bakery")), ((V)(0D)), ((V)("Cupcake with frosting hair")), ((V)("frosting swirl")), ((V)("Frosting Twist")), ((V)("twist"))), Arr(((V)(63D)), ((V)("Chip")), ((V)("bakery")), ((V)(0D)), ((V)("Chocolate chip cookie")), ((V)("crumbly crunch")), ((V)("Cookie Crumble")), ((V)("shuffle"))), Arr(((V)(64D)), ((V)("Twisty")), ((V)("bakery")), ((V)(0D)), ((V)("Pretzel")), ((V)("salty knot creak")), ((V)("Knot Wiggle")), ((V)("wiggle"))), Arr(((V)(65D)), ((V)("Crois")), ((V)("bakery")), ((V)(0D)), ((V)("Croissant")), ((V)("flaky layers")), ((V)("Flaky Sway")), ((V)("sway"))), Arr(((V)(66D)), ((V)("Maca")), ((V)("bakery")), ((V)(1D)), ((V)("Macaron")), ((V)("crisp then chewy")), ((V)("Macaron Pop")), ((V)("pop"))), Arr(((V)(67D)), ((V)("Puddi")), ((V)("bakery")), ((V)(1D)), ((V)("Caramel pudding")), ((V)("jiggle")), ((V)("Pudding Jelly")), ((V)("jelly"))), Arr(((V)(68D)), ((V)("Mochi")), ((V)("bakery")), ((V)(2D)), ((V)("Strawberry daifuku")), ((V)("stretchy pull")), ((V)("Mochi Slide")), ((V)("slide"))), Arr(((V)(69D)), ((V)("Cakey")), ((V)("bakery")), ((V)(3D)), ((V)("Three-tier party cake with candles")), ((V)("candle blow")), ((V)("Party Leap")), ((V)("leap"))), Arr(((V)(70D)), ((V)("Sugarplum")), ((V)("bakery")), ((V)(4D)), ((V)("Tiny baker queen")), ((V)("sugar sprinkle")), ((V)("Sugar Hop")), ((V)("hop"))), Arr(((V)(71D)), ((V)("Chef Bun")), ((V)("snack")), ((V)(2D)), ((V)("Tiny chef in a tall hat")), ((V)("dough pat")), ((V)("Chef's Kiss")), ((V)("robot"))), Arr(((V)(72D)), ((V)("Gourdy")), ((V)("spooky")), ((V)(0D)), ((V)("Round pumpkin with a curly vine")), ((V)("hollow thunk")), ((V)("Pumpkin Roll")), ((V)("bounce"))), Arr(((V)(73D)), ((V)("Batty")), ((V)("spooky")), ((V)(0D)), ((V)("Baby bat with velvet wings")), ((V)("leathery flutter")), ((V)("Bat Flap")), ((V)("hop"))), Arr(((V)(74D)), ((V)("Kernel")), ((V)("spooky")), ((V)(0D)), ((V)("Candy corn kid")), ((V)("waxy squeak")), ((V)("Candy Shuffle")), ((V)("shuffle"))), Arr(((V)(75D)), ((V)("Hexie")), ((V)("spooky")), ((V)(1D)), ((V)("Witch cat in a floppy hat")), ((V)("purr and sparkle")), ((V)("Broom Sway")), ((V)("sway"))), Arr(((V)(76D)), ((V)("Mumbles")), ((V)("spooky")), ((V)(2D)), ((V)("Mummy bunny in soft bandages")), ((V)("gauze rustle")), ((V)("Mummy Robot")), ((V)("robot"))), Arr(((V)(77D)), ((V)("Hocus")), ((V)("spooky")), ((V)(3D)), ((V)("Wizard owl with a glowing spellbook")), ((V)("page flip and chime")), ((V)("Spell Twist")), ((V)("twist"))), Arr(((V)(78D)), ((V)("Count Squishula")), ((V)("spooky")), ((V)(3D)), ((V)("Tiny vampire with a velvet cape")), ((V)("cape swish")), ((V)("Cape Slide")), ((V)("slide")), ((V)("pass"))), Arr(((V)(79D)), ((V)("Wisecrack")), ((V)("heroes")), ((V)(3D)), ((V)("Cheeky masked troublemaker who winks at you")), ((V)("squeaky giggle")), ((V)("Wisecrack Wiggle")), ((V)("wiggle"))), Arr(((V)(80D)), ((V)("Giga-Growth")), ((V)("elemental")), ((V)(3D)), ((V)("Mossy stone giant who grows plants with every stomp")), ((V)("rumbling stomp")), ((V)("Overgrowth Stomp")), ((V)("bounce"))), Arr(((V)(81D)), ((V)("Crystalline")), ((V)("elemental")), ((V)(2D)), ((V)("Prism hero with orbiting crystal shards")), ((V)("crystal chime")), ((V)("Prism Waltz")), ((V)("twist"))), Arr(((V)(82D)), ((V)("Aero-Swift")), ((V)("elemental")), ((V)(2D)), ((V)("Wind-speed hero who hovers on her own breeze")), ((V)("whoosh")), ((V)("Tornado Twist")), ((V)("leap"))), Arr(((V)(83D)), ((V)("Phantasm")), ((V)("elemental")), ((V)(3D)), ((V)("Faceless cosmic spirit in a galaxy cloak")), ((V)("cosmic hum")), ((V)("Cosmic Phase")), ((V)("sway"))), Arr(((V)(84D)), ((V)("Magmara")), ((V)("elemental")), ((V)(2D)), ((V)("Lava-rock brawler with fists of fire")), ((V)("sizzling crackle")), ((V)("Magma Punch")), ((V)("bounce"))), Arr(((V)(85D)), ((V)("Chrono-Shade")), ((V)("elemental")), ((V)(3D)), ((V)("Masked time-bender with a ticking clock")), ((V)("clock tick")), ((V)("Time Warp")), ((V)("robot"))), Arr(((V)(86D)), ((V)("Ribbit")), ((V)("pet")), ((V)(3D)), ((V)("Big-eyed frog who loves to hop")), ((V)("squishy croak")), ((V)("Lily Pad Hop")), ((V)("hop"))), Arr(((V)(87D)), ((V)("Frankie")), ((V)("snack")), ((V)(1D)), ((V)("Hot dog snug in a soft bun")), ((V)("squishy bun hug")), ((V)("Bun Hug Wiggle")), ((V)("wiggle"))), Arr(((V)(88D)), ((V)("Corny")), ((V)("snack")), ((V)(4D)), ((V)("Popcorn bucket heaped with popcorn that pops when she gets excited")), ((V)("buttery pop")), ((V)("Popcorn Pop")), ((V)("pop"))), Arr(((V)(89D)), ((V)("Peppi")), ((V)("snack")), ((V)(3D)), ((V)("Pizza slice with a floppy tip")), ((V)("cheesy stretch")), ((V)("Cheese Pull Sway")), ((V)("sway"))), Arr(((V)(90D)), ((V)("Nori")), ((V)("snack")), ((V)(3D)), ((V)("Rice ball in a seaweed jacket")), ((V)("sticky rice squish")), ((V)("Rice Ball Roll")), ((V)("bounce"))), Arr(((V)(91D)), ((V)("Sunny")), ((V)("snack")), ((V)(0D)), ((V)("Soft-boiled egg that rolls everywhere")), ((V)("shell tap")), ((V)("Roly-Poly Rock")), ((V)("sway"))), Arr(((V)(92D)), ((V)("Toco")), ((V)("snack")), ((V)(1D)), ((V)("Taco with a lettuce frill")), ((V)("crunchy shell snap")), ((V)("Taco Snap")), ((V)("hop"))), Arr(((V)(93D)), ((V)("Churro")), ((V)("snack")), ((V)(1D)), ((V)("Sugar-dusted churro dipped in chocolate")), ((V)("sugary crunch")), ((V)("Churro Corkscrew")), ((V)("twist"))), Arr(((V)(94D)), ((V)("Khinki")), ((V)("snack")), ((V)(3D)), ((V)("Georgian khinkali dumpling with a twisted top knot")), ((V)("juicy squish")), ((V)("Topknot Twist")), ((V)("twist"))), Arr(((V)(95D)), ((V)("Maki")), ((V)("snack")), ((V)(3D)), ((V)("Sushi roll standing up, its filling showing on top")), ((V)("soft rice press")), ((V)("Sushi Spin")), ((V)("twist"))), Arr(((V)(96D)), ((V)("Noodle")), ((V)("snack")), ((V)(0D)), ((V)("Bowl of ramen with an egg and chopsticks")), ((V)("noodle slurp")), ((V)("Noodle Slurp")), ((V)("shuffle"))), Arr(((V)(97D)), ((V)("Flossie")), ((V)("snack")), ((V)(2D)), ((V)("Cotton candy cloud on a paper stick")), ((V)("sugar-cloud fluff")), ((V)("Candy Cloud Float")), ((V)("sway"))), Arr(((V)(98D)), ((V)("Shelly")), ((V)("pet")), ((V)(3D)), ((V)("Fluffy turtle in a quilted shell")), ((V)("hollow tap")), ((V)("Shell Spin")), ((V)("shuffle"))), Arr(((V)(99D)), ((V)("Tilly")), ((V)("pet")), ((V)(1D)), ((V)("Cockatiel with a swoopy crest and rosy-orange cheeks")), ((V)("happy whistle")), ((V)("Crest Shake Boogie")), ((V)("bounce"))), Arr(((V)(100D)), ((V)("Pico")), ((V)("pet")), ((V)(2D)), ((V)("Chirpy budgie who loves to whistle")), ((V)("cheerful tweet")), ((V)("Birdie Bop")), ((V)("bounce"))), Arr(((V)(101D)), ((V)("Clover")), ((V)("pet")), ((V)(3D)), ((V)("Bunny with tall ears and a cotton tail")), ((V)("soft thump")), ((V)("Bunny Hop")), ((V)("hop"))), Arr(((V)(102D)), ((V)("Chilla")), ((V)("pet")), ((V)(2D)), ((V)("Chinchilla with huge round ears and a bushy tail")), ((V)("dust-bath poof")), ((V)("Dust Bath Roll")), ((V)("wiggle"))), Arr(((V)(103D)), ((V)("Mimi")), ((V)("pet")), ((V)(1D)), ((V)("Tiny white mouse with big pink ears")), ((V)("squeak")), ((V)("Cheese Shuffle")), ((V)("shuffle"))), Arr(((V)(104D)), ((V)("Puddles")), ((V)("pet")), ((V)(3D)), ((V)("Fluffy duckling who loves puddles")), ((V)("little quack")), ((V)("Puddle Splash")), ((V)("bounce"))), Arr(((V)(105D)), ((V)("Bean")), ((V)("pet")), ((V)(0D)), ((V)("Wrinkly pug with a curly tail")), ((V)("snorty snuffle")), ((V)("Pug Wiggle")), ((V)("wiggle"))), Arr(((V)(106D)), ((V)("Zippy")), ((V)("pet")), ((V)(0D)), ((V)("Bouncy ferret in a bandit mask")), ((V)("happy dook")), ((V)("Weasel War Dance")), ((V)("hop"))), Arr(((V)(107D)), ((V)("Nana")), ((V)("fruit")), ((V)(0D)), ((V)("Curvy banana who stands tall")), ((V)("soft peel slip")), ((V)("Banana Boogie")), ((V)("sway"))), Arr(((V)(108D)), ((V)("Bing")), ((V)("fruit")), ((V)(1D)), ((V)("Glossy cherry on a long stem")), ((V)("juicy plink")), ((V)("Stem Twirl")), ((V)("bounce"))), Arr(((V)(109D)), ((V)("Plummy")), ((V)("fruit")), ((V)(2D)), ((V)("Dusty purple plum who dances ballet")), ((V)("soft plummy squish")), ((V)("Sugar Plum Twirl")), ((V)("twist"))), Arr(((V)(110D)), ((V)("Clemmy")), ((V)("fruit")), ((V)(3D)), ((V)("Clementine with two little leaves")), ((V)("zesty spritz")), ((V)("Peel Spin")), ((V)("twist"))), Arr(((V)(111D)), ((V)("Appy")), ((V)("fruit")), ((V)(0D)), ((V)("Crisp green apple with a rosy blush")), ((V)("crunchy crunch")), ((V)("Apple Bob")), ((V)("bounce"))), Arr(((V)(112D)), ((V)("Blueby")), ((V)("fruit")), ((V)(0D)), ((V)("Blueberry with a little star crown")), ((V)("tiny pop")), ((V)("Blueberry Roll")), ((V)("hop"))), Arr(((V)(113D)), ((V)("Coco")), ((V)("fruit")), ((V)(3D)), ((V)("Hairy coconut who knocks out a beat")), ((V)("hollow knock")), ((V)("Coconut Knock")), ((V)("wiggle"))), Arr(((V)(114D)), ((V)("Perry")), ((V)("fruit")), ((V)(1D)), ((V)("Chubby pear with a round bottom")), ((V)("soft juicy squish")), ((V)("Pear Wobble")), ((V)("wiggle"))), Arr(((V)(115D)), ((V)("Grana")), ((V)("fruit")), ((V)(3D)), ((V)("Pomegranate with a royal crown")), ((V)("seed rattle")), ((V)("Seed Shower")), ((V)("leap"))), Arr(((V)(116D)), ((V)("Mangie")), ((V)("fruit")), ((V)(1D)), ((V)("Sunset-ripe mango")), ((V)("mellow squish")), ((V)("Mango Tango")), ((V)("slide"))), Arr(((V)(117D)), ((V)("Razzy")), ((V)("fruit")), ((V)(0D)), ((V)("Raspberry made of big juicy beads")), ((V)("bubbly pop")), ((V)("Razzle Dazzle")), ((V)("bounce"))));
ART_17 = New(G("Set"), Invoke(R_16, "map", Fn((V _self1, int _argc84, V r_90, V _a87, V _a88, V _a89, V[] _rest85) => {
return GetIdx(r_90, 0D);
}, 1, "", true)));
KEYOF_18 = NewObj(1).Put("59", ((V)("ember"))).V;
ALIAS_19 = Set(G("window"), "SQ_ALIAS", Object_assign((Get(G("window"), "SQ_ALIAS") is var _t91 && Truthy(_t91) ? _t91 : NewObj(0).V), NewObj(0).V));
AK_20 = Fn((V _self1, int _argc92, V k_98, V _a95, V _a96, V _a97, V[] _rest93) => {
return (GetK(ALIAS_19, k_98) is var _t99 && Truthy(_t99) ? _t99 : k_98);
}, 1, "", true);
REWARD_21 = New(G("Set"), Arr(((V)(36D)), ((V)(41D)), ((V)(49D)), ((V)(53D)), ((V)(70D)), ((V)(88D))));
ROSTER_22 = Invoke(R_16, "map", Fn((V _self1, int _argc100, V _a102, V _a103, V _a104, V _a105, V[] _rest101) => {
V id_108 = default;
V name_110 = default;
V set_112 = default;
V rar_114 = default;
V concept_116 = default;
V sound_118 = default;
V move_120 = default;
V dance_122 = default;
V flag_124 = default;
{ V _t106 = ListOf(_a102);
{ V _t107 = GetIdx(_t106, 0D);
id_108 = _t107; }
{ V _t109 = GetIdx(_t106, 1D);
name_110 = _t109; }
{ V _t111 = GetIdx(_t106, 2D);
set_112 = _t111; }
{ V _t113 = GetIdx(_t106, 3D);
rar_114 = _t113; }
{ V _t115 = GetIdx(_t106, 4D);
concept_116 = _t115; }
{ V _t117 = GetIdx(_t106, 5D);
sound_118 = _t117; }
{ V _t119 = GetIdx(_t106, 6D);
move_120 = _t119; }
{ V _t121 = GetIdx(_t106, 7D);
dance_122 = _t121; }
{ V _t123 = GetIdx(_t106, 8D);
flag_124 = _t123; }
}
return NewObj(14).Put("id", id_108).Put("name", name_110).Put("set", set_112).Put("rar", rar_114).Put("concept", concept_116).Put("sound", sound_118).Put("move", move_120).Put("dance", dance_122).Put("key", (GetK(KEYOF_18, id_108) is var _t125 && Truthy(_t125) ? _t125 : Invoke(Invoke(name_110, "toLowerCase"), "replace", NewRegExp(RX0, "[^a-z]", "g"), ((V)(""))))).Put("reward", Invoke(REWARD_21, "has", id_108)).Put("season", (SEqS(set_112, "spooky") ? V.True : V.False)).Put("pass", (SEqS(flag_124, "pass") ? V.True : V.False)).Put("base", ((!(Truthy(Invoke(REWARD_21, "has", id_108))) && !SEqS(set_112, "spooky")) ? V.True : V.False)).Getter("art", Fn((V _self126, int _argc127, V _a129, V _a130, V _a131, V _a132, V[] _rest128) => {
if (_self126.IsNullish) _self126 = GlobalV;
return Invoke(ART_17, "has", id_108);
return default;
}, 0, "art", false)).V;
}, 1, "", true));
Set(HEROES_13, "ids", Invoke(Invoke(ROSTER_22, "filter", Fn((V _self1, int _argc140, V c_146, V _a143, V _a144, V _a145, V[] _rest141) => {
return (SEq(Get(c_146, "set"), Get(HEROES_13, "key")) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _self1, int _argc133, V c_139, V _a136, V _a137, V _a138, V[] _rest134) => {
return Get(c_139, "id");
}, 1, "", true)));
Set(ELEMENTAL_14, "ids", Invoke(Invoke(ROSTER_22, "filter", Fn((V _self1, int _argc154, V c_160, V _a157, V _a158, V _a159, V[] _rest155) => {
return (SEq(Get(c_160, "set"), Get(ELEMENTAL_14, "key")) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _self1, int _argc147, V c_153, V _a150, V _a151, V _a152, V[] _rest148) => {
return Get(c_153, "id");
}, 1, "", true)));
Invoke(SETS_12, "forEach", Fn((V _self1, int _argc161, V s_167, V _a164, V _a165, V _a166, V[] _rest162) => {
Set(s_167, "ids", Invoke(Invoke(Invoke(ROSTER_22, "filter", Fn((V _self1, int _argc184, V c_190, V _a187, V _a188, V _a189, V[] _rest185) => {
return ((SEq(Get(c_190, "set"), Get(s_167, "key")) ? V.True : V.False) is var _t191 && !Truthy(_t191) ? _t191 : Get(c_190, "base"));
}, 1, "", true)), "map", Fn((V _self1, int _argc177, V c_183, V _a180, V _a181, V _a182, V[] _rest178) => {
return Get(c_183, "id");
}, 1, "", true)), "sort", Fn((V _self1, int _argc168, V a_174, V b_175, V _a172, V _a173, V[] _rest169) => {
return (((V)((ToNum(Get(GetK(ROSTER_22, a_174), "rar")) - ToNum(Get(GetK(ROSTER_22, b_175), "rar"))))) is var _t176 && Truthy(_t176) ? _t176 : ((V)((ToNum(a_174) - ToNum(b_175)))));
}, 2, "", true)));
Set(s_167, "reward", Get((Invoke(ROSTER_22, "find", Fn((V _self1, int _argc192, V c_198, V _a195, V _a196, V _a197, V[] _rest193) => {
return ((SEq(Get(c_198, "set"), Get(s_167, "key")) ? V.True : V.False) is var _t199 && !Truthy(_t199) ? _t199 : Get(c_198, "reward"));
}, 1, "", true)) is var _t200 && Truthy(_t200) ? _t200 : NewObj(0).V), "id"));
return default;
}, 1, "", true));
Set(SEASON_15, "ids", Invoke(Invoke(ROSTER_22, "filter", Fn((V _self1, int _argc208, V c_214, V _a211, V _a212, V _a213, V[] _rest209) => {
return Get(c_214, "season");
}, 1, "", true)), "map", Fn((V _self1, int _argc201, V c_207, V _a204, V _a205, V _a206, V[] _rest202) => {
return Get(c_207, "id");
}, 1, "", true)));
STAR_PRICE_23 = Arr(((V)(40D)), ((V)(100D)), ((V)(250D)), ((V)(700D)));
COIN_PRICE_24 = Arr(((V)(1500D)), ((V)(4000D)), ((V)(9000D)), V.Null);
DUPE_25 = Arr(((V)(5D)), ((V)(15D)), ((V)(40D)), ((V)(120D)), ((V)(40D)));
FIN_26 = Arr(NewObj(4).Put("k", ((V)("n"))).Put("name", ((V)("Normal"))).Put("odds", ((V)(97.4))).Put("x", ((V)(0D))).V, NewObj(4).Put("k", ((V)("s"))).Put("name", ((V)("Shiny"))).Put("odds", ((V)(2D))).Put("x", ((V)(3D))).V, NewObj(4).Put("k", ((V)("r"))).Put("name", ((V)("Rainbow"))).Put("odds", ((V)(0.5))).Put("x", ((V)(8D))).V, NewObj(4).Put("k", ((V)("g"))).Put("name", ((V)("Golden"))).Put("odds", ((V)(0.1))).Put("x", ((V)(0D))).V);
STAGES_27 = Arr(NewObj(3).Put("name", ((V)("Baby"))).Put("xp", ((V)(0D))).Put("stars", ((V)(0D))).V, NewObj(3).Put("name", ((V)("Grown"))).Put("xp", ((V)(100D))).Put("stars", ((V)(10D))).V, NewObj(3).Put("name", ((V)("Best Friend"))).Put("xp", ((V)(300D))).Put("stars", ((V)(40D))).V);
STAGE_FX_28 = Arr(NewObj(3).Put("sx", ((V)(0.8))).Put("sy", ((V)(0.72))).Put("crown", (false ? V.True : V.False)).V, NewObj(3).Put("sx", ((V)(1D))).Put("sy", ((V)(1D))).Put("crown", (false ? V.True : V.False)).V, NewObj(3).Put("sx", ((V)(1.04))).Put("sy", ((V)(1.04))).Put("crown", (true ? V.True : V.False)).V);
CHESTS_29 = NewObj(6).Put("basic", NewObj(1).Put("odds", Arr(((V)(72D)), ((V)(22D)), ((V)(5D)), ((V)(1D)))).V).Put("silver", NewObj(1).Put("odds", Arr(((V)(55D)), ((V)(33D)), ((V)(9.5)), ((V)(2.5)))).V).Put("gold", NewObj(2).Put("odds", Arr(((V)(30D)), ((V)(45D)), ((V)(20D)), ((V)(5D)))).Put("gp", ((V)(1D))).V).Put("crystal", NewObj(2).Put("odds", Arr(((V)(0D)), ((V)(50D)), ((V)(38D)), ((V)(12D)))).Put("gp", ((V)(1D))).V).Put("rainbow", NewObj(3).Put("odds", Arr(((V)(0D)), ((V)(0D)), ((V)(70D)), ((V)(30D)))).Put("gp", ((V)(1D))).Put("fx", ((V)(3D))).V).Put("season", NewObj(2).Put("odds", Arr(((V)(50D)), ((V)(30D)), ((V)(15D)), ((V)(5D)))).Put("season", ((V)(1D))).V).V;
SET_BONUS_30 = 50D;
SEED_31 = Fn((V _self1, int _argc215, V _a217, V _a218, V _a219, V _a220, V[] _rest216) => {
return NewObj(7).Put("v", ((V)(1D))).Put("fp11", ((V)(1D))).Put("gems", ((V)(600D))).Put("stars", ((V)(180D))).Put("pity", ((V)(18D))).Put("epic", ((V)(4D))).Put("col", Object_fromEntries(Invoke(Arr(Arr(((V)(0D)), NewObj(4).Put("f", NewObj(2).Put("n", ((V)(1D))).Put("s", ((V)(1D))).V).Put("eq", ((V)("s"))).Put("st", ((V)(1D))).Put("xp", ((V)(160D))).V), Arr(((V)(1D)), NewObj(4).Put("f", NewObj(1).Put("n", ((V)(1D))).V).Put("eq", ((V)("n"))).Put("st", ((V)(2D))).Put("xp", ((V)(320D))).V), Arr(((V)(2D)), NewObj(4).Put("f", NewObj(2).Put("n", ((V)(1D))).Put("r", ((V)(1D))).V).Put("eq", ((V)("r"))).Put("st", ((V)(0D))).Put("xp", ((V)(40D))).V), Arr(((V)(3D)), NewObj(4).Put("f", NewObj(1).Put("n", ((V)(1D))).V).Put("eq", ((V)("n"))).Put("st", ((V)(0D))).Put("xp", ((V)(70D))).V)), "concat", Invoke(Arr(((V)(4D)), ((V)(5D)), ((V)(7D)), ((V)(14D)), ((V)(28D)), ((V)(6D)), ((V)(10D)), ((V)(11D)), ((V)(8D)), ((V)(12D)), ((V)(22D)), ((V)(23D)), ((V)(9D)), ((V)(13D))), "map", Fn((V _self1, int _argc221, V id_227, V _a224, V _a225, V _a226, V[] _rest222) => {
return Arr(id_227, NewObj(4).Put("f", NewObj(1).Put("n", ((V)(1D))).V).Put("eq", ((V)("n"))).Put("st", ((V)(0D))).Put("xp", ((V)(((ToNum(id_227) * 37D) % 90D)))).V);
}, 1, "", true))))).V;
}, 0, "", true);
S_32 = V.Null;
pend_33 = (false ? V.True : V.False);
prof_37 = Fn((V _self1, int _argc228, V _a230, V _a231, V _a232, V _a233, V[] _rest229) => {
return (Truthy(Get(G("window"), "SquishProfile")) ? Invoke(Get(G("window"), "SquishProfile"), "get") : V.Null);
}, 0, "", true);
API_38 = NewObj(39).Put("RAR", RAR_11).Put("SETS", SETS_12).Put("SEASON", SEASON_15).Put("HEROES", HEROES_13).Put("ELEMENTAL", ELEMENTAL_14).Put("ROSTER", ROSTER_22).Put("STAR_PRICE", STAR_PRICE_23).Put("COIN_PRICE", COIN_PRICE_24).Put("DUPE", DUPE_25).Put("FIN", FIN_26).Put("STAGES", STAGES_27).Put("STAGE_FX", STAGE_FX_28).Put("CHESTS", CHESTS_29).Put("SET_BONUS", ((V)(SET_BONUS_30))).Put("stageOf", Fn((V _self234, int _argc235, V id_241, V _a238, V _a239, V _a240, V[] _rest236) => {
V e_242 = default;
if (_self234.IsNullish) _self234 = GlobalV;
e_242 = GetK(Get(Call(load_35, V.Undef), "col"), id_241);
return (Truthy(e_242) ? (Get(e_242, "st") is var _t243 && Truthy(_t243) ? _t243 : ((V)(0D))) : ((V)(0D)));
return default;
}, 1, "stageOf", false)).Put("headOf", Fn((V _self244, int _argc245, V id_251, V _a248, V _a249, V _a250, V[] _rest246) => {
V c_252 = default;
V v_253 = default;
if (_self244.IsNullish) _self244 = GlobalV;
c_252 = GetK(ROSTER_22, id_251);
v_253 = (c_252 is var _t262 && !Truthy(_t262) ? _t262 : Invoke((Get(G("window"), "CREATURES_V2") is var _t261 && Truthy(_t261) ? _t261 : Arr()), "find", Fn((V _self244, int _argc254, V x_260, V _a257, V _a258, V _a259, V[] _rest255) => {
return (SEq(Invoke(Get(x_260, "name"), "toLowerCase"), Call(AK_20, V.Undef, Get(c_252, "key"))) ? V.True : V.False);
}, 1, "", true)));
return (Truthy(v_253) ? Get(v_253, "head") : ((V)(20D)));
return default;
}, 1, "headOf", false)).Put("get", Fn((V _self1, int _argc263, V _a265, V _a266, V _a267, V _a268, V[] _rest264) => {
return Call(load_35, V.Undef);
}, 0, "get", true)).Put("src", Fn((V _self1, int _argc269, V id_275, V _a272, V _a273, V _a274, V[] _rest270) => {
V c_276 = default;
V k_277 = default;
c_276 = GetK(ROSTER_22, id_275);
k_277 = (c_276 is var _t278 && !Truthy(_t278) ? _t278 : (Truthy(GetK(CARD_9, Get(c_276, "key"))) ? Get(c_276, "key") : Call(AK_20, V.Undef, Get(c_276, "key"))));
return (Truthy((c_276 is var _t279 && !Truthy(_t279) ? _t279 : Get(c_276, "art"))) ? ((V)(string.Concat(new string[] { "export/tripo/", ToStr(k_277), "/", ToStr(k_277), (Truthy(GetK(CARD_9, k_277)) ? string.Concat("-card.png?v=", ToStr(GetK(CARD_9, k_277))) : string.Concat("-front.svg", (Truthy(GetK(SVGV_8, k_277)) ? string.Concat("?v=", ToStr(GetK(SVGV_8, k_277))) : ""))) }))) : V.Null);
return default;
}, 1, "src", true)).Put("markArt", Fn((V _self280, int _argc281, V ids_287, V _a284, V _a285, V _a286, V[] _rest282) => {
if (_self280.IsNullish) _self280 = GlobalV;
Invoke(ids_287, "forEach", Fn((V _self280, int _argc288, V i_294, V _a291, V _a292, V _a293, V[] _rest289) => {
return Invoke(ART_17, "add", i_294);
}, 1, "", true));
Call(emit_34, V.Undef);
return default;
}, 1, "markArt", false)).Put("coins", Fn((V _self295, int _argc296, V _a298, V _a299, V _a300, V _a301, V[] _rest297) => {
V p_302 = default;
if (_self295.IsNullish) _self295 = GlobalV;
p_302 = Call(prof_37, V.Undef);
return (Truthy(p_302) ? Get(p_302, "coins") : (Get(Call(load_35, V.Undef), "coins") is var _t303 && Truthy(_t303) ? _t303 : ((V)(0D))));
return default;
}, 0, "coins", false)).Put("wallet", Fn((V _self304, int _argc305, V _a307, V _a308, V _a309, V _a310, V[] _rest306) => {
V s_311 = default;
if (_self304.IsNullish) _self304 = GlobalV;
s_311 = Call(load_35, V.Undef);
return NewObj(3).Put("coins", Invoke(API_38, "coins")).Put("gems", Get(s_311, "gems")).Put("stars", Get(s_311, "stars")).V;
return default;
}, 0, "wallet", false)).Put("add", Fn((V _self312, int _argc313, V cur_319, V n_320, V _a317, V _a318, V[] _rest314) => {
V s_321 = default;
if (_self312.IsNullish) _self312 = GlobalV;
if (SEqS(cur_319, "coins")) {
if (Truthy(Get(G("window"), "SquishProfile"))) {
Invoke(Get(G("window"), "SquishProfile"), "set", NewObj(1).Put("coins", ((V)(Max(0D, ToNum(Add(Invoke(API_38, "coins"), n_320)))))).V);
} else {
Set(Call(load_35, V.Undef), "coins", ((V)(Max(0D, ToNum(Add((Get(S_32, "coins") is var _t322 && Truthy(_t322) ? _t322 : ((V)(0D))), n_320))))));
Call(save_36, V.Undef);
}
Call(emit_34, V.Undef);
return (true ? V.True : V.False);
}
s_321 = Call(load_35, V.Undef);
SetK(s_321, cur_319, ((V)(Max(0D, ToNum(Add((GetK(s_321, cur_319) is var _t323 && Truthy(_t323) ? _t323 : ((V)(0D))), n_320))))));
Call(save_36, V.Undef);
return (true ? V.True : V.False);
return default;
}, 2, "add", false)).Put("spend", Fn((V _self324, int _argc325, V cur_331, V n_332, V _a329, V _a330, V[] _rest326) => {
V have_333 = default;
if (_self324.IsNullish) _self324 = GlobalV;
have_333 = (SEqS(cur_331, "coins") ? Invoke(API_38, "coins") : (GetK(Call(load_35, V.Undef), cur_331) is var _t334 && Truthy(_t334) ? _t334 : ((V)(0D))));
if (Lt(have_333, n_332)) {
return (false ? V.True : V.False);
}
Invoke(API_38, "add", cur_331, ((V)((-ToNum(n_332)))));
return (true ? V.True : V.False);
return default;
}, 2, "spend", false)).Put("setWallet", Fn((V _self335, int _argc336, V w_342, V _a339, V _a340, V _a341, V[] _rest337) => {
V s_343 = default;
V ch_344 = default;
if (_self335.IsNullish) _self335 = GlobalV;
s_343 = Call(load_35, V.Undef);
ch_344 = (false ? V.True : V.False);
Invoke(Arr(((V)("gems")), ((V)("stars"))), "forEach", Fn((V _self335, int _argc345, V k_351, V _a348, V _a349, V _a350, V[] _rest346) => {
if ((!GetK(w_342, k_351).IsNullish && !SEq(GetK(w_342, k_351), GetK(s_343, k_351)))) {
SetK(s_343, k_351, GetK(w_342, k_351));
ch_344 = (true ? V.True : V.False);
}
return default;
}, 1, "", true));
if ((!Get(w_342, "coins").IsNullish && !SEq(Get(w_342, "coins"), Invoke(API_38, "coins")))) {
if (Truthy(Get(G("window"), "SquishProfile"))) {
Invoke(Get(G("window"), "SquishProfile"), "set", NewObj(1).Put("coins", Get(w_342, "coins")).V, (true ? V.True : V.False));
} else {
Set(s_343, "coins", Get(w_342, "coins"));
}
ch_344 = (true ? V.True : V.False);
}
if ((!Get(w_342, "pity").IsNullish && !SEq(Get(w_342, "pity"), Get(s_343, "pity")))) {
Set(s_343, "pity", Get(w_342, "pity"));
ch_344 = (true ? V.True : V.False);
}
if (Truthy(ch_344)) {
Call(save_36, V.Undef);
}
return default;
}, 1, "setWallet", false)).Put("owns", Fn((V _self352, int _argc353, V id_359, V _a356, V _a357, V _a358, V[] _rest354) => {
V p_360 = default;
if (_self352.IsNullish) _self352 = GlobalV;
if (Truthy(GetK(Get(Call(load_35, V.Undef), "col"), id_359))) {
return (true ? V.True : V.False);
}
p_360 = Call(prof_37, V.Undef);
return (!(!(Truthy(((p_360 is var _t361 && !Truthy(_t361) ? _t361 : (LtN(id_359, 30D) ? V.True : V.False)) is var _t363 && !Truthy(_t363) ? _t363 : Invoke((Get(p_360, "owned") is var _t362 && Truthy(_t362) ? _t362 : Arr()), "includes", id_359))))) ? V.True : V.False);
return default;
}, 1, "owns", false)).Put("entry", Fn((V _self364, int _argc365, V id_371, V _a368, V _a369, V _a370, V[] _rest366) => {
V s_372 = default;
if (_self364.IsNullish) _self364 = GlobalV;
s_372 = Call(load_35, V.Undef);
if (Truthy(((!(Truthy(GetK(Get(s_372, "col"), id_371))) ? V.True : V.False) is var _t373 && !Truthy(_t373) ? _t373 : Invoke(API_38, "owns", id_371)))) {
SetK(Get(s_372, "col"), id_371, NewObj(4).Put("f", NewObj(1).Put("n", ((V)(1D))).V).Put("eq", ((V)("n"))).Put("st", ((V)(0D))).Put("xp", ((V)(0D))).V);
Call(save_36, V.Undef, (true ? V.True : V.False));
}
return (GetK(Get(s_372, "col"), id_371) is var _t374 && Truthy(_t374) ? _t374 : V.Null);
return default;
}, 1, "entry", false)).Put("ownedIds", Fn((V _self375, int _argc376, V _a378, V _a379, V _a380, V _a381, V[] _rest377) => {
if (_self375.IsNullish) _self375 = GlobalV;
return Invoke(Invoke(ROSTER_22, "filter", Fn((V _self375, int _argc389, V c_395, V _a392, V _a393, V _a394, V[] _rest390) => {
return Invoke(API_38, "owns", Get(c_395, "id"));
}, 1, "", true)), "map", Fn((V _self375, int _argc382, V c_388, V _a385, V _a386, V _a387, V[] _rest383) => {
return Get(c_388, "id");
}, 1, "", true));
return default;
}, 0, "ownedIds", false)).Put("setInfo", Fn((V _self396, int _argc397, V key_403, V _a400, V _a401, V _a402, V[] _rest398) => {
V st_404 = default;
V have_405 = default;
if (_self396.IsNullish) _self396 = GlobalV;
st_404 = Invoke(SETS_12, "find", Fn((V _self396, int _argc406, V s_412, V _a409, V _a410, V _a411, V[] _rest407) => {
return (SEq(Get(s_412, "key"), key_403) ? V.True : V.False);
}, 1, "", true));
have_405 = Get(Invoke(Get(st_404, "ids"), "filter", Get(API_38, "owns")), "length");
return NewObj(4).Put("have", have_405).Put("total", Get(Get(st_404, "ids"), "length")).Put("done", (SEq(have_405, Get(Get(st_404, "ids"), "length")) ? V.True : V.False)).Put("rewardOwned", Invoke(API_38, "owns", Get(st_404, "reward"))).V;
return default;
}, 1, "setInfo", false)).Put("grant", Fn((V _self413, int _argc414, V id_420, V f_421, V _a418, V _a419, V[] _rest415) => {
V s_422 = default;
V c_423 = default;
V e_424 = default;
V @out_425 = default;
if (_self413.IsNullish) _self413 = GlobalV;
f_421 = (f_421 is var _t426 && Truthy(_t426) ? _t426 : ((V)("n")));
s_422 = Call(load_35, V.Undef);
c_423 = GetK(ROSTER_22, id_420);
e_424 = Invoke(API_38, "entry", id_420);
@out_425 = NewObj(5).Put("id", id_420).Put("isNew", (!(Truthy(e_424)) ? V.True : V.False)).Put("newFinish", (false ? V.True : V.False)).Put("stars", ((V)(0D))).Put("reward", V.Null).V;
if (!(Truthy(e_424))) {
SetK(Get(s_422, "col"), id_420, NewObj(4).Put("f", NewObj(2).Put("n", ((V)(1D))).PutK(f_421, ((V)(1D))).V).Put("eq", f_421).Put("st", ((V)(0D))).Put("xp", ((V)(0D))).V);
} else {
if (!(Truthy(GetK(Get(e_424, "f"), f_421)))) {
SetK(Get(e_424, "f"), f_421, ((V)(1D)));
Set(@out_425, "newFinish", (true ? V.True : V.False));
} else {
Set(@out_425, "stars", ((V)((ToNum(GetK(DUPE_25, Get(c_423, "rar"))) * (!SEqS(f_421, "n") ? 2D : 1D)))));
}
}
OpSet(s_422, "stars", 0, Get(@out_425, "stars"));
if (Truthy(Get(c_423, "base"))) {
V st_427 = default;
st_427 = Invoke(SETS_12, "find", Fn((V _self413, int _argc428, V x_434, V _a431, V _a432, V _a433, V[] _rest429) => {
return (SEq(Get(x_434, "key"), Get(c_423, "set")) ? V.True : V.False);
}, 1, "", true));
if (Truthy((((st_427 is var _t435 && !Truthy(_t435) ? _t435 : (!Get(st_427, "reward").IsNullish ? V.True : V.False)) is var _t436 && !Truthy(_t436) ? _t436 : (!(Truthy(GetK(Get(s_422, "col"), Get(st_427, "reward")))) ? V.True : V.False)) is var _t437 && !Truthy(_t437) ? _t437 : Invoke(Get(st_427, "ids"), "every", Get(API_38, "owns"))))) {
SetK(Get(s_422, "col"), Get(st_427, "reward"), NewObj(4).Put("f", NewObj(1).Put("n", ((V)(1D))).V).Put("eq", ((V)("n"))).Put("st", ((V)(0D))).Put("xp", ((V)(0D))).V);
OpSet(s_422, "stars", 0, ((V)(SET_BONUS_30)));
Set(@out_425, "reward", Get(st_427, "reward"));
}
}
Call(save_36, V.Undef);
return @out_425;
return default;
}, 2, "grant", false)).Put("addXp", Fn((V _self438, int _argc439, V id_445, V n_446, V _a443, V _a444, V[] _rest440) => {
V e_447 = default;
if (_self438.IsNullish) _self438 = GlobalV;
e_447 = Invoke(API_38, "entry", id_445);
if ((!(Truthy(e_447)) || !(Truthy(n_446)))) {
return default;
}
Set(e_447, "xp", Add((Get(e_447, "xp") is var _t448 && Truthy(_t448) ? _t448 : ((V)(0D))), n_446));
Call(save_36, V.Undef, (true ? V.True : V.False));
Call(G("clearTimeout"), V.Undef, Get(API_38, "_xpT"));
Set(API_38, "_xpT", Call(G("setTimeout"), V.Undef, emit_34, ((V)(400D))));
return default;
}, 2, "addXp", false)).Put("growInfo", Fn((V _self449, int _argc450, V id_456, V _a453, V _a454, V _a455, V[] _rest451) => {
V e_457 = default;
V next_458 = default;
if (_self449.IsNullish) _self449 = GlobalV;
e_457 = Invoke(API_38, "entry", id_456);
if (!(Truthy(e_457))) {
return V.Null;
}
next_458 = GetK(STAGES_27, Add(Get(e_457, "st"), ((V)(1D))));
if (!(Truthy(next_458))) {
return NewObj(3).Put("stage", Get(e_457, "st")).Put("max", (true ? V.True : V.False)).Put("xp", Get(e_457, "xp")).V;
}
return NewObj(8).Put("stage", Get(e_457, "st")).Put("max", (false ? V.True : V.False)).Put("xp", Get(e_457, "xp")).Put("needXp", Get(next_458, "xp")).Put("needStars", Get(next_458, "stars")).Put("xpOk", (Ge(Get(e_457, "xp"), Get(next_458, "xp")) ? V.True : V.False)).Put("starsOk", (Ge(Get(Call(load_35, V.Undef), "stars"), Get(next_458, "stars")) ? V.True : V.False)).Put("next", Get(next_458, "name")).V;
return default;
}, 1, "growInfo", false)).Put("grow", Fn((V _self459, int _argc460, V id_466, V _a463, V _a464, V _a465, V[] _rest461) => {
V g_467 = default;
V s_468 = default;
if (_self459.IsNullish) _self459 = GlobalV;
g_467 = Invoke(API_38, "growInfo", id_466);
if (Truthy(((((!(Truthy(g_467)) ? V.True : V.False) is var _t469 && Truthy(_t469) ? _t469 : Get(g_467, "max")) is var _t470 && Truthy(_t470) ? _t470 : (!(Truthy(Get(g_467, "xpOk"))) ? V.True : V.False)) is var _t471 && Truthy(_t471) ? _t471 : (!(Truthy(Get(g_467, "starsOk"))) ? V.True : V.False)))) {
return (false ? V.True : V.False);
}
s_468 = Call(load_35, V.Undef);
OpSet(s_468, "stars", 1, Get(g_467, "needStars"));
IncM(GetK(Get(s_468, "col"), id_466), "st", 1D, false);
if (SEqN(Get(GetK(Get(s_468, "col"), id_466), "st"), 2D)) {
OpSet(s_468, "stars", 0, ((V)(0D)));
}
Call(save_36, V.Undef);
return (true ? V.True : V.False);
return default;
}, 1, "grow", false)).Put("finishPrice", Fn((V _self472, int _argc473, V id_479, V f_480, V _a477, V _a478, V[] _rest474) => {
V c_481 = default;
V F_482 = default;
if (_self472.IsNullish) _self472 = GlobalV;
c_481 = GetK(ROSTER_22, id_479);
F_482 = Invoke(FIN_26, "find", Fn((V _self472, int _argc483, V x_489, V _a486, V _a487, V _a488, V[] _rest484) => {
return (SEq(Get(x_489, "k"), f_480) ? V.True : V.False);
}, 1, "", true));
if ((((!(Truthy(c_481)) || !(Truthy(F_482))) || !(Truthy(Get(F_482, "x")))) || GtN(Get(c_481, "rar"), 3D))) {
return V.Null;
}
return ((V)((ToNum(GetK(STAR_PRICE_23, Get(c_481, "rar"))) * ToNum(Get(F_482, "x")))));
return default;
}, 2, "finishPrice", false)).Put("buyFinish", Fn((V _self490, int _argc491, V id_497, V f_498, V _a495, V _a496, V[] _rest492) => {
V p_499 = default;
V e_500 = default;
if (_self490.IsNullish) _self490 = GlobalV;
p_499 = Invoke(API_38, "finishPrice", id_497, f_498);
e_500 = Invoke(API_38, "entry", id_497);
if (Truthy(((((!(Truthy(p_499)) || !(Truthy(e_500))) ? V.True : V.False) is var _t501 && Truthy(_t501) ? _t501 : GetK(Get(e_500, "f"), f_498)) is var _t502 && Truthy(_t502) ? _t502 : (Lt(Get(Call(load_35, V.Undef), "stars"), p_499) ? V.True : V.False)))) {
return (false ? V.True : V.False);
}
OpSet(S_32, "stars", 1, p_499);
SetK(Get(e_500, "f"), f_498, ((V)(1D)));
Set(e_500, "eq", f_498);
Call(save_36, V.Undef);
return (true ? V.True : V.False);
return default;
}, 2, "buyFinish", false)).Put("equip", Fn((V _self503, int _argc504, V id_510, V f_511, V _a508, V _a509, V[] _rest505) => {
V e_512 = default;
if (_self503.IsNullish) _self503 = GlobalV;
e_512 = Invoke(API_38, "entry", id_510);
if ((!(Truthy(e_512)) || !(Truthy(GetK(Get(e_512, "f"), f_511))))) {
return (false ? V.True : V.False);
}
Set(e_512, "eq", f_511);
Call(save_36, V.Undef);
return (true ? V.True : V.False);
return default;
}, 2, "equip", false)).Put("finishOf", Fn((V _self513, int _argc514, V id_520, V _a517, V _a518, V _a519, V[] _rest515) => {
V e_521 = default;
if (_self513.IsNullish) _self513 = GlobalV;
e_521 = GetK(Get(Call(load_35, V.Undef), "col"), id_520);
return (Truthy(e_521) ? (Get(e_521, "eq") is var _t522 && Truthy(_t522) ? _t522 : ((V)("n"))) : ((V)("n")));
return default;
}, 1, "finishOf", false)).Put("buy", Fn((V _self523, int _argc524, V id_530, V cur_531, V _a528, V _a529, V[] _rest525) => {
V c_532 = default;
V price_533 = default;
if (_self523.IsNullish) _self523 = GlobalV;
c_532 = GetK(ROSTER_22, id_530);
if (Truthy(((((!(Truthy(c_532)) || !(Truthy(Get(c_532, "base")))) || !(Truthy(Get(c_532, "art")))) ? V.True : V.False) is var _t534 && Truthy(_t534) ? _t534 : Invoke(API_38, "owns", id_530)))) {
return V.Null;
}
price_533 = (SEqS(cur_531, "stars") ? GetK(STAR_PRICE_23, Get(c_532, "rar")) : GetK(COIN_PRICE_24, Get(c_532, "rar")));
if ((!(Truthy(price_533)) || !(Truthy(Invoke(API_38, "spend", cur_531, price_533))))) {
return V.Null;
}
return Invoke(API_38, "grant", id_530, ((V)("n")));
return default;
}, 2, "buy", false)).Put("roll", Fn((V _self535, int _argc536, V tier_542, V _a539, V _a540, V _a541, V[] _rest537) => {
V T_543 = default;
V s_544 = default;
V odds_545 = default;
double x_546 = 0;
double r_547 = 0;
V pool_548 = default;
V w_549 = default;
double y_550 = 0;
double k_551 = 0;
V m_552 = default;
double fr_553 = 0;
V f_554 = default;
if (_self535.IsNullish) _self535 = GlobalV;
T_543 = (GetK(CHESTS_29, tier_542) is var _t555 && Truthy(_t555) ? _t555 : Get(CHESTS_29, "basic"));
s_544 = Call(load_35, V.Undef);
if (Truthy(Get(T_543, "gp"))) {
Set(s_544, "pity", Add((Get(s_544, "pity") is var _t556 && Truthy(_t556) ? _t556 : ((V)(0D))), ((V)(1D))));
}
Set(s_544, "epic", Add((Get(s_544, "epic") is var _t557 && Truthy(_t557) ? _t557 : ((V)(0D))), ((V)(1D))));
odds_545 = Get(T_543, "odds");
x_546 = (ToNum(Invoke(G("Math"), "random")) * ToNum(Invoke(odds_545, "reduce", Fn((V _self535, int _argc558, V a_564, V b_565, V _a562, V _a563, V[] _rest559) => {
return Add(a_564, b_565);
}, 2, "", true), ((V)(0D)))));
r_547 = 0D;
{
while (true) {
if (!((r_547 < 3D))) break;
if (Lt(((V)(x_546)), GetIdx(odds_545, r_547))) {
break;
}
x_546 = (x_546 - ToNum(GetIdx(odds_545, r_547)));
r_547++;
}
}
if (Truthy((Get(T_543, "gp") is var _t567 && !Truthy(_t567) ? _t567 : (GeN(Get(s_544, "pity"), 30D) ? V.True : V.False)))) {
r_547 = 3D;
}
if (((r_547 < 2D) && GeN(Get(s_544, "epic"), 10D))) {
r_547 = 2D;
}
if ((r_547 == 3D)) {
Set(s_544, "pity", ((V)(0D)));
}
if ((r_547 >= 2D)) {
Set(s_544, "epic", ((V)(0D)));
}
pool_548 = Invoke(ROSTER_22, "filter", Fn((V _self535, int _argc568, V c_574, V _a571, V _a572, V _a573, V[] _rest569) => {
return (((Truthy(Get(T_543, "season")) ? (Get(c_574, "season") is var _t575 && !Truthy(_t575) ? _t575 : (!(Truthy(Get(c_574, "pass"))) ? V.True : V.False)) : Get(c_574, "base")) is var _t576 && !Truthy(_t576) ? _t576 : (SEqN(Get(c_574, "rar"), r_547) ? V.True : V.False)) is var _t577 && !Truthy(_t577) ? _t577 : Get(c_574, "art"));
}, 1, "", true));
if (!(Truthy(Get(pool_548, "length")))) {
pool_548 = Invoke(Invoke(Invoke(ROSTER_22, "filter", Fn((V _self535, int _argc595, V c_601, V _a598, V _a599, V _a600, V[] _rest596) => {
return ((Get(c_601, "base") is var _t602 && !Truthy(_t602) ? _t602 : Get(c_601, "art")) is var _t603 && !Truthy(_t603) ? _t603 : (LeN(Get(c_601, "rar"), r_547) ? V.True : V.False));
}, 1, "", true)), "sort", Fn((V _self535, int _argc587, V a_593, V b_594, V _a591, V _a592, V[] _rest588) => {
return ((V)((ToNum(Get(b_594, "rar")) - ToNum(Get(a_593, "rar")))));
}, 2, "", true)), "filter", Fn((V _self535, int _argc578, V c_584, V i_585, V a_586, V _a583, V[] _rest579) => {
return (SEq(Get(c_584, "rar"), Get(GetIdx(a_586, 0D), "rar")) ? V.True : V.False);
}, 3, "", true));
}
w_549 = Invoke(pool_548, "map", Fn((V _self535, int _argc604, V c_610, V _a607, V _a608, V _a609, V[] _rest605) => {
return ((V)((Truthy(Invoke(API_38, "owns", Get(c_610, "id"))) ? 1D : 3D)));
}, 1, "", true));
y_550 = (ToNum(Invoke(G("Math"), "random")) * ToNum(Invoke(w_549, "reduce", Fn((V _self535, int _argc611, V a_617, V b_618, V _a615, V _a616, V[] _rest612) => {
return Add(a_617, b_618);
}, 2, "", true), ((V)(0D)))));
k_551 = 0D;
{
while (true) {
if (!((k_551 < (ToNum(Get(pool_548, "length")) - 1D)))) break;
if (Lt(((V)(y_550)), GetIdx(w_549, k_551))) {
break;
}
y_550 = (y_550 - ToNum(GetIdx(w_549, k_551)));
k_551++;
}
}
m_552 = (Get(T_543, "fx") is var _t620 && Truthy(_t620) ? _t620 : ((V)(1D)));
fr_553 = (ToNum(Invoke(G("Math"), "random")) * 100D);
f_554 = ((V)(((fr_553 < (0.1 * ToNum(m_552))) ? "g" : ((fr_553 < (0.6 * ToNum(m_552))) ? "r" : ((fr_553 < (2.6 * ToNum(m_552))) ? "s" : "n")))));
Call(save_36, V.Undef, (true ? V.True : V.False));
return NewObj(3).Put("id", Get(GetIdx(pool_548, k_551), "id")).Put("rar", ((V)(r_547))).Put("f", f_554).V;
return default;
}, 1, "roll", false)).Put("reset", Fn((V _self621, int _argc622, V _a624, V _a625, V _a626, V _a627, V[] _rest623) => {
if (_self621.IsNullish) _self621 = GlobalV;
S_32 = Call(SEED_31, V.Undef);
Call(save_36, V.Undef);
return default;
}, 0, "reset", false)).V;
Invoke(G("window"), "addEventListener", ((V)("storage")), Fn((V _self1, int _argc628, V e_634, V _a631, V _a632, V _a633, V[] _rest629) => {
if (SEq(Get(e_634, "key"), KEY_10)) {
S_32 = V.Null;
Call(emit_34, V.Undef);
}
if (SEqS(Get(e_634, "key"), "squishsquad.profile.v1")) {
Call(emit_34, V.Undef);
}
return default;
}, 1, "", true));
Invoke(G("window"), "addEventListener", ((V)("squishprofile")), emit_34);
Set(G("window"), "SquishSquad", API_38);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
