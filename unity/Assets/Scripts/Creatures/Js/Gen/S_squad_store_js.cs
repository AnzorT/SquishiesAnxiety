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
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis59, int _argc53, V _a55, V _a56, V _a57, V _a58, V[] _rest54) => {
pend_33 = (false ? V.True : V.False);
Invoke(G("window"), "dispatchEvent", New(G("CustomEvent"), ((V)("squishsquad"))));
return default;
}, 0, "", true), ((V)(0D)));
return default;
}, 0, "emit", false);
load_35 = Fn((V _self60, int _argc61, V _a63, V _a64, V _a65, V _a66, V[] _rest62) => {
if (_self60.IsNullish) _self60 = GlobalV;
if (Truthy(S_32)) {
return S_32;
}
try {
S_32 = Invoke(G("JSON"), "parse", Invoke(G("localStorage"), "getItem", KEY_10));
} catch (System.Exception _ex67) {
V e_68 = default;
e_68 = Caught(_ex67);

}
if ((!(Truthy(S_32)) || !SEqN(Get(S_32, "v"), 1D))) {
S_32 = Call(SEED_31, V.Undef);
Call(save_36, V.Undef, (true ? V.True : V.False));
}
if (Truthy(Get(S_32, "col"))) {
Invoke(Object_keys(Get(S_32, "col")), "forEach", Fn((V _arrowThis76, int _argc69, V id_75, V _a72, V _a73, V _a74, V[] _rest70) => {
if (!(Truthy(GetIdx(ROSTER_22, ToNum(id_75))))) {
DeleteK(Get(S_32, "col"), id_75);
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
save_36 = Fn((V _self77, int _argc78, V silent_84, V _a81, V _a82, V _a83, V[] _rest79) => {
if (_self77.IsNullish) _self77 = GlobalV;
try {
Invoke(G("localStorage"), "setItem", KEY_10, Invoke(G("JSON"), "stringify", S_32));
} catch (System.Exception _ex85) {
V e_86 = default;
e_86 = Caught(_ex85);

}
if (!(Truthy(silent_84))) {
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
ART_17 = New(G("Set"), Invoke(R_16, "map", Fn((V _arrowThis94, int _argc87, V r_93, V _a90, V _a91, V _a92, V[] _rest88) => {
return GetIdx(r_93, 0D);
}, 1, "", true)));
KEYOF_18 = NewObj(1).Put("59", ((V)("ember"))).V;
ALIAS_19 = Set(G("window"), "SQ_ALIAS", Object_assign((Get(G("window"), "SQ_ALIAS") is var _t95 && Truthy(_t95) ? _t95 : NewObj(0).V), NewObj(0).V));
AK_20 = Fn((V _arrowThis103, int _argc96, V k_102, V _a99, V _a100, V _a101, V[] _rest97) => {
return (GetK(ALIAS_19, k_102) is var _t104 && Truthy(_t104) ? _t104 : k_102);
}, 1, "", true);
REWARD_21 = New(G("Set"), Arr(((V)(36D)), ((V)(41D)), ((V)(49D)), ((V)(53D)), ((V)(70D)), ((V)(88D))));
ROSTER_22 = Invoke(R_16, "map", Fn((V _arrowThis130, int _argc105, V _a107, V _a108, V _a109, V _a110, V[] _rest106) => {
V id_113 = default;
V name_115 = default;
V set_117 = default;
V rar_119 = default;
V concept_121 = default;
V sound_123 = default;
V move_125 = default;
V dance_127 = default;
V flag_129 = default;
{ V _t111 = ListOf(_a107);
{ V _t112 = GetIdx(_t111, 0D);
id_113 = _t112; }
{ V _t114 = GetIdx(_t111, 1D);
name_115 = _t114; }
{ V _t116 = GetIdx(_t111, 2D);
set_117 = _t116; }
{ V _t118 = GetIdx(_t111, 3D);
rar_119 = _t118; }
{ V _t120 = GetIdx(_t111, 4D);
concept_121 = _t120; }
{ V _t122 = GetIdx(_t111, 5D);
sound_123 = _t122; }
{ V _t124 = GetIdx(_t111, 6D);
move_125 = _t124; }
{ V _t126 = GetIdx(_t111, 7D);
dance_127 = _t126; }
{ V _t128 = GetIdx(_t111, 8D);
flag_129 = _t128; }
}
return NewObj(14).Put("id", id_113).Put("name", name_115).Put("set", set_117).Put("rar", rar_119).Put("concept", concept_121).Put("sound", sound_123).Put("move", move_125).Put("dance", dance_127).Put("key", (GetK(KEYOF_18, id_113) is var _t131 && Truthy(_t131) ? _t131 : Invoke(Invoke(name_115, "toLowerCase"), "replace", NewRegExp(RX0, "[^a-z]", "g"), ((V)(""))))).Put("reward", Invoke(REWARD_21, "has", id_113)).Put("season", (SEqS(set_117, "spooky") ? V.True : V.False)).Put("pass", (SEqS(flag_129, "pass") ? V.True : V.False)).Put("base", ((!(Truthy(Invoke(REWARD_21, "has", id_113))) && !SEqS(set_117, "spooky")) ? V.True : V.False)).Getter("art", Fn((V _self132, int _argc133, V _a135, V _a136, V _a137, V _a138, V[] _rest134) => {
if (_self132.IsNullish) _self132 = GlobalV;
return Invoke(ART_17, "has", id_113);
return default;
}, 0, "art", false)).V;
}, 1, "", true));
Set(HEROES_13, "ids", Invoke(Invoke(ROSTER_22, "filter", Fn((V _arrowThis154, int _argc147, V c_153, V _a150, V _a151, V _a152, V[] _rest148) => {
return (SEq(Get(c_153, "set"), Get(HEROES_13, "key")) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _arrowThis146, int _argc139, V c_145, V _a142, V _a143, V _a144, V[] _rest140) => {
return Get(c_145, "id");
}, 1, "", true)));
Set(ELEMENTAL_14, "ids", Invoke(Invoke(ROSTER_22, "filter", Fn((V _arrowThis170, int _argc163, V c_169, V _a166, V _a167, V _a168, V[] _rest164) => {
return (SEq(Get(c_169, "set"), Get(ELEMENTAL_14, "key")) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _arrowThis162, int _argc155, V c_161, V _a158, V _a159, V _a160, V[] _rest156) => {
return Get(c_161, "id");
}, 1, "", true)));
Invoke(SETS_12, "forEach", Fn((V _arrowThis178, int _argc171, V s_177, V _a174, V _a175, V _a176, V[] _rest172) => {
Set(s_177, "ids", Invoke(Invoke(Invoke(ROSTER_22, "filter", Fn((V _arrowThis204, int _argc197, V c_203, V _a200, V _a201, V _a202, V[] _rest198) => {
return ((SEq(Get(c_203, "set"), Get(s_177, "key")) ? V.True : V.False) is var _t205 && !Truthy(_t205) ? _t205 : Get(c_203, "base"));
}, 1, "", true)), "map", Fn((V _arrowThis196, int _argc189, V c_195, V _a192, V _a193, V _a194, V[] _rest190) => {
return Get(c_195, "id");
}, 1, "", true)), "sort", Fn((V _arrowThis187, int _argc179, V a_185, V b_186, V _a183, V _a184, V[] _rest180) => {
return (((V)((ToNum(Get(GetK(ROSTER_22, a_185), "rar")) - ToNum(Get(GetK(ROSTER_22, b_186), "rar"))))) is var _t188 && Truthy(_t188) ? _t188 : ((V)((ToNum(a_185) - ToNum(b_186)))));
}, 2, "", true)));
Set(s_177, "reward", Get((Invoke(ROSTER_22, "find", Fn((V _arrowThis213, int _argc206, V c_212, V _a209, V _a210, V _a211, V[] _rest207) => {
return ((SEq(Get(c_212, "set"), Get(s_177, "key")) ? V.True : V.False) is var _t214 && !Truthy(_t214) ? _t214 : Get(c_212, "reward"));
}, 1, "", true)) is var _t215 && Truthy(_t215) ? _t215 : NewObj(0).V), "id"));
return default;
}, 1, "", true));
Set(SEASON_15, "ids", Invoke(Invoke(ROSTER_22, "filter", Fn((V _arrowThis231, int _argc224, V c_230, V _a227, V _a228, V _a229, V[] _rest225) => {
return Get(c_230, "season");
}, 1, "", true)), "map", Fn((V _arrowThis223, int _argc216, V c_222, V _a219, V _a220, V _a221, V[] _rest217) => {
return Get(c_222, "id");
}, 1, "", true)));
STAR_PRICE_23 = Arr(((V)(40D)), ((V)(100D)), ((V)(250D)), ((V)(700D)));
COIN_PRICE_24 = Arr(((V)(1500D)), ((V)(4000D)), ((V)(9000D)), V.Null);
DUPE_25 = Arr(((V)(5D)), ((V)(15D)), ((V)(40D)), ((V)(120D)), ((V)(40D)));
FIN_26 = Arr(NewObj(4).Put("k", ((V)("n"))).Put("name", ((V)("Normal"))).Put("odds", ((V)(97.4))).Put("x", ((V)(0D))).V, NewObj(4).Put("k", ((V)("s"))).Put("name", ((V)("Shiny"))).Put("odds", ((V)(2D))).Put("x", ((V)(3D))).V, NewObj(4).Put("k", ((V)("r"))).Put("name", ((V)("Rainbow"))).Put("odds", ((V)(0.5))).Put("x", ((V)(8D))).V, NewObj(4).Put("k", ((V)("g"))).Put("name", ((V)("Golden"))).Put("odds", ((V)(0.1))).Put("x", ((V)(0D))).V);
STAGES_27 = Arr(NewObj(3).Put("name", ((V)("Baby"))).Put("xp", ((V)(0D))).Put("stars", ((V)(0D))).V, NewObj(3).Put("name", ((V)("Grown"))).Put("xp", ((V)(100D))).Put("stars", ((V)(10D))).V, NewObj(3).Put("name", ((V)("Best Friend"))).Put("xp", ((V)(300D))).Put("stars", ((V)(40D))).V);
STAGE_FX_28 = Arr(NewObj(3).Put("sx", ((V)(0.8))).Put("sy", ((V)(0.72))).Put("crown", (false ? V.True : V.False)).V, NewObj(3).Put("sx", ((V)(1D))).Put("sy", ((V)(1D))).Put("crown", (false ? V.True : V.False)).V, NewObj(3).Put("sx", ((V)(1.04))).Put("sy", ((V)(1.04))).Put("crown", (true ? V.True : V.False)).V);
CHESTS_29 = NewObj(6).Put("basic", NewObj(1).Put("odds", Arr(((V)(72D)), ((V)(22D)), ((V)(5D)), ((V)(1D)))).V).Put("silver", NewObj(1).Put("odds", Arr(((V)(55D)), ((V)(33D)), ((V)(9.5)), ((V)(2.5)))).V).Put("gold", NewObj(2).Put("odds", Arr(((V)(30D)), ((V)(45D)), ((V)(20D)), ((V)(5D)))).Put("gp", ((V)(1D))).V).Put("crystal", NewObj(2).Put("odds", Arr(((V)(0D)), ((V)(50D)), ((V)(38D)), ((V)(12D)))).Put("gp", ((V)(1D))).V).Put("rainbow", NewObj(3).Put("odds", Arr(((V)(0D)), ((V)(0D)), ((V)(70D)), ((V)(30D)))).Put("gp", ((V)(1D))).Put("fx", ((V)(3D))).V).Put("season", NewObj(2).Put("odds", Arr(((V)(50D)), ((V)(30D)), ((V)(15D)), ((V)(5D)))).Put("season", ((V)(1D))).V).V;
SET_BONUS_30 = 50D;
SEED_31 = Fn((V _arrowThis238, int _argc232, V _a234, V _a235, V _a236, V _a237, V[] _rest233) => {
return NewObj(7).Put("v", ((V)(1D))).Put("fp11", ((V)(1D))).Put("gems", ((V)(600D))).Put("stars", ((V)(180D))).Put("pity", ((V)(18D))).Put("epic", ((V)(4D))).Put("col", Object_fromEntries(Invoke(Arr(Arr(((V)(0D)), NewObj(4).Put("f", NewObj(2).Put("n", ((V)(1D))).Put("s", ((V)(1D))).V).Put("eq", ((V)("s"))).Put("st", ((V)(1D))).Put("xp", ((V)(160D))).V), Arr(((V)(1D)), NewObj(4).Put("f", NewObj(1).Put("n", ((V)(1D))).V).Put("eq", ((V)("n"))).Put("st", ((V)(2D))).Put("xp", ((V)(320D))).V), Arr(((V)(2D)), NewObj(4).Put("f", NewObj(2).Put("n", ((V)(1D))).Put("r", ((V)(1D))).V).Put("eq", ((V)("r"))).Put("st", ((V)(0D))).Put("xp", ((V)(40D))).V), Arr(((V)(3D)), NewObj(4).Put("f", NewObj(1).Put("n", ((V)(1D))).V).Put("eq", ((V)("n"))).Put("st", ((V)(0D))).Put("xp", ((V)(70D))).V)), "concat", Invoke(Arr(((V)(4D)), ((V)(5D)), ((V)(7D)), ((V)(14D)), ((V)(28D)), ((V)(6D)), ((V)(10D)), ((V)(11D)), ((V)(8D)), ((V)(12D)), ((V)(22D)), ((V)(23D)), ((V)(9D)), ((V)(13D))), "map", Fn((V _arrowThis246, int _argc239, V id_245, V _a242, V _a243, V _a244, V[] _rest240) => {
return Arr(id_245, NewObj(4).Put("f", NewObj(1).Put("n", ((V)(1D))).V).Put("eq", ((V)("n"))).Put("st", ((V)(0D))).Put("xp", ((V)(((ToNum(id_245) * 37D) % 90D)))).V);
}, 1, "", true))))).V;
}, 0, "", true);
S_32 = V.Null;
pend_33 = (false ? V.True : V.False);
prof_37 = Fn((V _arrowThis253, int _argc247, V _a249, V _a250, V _a251, V _a252, V[] _rest248) => {
return (Truthy(Get(G("window"), "SquishProfile")) ? Invoke(Get(G("window"), "SquishProfile"), "get") : V.Null);
}, 0, "", true);
API_38 = NewObj(39).Put("RAR", RAR_11).Put("SETS", SETS_12).Put("SEASON", SEASON_15).Put("HEROES", HEROES_13).Put("ELEMENTAL", ELEMENTAL_14).Put("ROSTER", ROSTER_22).Put("STAR_PRICE", STAR_PRICE_23).Put("COIN_PRICE", COIN_PRICE_24).Put("DUPE", DUPE_25).Put("FIN", FIN_26).Put("STAGES", STAGES_27).Put("STAGE_FX", STAGE_FX_28).Put("CHESTS", CHESTS_29).Put("SET_BONUS", ((V)(SET_BONUS_30))).Put("stageOf", Fn((V _self254, int _argc255, V id_261, V _a258, V _a259, V _a260, V[] _rest256) => {
V e_262 = default;
if (_self254.IsNullish) _self254 = GlobalV;
e_262 = GetK(Get(Call(load_35, V.Undef), "col"), id_261);
return (Truthy(e_262) ? (Get(e_262, "st") is var _t263 && Truthy(_t263) ? _t263 : ((V)(0D))) : ((V)(0D)));
return default;
}, 1, "stageOf", false)).Put("headOf", Fn((V _self264, int _argc265, V id_271, V _a268, V _a269, V _a270, V[] _rest266) => {
V c_272 = default;
V v_273 = default;
if (_self264.IsNullish) _self264 = GlobalV;
c_272 = GetK(ROSTER_22, id_271);
v_273 = (c_272 is var _t283 && !Truthy(_t283) ? _t283 : Invoke((Get(G("window"), "CREATURES_V2") is var _t282 && Truthy(_t282) ? _t282 : Arr()), "find", Fn((V _arrowThis281, int _argc274, V x_280, V _a277, V _a278, V _a279, V[] _rest275) => {
return (SEq(Invoke(Get(x_280, "name"), "toLowerCase"), Call(AK_20, V.Undef, Get(c_272, "key"))) ? V.True : V.False);
}, 1, "", true)));
return (Truthy(v_273) ? Get(v_273, "head") : ((V)(20D)));
return default;
}, 1, "headOf", false)).Put("get", Fn((V _arrowThis290, int _argc284, V _a286, V _a287, V _a288, V _a289, V[] _rest285) => {
return Call(load_35, V.Undef);
}, 0, "get", true)).Put("src", Fn((V _arrowThis298, int _argc291, V id_297, V _a294, V _a295, V _a296, V[] _rest292) => {
V c_299 = default;
V k_300 = default;
c_299 = GetK(ROSTER_22, id_297);
k_300 = (c_299 is var _t301 && !Truthy(_t301) ? _t301 : (Truthy(GetK(CARD_9, Get(c_299, "key"))) ? Get(c_299, "key") : Call(AK_20, V.Undef, Get(c_299, "key"))));
return (Truthy((c_299 is var _t302 && !Truthy(_t302) ? _t302 : Get(c_299, "art"))) ? ((V)(JsStrBuf.Begin().S("export/tripo/").V(k_300).S("/").V(k_300).S((Truthy(GetK(CARD_9, k_300)) ? JsStrBuf.Begin().S("-card.png?v=").V(GetK(CARD_9, k_300)).End() : string.Concat("-front.svg", (Truthy(GetK(SVGV_8, k_300)) ? JsStrBuf.Begin().S("?v=").V(GetK(SVGV_8, k_300)).End() : "")))).End())) : V.Null);
return default;
}, 1, "src", true)).Put("markArt", Fn((V _self303, int _argc304, V ids_310, V _a307, V _a308, V _a309, V[] _rest305) => {
if (_self303.IsNullish) _self303 = GlobalV;
Invoke(ids_310, "forEach", Fn((V _arrowThis318, int _argc311, V i_317, V _a314, V _a315, V _a316, V[] _rest312) => {
return Invoke(ART_17, "add", i_317);
}, 1, "", true));
Call(emit_34, V.Undef);
return default;
}, 1, "markArt", false)).Put("coins", Fn((V _self319, int _argc320, V _a322, V _a323, V _a324, V _a325, V[] _rest321) => {
V p_326 = default;
if (_self319.IsNullish) _self319 = GlobalV;
p_326 = Call(prof_37, V.Undef);
return (Truthy(p_326) ? Get(p_326, "coins") : (Get(Call(load_35, V.Undef), "coins") is var _t327 && Truthy(_t327) ? _t327 : ((V)(0D))));
return default;
}, 0, "coins", false)).Put("wallet", Fn((V _self328, int _argc329, V _a331, V _a332, V _a333, V _a334, V[] _rest330) => {
V s_335 = default;
if (_self328.IsNullish) _self328 = GlobalV;
s_335 = Call(load_35, V.Undef);
return NewObj(3).Put("coins", Invoke(API_38, "coins")).Put("gems", Get(s_335, "gems")).Put("stars", Get(s_335, "stars")).V;
return default;
}, 0, "wallet", false)).Put("add", Fn((V _self336, int _argc337, V cur_343, V n_344, V _a341, V _a342, V[] _rest338) => {
V s_345 = default;
if (_self336.IsNullish) _self336 = GlobalV;
if (SEqS(cur_343, "coins")) {
if (Truthy(Get(G("window"), "SquishProfile"))) {
Invoke(Get(G("window"), "SquishProfile"), "set", NewObj(1).Put("coins", ((V)(Max(0D, ToNum(Add(Invoke(API_38, "coins"), n_344)))))).V);
} else {
Set(Call(load_35, V.Undef), "coins", ((V)(Max(0D, ToNum(Add((Get(S_32, "coins") is var _t346 && Truthy(_t346) ? _t346 : ((V)(0D))), n_344))))));
Call(save_36, V.Undef);
}
Call(emit_34, V.Undef);
return (true ? V.True : V.False);
}
s_345 = Call(load_35, V.Undef);
SetK(s_345, cur_343, ((V)(Max(0D, ToNum(Add((GetK(s_345, cur_343) is var _t347 && Truthy(_t347) ? _t347 : ((V)(0D))), n_344))))));
Call(save_36, V.Undef);
return (true ? V.True : V.False);
return default;
}, 2, "add", false)).Put("spend", Fn((V _self348, int _argc349, V cur_355, V n_356, V _a353, V _a354, V[] _rest350) => {
V have_357 = default;
if (_self348.IsNullish) _self348 = GlobalV;
have_357 = (SEqS(cur_355, "coins") ? Invoke(API_38, "coins") : (GetK(Call(load_35, V.Undef), cur_355) is var _t358 && Truthy(_t358) ? _t358 : ((V)(0D))));
if (Lt(have_357, n_356)) {
return (false ? V.True : V.False);
}
Invoke(API_38, "add", cur_355, ((V)((-ToNum(n_356)))));
return (true ? V.True : V.False);
return default;
}, 2, "spend", false)).Put("setWallet", Fn((V _self359, int _argc360, V w_366, V _a363, V _a364, V _a365, V[] _rest361) => {
V s_367 = default;
V ch_368 = default;
if (_self359.IsNullish) _self359 = GlobalV;
s_367 = Call(load_35, V.Undef);
ch_368 = (false ? V.True : V.False);
Invoke(Arr(((V)("gems")), ((V)("stars"))), "forEach", Fn((V _arrowThis376, int _argc369, V k_375, V _a372, V _a373, V _a374, V[] _rest370) => {
if ((!GetK(w_366, k_375).IsNullish && !SEq(GetK(w_366, k_375), GetK(s_367, k_375)))) {
SetK(s_367, k_375, GetK(w_366, k_375));
ch_368 = (true ? V.True : V.False);
}
return default;
}, 1, "", true));
if ((!Get(w_366, "coins").IsNullish && !SEq(Get(w_366, "coins"), Invoke(API_38, "coins")))) {
if (Truthy(Get(G("window"), "SquishProfile"))) {
Invoke(Get(G("window"), "SquishProfile"), "set", NewObj(1).Put("coins", Get(w_366, "coins")).V, (true ? V.True : V.False));
} else {
Set(s_367, "coins", Get(w_366, "coins"));
}
ch_368 = (true ? V.True : V.False);
}
if ((!Get(w_366, "pity").IsNullish && !SEq(Get(w_366, "pity"), Get(s_367, "pity")))) {
Set(s_367, "pity", Get(w_366, "pity"));
ch_368 = (true ? V.True : V.False);
}
if (Truthy(ch_368)) {
Call(save_36, V.Undef);
}
return default;
}, 1, "setWallet", false)).Put("owns", Fn((V _self377, int _argc378, V id_384, V _a381, V _a382, V _a383, V[] _rest379) => {
V p_385 = default;
if (_self377.IsNullish) _self377 = GlobalV;
if (Truthy(GetK(Get(Call(load_35, V.Undef), "col"), id_384))) {
return (true ? V.True : V.False);
}
p_385 = Call(prof_37, V.Undef);
return (!(!(Truthy(((p_385 is var _t386 && !Truthy(_t386) ? _t386 : (LtN(id_384, 30D) ? V.True : V.False)) is var _t388 && !Truthy(_t388) ? _t388 : Invoke((Get(p_385, "owned") is var _t387 && Truthy(_t387) ? _t387 : Arr()), "includes", id_384))))) ? V.True : V.False);
return default;
}, 1, "owns", false)).Put("entry", Fn((V _self389, int _argc390, V id_396, V _a393, V _a394, V _a395, V[] _rest391) => {
V s_397 = default;
if (_self389.IsNullish) _self389 = GlobalV;
s_397 = Call(load_35, V.Undef);
if (Truthy(((!(Truthy(GetK(Get(s_397, "col"), id_396))) ? V.True : V.False) is var _t398 && !Truthy(_t398) ? _t398 : Invoke(API_38, "owns", id_396)))) {
SetK(Get(s_397, "col"), id_396, NewObj(4).Put("f", NewObj(1).Put("n", ((V)(1D))).V).Put("eq", ((V)("n"))).Put("st", ((V)(0D))).Put("xp", ((V)(0D))).V);
Call(save_36, V.Undef, (true ? V.True : V.False));
}
return (GetK(Get(s_397, "col"), id_396) is var _t399 && Truthy(_t399) ? _t399 : V.Null);
return default;
}, 1, "entry", false)).Put("ownedIds", Fn((V _self400, int _argc401, V _a403, V _a404, V _a405, V _a406, V[] _rest402) => {
if (_self400.IsNullish) _self400 = GlobalV;
return Invoke(Invoke(ROSTER_22, "filter", Fn((V _arrowThis422, int _argc415, V c_421, V _a418, V _a419, V _a420, V[] _rest416) => {
return Invoke(API_38, "owns", Get(c_421, "id"));
}, 1, "", true)), "map", Fn((V _arrowThis414, int _argc407, V c_413, V _a410, V _a411, V _a412, V[] _rest408) => {
return Get(c_413, "id");
}, 1, "", true));
return default;
}, 0, "ownedIds", false)).Put("setInfo", Fn((V _self423, int _argc424, V key_430, V _a427, V _a428, V _a429, V[] _rest425) => {
V st_431 = default;
V have_432 = default;
if (_self423.IsNullish) _self423 = GlobalV;
st_431 = Invoke(SETS_12, "find", Fn((V _arrowThis440, int _argc433, V s_439, V _a436, V _a437, V _a438, V[] _rest434) => {
return (SEq(Get(s_439, "key"), key_430) ? V.True : V.False);
}, 1, "", true));
have_432 = Get(Invoke(Get(st_431, "ids"), "filter", Get(API_38, "owns")), "length");
return NewObj(4).Put("have", have_432).Put("total", Get(Get(st_431, "ids"), "length")).Put("done", (SEq(have_432, Get(Get(st_431, "ids"), "length")) ? V.True : V.False)).Put("rewardOwned", Invoke(API_38, "owns", Get(st_431, "reward"))).V;
return default;
}, 1, "setInfo", false)).Put("grant", Fn((V _self441, int _argc442, V id_448, V f_449, V _a446, V _a447, V[] _rest443) => {
V s_450 = default;
V c_451 = default;
V e_452 = default;
V @out_453 = default;
if (_self441.IsNullish) _self441 = GlobalV;
f_449 = (f_449 is var _t454 && Truthy(_t454) ? _t454 : ((V)("n")));
s_450 = Call(load_35, V.Undef);
c_451 = GetK(ROSTER_22, id_448);
e_452 = Invoke(API_38, "entry", id_448);
@out_453 = NewObj(5).Put("id", id_448).Put("isNew", (!(Truthy(e_452)) ? V.True : V.False)).Put("newFinish", (false ? V.True : V.False)).Put("stars", ((V)(0D))).Put("reward", V.Null).V;
if (!(Truthy(e_452))) {
SetK(Get(s_450, "col"), id_448, NewObj(4).Put("f", NewObj(2).Put("n", ((V)(1D))).PutK(f_449, ((V)(1D))).V).Put("eq", f_449).Put("st", ((V)(0D))).Put("xp", ((V)(0D))).V);
} else {
if (!(Truthy(GetK(Get(e_452, "f"), f_449)))) {
SetK(Get(e_452, "f"), f_449, ((V)(1D)));
Set(@out_453, "newFinish", (true ? V.True : V.False));
} else {
Set(@out_453, "stars", ((V)((ToNum(GetK(DUPE_25, Get(c_451, "rar"))) * (!SEqS(f_449, "n") ? 2D : 1D)))));
}
}
OpSet(s_450, "stars", 0, Get(@out_453, "stars"));
if (Truthy(Get(c_451, "base"))) {
V st_455 = default;
st_455 = Invoke(SETS_12, "find", Fn((V _arrowThis463, int _argc456, V x_462, V _a459, V _a460, V _a461, V[] _rest457) => {
return (SEq(Get(x_462, "key"), Get(c_451, "set")) ? V.True : V.False);
}, 1, "", true));
if (Truthy((((st_455 is var _t464 && !Truthy(_t464) ? _t464 : (!Get(st_455, "reward").IsNullish ? V.True : V.False)) is var _t465 && !Truthy(_t465) ? _t465 : (!(Truthy(GetK(Get(s_450, "col"), Get(st_455, "reward")))) ? V.True : V.False)) is var _t466 && !Truthy(_t466) ? _t466 : Invoke(Get(st_455, "ids"), "every", Get(API_38, "owns"))))) {
SetK(Get(s_450, "col"), Get(st_455, "reward"), NewObj(4).Put("f", NewObj(1).Put("n", ((V)(1D))).V).Put("eq", ((V)("n"))).Put("st", ((V)(0D))).Put("xp", ((V)(0D))).V);
OpSet(s_450, "stars", 0, ((V)(SET_BONUS_30)));
Set(@out_453, "reward", Get(st_455, "reward"));
}
}
Call(save_36, V.Undef);
return @out_453;
return default;
}, 2, "grant", false)).Put("addXp", Fn((V _self467, int _argc468, V id_474, V n_475, V _a472, V _a473, V[] _rest469) => {
V e_476 = default;
if (_self467.IsNullish) _self467 = GlobalV;
e_476 = Invoke(API_38, "entry", id_474);
if ((!(Truthy(e_476)) || !(Truthy(n_475)))) {
return default;
}
Set(e_476, "xp", Add((Get(e_476, "xp") is var _t477 && Truthy(_t477) ? _t477 : ((V)(0D))), n_475));
Call(save_36, V.Undef, (true ? V.True : V.False));
Call(G("clearTimeout"), V.Undef, Get(API_38, "_xpT"));
Set(API_38, "_xpT", Call(G("setTimeout"), V.Undef, emit_34, ((V)(400D))));
return default;
}, 2, "addXp", false)).Put("growInfo", Fn((V _self478, int _argc479, V id_485, V _a482, V _a483, V _a484, V[] _rest480) => {
V e_486 = default;
V next_487 = default;
if (_self478.IsNullish) _self478 = GlobalV;
e_486 = Invoke(API_38, "entry", id_485);
if (!(Truthy(e_486))) {
return V.Null;
}
next_487 = GetK(STAGES_27, Add(Get(e_486, "st"), ((V)(1D))));
if (!(Truthy(next_487))) {
return NewObj(3).Put("stage", Get(e_486, "st")).Put("max", (true ? V.True : V.False)).Put("xp", Get(e_486, "xp")).V;
}
return NewObj(8).Put("stage", Get(e_486, "st")).Put("max", (false ? V.True : V.False)).Put("xp", Get(e_486, "xp")).Put("needXp", Get(next_487, "xp")).Put("needStars", Get(next_487, "stars")).Put("xpOk", (Ge(Get(e_486, "xp"), Get(next_487, "xp")) ? V.True : V.False)).Put("starsOk", (Ge(Get(Call(load_35, V.Undef), "stars"), Get(next_487, "stars")) ? V.True : V.False)).Put("next", Get(next_487, "name")).V;
return default;
}, 1, "growInfo", false)).Put("grow", Fn((V _self488, int _argc489, V id_495, V _a492, V _a493, V _a494, V[] _rest490) => {
V g_496 = default;
V s_497 = default;
if (_self488.IsNullish) _self488 = GlobalV;
g_496 = Invoke(API_38, "growInfo", id_495);
if (Truthy(((((!(Truthy(g_496)) ? V.True : V.False) is var _t498 && Truthy(_t498) ? _t498 : Get(g_496, "max")) is var _t499 && Truthy(_t499) ? _t499 : (!(Truthy(Get(g_496, "xpOk"))) ? V.True : V.False)) is var _t500 && Truthy(_t500) ? _t500 : (!(Truthy(Get(g_496, "starsOk"))) ? V.True : V.False)))) {
return (false ? V.True : V.False);
}
s_497 = Call(load_35, V.Undef);
OpSet(s_497, "stars", 1, Get(g_496, "needStars"));
IncM(GetK(Get(s_497, "col"), id_495), "st", 1D, false);
if (SEqN(Get(GetK(Get(s_497, "col"), id_495), "st"), 2D)) {
OpSet(s_497, "stars", 0, ((V)(0D)));
}
Call(save_36, V.Undef);
return (true ? V.True : V.False);
return default;
}, 1, "grow", false)).Put("finishPrice", Fn((V _self501, int _argc502, V id_508, V f_509, V _a506, V _a507, V[] _rest503) => {
V c_510 = default;
V F_511 = default;
if (_self501.IsNullish) _self501 = GlobalV;
c_510 = GetK(ROSTER_22, id_508);
F_511 = Invoke(FIN_26, "find", Fn((V _arrowThis519, int _argc512, V x_518, V _a515, V _a516, V _a517, V[] _rest513) => {
return (SEq(Get(x_518, "k"), f_509) ? V.True : V.False);
}, 1, "", true));
if ((((!(Truthy(c_510)) || !(Truthy(F_511))) || !(Truthy(Get(F_511, "x")))) || GtN(Get(c_510, "rar"), 3D))) {
return V.Null;
}
return ((V)((ToNum(GetK(STAR_PRICE_23, Get(c_510, "rar"))) * ToNum(Get(F_511, "x")))));
return default;
}, 2, "finishPrice", false)).Put("buyFinish", Fn((V _self520, int _argc521, V id_527, V f_528, V _a525, V _a526, V[] _rest522) => {
V p_529 = default;
V e_530 = default;
if (_self520.IsNullish) _self520 = GlobalV;
p_529 = Invoke(API_38, "finishPrice", id_527, f_528);
e_530 = Invoke(API_38, "entry", id_527);
if (Truthy(((((!(Truthy(p_529)) || !(Truthy(e_530))) ? V.True : V.False) is var _t531 && Truthy(_t531) ? _t531 : GetK(Get(e_530, "f"), f_528)) is var _t532 && Truthy(_t532) ? _t532 : (Lt(Get(Call(load_35, V.Undef), "stars"), p_529) ? V.True : V.False)))) {
return (false ? V.True : V.False);
}
OpSet(S_32, "stars", 1, p_529);
SetK(Get(e_530, "f"), f_528, ((V)(1D)));
Set(e_530, "eq", f_528);
Call(save_36, V.Undef);
return (true ? V.True : V.False);
return default;
}, 2, "buyFinish", false)).Put("equip", Fn((V _self533, int _argc534, V id_540, V f_541, V _a538, V _a539, V[] _rest535) => {
V e_542 = default;
if (_self533.IsNullish) _self533 = GlobalV;
e_542 = Invoke(API_38, "entry", id_540);
if ((!(Truthy(e_542)) || !(Truthy(GetK(Get(e_542, "f"), f_541))))) {
return (false ? V.True : V.False);
}
Set(e_542, "eq", f_541);
Call(save_36, V.Undef);
return (true ? V.True : V.False);
return default;
}, 2, "equip", false)).Put("finishOf", Fn((V _self543, int _argc544, V id_550, V _a547, V _a548, V _a549, V[] _rest545) => {
V e_551 = default;
if (_self543.IsNullish) _self543 = GlobalV;
e_551 = GetK(Get(Call(load_35, V.Undef), "col"), id_550);
return (Truthy(e_551) ? (Get(e_551, "eq") is var _t552 && Truthy(_t552) ? _t552 : ((V)("n"))) : ((V)("n")));
return default;
}, 1, "finishOf", false)).Put("buy", Fn((V _self553, int _argc554, V id_560, V cur_561, V _a558, V _a559, V[] _rest555) => {
V c_562 = default;
V price_563 = default;
if (_self553.IsNullish) _self553 = GlobalV;
c_562 = GetK(ROSTER_22, id_560);
if (Truthy(((((!(Truthy(c_562)) || !(Truthy(Get(c_562, "base")))) || !(Truthy(Get(c_562, "art")))) ? V.True : V.False) is var _t564 && Truthy(_t564) ? _t564 : Invoke(API_38, "owns", id_560)))) {
return V.Null;
}
price_563 = (SEqS(cur_561, "stars") ? GetK(STAR_PRICE_23, Get(c_562, "rar")) : GetK(COIN_PRICE_24, Get(c_562, "rar")));
if ((!(Truthy(price_563)) || !(Truthy(Invoke(API_38, "spend", cur_561, price_563))))) {
return V.Null;
}
return Invoke(API_38, "grant", id_560, ((V)("n")));
return default;
}, 2, "buy", false)).Put("roll", Fn((V _self565, int _argc566, V tier_572, V _a569, V _a570, V _a571, V[] _rest567) => {
V T_573 = default;
V s_574 = default;
V odds_575 = default;
double x_576 = 0;
double r_577 = 0;
V pool_578 = default;
V w_579 = default;
double y_580 = 0;
double k_581 = 0;
V m_582 = default;
double fr_583 = 0;
V f_584 = default;
if (_self565.IsNullish) _self565 = GlobalV;
T_573 = (GetK(CHESTS_29, tier_572) is var _t585 && Truthy(_t585) ? _t585 : Get(CHESTS_29, "basic"));
s_574 = Call(load_35, V.Undef);
if (Truthy(Get(T_573, "gp"))) {
Set(s_574, "pity", Add((Get(s_574, "pity") is var _t586 && Truthy(_t586) ? _t586 : ((V)(0D))), ((V)(1D))));
}
Set(s_574, "epic", Add((Get(s_574, "epic") is var _t587 && Truthy(_t587) ? _t587 : ((V)(0D))), ((V)(1D))));
odds_575 = Get(T_573, "odds");
x_576 = (ToNum(Invoke(G("Math"), "random")) * ToNum(Invoke(odds_575, "reduce", Fn((V _arrowThis596, int _argc588, V a_594, V b_595, V _a592, V _a593, V[] _rest589) => {
return Add(a_594, b_595);
}, 2, "", true), ((V)(0D)))));
r_577 = 0D;
{
while (true) {
if (!((r_577 < 3D))) break;
if (Lt(((V)(x_576)), GetIdx(odds_575, r_577))) {
break;
}
x_576 = (x_576 - ToNum(GetIdx(odds_575, r_577)));
r_577++;
}
}
if (Truthy((Get(T_573, "gp") is var _t598 && !Truthy(_t598) ? _t598 : (GeN(Get(s_574, "pity"), 30D) ? V.True : V.False)))) {
r_577 = 3D;
}
if (((r_577 < 2D) && GeN(Get(s_574, "epic"), 10D))) {
r_577 = 2D;
}
if ((r_577 == 3D)) {
Set(s_574, "pity", ((V)(0D)));
}
if ((r_577 >= 2D)) {
Set(s_574, "epic", ((V)(0D)));
}
pool_578 = Invoke(ROSTER_22, "filter", Fn((V _arrowThis606, int _argc599, V c_605, V _a602, V _a603, V _a604, V[] _rest600) => {
return (((Truthy(Get(T_573, "season")) ? (Get(c_605, "season") is var _t607 && !Truthy(_t607) ? _t607 : (!(Truthy(Get(c_605, "pass"))) ? V.True : V.False)) : Get(c_605, "base")) is var _t608 && !Truthy(_t608) ? _t608 : (SEqN(Get(c_605, "rar"), r_577) ? V.True : V.False)) is var _t609 && !Truthy(_t609) ? _t609 : Get(c_605, "art"));
}, 1, "", true));
if (!(Truthy(Get(pool_578, "length")))) {
pool_578 = Invoke(Invoke(Invoke(ROSTER_22, "filter", Fn((V _arrowThis636, int _argc629, V c_635, V _a632, V _a633, V _a634, V[] _rest630) => {
return ((Get(c_635, "base") is var _t637 && !Truthy(_t637) ? _t637 : Get(c_635, "art")) is var _t638 && !Truthy(_t638) ? _t638 : (LeN(Get(c_635, "rar"), r_577) ? V.True : V.False));
}, 1, "", true)), "sort", Fn((V _arrowThis628, int _argc620, V a_626, V b_627, V _a624, V _a625, V[] _rest621) => {
return ((V)((ToNum(Get(b_627, "rar")) - ToNum(Get(a_626, "rar")))));
}, 2, "", true)), "filter", Fn((V _arrowThis619, int _argc610, V c_616, V i_617, V a_618, V _a615, V[] _rest611) => {
return (SEq(Get(c_616, "rar"), Get(GetIdx(a_618, 0D), "rar")) ? V.True : V.False);
}, 3, "", true));
}
w_579 = Invoke(pool_578, "map", Fn((V _arrowThis646, int _argc639, V c_645, V _a642, V _a643, V _a644, V[] _rest640) => {
return ((V)((Truthy(Invoke(API_38, "owns", Get(c_645, "id"))) ? 1D : 3D)));
}, 1, "", true));
y_580 = (ToNum(Invoke(G("Math"), "random")) * ToNum(Invoke(w_579, "reduce", Fn((V _arrowThis655, int _argc647, V a_653, V b_654, V _a651, V _a652, V[] _rest648) => {
return Add(a_653, b_654);
}, 2, "", true), ((V)(0D)))));
k_581 = 0D;
{
while (true) {
if (!((k_581 < (ToNum(Get(pool_578, "length")) - 1D)))) break;
if (Lt(((V)(y_580)), GetIdx(w_579, k_581))) {
break;
}
y_580 = (y_580 - ToNum(GetIdx(w_579, k_581)));
k_581++;
}
}
m_582 = (Get(T_573, "fx") is var _t657 && Truthy(_t657) ? _t657 : ((V)(1D)));
fr_583 = (ToNum(Invoke(G("Math"), "random")) * 100D);
f_584 = ((V)(((fr_583 < (0.1 * ToNum(m_582))) ? "g" : ((fr_583 < (0.6 * ToNum(m_582))) ? "r" : ((fr_583 < (2.6 * ToNum(m_582))) ? "s" : "n")))));
Call(save_36, V.Undef, (true ? V.True : V.False));
return NewObj(3).Put("id", Get(GetIdx(pool_578, k_581), "id")).Put("rar", ((V)(r_577))).Put("f", f_584).V;
return default;
}, 1, "roll", false)).Put("reset", Fn((V _self658, int _argc659, V _a661, V _a662, V _a663, V _a664, V[] _rest660) => {
if (_self658.IsNullish) _self658 = GlobalV;
S_32 = Call(SEED_31, V.Undef);
Call(save_36, V.Undef);
return default;
}, 0, "reset", false)).V;
Invoke(G("window"), "addEventListener", ((V)("storage")), Fn((V _arrowThis672, int _argc665, V e_671, V _a668, V _a669, V _a670, V[] _rest666) => {
if (SEq(Get(e_671, "key"), KEY_10)) {
S_32 = V.Null;
Call(emit_34, V.Undef);
}
if (SEqS(Get(e_671, "key"), "squishsquad.profile.v1")) {
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
