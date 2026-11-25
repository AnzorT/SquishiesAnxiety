// reno-draw.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_draw_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("s$", "");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("^([^.@*+]+)(.*)$", "");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("([.@*+])(\\w+(?:\\.\\d+)?)", "g");
        static readonly System.Text.RegularExpressions.Regex RX3 = JsRegExp.Compile("foam|egg-carton", "");
        static readonly System.Text.RegularExpressions.Regex RX4 = JsRegExp.Compile("black", "");
        static readonly System.Text.RegularExpressions.Regex RX5 = JsRegExp.Compile("wainscot", "");
        static readonly System.Text.RegularExpressions.Regex RX6 = JsRegExp.Compile("egg-carton|pyramid|foam", "");
        static readonly System.Text.RegularExpressions.Regex RX7 = JsRegExp.Compile("drape|velvet|silk-woven|curtain", "");
        static readonly System.Text.RegularExpressions.Regex RX8 = JsRegExp.Compile("slat|panel+ing|paneling|shiplap|hinoki|cedar accent", "");
        static readonly System.Text.RegularExpressions.Regex RX9 = JsRegExp.Compile("brick|cinderblock", "");
        static readonly System.Text.RegularExpressions.Regex RX10 = JsRegExp.Compile("subway|tile|backsplash|zellige", "");
        static readonly System.Text.RegularExpressions.Regex RX11 = JsRegExp.Compile("hex", "");
        static readonly System.Text.RegularExpressions.Regex RX12 = JsRegExp.Compile("mildew|cracked", "");
        static readonly System.Text.RegularExpressions.Regex RX13 = JsRegExp.Compile("cracked", "");
        static readonly System.Text.RegularExpressions.Regex RX14 = JsRegExp.Compile("herringbone", "");
        static readonly System.Text.RegularExpressions.Regex RX15 = JsRegExp.Compile("marble|onyx|quartzite|calacatta|stone|slate|basalt|tadelakt|limewash|plaster|venetian|travertine", "");
        static readonly System.Text.RegularExpressions.Regex RX16 = JsRegExp.Compile("brass|gold", "");
        static readonly System.Text.RegularExpressions.Regex RX17 = JsRegExp.Compile("slab|slate", "");
        static readonly System.Text.RegularExpressions.Regex RX18 = JsRegExp.Compile("backlit|translucent", "");
        static readonly System.Text.RegularExpressions.Regex RX19 = JsRegExp.Compile("wallpaper", "");
        static readonly System.Text.RegularExpressions.Regex RX20 = JsRegExp.Compile("chinoiserie|botanical", "");
        static readonly System.Text.RegularExpressions.Regex RX21 = JsRegExp.Compile("graffiti", "");
        static readonly System.Text.RegularExpressions.Regex RX22 = JsRegExp.Compile("mirror-tile|geometric mirror|led matrix|visualizer|plasma|starlight|holographic|liquid-light", "");
        static readonly System.Text.RegularExpressions.Regex RX23 = JsRegExp.Compile("mirror", "");
        static readonly System.Text.RegularExpressions.Regex RX24 = JsRegExp.Compile("plasma|liquid|visualizer", "");
        static readonly System.Text.RegularExpressions.Regex RX25 = JsRegExp.Compile("copper", "");
        static readonly System.Text.RegularExpressions.Regex RX26 = JsRegExp.Compile("neon", "");
        static readonly System.Text.RegularExpressions.Regex RX27 = JsRegExp.Compile("neon tube|neon accent", "");
        static readonly System.Text.RegularExpressions.Regex RX28 = JsRegExp.Compile("peeling|stain|water-|scuffed|grease|tack|mildew", "");
        static readonly System.Text.RegularExpressions.Regex RX29 = JsRegExp.Compile("peel", "");
        static readonly System.Text.RegularExpressions.Regex RX30 = JsRegExp.Compile("tack", "");
        static readonly System.Text.RegularExpressions.Regex RX31 = JsRegExp.Compile("grease", "");
        static readonly System.Text.RegularExpressions.Regex RX32 = JsRegExp.Compile("foil", "");
        static readonly System.Text.RegularExpressions.Regex RX33 = JsRegExp.Compile("hinoki|cedar accent|walnut paneling", "");
        static readonly System.Text.RegularExpressions.Regex RX34 = JsRegExp.Compile("mirror-polished|pristine", "");
        static readonly System.Text.RegularExpressions.Regex RX35 = JsRegExp.Compile("concrete", "");
        static readonly System.Text.RegularExpressions.Regex RX36 = JsRegExp.Compile("dirt|mud", "");
        static readonly System.Text.RegularExpressions.Regex RX37 = JsRegExp.Compile("lawn|turf|grass|clover|moss lawn|star-moss", "");
        static readonly System.Text.RegularExpressions.Regex RX38 = JsRegExp.Compile("star|bioluminescent", "");
        static readonly System.Text.RegularExpressions.Regex RX39 = JsRegExp.Compile("carpet|pile|cushion", "");
        static readonly System.Text.RegularExpressions.Regex RX40 = JsRegExp.Compile("checker|checkerboard|vinyl tile|moss-inlaid", "");
        static readonly System.Text.RegularExpressions.Regex RX41 = JsRegExp.Compile("moss", "");
        static readonly System.Text.RegularExpressions.Regex RX42 = JsRegExp.Compile("peeling", "");
        static readonly System.Text.RegularExpressions.Regex RX43 = JsRegExp.Compile("light-up|disco squares|rgb matrix|interactive|haptic|levitation|glass flooring|led guides|footstep glow", "");
        static readonly System.Text.RegularExpressions.Regex RX44 = JsRegExp.Compile("guides|footstep", "");
        static readonly System.Text.RegularExpressions.Regex RX45 = JsRegExp.Compile("guides", "");
        static readonly System.Text.RegularExpressions.Regex RX46 = JsRegExp.Compile("herringbone|chevron|parquet", "");
        static readonly System.Text.RegularExpressions.Regex RX47 = JsRegExp.Compile("plank|oak|teak|hardwood|subfloor|laminate|ash|wood|duckboard", "");
        static readonly System.Text.RegularExpressions.Regex RX48 = JsRegExp.Compile("splintery|cold", "");
        static readonly System.Text.RegularExpressions.Regex RX49 = JsRegExp.Compile("plush perimeter", "");
        static readonly System.Text.RegularExpressions.Regex RX50 = JsRegExp.Compile("pebble", "");
        static readonly System.Text.RegularExpressions.Regex RX51 = JsRegExp.Compile("hex|porcelain|terrazzo|quarry|tile|linoleum|vinyl", "");
        static readonly System.Text.RegularExpressions.Regex RX52 = JsRegExp.Compile("terrazzo", "");
        static readonly System.Text.RegularExpressions.Regex RX53 = JsRegExp.Compile("cracked|curled|scuffed", "");
        static readonly System.Text.RegularExpressions.Regex RX54 = JsRegExp.Compile("marble|stone|basalt|onyx|quartz|slab|travertine|paver|flagstone", "");
        static readonly System.Text.RegularExpressions.Regex RX55 = JsRegExp.Compile("gold", "");
        static readonly System.Text.RegularExpressions.Regex RX56 = JsRegExp.Compile("gold vein|illumination", "");
        static readonly System.Text.RegularExpressions.Regex RX57 = JsRegExp.Compile("drain", "");
        static readonly System.Text.RegularExpressions.Regex RX58 = JsRegExp.Compile("carpet|pile|loop", "");
        static readonly System.Text.RegularExpressions.Regex RX59 = JsRegExp.Compile("aisle", "");
        static readonly System.Text.RegularExpressions.Regex RX60 = JsRegExp.Compile("tiles", "");
        static readonly System.Text.RegularExpressions.Regex RX61 = JsRegExp.Compile("cardboard", "");
        static readonly System.Text.RegularExpressions.Regex RX62 = JsRegExp.Compile("duct-tape|cables", "");
        static readonly System.Text.RegularExpressions.Regex RX63 = JsRegExp.Compile("lawn|turf|grass|clover|ryegrass", "");
        static readonly System.Text.RegularExpressions.Regex RX64 = JsRegExp.Compile("clover", "");
        static readonly System.Text.RegularExpressions.Regex RX65 = JsRegExp.Compile("stepping|flagstone", "");
        static readonly System.Text.RegularExpressions.Regex RX66 = JsRegExp.Compile("puddle|patchy|crabgrass", "");
        static readonly System.Text.RegularExpressions.Regex RX67 = JsRegExp.Compile("star-moss|bioluminescent", "");
        static readonly System.Text.RegularExpressions.Regex RX68 = JsRegExp.Compile("porcelain patio|heated porcelain", "");
        static readonly System.Text.RegularExpressions.Regex RX69 = JsRegExp.Compile("pipes|rafters|basement", "");
        static readonly System.Text.RegularExpressions.Regex RX70 = JsRegExp.Compile("black painted|night sky|space|dome|vault|immersion|aurora", "");
        static readonly System.Text.RegularExpressions.Regex RX71 = JsRegExp.Compile("glass atrium|steam-dome", "");
        static readonly System.Text.RegularExpressions.Regex RX72 = JsRegExp.Compile("beam|rafter|coffer|shiplap", "");
        static readonly System.Text.RegularExpressions.Regex RX73 = JsRegExp.Compile("dark wood|cedar|beam", "");
        static readonly System.Text.RegularExpressions.Regex RX74 = JsRegExp.Compile("coffer|beam", "");
        static readonly System.Text.RegularExpressions.Regex RX75 = JsRegExp.Compile("coffer|mirror", "");
        static readonly System.Text.RegularExpressions.Regex RX76 = JsRegExp.Compile("pipes", "");
        static readonly System.Text.RegularExpressions.Regex RX77 = JsRegExp.Compile("cobweb", "");
        static readonly System.Text.RegularExpressions.Regex RX78 = JsRegExp.Compile("popcorn|stucco|water-spotted|stained|peeling", "");
        static readonly System.Text.RegularExpressions.Regex RX79 = JsRegExp.Compile("acoustic|drop-tile|pvc|foam", "");
        static readonly System.Text.RegularExpressions.Regex RX80 = JsRegExp.Compile("star|night sky|fiber-optic|space|nebula|aurora|immersion|halo rig|laser", "");
        static readonly System.Text.RegularExpressions.Regex RX81 = JsRegExp.Compile("aurora|nebula", "");
        static readonly System.Text.RegularExpressions.Regex RX82 = JsRegExp.Compile("laser|halo", "");
        static readonly System.Text.RegularExpressions.Regex RX83 = JsRegExp.Compile("fan", "");
        static readonly System.Text.RegularExpressions.Regex RX84 = JsRegExp.Compile("exhaust|vent|hood|fan", "");
        static readonly System.Text.RegularExpressions.Regex RX85 = JsRegExp.Compile("paddle", "");
        static readonly System.Text.RegularExpressions.Regex RX86 = JsRegExp.Compile("range hood|chimney|canopy range|hood", "");
        static readonly System.Text.RegularExpressions.Regex RX87 = JsRegExp.Compile("plaster", "");
        static readonly System.Text.RegularExpressions.Regex RX88 = JsRegExp.Compile("brass", "");
        static readonly System.Text.RegularExpressions.Regex RX89 = JsRegExp.Compile("pot lights|recessed|cove|tray|led vent|chromotherapy", "");
        static readonly System.Text.RegularExpressions.Regex RX90 = JsRegExp.Compile("cove|tray", "");
        static readonly System.Text.RegularExpressions.Regex RX91 = JsRegExp.Compile("chromo", "");
        static readonly System.Text.RegularExpressions.Regex RX92 = JsRegExp.Compile("skylight|atrium|glass|sky-vault", "");
        static readonly System.Text.RegularExpressions.Regex RX93 = JsRegExp.Compile("medallion|crown|molding|cove molding", "");
        static readonly System.Text.RegularExpressions.Regex RX94 = JsRegExp.Compile("steam-dome|rain-cloud|mist", "");
        static readonly System.Text.RegularExpressions.Regex RX95 = JsRegExp.Compile("truss", "");
        static readonly System.Text.RegularExpressions.Regex RX96 = JsRegExp.Compile("christmas|kinetic triangle|led ceiling", "");
        static readonly System.Text.RegularExpressions.Regex RX97 = JsRegExp.Compile("disco", "");
        static readonly System.Text.RegularExpressions.Regex RX98 = JsRegExp.Compile("triangle", "");
        static readonly System.Text.RegularExpressions.Regex RX99 = JsRegExp.Compile("chain-link", "");
        static readonly System.Text.RegularExpressions.Regex RX100 = JsRegExp.Compile("limestone|stone", "");
        static readonly System.Text.RegularExpressions.Regex RX101 = JsRegExp.Compile("living|rainforest|force-field", "");
        static readonly System.Text.RegularExpressions.Regex RX102 = JsRegExp.Compile("horizontal|slat", "");
        static readonly System.Text.RegularExpressions.Regex RX103 = JsRegExp.Compile("beaded|plastic curtain", "");
        static readonly System.Text.RegularExpressions.Regex RX104 = JsRegExp.Compile("shower curtain", "");
        static readonly System.Text.RegularExpressions.Regex RX105 = JsRegExp.Compile("stanchion|rope", "");
        static readonly System.Text.RegularExpressions.Regex RX106 = JsRegExp.Compile("curtain|beaded", "");
        static readonly System.Text.RegularExpressions.Regex RX107 = JsRegExp.Compile("squeaky|hollow|basement", "");
        static readonly System.Text.RegularExpressions.Regex RX108 = JsRegExp.Compile("airlock|portal|biometric|hologram|neon tunnel", "");
        static readonly System.Text.RegularExpressions.Regex RX109 = JsRegExp.Compile("padded|studio|speakeasy|steel", "");
        static readonly System.Text.RegularExpressions.Regex RX110 = JsRegExp.Compile("double|mahogany|palace|brass vip", "");
        static readonly System.Text.RegularExpressions.Regex RX111 = JsRegExp.Compile("mahogany", "");
        static readonly System.Text.RegularExpressions.Regex RX112 = JsRegExp.Compile("leather|padded", "");
        static readonly System.Text.RegularExpressions.Regex RX113 = JsRegExp.Compile("panoram|floor-to-ceiling|bay|wall|pass-through|skyline|glass wall", "");
        static readonly System.Text.RegularExpressions.Regex RX114 = JsRegExp.Compile("french|balcony|arch", "");
        static readonly System.Text.RegularExpressions.Regex RX115 = JsRegExp.Compile("herb|greenhouse|box window|hydroponic|window seat", "");
        static readonly System.Text.RegularExpressions.Regex RX116 = JsRegExp.Compile("lace|sheer", "");
        static readonly System.Text.RegularExpressions.Regex RX117 = JsRegExp.Compile("crack|hopper|rust screen|drafty", "");
        static readonly System.Text.RegularExpressions.Regex RX118 = JsRegExp.Compile("steel|smart", "");
        static readonly System.Text.RegularExpressions.Regex RX119 = JsRegExp.Compile("holo|skyline", "");
        static readonly System.Text.RegularExpressions.Regex RX120 = JsRegExp.Compile("shutter", "");
        static readonly System.Text.RegularExpressions.Regex RX121 = JsRegExp.Compile("accordion|paper", "");
        static readonly System.Text.RegularExpressions.Regex RX122 = JsRegExp.Compile("blinds|plastic", "");
        static readonly System.Text.RegularExpressions.Regex RX123 = JsRegExp.Compile("blackout", "");
        static readonly System.Text.RegularExpressions.Regex RX124 = JsRegExp.Compile("linen|roman|cotton", "");
        static readonly System.Text.RegularExpressions.Regex RX125 = JsRegExp.Compile("gingham|cafe", "");
        static readonly System.Text.RegularExpressions.Regex RX126 = JsRegExp.Compile("silk|drape", "");
        static readonly System.Text.RegularExpressions.Regex RX127 = JsRegExp.Compile("halo|herb", "");
        static readonly System.Text.RegularExpressions.Regex RX128 = JsRegExp.Compile("bulb|fluorescent|strip|dome|pull-chain|party bulb", "");
        static readonly System.Text.RegularExpressions.Regex RX129 = JsRegExp.Compile("track|spotlight|truss", "");
        static readonly System.Text.RegularExpressions.Regex RX130 = JsRegExp.Compile("sputnik|globe|pendant|flush-mount|deco", "");
        static readonly System.Text.RegularExpressions.Regex RX131 = JsRegExp.Compile("rattan|wicker|woven|bamboo|barn|enamel|paper|origami|drum", "");
        static readonly System.Text.RegularExpressions.Regex RX132 = JsRegExp.Compile("chandelier|murano|capiz|tiered", "");
        static readonly System.Text.RegularExpressions.Regex RX133 = JsRegExp.Compile("constellation|kinetic|floating|halo|aurora|herb-halo|feather|bioluminescent|hologram|plasma", "");
        static readonly System.Text.RegularExpressions.Regex RX134 = JsRegExp.Compile("laser|beam spot|moving-head|strobe", "");
        static readonly System.Text.RegularExpressions.Regex RX135 = JsRegExp.Compile("disco|mirror sphere|mirror ball|tin-foil ball", "");
        static readonly System.Text.RegularExpressions.Regex RX136 = JsRegExp.Compile("edison|bistro|festoon", "");
        static readonly System.Text.RegularExpressions.Regex RX137 = JsRegExp.Compile("paper lantern", "");
        static readonly System.Text.RegularExpressions.Regex RX138 = JsRegExp.Compile("[\\s,]+", "");
        static readonly System.Text.RegularExpressions.Regex RX139 = JsRegExp.Compile("matrix\\(|\\)", "g");
        static readonly System.Text.RegularExpressions.Regex RX140 = JsRegExp.Compile("\\s+", "");
        static readonly System.Text.RegularExpressions.Regex RX141 = JsRegExp.Compile("[^a-z0-9\\-\u00e9 ]+", "g");
        static readonly System.Text.RegularExpressions.Regex RX142 = JsRegExp.Compile("marble|stone", "");
        static readonly System.Text.RegularExpressions.Regex RX143 = JsRegExp.Compile("box", "");
        static readonly System.Text.RegularExpressions.Regex RX144 = JsRegExp.Compile("red", "");
        static readonly System.Text.RegularExpressions.Regex RX145 = JsRegExp.Compile("neon|sticker", "");
        static readonly System.Text.RegularExpressions.Regex RX146 = JsRegExp.Compile("galvanized|watering|rusty", "");
        static readonly System.Text.RegularExpressions.Regex RX147 = JsRegExp.Compile("cobalt|ceramic|barrel", "");
        static readonly System.Text.RegularExpressions.Regex RX148 = JsRegExp.Compile("ceramic|barrel|cobalt", "");
        static readonly System.Text.RegularExpressions.Regex RX149 = JsRegExp.Compile("watering", "");
        static readonly System.Text.RegularExpressions.Regex RX150 = JsRegExp.Compile("knit", "");
        static readonly System.Text.RegularExpressions.Regex RX151 = JsRegExp.Compile("gild|brass|gold", "");
        static readonly System.Text.RegularExpressions.Regex RX152 = JsRegExp.Compile("bubble", "");
        static readonly System.Text.RegularExpressions.Regex RX153 = JsRegExp.Compile("mascot|dancer|idol", "");
        static readonly System.Text.RegularExpressions.Regex RX154 = JsRegExp.Compile("arena|sport", "");
        static readonly System.Text.RegularExpressions.Regex RX155 = JsRegExp.Compile("\\bretro\\b|diner|70s|jukebox|vintage red|cola|neon pinball|'now showing'", "i");
        static readonly System.Text.RegularExpressions.Regex RX156 = JsRegExp.Compile("levitat|floating|hover|zero-g|anti-grav|suspended magnetic|magnetic cloud", "i");
        static readonly System.Text.RegularExpressions.Regex RX157 = JsRegExp.Compile("holo|hologra|bioluminescent|plasma|quantum|aurora|nebula", "i");
        static readonly System.Text.RegularExpressions.Regex RX158 = JsRegExp.Compile("\"", "g");
        static readonly System.Text.RegularExpressions.Regex RX159 = JsRegExp.Compile("&", "g");
        static readonly System.Text.RegularExpressions.Regex RX160 = JsRegExp.Compile("^(table|coffee|bistro|counter|diningTable|luxCounter|nightstand|#spoolTable|cart|bar|desk|dresser)$", "");
        public static void Run()
        {
Call(Named(boot_1126 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V X_8 = default;
V K_9 = default;
V solid_10 = default;
V box_11 = default;
V cush_12 = default;
V cyl_13 = default;
V ball_14 = default;
V slab_15 = default;
V slabX_16 = default;
V arcW_17 = default;
V disc_18 = default;
V pillowY_19 = default;
V pillowZ_20 = default;
V prism_21 = default;
V prismZ_22 = default;
V shade_23 = default;
V mix_24 = default;
V f1_25 = default;
V NE_26 = default;
V GOLD_27 = default;
V CH_28 = default;
V CR_29 = default;
V WH_30 = default;
V DK_31 = default;
V GL_32 = default;
double PI_33 = 0;
V em_34 = default;
V TB_35 = default;
V CA_36 = default;
V CW_37 = default;
V CM_38 = default;
V words_39 = default;
V colorsOf_40 = default;
V legs4_41 = default;
V metalOf_42 = default;
V holoBase_43 = default;
V N_44 = default;
V patch_45 = default;
V H_46 = default;
V M_47 = default;
V RETRO_48 = default;
V FLOAT_49 = default;
V HOLO_50 = default;
V parseSpec_51 = default;
V specFor_52 = default;
V pd_53 = default;
V rr_54 = default;
V circ_55 = default;
V ell_56 = default;
V has_57 = default;
V rnd_58 = default;
V wallPolys_59 = default;
V floorPolys_60 = default;
V ceilPolys_61 = default;
V fencePolys_62 = default;
V doorCurtain_63 = default;
V swPolys_64 = default;
V surface_65 = default;
V SD_66 = default;
V esc_67 = default;
V svgOf_68 = default;
V pstr_69 = default;
V svgDoc_70 = default;
V projOf_71 = default;
V HOSTB_72 = default;
V MEMO_73 = default;
V draw_74 = default;
V parseCSV_75 = default;
if (_self1.IsNullish) _self1 = GlobalV;
colorsOf_40 = Fn((V _self76, int _argc77, V name_83, V band_84, V _a81, V _a82, V[] _rest78) => {
V B_85 = default;
V W_86 = default;
V cs_87 = default;
V ms_88 = default;
V ws_89 = default;
V a_90 = default;
V b_91 = default;
V w_92 = default;
if (_self76.IsNullish) _self76 = GlobalV;
B_85 = GetIdx(Get((Invoke(Get(X_8, "BANDS"), "find", Fn((V _arrowThis100, int _argc93, V b_99, V _a96, V _a97, V _a98, V[] _rest94) => {
return (SEq(Get(b_99, "k"), band_84) ? V.True : V.False);
}, 1, "", true)) is var _t101 && Truthy(_t101) ? _t101 : GetIdx(Get(X_8, "BANDS"), 0D)), "cols"), 0D);
W_86 = Call(words_39, V.Undef, name_83);
cs_87 = Arr();
ms_88 = Arr();
ws_89 = Arr();
Invoke(W_86, "forEach", Fn((V _arrowThis109, int _argc102, V w_108, V _a105, V _a106, V _a107, V[] _rest103) => {
V s_110 = default;
s_110 = Invoke(w_108, "replace", NewRegExp(RX0, "s$", ""), ((V)("")));
if (Truthy((GetK(CA_36, w_108) is var _t111 && Truthy(_t111) ? _t111 : GetK(CA_36, s_110)))) {
Invoke(cs_87, "push", (GetK(CA_36, w_108) is var _t112 && Truthy(_t112) ? _t112 : GetK(CA_36, s_110)));
} else {
if (Truthy((GetK(CM_38, w_108) is var _t113 && Truthy(_t113) ? _t113 : GetK(CM_38, s_110)))) {
Invoke(ms_88, "push", (GetK(CM_38, w_108) is var _t114 && Truthy(_t114) ? _t114 : GetK(CM_38, s_110)));
} else {
if (Truthy((GetK(CW_37, w_108) is var _t115 && Truthy(_t115) ? _t115 : GetK(CW_37, s_110)))) {
Invoke(ws_89, "push", (GetK(CW_37, w_108) is var _t116 && Truthy(_t116) ? _t116 : GetK(CW_37, s_110)));
}
}
}
return default;
}, 1, "", true));
a_90 = (((GetIdx(cs_87, 0D) is var _t117 && Truthy(_t117) ? _t117 : GetIdx(ms_88, 0D)) is var _t118 && Truthy(_t118) ? _t118 : GetIdx(ws_89, 0D)) is var _t119 && Truthy(_t119) ? _t119 : Get(B_85, "a"));
b_91 = (((Truthy((GetIdx(cs_87, 0D) is var _t120 && Truthy(_t120) ? _t120 : GetIdx(ws_89, 0D))) ? GetIdx(ms_88, 0D) : GetIdx(ms_88, 1D)) is var _t121 && Truthy(_t121) ? _t121 : GetIdx(cs_87, 1D)) is var _t122 && Truthy(_t122) ? _t122 : Get(B_85, "b"));
w_92 = (GetIdx(ws_89, 0D) is var _t123 && Truthy(_t123) ? _t123 : Get(B_85, "w"));
return NewObj(5).Put("a", a_90).Put("b", b_91).Put("w", w_92).Put("m", (GetIdx(ms_88, 0D) is var _t124 && Truthy(_t124) ? _t124 : ((V)("#d5dde2")))).Put("anyA", (!(!(Truthy(((GetIdx(cs_87, 0D) is var _t125 && Truthy(_t125) ? _t125 : GetIdx(ms_88, 0D)) is var _t126 && Truthy(_t126) ? _t126 : GetIdx(ws_89, 0D))))) ? V.True : V.False)).V;
return default;
}, 2, "colorsOf", false);
parseSpec_51 = Fn((V _self127, int _argc128, V s_134, V _a131, V _a132, V _a133, V[] _rest129) => {
V m_135 = default;
V o_136 = default;
if (_self127.IsNullish) _self127 = GlobalV;
m_135 = Invoke(s_134, "match", NewRegExp(RX1, "^([^.@*+]+)(.*)$", ""));
o_136 = NewObj(5).Put("base", GetIdx(m_135, 1D)).Put("v", ((V)(""))).Put("band", ((V)(""))).Put("zs", ((V)(1D))).Put("flags", Arr()).V;
{
foreach (V _k137 in new JsIter(Invoke(GetIdx(m_135, 2D), "matchAll", NewRegExp(RX2, "([.@*+])(\\w+(?:\\.\\d+)?)", "g")))) {
V t_138 = default;
t_138 = _k137;
if (SEqS(GetIdx(t_138, 1D), ".")) {
Set(o_136, "v", GetIdx(t_138, 2D));
} else {
if (SEqS(GetIdx(t_138, 1D), "@")) {
Set(o_136, "band", GetIdx(t_138, 2D));
} else {
if (SEqS(GetIdx(t_138, 1D), "*")) {
Set(o_136, "zs", ((V)(ToNum(GetIdx(t_138, 2D)))));
} else {
Invoke(Get(o_136, "flags"), "push", GetIdx(t_138, 2D));
}
}
}
}
}
return o_136;
return default;
}, 1, "parseSpec", false);
wallPolys_59 = Fn((V _self139, int _argc140, V n_146, V C_147, V tier_148, V _a145, V[] _rest141) => {
V o_149 = default;
V L_150 = default;
V R_151 = default;
V b0_152 = default;
V dk_153 = default;
V lt_154 = default;
if (_self139.IsNullish) _self139 = GlobalV;
o_149 = Arr();
L_150 = Invoke(n_146, "toLowerCase");
R_151 = Call(rnd_58, V.Undef, n_146);
b0_152 = (Truthy(Get(C_147, "anyA")) ? Get(C_147, "a") : GetIdx(Arr(((V)("#d9c9ae")), ((V)("#e8dcc8")), ((V)("#ece6da")), ((V)("#e2d0b0")), ((V)("#3a3448"))), (ToNum(tier_148) - 1D)));
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX3, "foam|egg-carton", "")))) {
b0_152 = ((V)((Truthy(Invoke(NewRegExp(RX4, "black", ""), "test", L_150)) ? "#34343a" : "#8a8f94")));
}
Invoke(o_149, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)(56D)), ((V)(4D))), b0_152));
dk_153 = Call(shade_23, V.Undef, b0_152, ((V)(0.82)));
lt_154 = Call(mix_24, V.Undef, b0_152, ((V)("#ffffff")), ((V)(0.3)));
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX5, "wainscot", "")))) {
Invoke(o_149, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(80D)), ((V)(26D)), ((V)(0D))), ((V)((GeN(tier_148, 3D) ? "#2f4870" : "#f4f1ea")))), Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(80D)), ((V)(3D)), ((V)(0D))), ((V)("#fffaf1"))));
Invoke(Arr(((V)(6D)), ((V)(26D)), ((V)(46D)), ((V)(66D))), "forEach", Fn((V _arrowThis162, int _argc155, V x_161, V _a158, V _a159, V _a160, V[] _rest156) => {
return Invoke(o_149, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, x_161, ((V)(34D)), ((V)(12D)), ((V)(18D)), ((V)(1D))), ((V)("none")), Call(shade_23, V.Undef, ((V)((GeN(tier_148, 3D) ? "#2f4870" : "#f4f1ea"))), ((V)(0.85))), ((V)(1D))));
}, 1, "", true));
}
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX6, "egg-carton|pyramid|foam", "")))) {
{
double y_163 = 0;
y_163 = 0D;
while (true) {
if (!((y_163 < 5D))) break;
{
double x_165 = 0;
x_165 = 0D;
while (true) {
if (!((x_165 < 7D))) break;
double cx_167 = 0;
double cy_168 = 0;
cx_167 = (6D + (x_165 * 11.5));
cy_168 = (6D + (y_163 * 11D));
Invoke(o_149, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((cx_167 - 5D)).S(" ").N((cy_168 + 5D)).S("L").N(cx_167).S(" ").N((cy_168 - 5D)).S("L").N((cx_167 + 5D)).S(" ").N((cy_168 + 5D)).S("Z").End())), lt_154, ((V)(0D)), ((V)(0D)), ((V)(0.5))), Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").N(cx_167).S(" ").N((cy_168 - 5D)).S("L").N((cx_167 + 5D)).S(" ").N((cy_168 + 5D)).S("L").N(cx_167).S(" ").N((cy_168 + 2D)).S("Z").End())), dk_153, ((V)(0D)), ((V)(0D)), ((V)(0.7))));
x_165++;
}
}
y_163++;
}
}
} else {
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX7, "drape|velvet|silk-woven|curtain", "")))) {
{
double i_169 = 0;
i_169 = 0D;
while (true) {
if (!((i_169 < 8D))) break;
Invoke(o_149, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").N(((i_169 * 10D) + 2D)).S(" 0Q").N(((i_169 * 10D) + 6D)).S(" 28 ").N(((i_169 * 10D) + 2D)).S(" 56H").N(((i_169 * 10D) + 6D)).S("Q").N(((i_169 * 10D) + 9D)).S(" 28 ").N(((i_169 * 10D) + 6D)).S(" 0Z").End())), dk_153, ((V)(0D)), ((V)(0D)), ((V)(0.6))));
i_169++;
}
}
} else {
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX8, "slat|panel+ing|paneling|shiplap|hinoki|cedar accent", "")))) {
{
double i_171 = 0;
i_171 = 0D;
while (true) {
if (!((i_171 < 11D))) break;
Invoke(o_149, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(((i_171 * 7.4) + 1D))), ((V)(0D)), ((V)(5D)), ((V)(56D)), ((V)(1D))), (NumTruthy((i_171 % 2D)) ? lt_154 : dk_153), ((V)(0D)), ((V)(0D)), ((V)(0.5))));
i_171++;
}
}
} else {
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX9, "brick|cinderblock", "")))) {
{
double y_173 = 0;
y_173 = 0D;
while (true) {
if (!((y_173 < 8D))) break;
{
double x_175 = 0;
x_175 = 0D;
while (true) {
if (!((x_175 < 5D))) break;
Invoke(o_149, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(((x_175 * 17D) - ((y_173 % 2D) * 8D)))), ((V)((y_173 * 7D))), ((V)(16D)), ((V)(6D)), ((V)(1D))), (NumTruthy((y_173 % 3D)) ? b0_152 : dk_153), Call(shade_23, V.Undef, b0_152, ((V)(0.7))), ((V)(0.6))));
x_175++;
}
}
y_173++;
}
}
} else {
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX10, "subway|tile|backsplash|zellige", "")))) {
V hex_177 = default;
hex_177 = Invoke(NewRegExp(RX11, "hex", ""), "test", L_150);
{
double y_178 = 0;
y_178 = 0D;
while (true) {
if (!((y_178 < 9D))) break;
{
double x_180 = 0;
x_180 = 0D;
while (true) {
if (!((x_180 < 6D))) break;
Invoke(o_149, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(((x_180 * 14D) - ((y_178 % 2D) * 7D)))), ((V)((y_178 * 6.4))), ((V)(13D)), ((V)(5.6)), ((V)((Truthy(hex_177) ? 2.5 : 1D)))), (NumTruthy(((double)(ToInt32(((y_178 * 7D) + (x_180 * 3D))) & ToInt32(1D)))) ? b0_152 : lt_154), ((V)((Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX12, "mildew|cracked", ""))) ? "#8a8a70" : "#ffffff"))), ((V)(0.7))));
x_180++;
}
}
y_178++;
}
}
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX13, "cracked", "")))) {
Invoke(o_149, "push", Call(pd_53, V.Undef, ((V)("M30 4L36 18L32 26L40 40")), ((V)("none")), ((V)("#6a6a5a")), ((V)(1D))));
}
} else {
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX14, "herringbone", "")))) {
{
double y_182 = 0;
y_182 = 0D;
while (true) {
if (!((y_182 < 6D))) break;
Invoke(o_149, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M0 ").N(((y_182 * 10D) + 5D)).S("l10 -8l10 8l10 -8l10 8l10 -8l10 8l10 -8l10 8").End())), ((V)("none")), dk_153, ((V)(1.6)), ((V)(0.7))));
y_182++;
}
}
} else {
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX15, "marble|onyx|quartzite|calacatta|stone|slate|basalt|tadelakt|limewash|plaster|venetian|travertine", "")))) {
Invoke(o_149, "push", Call(pd_53, V.Undef, ((V)("M0 18Q20 10 34 22T80 14")), ((V)("none")), dk_153, ((V)(1D)), ((V)(0.7))), Call(pd_53, V.Undef, ((V)("M8 56Q22 36 46 40T80 30")), ((V)("none")), dk_153, ((V)(0.8)), ((V)(0.6))), Call(pd_53, V.Undef, ((V)("M40 0Q48 14 62 18")), ((V)("none")), lt_154, ((V)(1.2)), ((V)(0.7))));
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX16, "brass|gold", "")))) {
Invoke(o_149, "push", Call(pd_53, V.Undef, ((V)("M0 28H80")), ((V)("none")), GOLD_27, ((V)(1.6))));
}
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX17, "slab|slate", "")))) {
Invoke(o_149, "push", Call(pd_53, V.Undef, ((V)("M0 28H80M40 0V28M20 28V56M60 28V56")), ((V)("none")), dk_153, ((V)(1D))));
}
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX18, "backlit|translucent", "")))) {
Invoke(o_149, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)(56D)), ((V)(4D))), ((V)("#ffe9a0")), ((V)(0D)), ((V)(0D)), ((V)(0.25))));
}
} else {
if (Truthy((Call(has_57, V.Undef, L_150, NewRegExp(RX19, "wallpaper", "")) is var _t184 && !Truthy(_t184) ? _t184 : (!(Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX20, "chinoiserie|botanical", "")))) ? V.True : V.False)))) {
{
double i_185 = 0;
i_185 = 0D;
while (true) {
if (!((i_185 < 5D))) break;
Invoke(o_149, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)((4D + (i_185 * 16D)))), ((V)(0D)), ((V)(7D)), ((V)(56D)), ((V)(0D))), lt_154, ((V)(0D)), ((V)(0D)), ((V)(0.45))));
i_185++;
}
}
} else {
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX20, "chinoiserie|botanical", "")))) {
Invoke(Arr(Arr(((V)(14D)), ((V)(12D))), Arr(((V)(48D)), ((V)(8D))), Arr(((V)(30D)), ((V)(30D))), Arr(((V)(64D)), ((V)(32D))), Arr(((V)(10D)), ((V)(46D))), Arr(((V)(50D)), ((V)(50D)))), "forEach", Fn((V _arrowThis199, int _argc187, V _a189, V i_193, V _a191, V _a192, V[] _rest188) => {
V x_196 = default;
V y_198 = default;
{ V _t194 = ListOf(_a189);
{ V _t195 = GetIdx(_t194, 0D);
x_196 = _t195; }
{ V _t197 = GetIdx(_t194, 1D);
y_198 = _t197; }
}
Invoke(o_149, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_196).S(" ").V(y_198).S("q6 -8 12 -2q-6 8 -12 2Z").End())), ((V)((NumTruthy((ToNum(i_193) % 2D)) ? "#6aa65a" : "#9fb58c"))), ((V)(0D)), ((V)(0D)), ((V)(0.8))), Call(pd_53, V.Undef, Call(circ_55, V.Undef, Add(x_196, ((V)(3D))), Add(y_198, ((V)(4D))), ((V)(2D))), ((V)("#e3946a")), ((V)(0D)), ((V)(0D)), ((V)(0.8))));
return default;
}, 2, "", true));
} else {
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX21, "graffiti", "")))) {
Invoke(o_149, "push", Call(pd_53, V.Undef, ((V)("M8 30q8 -16 16 0t16 0")), ((V)("none")), ((V)("#e2554a")), ((V)(3D))), Call(pd_53, V.Undef, ((V)("M44 18q6 10 14 -2t12 6")), ((V)("none")), ((V)("#4fe0d0")), ((V)(3D))), Call(pd_53, V.Undef, ((V)("M14 46l10 -6l8 8l12 -10")), ((V)("none")), ((V)("#ffd66b")), ((V)(2.4))));
{
double i_200 = 0;
i_200 = 0D;
while (true) {
if (!((i_200 < 8D))) break;
Invoke(o_149, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)((ToNum(Call(R_151, V.Undef)) * 70D))), ((V)((ToNum(Call(R_151, V.Undef)) * 50D))), ((V)(8D)), ((V)(6D)), ((V)(0D))), ((V)("#d5dde2")), ((V)(0D)), ((V)(0D)), ((V)(0.5))));
i_200++;
}
}
{
double y_202 = 0;
y_202 = 0D;
while (true) {
if (!((y_202 < 8D))) break;
Invoke(o_149, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M0 ").N((y_202 * 7D)).S("H80").End())), ((V)("none")), dk_153, ((V)(0.5)), ((V)(0.4))));
y_202++;
}
}
} else {
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX22, "mirror-tile|geometric mirror|led matrix|visualizer|plasma|starlight|holographic|liquid-light", "")))) {
SetIdx(o_149, 0D, Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)(56D)), ((V)(4D))), ((V)((Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX23, "mirror", ""))) ? "#5a6a7a" : "#1e1a30")))));
{
double i_204 = 0;
i_204 = 0D;
while (true) {
if (!((i_204 < 26D))) break;
Invoke(o_149, "push", Call(pd_53, V.Undef, Call(circ_55, V.Undef, ((V)((ToNum(Call(R_151, V.Undef)) * 80D))), ((V)((ToNum(Call(R_151, V.Undef)) * 56D))), ((V)((0.8 + (ToNum(Call(R_151, V.Undef)) * 1.4))))), GetIdx(NE_26, (i_204 % 6D)), ((V)(0D)), ((V)(0D)), ((V)(0.9))));
i_204++;
}
}
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX24, "plasma|liquid|visualizer", "")))) {
Invoke(o_149, "push", Call(pd_53, V.Undef, ((V)("M0 40Q20 10 40 30T80 20")), ((V)("none")), ((V)("#8f7bff")), ((V)(4D)), ((V)(0.6))), Call(pd_53, V.Undef, ((V)("M0 20Q24 44 50 24T80 40")), ((V)("none")), ((V)("#4fe0d0")), ((V)(3D)), ((V)(0.6))));
}
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX23, "mirror", "")))) {
{
double x_206 = 0;
x_206 = 0D;
while (true) {
if (!((x_206 < 6D))) break;
Invoke(o_149, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((x_206 * 14D)).S(" 0L").N(((x_206 * 14D) + 7D)).S(" 28L").N((x_206 * 14D)).S(" 56").End())), ((V)("none")), ((V)("#c9d8e4")), ((V)(0.8)), ((V)(0.8))));
x_206++;
}
}
}
} else {
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX25, "copper", "")))) {
{
double i_208 = 0;
i_208 = 0D;
while (true) {
if (!((i_208 < 30D))) break;
Invoke(o_149, "push", Call(pd_53, V.Undef, Call(circ_55, V.Undef, ((V)((ToNum(Call(R_151, V.Undef)) * 80D))), ((V)((ToNum(Call(R_151, V.Undef)) * 56D))), ((V)(2.6))), ((V)("#c87a46")), ((V)("#a8643a")), ((V)(0.5)), ((V)(0.6))));
i_208++;
}
}
} else {
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX26, "neon", "")))) {

}
}
}
}
}
}
}
}
}
}
}
}
}
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX27, "neon tube|neon accent", "")))) {
Invoke(o_149, "push", Call(pd_53, V.Undef, ((V)("M0 14H80")), ((V)("none")), ((V)("#ff6ad5")), ((V)(2.4))), Call(pd_53, V.Undef, ((V)("M0 14H80")), ((V)("none")), ((V)("#ffffff")), ((V)(0.8))), Call(pd_53, V.Undef, ((V)("M0 44H80")), ((V)("none")), ((V)("#4fe0d0")), ((V)(2.4))));
}
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX28, "peeling|stain|water-|scuffed|grease|tack|mildew", "")))) {
Invoke(o_149, "push", Call(pd_53, V.Undef, Call(ell_56, V.Undef, ((V)(22D)), ((V)(18D)), ((V)(11D)), ((V)(7D))), ((V)("#8a6a48")), ((V)(0D)), ((V)(0D)), ((V)(0.18))), Call(pd_53, V.Undef, Call(ell_56, V.Undef, ((V)(56D)), ((V)(34D)), ((V)(8D)), ((V)(12D))), ((V)("#8a6a48")), ((V)(0D)), ((V)(0D)), ((V)(0.12))));
if (Truthy(Invoke(NewRegExp(RX29, "peel", ""), "test", L_150))) {
Invoke(o_149, "push", Call(pd_53, V.Undef, ((V)("M62 4Q70 8 66 20L74 22L72 2Z")), ((V)("#f1e8d6")), dk_153, ((V)(1D))));
}
if (Truthy(Invoke(NewRegExp(RX30, "tack", ""), "test", L_150))) {
Invoke(Arr(Arr(((V)(16D)), ((V)(10D))), Arr(((V)(38D)), ((V)(12D))), Arr(((V)(60D)), ((V)(8D))), Arr(((V)(24D)), ((V)(30D)))), "forEach", Fn((V _arrowThis221, int _argc210, V _a212, V _a213, V _a214, V _a215, V[] _rest211) => {
V x_218 = default;
V y_220 = default;
{ V _t216 = ListOf(_a212);
{ V _t217 = GetIdx(_t216, 0D);
x_218 = _t217; }
{ V _t219 = GetIdx(_t216, 1D);
y_220 = _t219; }
}
return Invoke(o_149, "push", Call(pd_53, V.Undef, Call(circ_55, V.Undef, x_218, y_220, ((V)(1.6))), ((V)("#6b5a40")), ((V)(0D)), ((V)(0D)), ((V)(0.5))));
}, 1, "", true));
}
if (Truthy(Invoke(NewRegExp(RX31, "grease", ""), "test", L_150))) {
Invoke(Arr(Arr(((V)(30D)), ((V)(40D))), Arr(((V)(36D)), ((V)(44D))), Arr(((V)(44D)), ((V)(38D)))), "forEach", Fn((V _arrowThis233, int _argc222, V _a224, V _a225, V _a226, V _a227, V[] _rest223) => {
V x_230 = default;
V y_232 = default;
{ V _t228 = ListOf(_a224);
{ V _t229 = GetIdx(_t228, 0D);
x_230 = _t229; }
{ V _t231 = GetIdx(_t228, 1D);
y_232 = _t231; }
}
return Invoke(o_149, "push", Call(pd_53, V.Undef, Call(circ_55, V.Undef, x_230, y_232, ((V)(3D))), ((V)("#a08040")), ((V)(0D)), ((V)(0D)), ((V)(0.25))));
}, 1, "", true));
}
}
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX32, "foil", "")))) {
Invoke(o_149, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(46D)), ((V)(6D)), ((V)(26D)), ((V)(20D)), ((V)(1D))), ((V)("#d5dde2")), ((V)("#9aa1a6")), ((V)(0.6))));
}
if (Truthy(Call(has_57, V.Undef, L_150, NewRegExp(RX33, "hinoki|cedar accent|walnut paneling", "")))) {
InvokeSpread(o_149, "push", new ArrBuilder().Add(Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(52D)), ((V)(0D)), ((V)(28D)), ((V)(56D)), ((V)(0D))), Get(C_147, "w"), ((V)(0D)), ((V)(0D)), ((V)(0.9)))).Spread(Invoke(Arr(((V)(56D)), ((V)(62D)), ((V)(68D)), ((V)(74D))), "map", Fn((V _arrowThis241, int _argc234, V x_240, V _a237, V _a238, V _a239, V[] _rest235) => {
return Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_240).S(" 0V56").End())), ((V)("none")), Call(shade_23, V.Undef, Get(C_147, "w"), ((V)(0.8))), ((V)(0.8)));
}, 1, "", true))).V);
}
Invoke(o_149, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)(56D)), ((V)(4D))), ((V)("none")), Call(shade_23, V.Undef, b0_152, ((V)(0.6))), ((V)(1.2))));
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", o_149).V;
return default;
}, 3, "wallPolys", false);
floorPolys_60 = Fn((V _self242, int _argc243, V n_249, V C_250, V tier_251, V ground_252, V[] _rest244) => {
V o_253 = default;
V L_254 = default;
V R_255 = default;
V T_256 = default;
V px_257 = default;
V P_258 = default;
V f_259 = default;
V dk_260 = default;
V lt_261 = default;
V line_262 = default;
if (_self242.IsNullish) _self242 = GlobalV;
o_253 = Arr();
L_254 = Invoke(n_249, "toLowerCase");
R_255 = Call(rnd_58, V.Undef, n_249);
T_256 = ((V)("M14 0H66L80 56H0Z"));
px_257 = Fn((V _arrowThis271, int _argc263, V u_269, V v_270, V _a267, V _a268, V[] _rest264) => {
return Arr(((V)(((14D - (14D * ToNum(v_270))) + ((52D + (28D * ToNum(v_270))) * ToNum(u_269))))), ((V)((ToNum(v_270) * 56D))));
}, 2, "", true);
P_258 = Fn((V _arrowThis280, int _argc272, V u_278, V v_279, V _a276, V _a277, V[] _rest273) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_25, V.Undef, GetIdx(Call(px_257, V.Undef, u_278, v_279), 0D))).S(" ").V(Call(f1_25, V.Undef, GetIdx(Call(px_257, V.Undef, u_278, v_279), 1D))).End()));
}, 2, "", true);
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX34, "mirror-polished|pristine", "")))) {
V q_281 = default;
V ln_282 = default;
q_281 = Arr(Call(pd_53, V.Undef, T_256, ((V)("#f7f4ef"))));
ln_282 = Fn((V _arrowThis296, int _argc283, V u0_289, V v0_290, V u1_291, V v1_292, V[] _rest284) => {
V c_293 = default;
V w_294 = default;
V op_295 = default;
c_293 = (_argc283 > 4 ? _rest284[0] : V.Undef);
w_294 = (_argc283 > 5 ? _rest284[1] : V.Undef);
op_295 = (_argc283 > 6 ? _rest284[2] : V.Undef);
return Invoke(q_281, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(P_258, V.Undef, u0_289, v0_290)).S("L").V(Call(P_258, V.Undef, u1_291, v1_292)).End())), ((V)("none")), c_293, w_294, op_295));
}, 7, "", true);
{
double u_297 = 0;
u_297 = 1D;
while (true) {
if (!((u_297 < 4D))) break;
Call(ln_282, V.Undef, ((V)((u_297 / 4D))), ((V)(0D)), ((V)((u_297 / 4D))), ((V)(1D)), ((V)("#e6dfd2")), ((V)(0.8)), ((V)(1D)));
u_297++;
}
}
{
double v_299 = 0;
v_299 = 1D;
while (true) {
if (!((v_299 < 3D))) break;
Call(ln_282, V.Undef, ((V)(0D)), ((V)((v_299 / 3D))), ((V)(1D)), ((V)((v_299 / 3D))), ((V)("#e6dfd2")), ((V)(0.8)), ((V)(1D)));
v_299++;
}
}
Call(ln_282, V.Undef, ((V)(0.5)), ((V)(0D)), ((V)(0.5)), ((V)(1D)), GOLD_27, ((V)(1.4)), ((V)(1D)));
Call(ln_282, V.Undef, ((V)(0D)), ((V)(0.5)), ((V)(1D)), ((V)(0.5)), GOLD_27, ((V)(1.4)), ((V)(1D)));
Invoke(q_281, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(P_258, V.Undef, ((V)(0.42)), ((V)(0.42)))).S("L").V(Call(P_258, V.Undef, ((V)(0.58)), ((V)(0.42)))).S("L").V(Call(P_258, V.Undef, ((V)(0.58)), ((V)(0.58)))).S("L").V(Call(P_258, V.Undef, ((V)(0.42)), ((V)(0.58)))).S("Z").End())), ((V)("none")), GOLD_27, ((V)(1.2))));
Invoke(Arr(Arr(((V)(0.18)), ((V)(0.2))), Arr(((V)(0.7)), ((V)(0.3))), Arr(((V)(0.32)), ((V)(0.75))), Arr(((V)(0.82)), ((V)(0.8)))), "forEach", Fn((V _arrowThis312, int _argc301, V _a303, V _a304, V _a305, V _a306, V[] _rest302) => {
V a_313 = default;
V u_309 = default;
V v_311 = default;
{ V _t307 = ListOf(_a303);
{ V _t308 = GetIdx(_t307, 0D);
u_309 = _t308; }
{ V _t310 = GetIdx(_t307, 1D);
v_311 = _t310; }
}
a_313 = Call(px_257, V.Undef, u_309, v_311);
Invoke(q_281, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_25, V.Undef, ((V)((ToNum(GetIdx(a_313, 0D)) - 3D))))).S(" ").V(Call(f1_25, V.Undef, Add(GetIdx(a_313, 1D), ((V)(6D))))).S("l6 -12l2 0l-6 12Z").End())), ((V)("#ffffff")), ((V)(0D)), ((V)(0D)), ((V)(0.7))));
return default;
}, 1, "", true));
Invoke(q_281, "push", Call(pd_53, V.Undef, T_256, ((V)("none")), ((V)("#c9bfae")), ((V)(1.2))));
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", q_281).V;
}
f_259 = (Truthy(Get(C_250, "anyA")) ? Get(C_250, "a") : (Truthy(ground_252) ? ((V)("#93cf70")) : GetIdx(Arr(((V)("#a9a8a2")), ((V)("#d4a56a")), ((V)("#e0c49a")), ((V)("#d8cbb4")), ((V)("#2a2630"))), (ToNum(tier_251) - 1D))));
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX35, "concrete", "")))) {
f_259 = ((V)("#a9a8a2"));
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX36, "dirt|mud", "")))) {
f_259 = ((V)("#a88a5c"));
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX37, "lawn|turf|grass|clover|moss lawn|star-moss", "")))) {
f_259 = ((V)((Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX38, "star|bioluminescent", ""))) ? "#2a3a40" : "#8fcf6a")));
}
if (Truthy((Call(has_57, V.Undef, L_254, NewRegExp(RX39, "carpet|pile|cushion", "")) is var _t314 && !Truthy(_t314) ? _t314 : (!(Truthy(Get(C_250, "anyA"))) ? V.True : V.False)))) {
f_259 = ((V)("#b9ab9a"));
}
Invoke(o_253, "push", Call(pd_53, V.Undef, T_256, f_259));
dk_260 = Call(shade_23, V.Undef, f_259, ((V)(0.8)));
lt_261 = Call(mix_24, V.Undef, f_259, ((V)("#ffffff")), ((V)(0.3)));
line_262 = Fn((V _arrowThis328, int _argc315, V u0_321, V v0_322, V u1_323, V v1_324, V[] _rest316) => {
V c_325 = default;
V w_326 = default;
V op_327 = default;
c_325 = (_argc315 > 4 ? _rest316[0] : V.Undef);
w_326 = (_argc315 > 5 ? _rest316[1] : V.Undef);
op_327 = (_argc315 > 6 ? _rest316[2] : V.Undef);
return Invoke(o_253, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(P_258, V.Undef, u0_321, v0_322)).S("L").V(Call(P_258, V.Undef, u1_323, v1_324)).End())), ((V)("none")), c_325, w_326, op_327));
}, 7, "", true);
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX40, "checker|checkerboard|vinyl tile|moss-inlaid", "")))) {
{
double v_329 = 0;
v_329 = 0D;
while (true) {
if (!((v_329 < 5D))) break;
{
double u_331 = 0;
u_331 = 0D;
while (true) {
if (!((u_331 < 6D))) break;
if (NumTruthy(((u_331 + v_329) % 2D))) {
Invoke(o_253, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(P_258, V.Undef, ((V)((u_331 / 6D))), ((V)((v_329 / 5D))))).S("L").V(Call(P_258, V.Undef, ((V)(((u_331 + 1D) / 6D))), ((V)((v_329 / 5D))))).S("L").V(Call(P_258, V.Undef, ((V)(((u_331 + 1D) / 6D))), ((V)(((v_329 + 1D) / 5D))))).S("L").V(Call(P_258, V.Undef, ((V)((u_331 / 6D))), ((V)(((v_329 + 1D) / 5D))))).S("Z").End())), (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX41, "moss", ""))) ? ((V)("#6f8f4a")) : (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX4, "black", ""))) ? ((V)("#2c2d31")) : dk_260)), ((V)(0D)), ((V)(0D)), ((V)(0.9))));
}
u_331++;
}
}
v_329++;
}
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX42, "peeling", "")))) {
Invoke(o_253, "push", Call(pd_53, V.Undef, Call(ell_56, V.Undef, ((V)(54D)), ((V)(40D)), ((V)(7D)), ((V)(3D))), ((V)("#c9c2b2")), ((V)(0D)), ((V)(0D)), ((V)(0.9))));
}
} else {
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX43, "light-up|disco squares|rgb matrix|interactive|haptic|levitation|glass flooring|led guides|footstep glow", "")))) {
{
double v_333 = 0;
v_333 = 0D;
while (true) {
if (!((v_333 < 4D))) break;
{
double u_335 = 0;
u_335 = 0D;
while (true) {
if (!((u_335 < 5D))) break;
Invoke(o_253, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(P_258, V.Undef, ((V)(((u_335 / 5D) + 0.01))), ((V)(((v_333 / 4D) + 0.02))))).S("L").V(Call(P_258, V.Undef, ((V)((((u_335 + 1D) / 5D) - 0.01))), ((V)(((v_333 / 4D) + 0.02))))).S("L").V(Call(P_258, V.Undef, ((V)((((u_335 + 1D) / 5D) - 0.01))), ((V)((((v_333 + 1D) / 4D) - 0.02))))).S("L").V(Call(P_258, V.Undef, ((V)(((u_335 / 5D) + 0.01))), ((V)((((v_333 + 1D) / 4D) - 0.02))))).S("Z").End())), GetIdx(NE_26, (((u_335 * 3D) + (v_333 * 2D)) % 6D)), ((V)(0D)), ((V)(0D)), ((V)((Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX44, "guides|footstep", ""))) ? 0.12 : 0.75)))));
u_335++;
}
}
v_333++;
}
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX45, "guides", "")))) {
Invoke(Arr(((V)(0.2)), ((V)(0.8))), "forEach", Fn((V _arrowThis344, int _argc337, V u_343, V _a340, V _a341, V _a342, V[] _rest338) => {
return Call(line_262, V.Undef, u_343, ((V)(0D)), u_343, ((V)(1D)), ((V)("#ffe9a0")), ((V)(1.6)), ((V)(0.9)));
}, 1, "", true));
}
} else {
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX46, "herringbone|chevron|parquet", "")))) {
{
double v_345 = 0;
v_345 = 0D;
while (true) {
if (!((v_345 < 6D))) break;
JsStrBuf d_347 = null;
d_347 = new JsStrBuf("");
{
double u_348 = 0;
u_348 = 0D;
while (true) {
if (!((u_348 <= 8D))) break;
d_347.S((NumTruthy(u_348) ? "L" : "M")).V(Call(P_258, V.Undef, ((V)((u_348 / 8D))), ((V)(((v_345 + ((u_348 % 2D) * 0.7)) / 6D)))));
u_348++;
}
}
Invoke(o_253, "push", Call(pd_53, V.Undef, ((V)(d_347.Str)), ((V)("none")), dk_260, ((V)(1.4)), ((V)(0.8))));
v_345++;
}
}
} else {
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX47, "plank|oak|teak|hardwood|subfloor|laminate|ash|wood|duckboard", "")))) {
{
double u_350 = 0;
u_350 = 1D;
while (true) {
if (!((u_350 < 7D))) break;
Call(line_262, V.Undef, ((V)((u_350 / 7D))), ((V)(0D)), ((V)((u_350 / 7D))), ((V)(1D)), dk_260, ((V)(1.1)), ((V)(0.8)));
u_350++;
}
}
{
double i_352 = 0;
i_352 = 0D;
while (true) {
if (!((i_352 < 6D))) break;
double u_354 = 0;
V v_355 = default;
u_354 = ((i_352 + 0.5) / 7D);
v_355 = Call(R_255, V.Undef);
Call(line_262, V.Undef, ((V)((u_354 - 0.07))), v_355, ((V)((u_354 + 0.07))), v_355, dk_260, ((V)(0.8)), ((V)(0.6)));
i_352++;
}
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX48, "splintery|cold", "")))) {
Invoke(o_253, "push", Call(pd_53, V.Undef, Call(ell_56, V.Undef, ((V)(50D)), ((V)(30D)), ((V)(6D)), ((V)(2D))), ((V)("#8a6a48")), ((V)(0D)), ((V)(0D)), ((V)(0.3))));
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX49, "plush perimeter", "")))) {
Invoke(o_253, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(P_258, V.Undef, ((V)(0D)), ((V)(0.75)))).S("L").V(Call(P_258, V.Undef, ((V)(1D)), ((V)(0.75)))).S("L").V(Call(P_258, V.Undef, ((V)(1D)), ((V)(1D)))).S("L").V(Call(P_258, V.Undef, ((V)(0D)), ((V)(1D)))).S("Z").End())), ((V)("#e8dcc8")), ((V)(0D)), ((V)(0D)), ((V)(0.9))));
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX50, "pebble", "")))) {

}
} else {
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX51, "hex|porcelain|terrazzo|quarry|tile|linoleum|vinyl", "")))) {
{
double u_356 = 0;
u_356 = 1D;
while (true) {
if (!((u_356 < 6D))) break;
Call(line_262, V.Undef, ((V)((u_356 / 6D))), ((V)(0D)), ((V)((u_356 / 6D))), ((V)(1D)), dk_260, ((V)(0.9)), ((V)(0.7)));
u_356++;
}
}
{
double v_358 = 0;
v_358 = 1D;
while (true) {
if (!((v_358 < 5D))) break;
Call(line_262, V.Undef, ((V)(0D)), ((V)((v_358 / 5D))), ((V)(1D)), ((V)((v_358 / 5D))), dk_260, ((V)(0.9)), ((V)(0.7)));
v_358++;
}
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX52, "terrazzo", "")))) {
{
double i_360 = 0;
i_360 = 0D;
while (true) {
if (!((i_360 < 24D))) break;
V q_362 = default;
q_362 = Call(px_257, V.Undef, Call(R_255, V.Undef), Call(R_255, V.Undef));
Invoke(o_253, "push", Call(pd_53, V.Undef, Call(circ_55, V.Undef, GetIdx(q_362, 0D), GetIdx(q_362, 1D), ((V)(1.2))), GetIdx(NE_26, (i_360 % 6D)), ((V)(0D)), ((V)(0D)), ((V)(0.5))));
i_360++;
}
}
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX53, "cracked|curled|scuffed", "")))) {
Invoke(o_253, "push", Call(pd_53, V.Undef, ((V)("M20 20L30 30L26 40")), ((V)("none")), ((V)("#6a6a5a")), ((V)(1D))), Call(pd_53, V.Undef, ((V)("M66 4L72 10L64 12Z")), ((V)("#c9c2b2"))));
}
} else {
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX50, "pebble", "")))) {
{
double i_363 = 0;
i_363 = 0D;
while (true) {
if (!((i_363 < 30D))) break;
V q_365 = default;
q_365 = Call(px_257, V.Undef, Call(R_255, V.Undef), Call(R_255, V.Undef));
Invoke(o_253, "push", Call(pd_53, V.Undef, Call(ell_56, V.Undef, GetIdx(q_365, 0D), GetIdx(q_365, 1D), ((V)(3D)), ((V)(1.8))), ((V)((NumTruthy((i_363 % 2D)) ? "#c9c2b6" : "#9a948a"))), ((V)(0D)), ((V)(0D)), ((V)(0.9))));
i_363++;
}
}
} else {
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX54, "marble|stone|basalt|onyx|quartz|slab|travertine|paver|flagstone", "")))) {
Call(line_262, V.Undef, ((V)(0.5)), ((V)(0D)), ((V)(0.5)), ((V)(1D)), dk_260, ((V)(1.2)), ((V)(0.7)));
Call(line_262, V.Undef, ((V)(0D)), ((V)(0.45)), ((V)(1D)), ((V)(0.45)), dk_260, ((V)(1.2)), ((V)(0.7)));
Invoke(o_253, "push", Call(pd_53, V.Undef, ((V)("M10 40Q24 32 38 42")), ((V)("none")), (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX55, "gold", ""))) ? GOLD_27 : lt_261), ((V)(1.4)), ((V)(0.8))));
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX56, "gold vein|illumination", "")))) {
Invoke(o_253, "push", Call(pd_53, V.Undef, ((V)("M44 10Q56 20 70 16")), ((V)("none")), GOLD_27, ((V)(1.4))));
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX57, "drain", "")))) {
Call(line_262, V.Undef, ((V)(0.1)), ((V)(0.8)), ((V)(0.9)), ((V)(0.8)), GOLD_27, ((V)(2D)), ((V)(1D)));
}
} else {
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX58, "carpet|pile|loop", "")))) {
{
double i_366 = 0;
i_366 = 0D;
while (true) {
if (!((i_366 < 70D))) break;
V q_368 = default;
q_368 = Call(px_257, V.Undef, Call(R_255, V.Undef), Call(R_255, V.Undef));
Invoke(o_253, "push", Call(pd_53, V.Undef, Call(circ_55, V.Undef, GetIdx(q_368, 0D), GetIdx(q_368, 1D), ((V)(0.8))), (NumTruthy((i_366 % 2D)) ? dk_260 : lt_261), ((V)(0D)), ((V)(0D)), ((V)(0.6))));
i_366++;
}
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX59, "aisle", "")))) {
Invoke(Arr(((V)(0.25)), ((V)(0.75))), "forEach", Fn((V _arrowThis376, int _argc369, V u_375, V _a372, V _a373, V _a374, V[] _rest370) => {
return Call(line_262, V.Undef, u_375, ((V)(0D)), u_375, ((V)(1D)), ((V)("#e2b14a")), ((V)(1.6)), ((V)(0.9)));
}, 1, "", true));
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX60, "tiles", "")))) {
Call(line_262, V.Undef, ((V)(0.5)), ((V)(0D)), ((V)(0.5)), ((V)(1D)), dk_260, ((V)(0.8)), ((V)(0.6)));
Call(line_262, V.Undef, ((V)(0D)), ((V)(0.5)), ((V)(1D)), ((V)(0.5)), dk_260, ((V)(0.8)), ((V)(0.6)));
}
} else {
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX61, "cardboard", "")))) {
Invoke(o_253, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(P_258, V.Undef, ((V)(0.2)), ((V)(0.2)))).S("L").V(Call(P_258, V.Undef, ((V)(0.8)), ((V)(0.2)))).S("L").V(Call(P_258, V.Undef, ((V)(0.8)), ((V)(0.85)))).S("L").V(Call(P_258, V.Undef, ((V)(0.2)), ((V)(0.85)))).S("Z").End())), ((V)("#c49a62")), ((V)("#8a6a42")), ((V)(0.8))), Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(P_258, V.Undef, ((V)(0.2)), ((V)(0.5)))).S("L").V(Call(P_258, V.Undef, ((V)(0.8)), ((V)(0.5)))).End())), ((V)("none")), ((V)("#d8c8a0")), ((V)(3D))));
}
}
}
}
}
}
}
}
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX35, "concrete", "")))) {
{
double i_377 = 0;
i_377 = 0D;
while (true) {
if (!((i_377 < 20D))) break;
V q_379 = default;
q_379 = Call(px_257, V.Undef, Call(R_255, V.Undef), Call(R_255, V.Undef));
Invoke(o_253, "push", Call(pd_53, V.Undef, Call(circ_55, V.Undef, GetIdx(q_379, 0D), GetIdx(q_379, 1D), ((V)(0.7))), dk_260, ((V)(0D)), ((V)(0D)), ((V)(0.6))));
i_377++;
}
}
Invoke(o_253, "push", Call(pd_53, V.Undef, ((V)("M30 10L36 24L32 34L40 50")), ((V)("none")), Call(shade_23, V.Undef, f_259, ((V)(0.6))), ((V)(1D))));
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX62, "duct-tape|cables", "")))) {
Invoke(o_253, "push", Call(pd_53, V.Undef, ((V)("M4 40Q30 30 50 44T80 36")), ((V)("none")), ((V)("#2c2d31")), ((V)(1.6))), Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(30D)), ((V)(32D)), ((V)(10D)), ((V)(4D)), ((V)(1D))), ((V)("#b9bcbf"))));
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX63, "lawn|turf|grass|clover|ryegrass", "")))) {
{
double i_380 = 0;
i_380 = 0D;
while (true) {
if (!((i_380 < 22D))) break;
V q_382 = default;
q_382 = Call(px_257, V.Undef, Call(R_255, V.Undef), Call(R_255, V.Undef));
Invoke(o_253, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_25, V.Undef, GetIdx(q_382, 0D))).S(" ").V(Call(f1_25, V.Undef, GetIdx(q_382, 1D))).S("l-1.4 -4M").V(Call(f1_25, V.Undef, Add(GetIdx(q_382, 0D), ((V)(2D))))).S(" ").V(Call(f1_25, V.Undef, GetIdx(q_382, 1D))).S("l1 -4.4").End())), ((V)("none")), dk_260, ((V)(1D)), ((V)(0.8))));
i_380++;
}
}
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX64, "clover", "")))) {
Invoke(Arr(Arr(((V)(30D)), ((V)(30D))), Arr(((V)(52D)), ((V)(44D))), Arr(((V)(20D)), ((V)(46D)))), "forEach", Fn((V _arrowThis394, int _argc383, V _a385, V _a386, V _a387, V _a388, V[] _rest384) => {
V x_391 = default;
V y_393 = default;
{ V _t389 = ListOf(_a385);
{ V _t390 = GetIdx(_t389, 0D);
x_391 = _t390; }
{ V _t392 = GetIdx(_t389, 1D);
y_393 = _t392; }
}
return Invoke(o_253, "push", Call(pd_53, V.Undef, Call(circ_55, V.Undef, x_391, y_393, ((V)(2D))), ((V)("#fffaf1"))), Call(pd_53, V.Undef, Call(circ_55, V.Undef, Add(x_391, ((V)(3D))), y_393, ((V)(2D))), ((V)("#fffaf1"))));
}, 1, "", true));
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX65, "stepping|flagstone", "")))) {
Invoke(Arr(Arr(((V)(0.4)), ((V)(0.15))), Arr(((V)(0.55)), ((V)(0.45))), Arr(((V)(0.4)), ((V)(0.8)))), "forEach", Fn((V _arrowThis406, int _argc395, V _a397, V _a398, V _a399, V _a400, V[] _rest396) => {
V q_407 = default;
V u_403 = default;
V v_405 = default;
{ V _t401 = ListOf(_a397);
{ V _t402 = GetIdx(_t401, 0D);
u_403 = _t402; }
{ V _t404 = GetIdx(_t401, 1D);
v_405 = _t404; }
}
q_407 = Call(px_257, V.Undef, u_403, v_405);
Invoke(o_253, "push", Call(pd_53, V.Undef, Call(ell_56, V.Undef, GetIdx(q_407, 0D), GetIdx(q_407, 1D), ((V)((8D + (ToNum(v_405) * 4D)))), ((V)((3D + (ToNum(v_405) * 2D))))), ((V)("#c9c2b6")), ((V)("#9a948a")), ((V)(0.8))));
return default;
}, 1, "", true));
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX66, "puddle|patchy|crabgrass", "")))) {
Invoke(o_253, "push", Call(pd_53, V.Undef, Call(ell_56, V.Undef, ((V)(48D)), ((V)(38D)), ((V)(12D)), ((V)(4D))), ((V)("#8fb8c8")), ((V)(0D)), ((V)(0D)), ((V)(0.8))), Call(pd_53, V.Undef, Call(ell_56, V.Undef, ((V)(24D)), ((V)(20D)), ((V)(9D)), ((V)(4D))), ((V)("#93b86a")), ((V)(0D)), ((V)(0D)), ((V)(0.9))));
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX67, "star-moss|bioluminescent", "")))) {
{
double i_408 = 0;
i_408 = 0D;
while (true) {
if (!((i_408 < 26D))) break;
V q_410 = default;
q_410 = Call(px_257, V.Undef, Call(R_255, V.Undef), Call(R_255, V.Undef));
Invoke(o_253, "push", Call(pd_53, V.Undef, Call(circ_55, V.Undef, GetIdx(q_410, 0D), GetIdx(q_410, 1D), Add(((V)(1D)), Call(R_255, V.Undef))), ((V)((NumTruthy((i_408 % 2D)) ? "#7af0d0" : "#ffe9a0"))), ((V)(0D)), ((V)(0D)), ((V)(0.9))));
i_408++;
}
}
}
if (Truthy(Call(has_57, V.Undef, L_254, NewRegExp(RX68, "porcelain patio|heated porcelain", "")))) {
Invoke(o_253, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(P_258, V.Undef, ((V)(0.55)), ((V)(0D)))).S("L").V(Call(P_258, V.Undef, ((V)(1D)), ((V)(0D)))).S("L").V(Call(P_258, V.Undef, ((V)(1D)), ((V)(1D)))).S("L").V(Call(P_258, V.Undef, ((V)(0.6)), ((V)(1D)))).S("Z").End())), ((V)("#e6e1d6")), ((V)(0D)), ((V)(0D)), ((V)(0.95))));
}
Invoke(o_253, "push", Call(pd_53, V.Undef, T_256, ((V)("none")), Call(shade_23, V.Undef, f_259, ((V)(0.6))), ((V)(1.2))));
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", o_253).V;
return default;
}, 4, "floorPolys", false);
ceilPolys_61 = Fn((V _self411, int _argc412, V n_418, V C_419, V tier_420, V _a417, V[] _rest413) => {
V o_421 = default;
V L_422 = default;
V R_423 = default;
V c_424 = default;
V top_425 = default;
V wl_426 = default;
V dk_427 = default;
V lt_428 = default;
V L0_429 = default;
if (_self411.IsNullish) _self411 = GlobalV;
o_421 = Arr();
L_422 = Invoke(n_418, "toLowerCase");
R_423 = Call(rnd_58, V.Undef, n_418);
c_424 = (Truthy(Get(C_419, "anyA")) ? Get(C_419, "a") : GetIdx(Arr(((V)("#d8d0c0")), ((V)("#f4f1ea")), ((V)("#c99a6a")), ((V)("#f4efe2")), ((V)("#1e1a30"))), (ToNum(tier_420) - 1D)));
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX69, "pipes|rafters|basement", "")))) {
c_424 = ((V)("#8a7a66"));
}
if (Truthy((Call(has_57, V.Undef, L_422, NewRegExp(RX70, "black painted|night sky|space|dome|vault|immersion|aurora", "")) is var _t430 && !Truthy(_t430) ? _t430 : (!(Truthy(Invoke(NewRegExp(RX71, "glass atrium|steam-dome", ""), "test", L_422))) ? V.True : V.False)))) {
c_424 = ((V)("#1e1a30"));
}
top_425 = ((V)("M0 0H80L64 26H16Z"));
wl_426 = Call(mix_24, V.Undef, c_424, ((V)("#e8e0d0")), ((V)(0.6)));
Invoke(o_421, "push", Call(pd_53, V.Undef, ((V)("M16 26H64V56H16Z")), wl_426), Call(pd_53, V.Undef, ((V)("M0 0L16 26V56H0Z")), Call(shade_23, V.Undef, wl_426, ((V)(0.9)))), Call(pd_53, V.Undef, ((V)("M80 0L64 26V56H80Z")), Call(shade_23, V.Undef, wl_426, ((V)(0.85)))), Call(pd_53, V.Undef, top_425, c_424));
dk_427 = Call(shade_23, V.Undef, c_424, ((V)(0.75)));
lt_428 = Call(mix_24, V.Undef, c_424, ((V)("#ffffff")), ((V)(0.35)));
L0_429 = Fn((V _arrowThis441, int _argc431, V d_437, V col_438, V w_439, V op_440, V[] _rest432) => {
return Invoke(o_421, "push", Call(pd_53, V.Undef, d_437, ((V)("none")), col_438, w_439, op_440));
}, 4, "", true);
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX72, "beam|rafter|coffer|shiplap", "")))) {
Invoke(Arr(((V)(0.2)), ((V)(0.4)), ((V)(0.6)), ((V)(0.8))), "forEach", Fn((V _arrowThis449, int _argc442, V t_448, V _a445, V _a446, V _a447, V[] _rest443) => {
return Invoke(o_421, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_25, V.Undef, ((V)((ToNum(t_448) * 80D))))).S(" 0L").V(Call(f1_25, V.Undef, ((V)((16D + (ToNum(t_448) * 48D)))))).S(" 26").End())), ((V)("none")), (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX73, "dark wood|cedar|beam", ""))) ? ((V)("#7a4a28")) : dk_427), ((V)((Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX74, "coffer|beam", ""))) ? 3.6 : 1.4)))));
}, 1, "", true));
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX75, "coffer|mirror", "")))) {
Invoke(Arr(((V)(8D)), ((V)(17D))), "forEach", Fn((V _arrowThis457, int _argc450, V y_456, V _a453, V _a454, V _a455, V[] _rest451) => {
return Call(L0_429, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_25, V.Undef, ((V)(((16D * ToNum(y_456)) / 26D))))).S(" ").V(y_456).S("H").V(Call(f1_25, V.Undef, ((V)((80D - ((16D * ToNum(y_456)) / 26D)))))).End())), dk_427, ((V)(3D)));
}, 1, "", true));
}
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX76, "pipes", "")))) {
Call(L0_429, V.Undef, ((V)("M0 6H80")), ((V)("#9aa1a6")), ((V)(3.4)));
Call(L0_429, V.Undef, ((V)("M0 14H80")), ((V)("#b07a50")), ((V)(2.6)));
Call(L0_429, V.Undef, ((V)("M40 6V22")), ((V)("#9aa1a6")), ((V)(2D)));
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX77, "cobweb", "")))) {
Invoke(o_421, "push", Call(pd_53, V.Undef, ((V)("M0 0L12 0Q8 6 0 10Z")), ((V)("none")), ((V)("#fffaf1")), ((V)(0.6))), Call(pd_53, V.Undef, ((V)("M2 0L6 8M0 4L10 3")), ((V)("none")), ((V)("#fffaf1")), ((V)(0.5))));
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX78, "popcorn|stucco|water-spotted|stained|peeling", "")))) {
{
double i_458 = 0;
i_458 = 0D;
while (true) {
if (!((i_458 < 40D))) break;
double x_460 = 0;
double y_461 = 0;
x_460 = (6D + (ToNum(Call(R_423, V.Undef)) * 68D));
y_461 = (ToNum(Call(R_423, V.Undef)) * 24D);
if (((x_460 > (((16D * y_461) / 26D) + 2D)) && (x_460 < ((80D - ((16D * y_461) / 26D)) - 2D)))) {
Invoke(o_421, "push", Call(pd_53, V.Undef, Call(circ_55, V.Undef, ((V)(x_460)), ((V)(y_461)), ((V)(0.7))), dk_427, ((V)(0D)), ((V)(0D)), ((V)(0.6))));
}
i_458++;
}
}
Invoke(o_421, "push", Call(pd_53, V.Undef, Call(ell_56, V.Undef, ((V)(54D)), ((V)(10D)), ((V)(8D)), ((V)(3D))), ((V)("#a08a60")), ((V)(0D)), ((V)(0D)), ((V)(0.3))));
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX79, "acoustic|drop-tile|pvc|foam", "")))) {
Invoke(Arr(((V)(0.25)), ((V)(0.5)), ((V)(0.75))), "forEach", Fn((V _arrowThis469, int _argc462, V t_468, V _a465, V _a466, V _a467, V[] _rest463) => {
return Call(L0_429, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_25, V.Undef, ((V)((ToNum(t_468) * 80D))))).S(" 0L").V(Call(f1_25, V.Undef, ((V)((16D + (ToNum(t_468) * 48D)))))).S(" 26").End())), dk_427, ((V)(0.8)));
}, 1, "", true));
Invoke(Arr(((V)(9D)), ((V)(18D))), "forEach", Fn((V _arrowThis477, int _argc470, V y_476, V _a473, V _a474, V _a475, V[] _rest471) => {
return Call(L0_429, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_25, V.Undef, ((V)(((16D * ToNum(y_476)) / 26D))))).S(" ").V(y_476).S("H").V(Call(f1_25, V.Undef, ((V)((80D - ((16D * ToNum(y_476)) / 26D)))))).End())), dk_427, ((V)(0.8)));
}, 1, "", true));
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX80, "star|night sky|fiber-optic|space|nebula|aurora|immersion|halo rig|laser", "")))) {
{
double i_478 = 0;
i_478 = 0D;
while (true) {
if (!((i_478 < 26D))) break;
double y_480 = 0;
double x_481 = 0;
y_480 = (ToNum(Call(R_423, V.Undef)) * 24D);
x_481 = (((16D * y_480) / 26D) + (ToNum(Call(R_423, V.Undef)) * (80D - ((32D * y_480) / 26D))));
Invoke(o_421, "push", Call(pd_53, V.Undef, Call(circ_55, V.Undef, ((V)(x_481)), ((V)(y_480)), ((V)((0.6 + (ToNum(Call(R_423, V.Undef)) * 0.9))))), (NumTruthy((i_478 % 5D)) ? ((V)("#fffbe0")) : GetIdx(NE_26, (i_478 % 6D))), ((V)(0D)), ((V)(0D)), ((V)(0.95))));
i_478++;
}
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX81, "aurora|nebula", "")))) {
Call(L0_429, V.Undef, ((V)("M6 6Q30 20 50 8T76 10")), ((V)("#7ae8c8")), ((V)(4D)), ((V)(0.55)));
Call(L0_429, V.Undef, ((V)("M10 14Q34 4 60 16")), ((V)("#b48cff")), ((V)(3D)), ((V)(0.5)));
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX82, "laser|halo", "")))) {
Invoke(o_421, "push", Call(pd_53, V.Undef, Call(ell_56, V.Undef, ((V)(40D)), ((V)(13D)), ((V)(16D)), ((V)(4D))), ((V)("none")), ((V)("#ff6ad5")), ((V)(1.4))), Call(pd_53, V.Undef, Call(ell_56, V.Undef, ((V)(40D)), ((V)(13D)), ((V)(10D)), ((V)(2.4))), ((V)("none")), ((V)("#4fe0d0")), ((V)(1.2))));
}
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX83, "fan", "")))) {
Invoke(o_421, "push", Call(pd_53, V.Undef, Call(circ_55, V.Undef, ((V)(40D)), ((V)(14D)), ((V)(2.4))), ((V)("#9aa1a6"))));
Invoke(Arr(Arr(((V)((-16D))), ((V)((-2D)))), Arr(((V)(12D)), ((V)((-4D)))), Arr(((V)(4D)), ((V)(6D)))), "forEach", Fn((V _arrowThis493, int _argc482, V _a484, V _a485, V _a486, V _a487, V[] _rest483) => {
V dx_490 = default;
V dy_492 = default;
{ V _t488 = ListOf(_a484);
{ V _t489 = GetIdx(_t488, 0D);
dx_490 = _t489; }
{ V _t491 = GetIdx(_t488, 1D);
dy_492 = _t491; }
}
return Invoke(o_421, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M40 14L").V(Add(((V)(40D)), dx_490)).S(" ").V(Add(((V)(14D)), dy_492)).S("l3 3Z").End())), ((V)("#d4a56a")), ((V)("#a87a48")), ((V)(0.6))));
}, 1, "", true));
}
if (Truthy((Call(has_57, V.Undef, L_422, NewRegExp(RX84, "exhaust|vent|hood|fan", "")) is var _t494 && !Truthy(_t494) ? _t494 : (!(Truthy(Invoke(NewRegExp(RX85, "paddle", ""), "test", L_422))) ? V.True : V.False)))) {
Invoke(o_421, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(32D)), ((V)(6D)), ((V)(16D)), ((V)(10D)), ((V)(1D))), ((V)("#c9d3d8")), ((V)("#8a949a")), ((V)(0.8))), Call(pd_53, V.Undef, ((V)("M34 9H46M34 12H46")), ((V)("none")), ((V)("#8a949a")), ((V)(0.8))));
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX86, "range hood|chimney|canopy range|hood", "")))) {
Invoke(o_421, "push", Call(pd_53, V.Undef, ((V)("M30 26L34 34H46L50 26Z")), ((V)((Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX88, "brass", ""))) ? "#d4a548" : (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX87, "plaster", ""))) ? "#ece2d0" : "#c9d3d8")))), ((V)("#8a949a")), ((V)(0.8))), Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(37D)), ((V)(18D)), ((V)(6D)), ((V)(9D)), ((V)(0D))), ((V)((Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX88, "brass", ""))) ? "#d4a548" : "#c9d3d8")))));
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX89, "pot lights|recessed|cove|tray|led vent|chromotherapy", "")))) {
Invoke(Arr(Arr(((V)(26D)), ((V)(8D))), Arr(((V)(40D)), ((V)(8D))), Arr(((V)(54D)), ((V)(8D))), Arr(((V)(32D)), ((V)(18D))), Arr(((V)(48D)), ((V)(18D)))), "forEach", Fn((V _arrowThis506, int _argc495, V _a497, V _a498, V _a499, V _a500, V[] _rest496) => {
V x_503 = default;
V y_505 = default;
{ V _t501 = ListOf(_a497);
{ V _t502 = GetIdx(_t501, 0D);
x_503 = _t502; }
{ V _t504 = GetIdx(_t501, 1D);
y_505 = _t504; }
}
return Invoke(o_421, "push", Call(pd_53, V.Undef, Call(ell_56, V.Undef, x_503, y_505, ((V)(2.6)), ((V)(1.2))), ((V)("#fff2b0"))));
}, 1, "", true));
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX90, "cove|tray", "")))) {
Invoke(o_421, "push", Call(pd_53, V.Undef, ((V)("M10 4H70L58 22H22Z")), ((V)("none")), ((V)("#ffd88a")), ((V)(1.6)), ((V)(0.8))));
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX91, "chromo", "")))) {
Invoke(o_421, "push", Call(pd_53, V.Undef, Call(ell_56, V.Undef, ((V)(40D)), ((V)(13D)), ((V)(14D)), ((V)(4D))), ((V)("none")), ((V)("#8f7bff")), ((V)(2D))));
}
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX92, "skylight|atrium|glass|sky-vault", "")))) {
Invoke(o_421, "push", Call(pd_53, V.Undef, ((V)("M24 4H56L50 18H30Z")), ((V)("url(#hsSky)")), ((V)("#c9d3d8")), ((V)(1D))), Call(pd_53, V.Undef, ((V)("M40 4V18M27 11H53")), ((V)("none")), ((V)("#c9d3d8")), ((V)(1D))));
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX93, "medallion|crown|molding|cove molding", "")))) {
Invoke(o_421, "push", Call(pd_53, V.Undef, ((V)("M0 0H80L77 4H3Z")), ((V)("#fffaf1")), ((V)("#d8cbb4")), ((V)(0.6))), Call(pd_53, V.Undef, Call(circ_55, V.Undef, ((V)(40D)), ((V)(13D)), ((V)(6D))), ((V)("#fffaf1")), ((V)("#d8cbb4")), ((V)(0.8))), Call(pd_53, V.Undef, Call(circ_55, V.Undef, ((V)(40D)), ((V)(13D)), ((V)(3D))), ((V)("none")), ((V)("#d8cbb4")), ((V)(0.8))));
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX94, "steam-dome|rain-cloud|mist", "")))) {
Invoke(o_421, "push", Call(pd_53, V.Undef, Call(ell_56, V.Undef, ((V)(30D)), ((V)(12D)), ((V)(12D)), ((V)(5D))), ((V)("#ffffff")), ((V)(0D)), ((V)(0D)), ((V)(0.9))), Call(pd_53, V.Undef, Call(ell_56, V.Undef, ((V)(50D)), ((V)(10D)), ((V)(14D)), ((V)(6D))), ((V)("#f4f8fb")), ((V)(0D)), ((V)(0D)), ((V)(0.9))), Call(pd_53, V.Undef, ((V)("M30 18v6M40 20v6M50 18v6")), ((V)("none")), ((V)("#9fd2f2")), ((V)(1D)), ((V)(0.8))));
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX95, "truss", "")))) {
Call(L0_429, V.Undef, ((V)("M8 8H72")), ((V)("#9aa1a6")), ((V)(2D)));
Call(L0_429, V.Undef, ((V)("M10 12H70")), ((V)("#9aa1a6")), ((V)(2D)));
{
double x_507 = 0;
x_507 = 10D;
while (true) {
if (!((x_507 < 70D))) break;
Call(L0_429, V.Undef, ((V)(JsStrBuf.Begin().S("M").N(x_507).S(" 8L").N((x_507 + 3D)).S(" 12").End())), ((V)("#9aa1a6")), ((V)(1D)));
x_507 = (x_507 + 6D);
}
}
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX96, "christmas|kinetic triangle|led ceiling", "")))) {
{
double i_509 = 0;
i_509 = 0D;
while (true) {
if (!((i_509 < 10D))) break;
Invoke(o_421, "push", Call(pd_53, V.Undef, Call(circ_55, V.Undef, ((V)((10D + (i_509 * 6.6)))), ((V)((6D + (FdLibm.Sin(i_509) * 2D)))), ((V)(1.6))), GetIdx(NE_26, (i_509 % 6D))));
i_509++;
}
}
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX97, "disco", "")))) {
Invoke(Arr(Arr(((V)(30D)), ((V)(14D))), Arr(((V)(52D)), ((V)(12D)))), "forEach", Fn((V _arrowThis522, int _argc511, V _a513, V _a514, V _a515, V _a516, V[] _rest512) => {
V x_519 = default;
V y_521 = default;
{ V _t517 = ListOf(_a513);
{ V _t518 = GetIdx(_t517, 0D);
x_519 = _t518; }
{ V _t520 = GetIdx(_t517, 1D);
y_521 = _t520; }
}
return Invoke(o_421, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_519).S(" 0V").N((ToNum(y_521) - 4D)).End())), ((V)("none")), ((V)("#9aa1a6")), ((V)(0.6))), Call(pd_53, V.Undef, Call(circ_55, V.Undef, x_519, y_521, ((V)(4.4))), ((V)("url(#dBall)")), ((V)("#6c72a8")), ((V)(0.6))));
}, 1, "", true));
}
if (Truthy(Call(has_57, V.Undef, L_422, NewRegExp(RX98, "triangle", "")))) {
{
double i_523 = 0;
i_523 = 0D;
while (true) {
if (!((i_523 < 6D))) break;
Invoke(o_421, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((12D + (i_523 * 10D))).S(" 4l5 8h-10Z").End())), GetIdx(NE_26, (i_523 % 6D)), ((V)(0D)), ((V)(0D)), ((V)(0.7))));
i_523++;
}
}
}
Invoke(o_421, "push", Call(pd_53, V.Undef, top_425, ((V)("none")), Call(shade_23, V.Undef, c_424, ((V)(0.6))), ((V)(1D))), Call(pd_53, V.Undef, ((V)("M16 26H64V56H16Z")), ((V)("none")), Call(shade_23, V.Undef, wl_426, ((V)(0.7))), ((V)(0.8))));
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", o_421).V;
return default;
}, 3, "ceilPolys", false);
fencePolys_62 = Fn((V _self525, int _argc526, V n_532, V C_533, V tier_534, V _a531, V[] _rest527) => {
V o_535 = default;
V L_536 = default;
if (_self525.IsNullish) _self525 = GlobalV;
o_535 = Arr();
L_536 = Invoke(n_532, "toLowerCase");
if (Truthy(Call(has_57, V.Undef, L_536, NewRegExp(RX99, "chain-link", "")))) {
JsStrBuf d_537 = null;
Invoke(Arr(((V)(4D)), ((V)(40D)), ((V)(76D))), "forEach", Fn((V _arrowThis545, int _argc538, V x_544, V _a541, V _a542, V _a543, V[] _rest539) => {
return Invoke(o_535, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)((ToNum(x_544) - 1.6))), ((V)(4D)), ((V)(3.2)), ((V)(52D)), ((V)(1D))), ((V)("#8a8f94"))));
}, 1, "", true));
Invoke(o_535, "push", Call(pd_53, V.Undef, ((V)("M4 8H76")), ((V)("none")), ((V)("#8a8f94")), ((V)(1.6))));
d_537 = new JsStrBuf("");
{
double x_546 = 0;
x_546 = (-40D);
while (true) {
if (!((x_546 < 80D))) break;
d_537.S("M").N(x_546).S(" 56L").N((x_546 + 48D)).S(" 8M").N((x_546 + 48D)).S(" 56L").N(x_546).S(" 8");
x_546 = (x_546 + 6D);
}
}
Invoke(o_535, "push", Call(pd_53, V.Undef, ((V)(d_537.Str)), ((V)("none")), ((V)("#a0603a")), ((V)(0.6)), ((V)(0.8))), Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(50D)), ((V)(20D)), ((V)(14D)), ((V)(18D)), ((V)(0D))), ((V)("#93cf70")), ((V)(0D)), ((V)(0D)), ((V)(0.5))));
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", o_535).V;
}
if (Truthy(Call(has_57, V.Undef, L_536, NewRegExp(RX100, "limestone|stone", "")))) {
Invoke(o_535, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(80D)), ((V)(42D)), ((V)(1D))), ((V)("#e3d8c0")), ((V)("#b9ab92")), ((V)(1D))));
{
double y_548 = 0;
y_548 = 0D;
while (true) {
if (!((y_548 < 5D))) break;
{
double x_550 = 0;
x_550 = 0D;
while (true) {
if (!((x_550 < 5D))) break;
Invoke(o_535, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(((x_550 * 17D) - ((y_548 % 2D) * 8D)))), ((V)((14D + (y_548 * 8.4)))), ((V)(16D)), ((V)(7.6)), ((V)(1D))), ((V)("#e3d8c0")), ((V)("#b9ab92")), ((V)(0.6))));
x_550++;
}
}
y_548++;
}
}
Invoke(o_535, "push", Call(pd_53, V.Undef, ((V)("M0 16H80")), ((V)("none")), ((V)("#3a3a3e")), ((V)(1.4))));
{
double x_552 = 0;
x_552 = 4D;
while (true) {
if (!((x_552 < 80D))) break;
Invoke(o_535, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").N(x_552).S(" 16V9").End())), ((V)("none")), ((V)("#3a3a3e")), ((V)(1D))));
x_552 = (x_552 + 8D);
}
}
{
double i_554 = 0;
i_554 = 0D;
while (true) {
if (!((i_554 < 9D))) break;
Invoke(o_535, "push", Call(pd_53, V.Undef, Call(ell_56, V.Undef, ((V)((6D + (i_554 * 9D)))), ((V)((14D + ((i_554 % 3D) * 3D)))), ((V)(5D)), ((V)(3D))), ((V)((NumTruthy((i_554 % 2D)) ? "#5fa84a" : "#4f9a3e")))));
i_554++;
}
}
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", o_535).V;
}
if (Truthy(Call(has_57, V.Undef, L_536, NewRegExp(RX101, "living|rainforest|force-field", "")))) {
Invoke(o_535, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)(56D)), ((V)(3D))), ((V)("#2f6a3c"))));
{
double i_556 = 0;
i_556 = 0D;
while (true) {
if (!((i_556 < 40D))) break;
Invoke(o_535, "push", Call(pd_53, V.Undef, Call(ell_56, V.Undef, ((V)(((i_556 * 23D) % 80D))), ((V)(((i_556 * 37D) % 56D))), ((V)(6D)), ((V)(4D))), GetIdx(Arr(((V)("#5fa84a")), ((V)("#6fbf54")), ((V)("#4f9a3e")), ((V)("#7ac860"))), (i_556 % 4D))));
i_556++;
}
}
Invoke(o_535, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)(56D)), ((V)(3D))), ((V)("#8fe8ff")), ((V)(0D)), ((V)(0D)), ((V)(0.18))), Call(pd_53, V.Undef, ((V)("M0 6H80")), ((V)("none")), ((V)("#8fe8ff")), ((V)(1.6)), ((V)(0.8))));
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", o_535).V;
}
if (Truthy(Call(has_57, V.Undef, L_536, NewRegExp(RX102, "horizontal|slat", "")))) {
Invoke(Arr(((V)(4D)), ((V)(76D))), "forEach", Fn((V _arrowThis565, int _argc558, V x_564, V _a561, V _a562, V _a563, V[] _rest559) => {
return Invoke(o_535, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)((ToNum(x_564) - 2D))), ((V)(4D)), ((V)(4D)), ((V)(52D)), ((V)(1D))), Call(shade_23, V.Undef, Get(C_533, "w"), ((V)(0.8)))));
}, 1, "", true));
{
double i_566 = 0;
i_566 = 0D;
while (true) {
if (!((i_566 < 8D))) break;
Invoke(o_535, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(0D)), ((V)((6D + (i_566 * 6.2)))), ((V)(80D)), ((V)(5D)), ((V)(1D))), (NumTruthy((i_566 % 2D)) ? Get(C_533, "w") : Call(shade_23, V.Undef, Get(C_533, "w"), ((V)(1.1)))), Call(shade_23, V.Undef, Get(C_533, "w"), ((V)(0.7))), ((V)(0.6))));
i_566++;
}
}
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", o_535).V;
}
{
double i_568 = 0;
i_568 = 0D;
while (true) {
if (!((i_568 < 6D))) break;
double x_570 = 0;
x_570 = (2D + (i_568 * 13.4));
Invoke(o_535, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").N(x_570).S(" 56V18L").N((x_570 + 5D)).S(" 11L").N((x_570 + 10D)).S(" 18V56Z").End())), ((V)("#fffaf1")), ((V)("#d8cbb4")), ((V)(1.2))));
i_568++;
}
}
Invoke(o_535, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(80D)), ((V)(4D)), ((V)(1D))), ((V)("#f4efe6")), ((V)("#d8cbb4")), ((V)(0.8))), Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(80D)), ((V)(4D)), ((V)(1D))), ((V)("#f4efe6")), ((V)("#d8cbb4")), ((V)(0.8))));
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", o_535).V;
return default;
}, 3, "fencePolys", false);
doorCurtain_63 = Fn((V _self571, int _argc572, V n_578, V C_579, V _a576, V _a577, V[] _rest573) => {
V o_580 = default;
V L_581 = default;
if (_self571.IsNullish) _self571 = GlobalV;
o_580 = Arr();
L_581 = Invoke(n_578, "toLowerCase");
Invoke(o_580, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)((-34D))), ((V)(16D)), ((V)(68D)), ((V)(86D)), ((V)(3D))), ((V)("#d8cbb4"))), Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)((-26D))), ((V)(22D)), ((V)(52D)), ((V)(80D)), ((V)(2D))), ((V)("#2c2830"))));
if (Truthy(Call(has_57, V.Undef, L_581, NewRegExp(RX103, "beaded|plastic curtain", "")))) {
{
double i_582 = 0;
i_582 = 0D;
while (true) {
if (!((i_582 < 10D))) break;
{
double j_584 = 0;
j_584 = 0D;
while (true) {
if (!((j_584 < 12D))) break;
Invoke(o_580, "push", Call(pd_53, V.Undef, Call(circ_55, V.Undef, ((V)(((-23D) + (i_582 * 5.2)))), ((V)((26D + (j_584 * 6.4)))), ((V)(1.6))), GetIdx(NE_26, ((i_582 + j_584) % 6D))));
j_584++;
}
}
i_582++;
}
}
} else {
if (Truthy(Call(has_57, V.Undef, L_581, NewRegExp(RX104, "shower curtain", "")))) {
Invoke(o_580, "push", Call(pd_53, V.Undef, ((V)("M-30 22H30")), ((V)("none")), ((V)("#9aa1a6")), ((V)(2D))));
{
double i_586 = 0;
i_586 = 0D;
while (true) {
if (!((i_586 < 6D))) break;
Invoke(o_580, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").N(((-26D) + (i_586 * 9D))).S(" 22Q").N(((-22D) + (i_586 * 9D))).S(" 60 ").N((((-26D) + (i_586 * 9D)) + ((i_586 == 4D) ? 6D : 0D))).S(" 100H").N(((-17D) + (i_586 * 9D))).S("Q").N(((-20D) + (i_586 * 9D))).S(" 60 ").N(((-17D) + (i_586 * 9D))).S(" 22Z").End())), ((V)((NumTruthy((i_586 % 2D)) ? "#cfe8f2" : "#bfe0ee"))), ((V)(0D)), ((V)(0D)), ((V)(0.9))));
i_586++;
}
}
Invoke(o_580, "push", Call(pd_53, V.Undef, ((V)("M8 40L14 52L10 60")), ((V)("none")), ((V)("#2c2830")), ((V)(1D))));
} else {
{
double i_588 = 0;
i_588 = 0D;
while (true) {
if (!((i_588 < 6D))) break;
Invoke(o_580, "push", Call(pd_53, V.Undef, ((V)(JsStrBuf.Begin().S("M").N(((-26D) + (i_588 * 9D))).S(" 22Q").N(((-22D) + (i_588 * 9D))).S(" 60 ").N(((-26D) + (i_588 * 9D))).S(" 102H").N(((-17D) + (i_588 * 9D))).S("Q").N(((-20D) + (i_588 * 9D))).S(" 60 ").N(((-17D) + (i_588 * 9D))).S(" 22Z").End())), ((V)((NumTruthy((i_588 % 2D)) ? "#2c2d31" : "#3a3a40")))));
i_588++;
}
}
Invoke(o_580, "push", Call(pd_53, V.Undef, ((V)("M-30 22H30")), ((V)("none")), ((V)("#9aa1a6")), ((V)(2.4))));
if (Truthy(Call(has_57, V.Undef, L_581, NewRegExp(RX105, "stanchion|rope", "")))) {
Invoke(o_580, "push", Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)((-40D))), ((V)(80D)), ((V)(3D)), ((V)(22D)), ((V)(1D))), GOLD_27), Call(pd_53, V.Undef, Call(rr_54, V.Undef, ((V)(37D)), ((V)(80D)), ((V)(3D)), ((V)(22D)), ((V)(1D))), GOLD_27), Call(pd_53, V.Undef, ((V)("M-38 82Q0 96 38 82")), ((V)("none")), ((V)("#a8243a")), ((V)(2.4))));
}
}
}
return NewObj(2).Put("vb", ((V)("-40 16 80 86"))).Put("polys", o_580).V;
return default;
}, 2, "doorCurtain", false);
surface_65 = Fn((V _self590, int _argc591, V r_597, V kind_598, V C_599, V _a596, V[] _rest592) => {
V n_600 = default;
V L_601 = default;
V t_602 = default;
V id_603 = default;
if (_self590.IsNullish) _self590 = GlobalV;
n_600 = Get(r_597, "name");
L_601 = Invoke(n_600, "toLowerCase");
t_602 = Get(r_597, "tier");
id_603 = ((V)(JsStrBuf.Begin().S("rv_").V(Get(r_597, "id")).End()));
if (SEqS(kind_598, "wall")) {
return Call(wallPolys_59, V.Undef, n_600, C_599, t_602);
}
if (SEqS(kind_598, "floor")) {
return Call(floorPolys_60, V.Undef, n_600, C_599, t_602, (false ? V.True : V.False));
}
if (SEqS(kind_598, "ground")) {
return Call(floorPolys_60, V.Undef, n_600, C_599, t_602, (true ? V.True : V.False));
}
if (SEqS(kind_598, "ceil")) {
return Call(ceilPolys_61, V.Undef, n_600, C_599, t_602);
}
if (SEqS(kind_598, "fence")) {
return Call(fencePolys_62, V.Undef, n_600, C_599, t_602);
}
if (SEqS(kind_598, "door")) {
V k_604 = default;
V c_605 = default;
if (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX106, "curtain|beaded", "")))) {
return Call(doorCurtain_63, V.Undef, n_600, C_599);
}
k_604 = ((V)((Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX110, "double|mahogany|palace|brass vip", ""))) ? "palace" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX109, "padded|studio|speakeasy|steel", ""))) ? "flush" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX108, "airlock|portal|biometric|hologram|neon tunnel", ""))) ? "jet" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX107, "squeaky|hollow|basement", ""))) ? "scuff" : "plank"))))));
c_605 = (SEqS(k_604, "palace") ? ((V)((Truthy(Invoke(NewRegExp(RX111, "mahogany", ""), "test", L_601)) ? "#6a2a1c" : "#f3ead6"))) : (SEqS(k_604, "flush") ? ((V)((Truthy(Invoke(NewRegExp(RX112, "leather|padded", ""), "test", L_601)) ? "#3e3438" : "#7a8086"))) : (SEqS(k_604, "jet") ? ((V)((Truthy(Invoke(NewRegExp(RX26, "neon", ""), "test", L_601)) ? "#8f7bff" : "#2a2630"))) : (SEqS(k_604, "scuff") ? ((V)("#a89478")) : Get(C_599, "w")))));
return Call(swPolys_64, V.Undef, id_603, NewObj(3).Put("k", k_604).Put("c", c_605).Put("cl", (SEqS(k_604, "palace") ? GOLD_27 : (SEqS(k_604, "jet") ? ((V)("#8fe8ff")) : Call(shade_23, V.Undef, c_605, ((V)(1.2)))))).V, ((V)("door")));
}
if (SEqS(kind_598, "win")) {
V k_606 = default;
V fr_607 = default;
V cu_608 = default;
k_606 = ((V)((Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX117, "crack|hopper|rust screen|drafty", ""))) ? "crack" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX116, "lace|sheer", ""))) ? "lace" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX115, "herb|greenhouse|box window|hydroponic|window seat", ""))) ? "flower" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX114, "french|balcony|arch", ""))) ? "arch" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX113, "panoram|floor-to-ceiling|bay|wall|pass-through|skyline|glass wall", ""))) ? "big" : "curt")))))));
fr_607 = (SEqS(k_606, "big") ? ((V)((Truthy(Invoke(NewRegExp(RX119, "holo|skyline", ""), "test", L_601)) ? "#8f7bff" : (Truthy(Invoke(NewRegExp(RX118, "steel|smart", ""), "test", L_601)) ? "#3e4046" : "#f4f1ea")))) : (SEqS(k_606, "arch") ? GOLD_27 : ((V)((SEqS(k_606, "crack") ? "#cbbfa6" : "#fffaf1")))));
cu_608 = ((V)((Truthy(Invoke(NewRegExp(RX125, "gingham|cafe", ""), "test", L_601)) ? "#e3946a" : (Truthy(Invoke(NewRegExp(RX124, "linen|roman|cotton", ""), "test", L_601)) ? "#e9dfcc" : (Truthy(Invoke(NewRegExp(RX123, "blackout", ""), "test", L_601)) ? "#2f4870" : (Truthy(Invoke(NewRegExp(RX122, "blinds|plastic", ""), "test", L_601)) ? "#e8e2d4" : (Truthy(Invoke(NewRegExp(RX121, "accordion|paper", ""), "test", L_601)) ? "#efe6d4" : (Truthy(Invoke(NewRegExp(RX120, "shutter", ""), "test", L_601)) ? "#9fb58c" : "#c9a85a"))))))));
return Call(swPolys_64, V.Undef, id_603, NewObj(3).Put("k", k_606).Put("fr", fr_607).Put("cu", (SEqS(k_606, "arch") ? ((V)((Truthy(Invoke(NewRegExp(RX126, "silk|drape", ""), "test", L_601)) ? "#7f2030" : "#f3ead6"))) : cu_608)).V, ((V)("win")));
}
if (SEqS(kind_598, "light")) {
V k_609 = default;
k_609 = ((V)((Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX135, "disco|mirror sphere|mirror ball|tin-foil ball", ""))) ? "disco" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX134, "laser|beam spot|moving-head|strobe", ""))) ? "laser" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX26, "neon", ""))) ? "neon" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX133, "constellation|kinetic|floating|halo|aurora|herb-halo|feather|bioluminescent|hologram|plasma", ""))) ? (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX127, "halo|herb", ""))) ? "halo" : "crys") : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX132, "chandelier|murano|capiz|tiered", ""))) ? "chand" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX131, "rattan|wicker|woven|bamboo|barn|enamel|paper|origami|drum", ""))) ? "wicker" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX130, "sputnik|globe|pendant|flush-mount|deco", ""))) ? "globe" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX129, "track|spotlight|truss", ""))) ? "truss" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX128, "bulb|fluorescent|strip|dome|pull-chain|party bulb", ""))) ? "bulb" : "globe")))))))))));
return Call(swPolys_64, V.Undef, id_603, NewObj(1).Put("k", k_609).V, ((V)("light")));
}
if (SEqS(kind_598, "ylight")) {
return Call(swPolys_64, V.Undef, id_603, NewObj(1).Put("k", ((V)((Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX137, "paper lantern", ""))) ? "lantern" : (Truthy(Call(has_57, V.Undef, L_601, NewRegExp(RX136, "edison|bistro|festoon", ""))) ? "festoon" : "string"))))).V, ((V)("ylight")));
}
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", Arr()).V;
return default;
}, 3, "surface", false);
draw_74 = Fn((V _self610, int _argc611, V r_617, V o_618, V _a615, V _a616, V[] _rest612) => {
V X_619 = default;
double ci_620 = 0;
V st_621 = default;
V txt_622 = default;
V ex_623 = default;
double ra_624 = 0;
V RA_625 = default;
V key_626 = default;
V sp_627 = default;
V nm_628 = default;
V band_629 = default;
V cv_630 = default;
V C_631 = default;
V res_632 = default;
if (_self610.IsNullish) _self610 = GlobalV;
X_619 = Get(G("window"), "House3D");
o_618 = (o_618 is var _t633 && Truthy(_t633) ? _t633 : NewObj(0).V);
ci_620 = ((double)(ToInt32(ToNum(Get(o_618, "ci"))) | ToInt32(0D)));
st_621 = (Get(o_618, "st") is var _t634 && Truthy(_t634) ? _t634 : ((V)("")));
txt_622 = (Get(o_618, "txt") is var _t635 && Truthy(_t635) ? _t635 : ((V)("")));
ex_623 = (Get(o_618, "ex") is var _t636 && Truthy(_t636) ? _t636 : ((V)("")));
ra_624 = (Get(o_618, "rot").IsNullish ? (-30D) : (((ToNum((((V)(ToNum(Get(o_618, "rot")))) is var _t637 && Truthy(_t637) ? _t637 : ((V)(0D)))) % 360D) + 360D) % 360D));
if ((ra_624 == 330D)) {
ra_624 = (-30D);
}
RA_625 = ((V)(JsStrBuf.Begin().S("|").N(ra_624).S("|").End()));
key_626 = ((V)(JsStrBuf.Begin().V(Get(r_617, "id")).S("|").V(Get(r_617, "name")).S("|").V(Get(r_617, "tier")).S("|").N(ci_620).S("|").V(st_621).S("|").V(txt_622).S("|").V(ex_623).S("|").V((Get(r_617, "spec") is var _t638 && Truthy(_t638) ? _t638 : ((V)("")))).V(((ra_624 == (-30D)) ? ((V)("")) : RA_625)).End()));
if (Truthy(Invoke(MEMO_73, "has", key_626))) {
return Invoke(MEMO_73, "get", key_626);
}
sp_627 = (Truthy(Get(r_617, "spec")) ? Call(parseSpec_51, V.Undef, Get(r_617, "spec")) : Call(specFor_52, V.Undef, r_617));
nm_628 = Invoke(Get(r_617, "name"), "toLowerCase");
band_629 = (Get(sp_627, "band") is var _t639 && Truthy(_t639) ? _t639 : GetIdx(TB_35, (ToNum(Get(r_617, "tier")) - 1D)));
if (Truthy((((!(Truthy(Get(sp_627, "band"))) && LeN(Get(r_617, "tier"), 3D)) ? V.True : V.False) is var _t640 && !Truthy(_t640) ? _t640 : Invoke(RETRO_48, "test", Get(r_617, "name"))))) {
band_629 = ((V)("retro"));
}
cv_630 = (Get(r_617, "colors") is var _t641 && !Truthy(_t641) ? _t641 : GetIdx(Get(r_617, "colors"), ci_620));
C_631 = Call(colorsOf_40, V.Undef, Get(r_617, "name"), band_629);
if (Truthy(cv_630)) {
Set(C_631, "a", ((Get(cv_630, "c").O is JsArray) ? GetIdx(Get(cv_630, "c"), 0D) : Get(cv_630, "c")));
Set(C_631, "anyA", (true ? V.True : V.False));
}
res_632 = NewObj(4).Put("float", ((GeN(Get(r_617, "tier"), 4D) ? V.True : V.False) is var _t642 && !Truthy(_t642) ? _t642 : Invoke(FLOAT_49, "test", Get(r_617, "name")))).Put("holo", Invoke(HOLO_50, "test", Get(r_617, "name"))).Put("surf", (false ? V.True : V.False)).Put("err", ((V)(""))).V;
try {
if (Truthy(Invoke(Get(sp_627, "base"), "startsWith", ((V)("s:"))))) {
V s_643 = default;
V svg_644 = default;
s_643 = Call(surface_65, V.Undef, r_617, Invoke(Get(sp_627, "base"), "slice", ((V)(2D))), C_631);
svg_644 = Call(svgDoc_70, V.Undef, Get(s_643, "vb"), Arr(), Call(pstr_69, V.Undef, Get(s_643, "polys")));
Object_assign(res_632, NewObj(7).Put("svg", svg_644).Put("src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, svg_644)).End()))).Put("w", ((V)(0D))).Put("h", ((V)(0D))).Put("surf", (true ? V.True : V.False)).Put("vb", Get(s_643, "vb")).Put("kind", Invoke(Get(sp_627, "base"), "slice", ((V)(2D)))).V);
} else {
V id_645 = default;
V D_646 = default;
V S_647 = default;
V @base_648 = default;
V R_649 = default;
V polys_650 = default;
V gids_651 = default;
double x0_652 = 0;
double y0_653 = 0;
V x1_654 = default;
V y1_655 = default;
V grow_656 = default;
V p_657 = default;
V ctx_658 = default;
JsStrBuf back_659 = null;
JsStrBuf front_660 = null;
JsStrBuf frontS_661 = null;
V LY_662 = default;
V dsort_663 = default;
double tr0_664 = 0;
double c0_665 = 0;
double s0_666 = 0;
V LR_667 = default;
V before_668 = default;
V F_669 = default;
V mk_670 = default;
V all_671 = default;
V spl_672 = default;
V pd2_673 = default;
V vb_674 = default;
V svg_675 = default;
id_645 = ((V)(JsStrBuf.Begin().S("rv_").V(Get(r_617, "id")).S("_").V(Get(r_617, "tier")).S("_").N(ci_620).S("_").V(st_621).End()));
D_646 = V.Undef;
S_647 = Object_assign(NewObj(9).Put("k", band_629).Put("v", Get(sp_627, "v")).Put("nm", nm_628).Put("st", st_621).Put("txt", txt_622).Put("ex", ex_623).Put("ci", ((V)(ci_620))).Put("pal", (Truthy((cv_630 is var _t676 && !Truthy(_t676) ? _t676 : ((Get(cv_630, "c").O is JsArray) ? V.True : V.False))) ? Get(cv_630, "c") : V.Null)).Put("row", r_617).V, (Get(r_617, "sx") is var _t677 && Truthy(_t677) ? _t677 : NewObj(0).V));
Invoke(Get(sp_627, "flags"), "forEach", Fn((V _arrowThis685, int _argc678, V f_684, V _a681, V _a682, V _a683, V[] _rest679) => {
return SetK(S_647, f_684, ((V)(1D)));
}, 1, "", true));
if (Truthy(Invoke(Get(sp_627, "base"), "startsWith", ((V)("#"))))) {
V D0_686 = default;
D0_686 = GetK(Get(X_619, "CAT"), Invoke(Get(sp_627, "base"), "slice", ((V)(1D))));
D_646 = Object_assign(NewObj(0).V, D0_686);
} else {
V fn_687 = default;
fn_687 = ((GetK(N_44, Get(sp_627, "base")) is var _t688 && Truthy(_t688) ? _t688 : GetK(Get(X_619, "ARCH"), Get(sp_627, "base"))) is var _t689 && Truthy(_t689) ? _t689 : Get(Get(X_619, "ARCH"), "coffee"));
D_646 = Call(fn_687, V.Undef, S_647);
}
@base_648 = Get((Invoke(Get(X_619, "BANDS"), "find", Fn((V _arrowThis697, int _argc690, V b_696, V _a693, V _a694, V _a695, V[] _rest691) => {
return (SEq(Get(b_696, "k"), band_629) ? V.True : V.False);
}, 1, "", true)) is var _t698 && Truthy(_t698) ? _t698 : GetIdx(Get(X_619, "BANDS"), 0D)), "cols");
Set(D_646, "cols", (Truthy(Get(C_631, "anyA")) ? Arr(NewObj(4).Put("a", Get(C_631, "a")).Put("b", Get(C_631, "b")).Put("w", Get(C_631, "w")).Put("m", Get(C_631, "m")).V) : Arr(Object_assign(NewObj(0).V, GetIdx(@base_648, 0D), NewObj(1).Put("w", (!SEq(Get(C_631, "w"), Get(GetIdx(@base_648, 0D), "w")) ? Get(C_631, "w") : Get(GetIdx(@base_648, 0D), "w"))).V))));
Set(D_646, "zs", ((V)((ToNum((Get(D_646, "zs") is var _t699 && Truthy(_t699) ? _t699 : ((V)(1D)))) * ToNum(Get(sp_627, "zs"))))));
SetK(Get(Get(G("window"), "House3D"), "CAT"), id_645, D_646);
Invoke(Get(X_619, "CACHE"), "delete", ((V)(JsStrBuf.Begin().V(Add(Add(id_645, RA_625), ((V)(0D)))).S("|").V((Get(D_646, "v0") is var _t700 && Truthy(_t700) ? _t700 : ((V)("")))).End())));
R_649 = Invoke(X_619, "render", id_645, ((V)(ra_624)), ((V)(0D)), (Get(D_646, "v0") is var _t701 && Truthy(_t701) ? _t701 : ((V)(""))));
polys_650 = Invoke(Get(R_649, "back"), "concat", Get(R_649, "part"), Get(R_649, "front"));
gids_651 = Invoke(Get(R_649, "gids"), "slice");
if (Truthy(Get(R_649, "glow"))) {
Invoke(polys_650, "unshift", NewObj(5).Put("d", Get(Get(R_649, "glow"), "d")).Put("f", Get(Get(R_649, "glow"), "f")).Put("s", ((V)("none"))).Put("w", ((V)(0D))).Put("o", ((V)(1D))).V);
}
x0_652 = ToNum(Get(Get(R_649, "bb"), "x"));
y0_653 = ToNum(Get(Get(R_649, "bb"), "y"));
x1_654 = ((V)((x0_652 + ToNum(Get(Get(R_649, "bb"), "w")))));
y1_655 = ((V)((y0_653 + ToNum(Get(Get(R_649, "bb"), "h")))));
grow_656 = Fn((V _arrowThis709, int _argc702, V b_708, V _a705, V _a706, V _a707, V[] _rest703) => {
if (!(Truthy(b_708))) {
return default;
}
x0_652 = Min(x0_652, ToNum(GetIdx(b_708, 0D)));
y0_653 = Min(y0_653, ToNum(GetIdx(b_708, 1D)));
x1_654 = ((V)(Max(ToNum(x1_654), ToNum(GetIdx(b_708, 2D)))));
y1_655 = ((V)(Max(ToNum(y1_655), ToNum(GetIdx(b_708, 3D)))));
return default;
}, 1, "", true);
p_657 = Call(projOf_71, V.Undef, (Get(D_646, "zs") is var _t710 && Truthy(_t710) ? _t710 : ((V)(1D))), ((V)(ra_624)));
ctx_658 = NewObj(5).Put("p", p_657).Put("S", S_647).Put("P", Invoke(X_619, "pal", D_646, ((V)(0D)))).Put("band", band_629).Put("k", ((V)((ToNum(Get(X_619, "FS")) * ToNum((Get(D_646, "zs") is var _t711 && Truthy(_t711) ? _t711 : ((V)(1D)))))))).V;
back_659 = new JsStrBuf("");
front_660 = new JsStrBuf("");
frontS_661 = new JsStrBuf("");
LY_662 = (Get(D_646, "layers") is var _t712 && Truthy(_t712) ? _t712 : Arr());
dsort_663 = (((GtN(Get(LY_662, "length"), 0D) && !(!(Truthy((Get(D_646, "seats") is var _t713 && !Truthy(_t713) ? _t713 : Get(Get(D_646, "seats"), "length")))))) ? V.True : V.False) is var _t722 && !Truthy(_t722) ? _t722 : Invoke(LY_662, "some", Fn((V _arrowThis721, int _argc714, V L_720, V _a717, V _a718, V _a719, V[] _rest715) => {
return Get(L_720, "back");
}, 1, "", true)));
tr0_664 = ((ra_624 * PI_33) / 180D);
c0_665 = FdLibm.Cos(tr0_664);
s0_666 = FdLibm.Sin(tr0_664);
LR_667 = Invoke(LY_662, "map", Fn((V _arrowThis731, int _argc723, V L_729, V i_730, V _a727, V _a728, V[] _rest724) => {
V lid_732 = default;
V R2_733 = default;
lid_732 = ((V)(JsStrBuf.Begin().V(id_645).S("_L").V(i_730).End()));
SetK(Get(Get(G("window"), "House3D"), "CAT"), lid_732, Object_assign(NewObj(5).Put("w", Get(D_646, "w")).Put("d", Get(D_646, "d")).Put("zs", Get(D_646, "zs")).Put("cols", Get(D_646, "cols")).Put("build", Get(L_729, "build")).V, (Truthy(dsort_663) ? NewObj(2).Put("seats", Get(D_646, "seats")).Put("act", Get(D_646, "act")).V : NewObj(0).V)));
Invoke(Get(X_619, "CACHE"), "delete", ((V)(JsStrBuf.Begin().V(Add(lid_732, RA_625)).S("0|").End())));
R2_733 = Invoke(X_619, "render", lid_732, ((V)(ra_624)), ((V)(0D)), ((V)("")));
Invoke(Get(R2_733, "gids"), "forEach", Fn((V _arrowThis741, int _argc734, V g_740, V _a737, V _a738, V _a739, V[] _rest735) => {
return Invoke(gids_651, "push", g_740);
}, 1, "", true));
Call(grow_656, V.Undef, Arr(((V)(ToNum(Get(Get(R2_733, "bb"), "x")))), ((V)(ToNum(Get(Get(R2_733, "bb"), "y")))), ((V)((ToNum(Get(Get(R2_733, "bb"), "x")) + ToNum(Get(Get(R2_733, "bb"), "w"))))), ((V)((ToNum(Get(Get(R2_733, "bb"), "y")) + ToNum(Get(Get(R2_733, "bb"), "h")))))));
return NewObj(2).Put("L", L_729).Put("R2", R2_733).V;
return default;
}, 2, "", true));
before_668 = V.Null;
if (Truthy(dsort_663)) {
V SA_742 = default;
V CA_743 = default;
double wx_744 = 0;
double wz_745 = 0;
V bnd1_746 = default;
V sols_747 = default;
V G_748 = default;
V pr_749 = default;
V n_750 = default;
V aft_751 = default;
V ind_752 = default;
V WB_753 = default;
V dn_754 = default;
V ord_755 = default;
V bi_756 = default;
V rk_757 = default;
SA_742 = Get(X_619, "SA");
CA_743 = Get(X_619, "CA");
wx_744 = (-s0_666);
wz_745 = c0_665;
bnd1_746 = Fn((V _arrowThis765, int _argc758, V S0_764, V _a761, V _a762, V _a763, V[] _rest759) => {
V L0_766 = default;
V sb_767 = default;
double md_768 = 0;
L0_766 = Arr(((V)(1000000000D)), ((V)((-1000000000D))), ((V)(1000000000D)), ((V)((-1000000000D))), ((V)(1000000000D)), ((V)((-1000000000D))));
sb_767 = Arr(((V)(1000000000D)), ((V)((-1000000000D))), ((V)(1000000000D)), ((V)((-1000000000D))));
md_768 = (-1000000000D);
Invoke(Get(S0_764, "pts"), "forEach", Fn((V _arrowThis776, int _argc769, V q_775, V _a772, V _a773, V _a774, V[] _rest770) => {
double x1_777 = 0;
double z1_778 = 0;
double sy_779 = 0;
double dd_780 = 0;
{
double k_781 = 0;
k_781 = 0D;
while (true) {
if (!((k_781 < 3D))) break;
if (Lt(GetIdx(q_775, k_781), GetIdx(L0_766, (k_781 * 2D)))) {
SetIdx(L0_766, (k_781 * 2D), GetIdx(q_775, k_781));
}
if (Gt(GetIdx(q_775, k_781), GetIdx(L0_766, ((k_781 * 2D) + 1D)))) {
SetIdx(L0_766, ((k_781 * 2D) + 1D), GetIdx(q_775, k_781));
}
k_781++;
}
}
x1_777 = ((ToNum(GetIdx(q_775, 0D)) * c0_665) + (ToNum(GetIdx(q_775, 2D)) * s0_666));
z1_778 = (((-ToNum(GetIdx(q_775, 0D))) * s0_666) + (ToNum(GetIdx(q_775, 2D)) * c0_665));
sy_779 = ((z1_778 * ToNum(SA_742)) - (ToNum(GetIdx(q_775, 1D)) * ToNum(CA_743)));
dd_780 = ((ToNum(GetIdx(q_775, 1D)) * ToNum(SA_742)) + (z1_778 * ToNum(CA_743)));
if (Lt(((V)(x1_777)), GetIdx(sb_767, 0D))) {
SetIdx(sb_767, 0D, ((V)(x1_777)));
}
if (Gt(((V)(x1_777)), GetIdx(sb_767, 1D))) {
SetIdx(sb_767, 1D, ((V)(x1_777)));
}
if (Lt(((V)(sy_779)), GetIdx(sb_767, 2D))) {
SetIdx(sb_767, 2D, ((V)(sy_779)));
}
if (Gt(((V)(sy_779)), GetIdx(sb_767, 3D))) {
SetIdx(sb_767, 3D, ((V)(sy_779)));
}
if ((dd_780 > md_768)) {
md_768 = dd_780;
}
return default;
}, 1, "", true));
return NewObj(3).Put("L", L0_766).Put("sb", sb_767).Put("md", ((V)(md_768))).V;
return default;
}, 1, "", true);
sols_747 = Fn((V _arrowThis790, int _argc783, V f_789, V _a786, V _a787, V _a788, V[] _rest784) => {
try {
return Invoke(Invoke((Call(f_789, V.Undef) is var _t801 && Truthy(_t801) ? _t801 : Arr()), "filter", Fn((V _arrowThis798, int _argc791, V S0_797, V _a794, V _a795, V _a796, V[] _rest792) => {
return ((S0_797 is var _t799 && !Truthy(_t799) ? _t799 : Get(S0_797, "pts")) is var _t800 && !Truthy(_t800) ? _t800 : Get(Get(S0_797, "pts"), "length"));
}, 1, "", true)), "map", bnd1_746);
} catch (System.Exception _ex802) {
V e_803 = default;
e_803 = Caught(_ex802);
return Arr();
}
return default;
}, 1, "", true);
G_748 = Invoke(Arr(Call(sols_747, V.Undef, Fn((V _arrowThis825, int _argc819, V _a821, V _a822, V _a823, V _a824, V[] _rest820) => {
return Invoke(D_646, "build", Invoke(X_619, "pal", D_646, ((V)(0D))), (Get(D_646, "v0") is var _t826 && Truthy(_t826) ? _t826 : ((V)(""))));
}, 0, "", true))), "concat", Invoke(LR_667, "map", Fn((V _arrowThis811, int _argc804, V o_810, V _a807, V _a808, V _a809, V[] _rest805) => {
return Call(sols_747, V.Undef, Fn((V _arrowThis818, int _argc812, V _a814, V _a815, V _a816, V _a817, V[] _rest813) => {
return Invoke(Get(o_810, "L"), "build", Invoke(X_619, "pal", D_646, ((V)(0D))), ((V)("")));
}, 0, "", true));
}, 1, "", true)));
pr_749 = Fn((V _arrowThis835, int _argc827, V A0_833, V B0_834, V _a831, V _a832, V[] _rest828) => {
V P_836 = default;
V Q_837 = default;
double ox_838 = 0;
double oy_839 = 0;
V a_840 = default;
V b_841 = default;
V ax_842 = default;
V f_843 = default;
P_836 = Get(A0_833, "sb");
Q_837 = Get(B0_834, "sb");
ox_838 = (Min(ToNum(GetIdx(P_836, 1D)), ToNum(GetIdx(Q_837, 1D))) - Max(ToNum(GetIdx(P_836, 0D)), ToNum(GetIdx(Q_837, 0D))));
oy_839 = (Min(ToNum(GetIdx(P_836, 3D)), ToNum(GetIdx(Q_837, 3D))) - Max(ToNum(GetIdx(P_836, 2D)), ToNum(GetIdx(Q_837, 2D))));
if (((ox_838 <= 0.5) || (oy_839 <= 0.5))) {
return ((V)(0D));
}
a_840 = Get(A0_833, "L");
b_841 = Get(B0_834, "L");
ax_842 = Arr(Arr(((V)(Max((ToNum(GetIdx(a_840, 2D)) - ToNum(GetIdx(b_841, 3D))), (ToNum(GetIdx(b_841, 2D)) - ToNum(GetIdx(a_840, 3D)))))), ((V)((Gt(GetIdx(a_840, 2D), GetIdx(b_841, 2D)) ? 1D : (-1D))))));
if ((System.Math.Abs(wx_744) > 0.15)) {
Invoke(ax_842, "push", Arr(((V)(Max((ToNum(GetIdx(a_840, 0D)) - ToNum(GetIdx(b_841, 1D))), (ToNum(GetIdx(b_841, 0D)) - ToNum(GetIdx(a_840, 1D)))))), ((V)(((Gt(GetIdx(a_840, 0D), GetIdx(b_841, 0D)) ? 1D : (-1D)) * Sign(wx_744))))));
}
if ((System.Math.Abs(wz_745) > 0.15)) {
Invoke(ax_842, "push", Arr(((V)(Max((ToNum(GetIdx(a_840, 4D)) - ToNum(GetIdx(b_841, 5D))), (ToNum(GetIdx(b_841, 4D)) - ToNum(GetIdx(a_840, 5D)))))), ((V)(((Gt(GetIdx(a_840, 4D), GetIdx(b_841, 4D)) ? 1D : (-1D)) * Sign(wz_745))))));
}
if (Truthy((Invoke(ax_842, "some", Fn((V _arrowThis851, int _argc844, V u_850, V _a847, V _a848, V _a849, V[] _rest845) => {
return ((GtN(GetIdx(u_850, 0D), 0D) && SEqN(GetIdx(u_850, 1D), 1D)) ? V.True : V.False);
}, 1, "", true)) is var _t860 && !Truthy(_t860) ? _t860 : Invoke(ax_842, "some", Fn((V _arrowThis859, int _argc852, V u_858, V _a855, V _a856, V _a857, V[] _rest853) => {
return ((GtN(GetIdx(u_858, 0D), 0D) && SEqN(GetIdx(u_858, 1D), (-1D))) ? V.True : V.False);
}, 1, "", true))))) {
return ((V)(0D));
}
Invoke(ax_842, "sort", Fn((V _arrowThis869, int _argc861, V u_867, V v_868, V _a865, V _a866, V[] _rest862) => {
return ((V)((ToNum(GetIdx(v_868, 0D)) - ToNum(GetIdx(u_867, 0D)))));
}, 2, "", true));
f_843 = (GtN(GetIdx(GetIdx(ax_842, 0D), 0D), (-4D)) ? GetIdx(GetIdx(ax_842, 0D), 1D) : ((V)(0D)));
if ((!(Truthy(f_843)) && (System.Math.Abs((ToNum(Get(A0_833, "md")) - ToNum(Get(B0_834, "md")))) > 1D))) {
f_843 = ((V)((Gt(Get(A0_833, "md"), Get(B0_834, "md")) ? 1D : (-1D))));
}
return ((V)(((ToNum(f_843) * ox_838) * oy_839)));
return default;
}, 2, "", true);
n_750 = Get(G_748, "length");
aft_751 = Array_from(NewObj(1).Put("length", n_750).V, Fn((V _arrowThis876, int _argc870, V _a872, V _a873, V _a874, V _a875, V[] _rest871) => {
return Arr();
}, 0, "", true));
ind_752 = Invoke(New(G("Array"), n_750), "fill", ((V)(0D)));
WB_753 = Invoke(G_748, "map", Fn((V _arrowThis885, int _argc877, V g_883, V i_884, V _a881, V _a882, V[] _rest878) => {
double a_886 = 0;
double b_887 = 0;
if (((!(Truthy(i_884)) || !(Truthy(Get(Get(GetIdx(LR_667, (ToNum(i_884) - 1D)), "L"), "back")))) || (c0_665 <= 0.2))) {
return (false ? V.True : V.False);
}
a_886 = 1000000000D;
b_887 = (-1000000000D);
Invoke(g_883, "forEach", Fn((V _arrowThis895, int _argc888, V o_894, V _a891, V _a892, V _a893, V[] _rest889) => {
a_886 = Min(a_886, ToNum(GetIdx(Get(o_894, "L"), 0D)));
b_887 = Max(b_887, ToNum(GetIdx(Get(o_894, "L"), 1D)));
return default;
}, 1, "", true));
return (((b_887 - a_886) > (ToNum((Get(D_646, "w") is var _t896 && Truthy(_t896) ? _t896 : ((V)(0D)))) * 0.6)) ? V.True : V.False);
return default;
}, 2, "", true));
{
double i_897 = 0;
i_897 = 0D;
while (true) {
if (!(Lt(((V)(i_897)), n_750))) break;
{
V j_899 = default;
j_899 = ((V)((i_897 + 1D)));
while (true) {
V j_899_it = j_899;
if (!(Lt(j_899_it, n_750))) break;
V v_901 = default;
double f_902 = 0;
v_901 = ((V)(0D));
f_902 = 0D;
if (Truthy((GetK(WB_753, j_899_it) is var _t904 && !Truthy(_t904) ? _t904 : (((i_897 == 0D) ? V.True : V.False) is var _t903 && Truthy(_t903) ? _t903 : GetIdx(WB_753, i_897))))) {
f_902 = ((i_897 == 0D) ? 1D : (-1D));
} else {
Invoke(GetIdx(G_748, i_897), "forEach", Fn((V _arrowThis912, int _argc905, V A0_911, V _a908, V _a909, V _a910, V[] _rest906) => {
return Invoke(GetK(G_748, j_899_it), "forEach", Fn((V _arrowThis920, int _argc913, V B0_919, V _a916, V _a917, V _a918, V[] _rest914) => {
v_901 = Add(v_901, Call(pr_749, V.Undef, A0_911, B0_919));
return default;
}, 1, "", true));
}, 1, "", true));
f_902 = (GtN(v_901, 0D) ? 1D : (LtN(v_901, 0D) ? (-1D) : 0D));
}
if ((f_902 == 1D)) {
Invoke(GetK(aft_751, j_899_it), "push", ((V)(i_897)));
IncK(ind_752, ((V)(i_897)), 1D, false);
} else {
if ((f_902 == (-1D))) {
Invoke(GetIdx(aft_751, i_897), "push", j_899_it);
IncK(ind_752, j_899_it, 1D, false);
}
}
j_899 = j_899_it;
PostInc(ref j_899, 1D);
}
}
i_897++;
}
}
dn_754 = Invoke(New(G("Array"), n_750), "fill", (false ? V.True : V.False));
ord_755 = Arr();
{
double k_921 = 0;
k_921 = 0D;
while (true) {
if (!(Lt(((V)(k_921)), n_750))) break;
double pk_923 = 0;
pk_923 = (-1D);
{
double i_924 = 0;
i_924 = 0D;
while (true) {
if (!(Lt(((V)(i_924)), n_750))) break;
if ((!(Truthy(GetIdx(dn_754, i_924))) && SEqN(GetIdx(ind_752, i_924), 0D))) {
pk_923 = i_924;
break;
}
i_924++;
}
}
if ((pk_923 < 0D)) {
{
double i_926 = 0;
i_926 = 0D;
while (true) {
if (!(Lt(((V)(i_926)), n_750))) break;
if (!(Truthy(GetIdx(dn_754, i_926)))) {
pk_923 = i_926;
break;
}
i_926++;
}
}
}
SetIdx(dn_754, pk_923, (true ? V.True : V.False));
Invoke(ord_755, "push", ((V)(pk_923)));
Invoke(GetIdx(aft_751, pk_923), "forEach", Fn((V _arrowThis935, int _argc928, V q_934, V _a931, V _a932, V _a933, V[] _rest929) => {
return ((V)(IncK(ind_752, q_934, -1D, false)));
}, 1, "", true));
k_921++;
}
}
bi_756 = Invoke(ord_755, "indexOf", ((V)(0D)));
before_668 = New(G("Set"), Invoke(Invoke(ord_755, "slice", ((V)(0D)), bi_756), "map", Fn((V _arrowThis943, int _argc936, V i_942, V _a939, V _a940, V _a941, V[] _rest937) => {
return ((V)((ToNum(i_942) - 1D)));
}, 1, "", true)));
rk_757 = New(G("Map"), Invoke(ord_755, "map", Fn((V _arrowThis952, int _argc944, V g_950, V i_951, V _a948, V _a949, V[] _rest945) => {
return Arr(((V)((ToNum(g_950) - 1D))), i_951);
}, 2, "", true)));
Invoke(LR_667, "forEach", Fn((V _arrowThis961, int _argc953, V o_959, V i_960, V _a957, V _a958, V[] _rest954) => {
return Set(o_959, "i", i_960);
}, 2, "", true));
Invoke(LR_667, "sort", Fn((V _arrowThis970, int _argc962, V u_968, V v_969, V _a966, V _a967, V[] _rest963) => {
return ((V)((ToNum(Invoke(rk_757, "get", Get(u_968, "i"))) - ToNum(Invoke(rk_757, "get", Get(v_969, "i"))))));
}, 2, "", true));
}
Invoke(LR_667, "forEach", Fn((V _arrowThis978, int _argc971, V o_977, V _a974, V _a975, V _a976, V[] _rest972) => {
V L_979 = default;
V R2_980 = default;
V all2_981 = default;
V m_982 = default;
V nB_983 = default;
{ V _t984 = o_977;
if (_t984.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t984));
{ V _t985 = Get(_t984, "L");
L_979 = _t985; }
{ V _t986 = Get(_t984, "R2");
R2_980 = _t986; } }
all2_981 = Invoke(Get(R2_980, "back"), "concat", Get(R2_980, "part"), Get(R2_980, "front"));
m_982 = (Truthy(Get(L_979, "wrap")) ? Invoke(L_979, "wrap", p_657, Call(pstr_69, V.Undef, all2_981)) : ((V)(JsStrBuf.Begin().S("<g>").V((Get(L_979, "anim") is var _t987 && Truthy(_t987) ? _t987 : ((V)("")))).V(Call(pstr_69, V.Undef, all2_981)).S("</g>").End())));
if (!(Truthy(dsort_663))) {
if (Truthy(Get(L_979, "back"))) {
back_659.V(m_982);
} else {
front_660.V(m_982);
}
return default;
}
nB_983 = Add(Get(Get(R2_980, "back"), "length"), Get(Get(R2_980, "part"), "length"));
if (Truthy((Get(Get(R2_980, "front"), "length") is var _t988 && !Truthy(_t988) ? _t988 : (Ge(Get(Get(R2_980, "front"), "length"), nB_983) ? V.True : V.False)))) {
frontS_661.V(m_982);
} else {
if (Truthy(Invoke(before_668, "has", Get(o_977, "i")))) {
back_659.V(m_982);
} else {
front_660.V(m_982);
}
}
return default;
}, 1, "", true));
F_669 = (Truthy(Get(D_646, "fx")) ? (Invoke(D_646, "fx", ctx_658) is var _t989 && Truthy(_t989) ? _t989 : NewObj(0).V) : NewObj(0).V);
if (Truthy(Get(F_669, "bb"))) {
Call(grow_656, V.Undef, Get(F_669, "bb"));
}
mk_670 = Fn((V _arrowThis999, int _argc990, V PL_996, V bare_997, V noS_998, V _a995, V[] _rest991) => {
V a_1000 = default;
a_1000 = ((V)((Truthy(bare_997) ? JsStrBuf.Begin().V(Call(pstr_69, V.Undef, PL_996)).S(frontS_661.Str).End() : JsStrBuf.Begin().V((Get(F_669, "back") is var _t1001 && Truthy(_t1001) ? _t1001 : ((V)("")))).S(back_659.Str).V(Call(pstr_69, V.Undef, PL_996)).S(front_660.Str).S((Truthy(noS_998) ? "" : frontS_661.Str)).V((Get(F_669, "front") is var _t1002 && Truthy(_t1002) ? _t1002 : ((V)("")))).End())));
if (Truthy(Get(D_646, "wrap"))) {
a_1000 = Invoke(D_646, "wrap", p_657, a_1000);
} else {
if (Truthy(Get(D_646, "anim"))) {
a_1000 = ((V)(JsStrBuf.Begin().S("<g>").V((string.Equals(Typeof(Get(D_646, "anim")), "function") ? Invoke(D_646, "anim", p_657) : Get(D_646, "anim"))).V(a_1000).S("</g>").End()));
}
}
return (Truthy(bare_997) ? a_1000 : Add(Add((Get(F_669, "under") is var _t1003 && Truthy(_t1003) ? _t1003 : ((V)(""))), a_1000), (Get(F_669, "over") is var _t1004 && Truthy(_t1004) ? _t1004 : ((V)("")))));
return default;
}, 3, "", true);
all_671 = Call(mk_670, V.Undef, polys_650);
spl_672 = (((GtN(Get(Get(R_649, "front"), "length"), 0D) || !(!(((frontS_661.Str).Length != 0)))) && !(Truthy(Get(D_646, "roam")))) ? V.True : V.False);
pd2_673 = (Get(D_646, "pad") is var _t1005 && Truthy(_t1005) ? _t1005 : Arr(((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(0D))));
x0_652 = (x0_652 - ToNum(GetIdx(pd2_673, 0D)));
y0_653 = (y0_653 - ToNum(GetIdx(pd2_673, 1D)));
x1_654 = Add(x1_654, GetIdx(pd2_673, 2D));
y1_655 = Add(y1_655, GetIdx(pd2_673, 3D));
vb_674 = ((V)(JsStrBuf.Begin().V(Call(f1_25, V.Undef, ((V)(x0_652)))).S(" ").V(Call(f1_25, V.Undef, ((V)(y0_653)))).S(" ").V(Call(f1_25, V.Undef, ((V)((ToNum(x1_654) - x0_652))))).S(" ").V(Call(f1_25, V.Undef, ((V)((ToNum(y1_655) - y0_653))))).End()));
svg_675 = Call(svgDoc_70, V.Undef, vb_674, gids_651, ((V)(JsStrBuf.Begin().S((Truthy(Get(F_669, "defs")) ? JsStrBuf.Begin().S("<defs>").V(Get(F_669, "defs")).S("</defs>").End() : "")).V(all_671).End())));
if (Truthy(spl_672)) {
V DF_1006 = default;
V FF_1007 = default;
JsStrBuf FB_1008 = null;
V FS_1009 = default;
DF_1006 = ((V)((Truthy(Get(F_669, "defs")) ? JsStrBuf.Begin().S("<defs>").V(Get(F_669, "defs")).S("</defs>").End() : "")));
FF_1007 = (Truthy(Get(D_646, "fxF")) ? (Get(F_669, "front") is var _t1010 && Truthy(_t1010) ? _t1010 : ((V)(""))) : ((V)("")));
if (Truthy(Get(D_646, "fxF"))) {
Set(F_669, "front", ((V)("")));
}
FB_1008 = new JsStrBuf("");
FS_1009 = Add(Call(mk_670, V.Undef, Get(R_649, "front"), ((V)(1D))), FF_1007);
if (Truthy(Get(D_646, "cutF"))) {
V q_1011 = default;
V cy_1012 = default;
V W2_1013 = default;
V WW_1014 = default;
V CD_1015 = default;
q_1011 = Call(p_657, V.Undef, GetIdx(Get(D_646, "cutF"), 0D), GetIdx(Get(D_646, "cutF"), 1D), GetIdx(Get(D_646, "cutF"), 2D));
cy_1012 = Call(f1_25, V.Undef, GetIdx(q_1011, 1D));
W2_1013 = Call(f1_25, V.Undef, ((V)((x0_652 - 50D))));
WW_1014 = Call(f1_25, V.Undef, ((V)(((ToNum(x1_654) - x0_652) + 100D))));
FB_1008.Set(JsStrBuf.Begin().S("<clipPath id=\"cfB\"><rect x=\"").V(W2_1013).S("\" y=\"").V(Call(f1_25, V.Undef, ((V)((y0_653 - 200D))))).S("\" width=\"").V(WW_1014).S("\" height=\"").V(Call(f1_25, V.Undef, ((V)(((ToNum(GetIdx(q_1011, 1D)) - y0_653) + 200D))))).S("\"/></clipPath><clipPath id=\"cfF\"><rect x=\"").V(W2_1013).S("\" y=\"").V(cy_1012).S("\" width=\"").V(WW_1014).S("\" height=\"").V(Call(f1_25, V.Undef, ((V)(((ToNum(y1_655) - ToNum(GetIdx(q_1011, 1D))) + 200D))))).S("\"/></clipPath>").End());
CD_1015 = ((V)(string.Concat("<defs>", FB_1008.Str, "</defs>")));
FB_1008.Set(JsStrBuf.Begin().V(CD_1015).S("<g clip-path=\"url(#cfB)\">").V(FS_1009).S("</g>").End());
FS_1009 = ((V)(JsStrBuf.Begin().V(CD_1015).S("<g clip-path=\"url(#cfF)\">").V(FS_1009).S("</g>").End()));
}
Set(res_632, "srcB", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Call(svgDoc_70, V.Undef, vb_674, gids_651, ((V)(JsStrBuf.Begin().V(Add(DF_1006, Call(mk_670, V.Undef, Invoke(polys_650, "filter", Fn((V _arrowThis1030, int _argc1024, V q_1022, V _a1027, V _a1028, V _a1029, V[] _rest1025) => {
return (!(Truthy(Invoke(Get(R_649, "front"), "includes", q_1022))) ? V.True : V.False);
}, 1, "", true)), (false ? V.True : V.False), (true ? V.True : V.False)))).S(FB_1008.Str).End()))))).End())));
Set(res_632, "srcF", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Call(svgDoc_70, V.Undef, vb_674, gids_651, Add(DF_1006, FS_1009)))).End())));
if (Truthy(Get(D_646, "fxF"))) {
Set(F_669, "front", FF_1007);
}
}
Object_assign(res_632, NewObj(10).Put("svg", svg_675).Put("src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, svg_675)).End()))).Put("w", ((V)((ToNum(x1_654) - x0_652)))).Put("h", ((V)((ToNum(y1_655) - y0_653)))).Put("vb", vb_674).Put("bb", Arr(((V)(x0_652)), ((V)(y0_653)), ((V)((ToNum(x1_654) - x0_652))), ((V)((ToNum(y1_655) - y0_653))))).Put("squish", (!(!(Truthy(Get(D_646, "squish")))) ? V.True : V.False)).Put("roam", (!(!(Truthy(Get(D_646, "roam")))) ? V.True : V.False)).Put("mount", (Get(D_646, "mount") is var _t1031 && Truthy(_t1031) ? _t1031 : ((V)("")))).Put("foot", Call(p_657, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)))).V);
{
V SC_1032 = default;
SC_1032 = Get(R_649, "screen");
if ((!(Truthy(SC_1032)) && (SEqS(Get(D_646, "anim"), "tv") || SEqS(Get(D_646, "act"), "watch")))) {
try {
Invoke(Get(X_619, "CACHE"), "delete", ((V)(JsStrBuf.Begin().V(Add(id_645, RA_625)).S("0|on").End())));
SC_1032 = Get(Invoke(X_619, "render", id_645, ((V)(ra_624)), ((V)(0D)), ((V)("on"))), "screen");
} catch (System.Exception _ex1033) {
V e_1034 = default;
e_1034 = Caught(_ex1033);

}
}
if (Truthy(SC_1032)) {
Set(res_632, "screen", NewObj(3).Put("w", ((V)(ToNum(Get(SC_1032, "w"))))).Put("h", ((V)(ToNum(Get(SC_1032, "h"))))).Put("m", Invoke(Invoke(Invoke(Invoke(((V)(ToStrS(Get(SC_1032, "m")))), "replace", NewRegExp(RX139, "matrix\\(|\\)", "g"), ((V)(""))), "trim"), "split", NewRegExp(RX138, "[\\s,]+", "")), "map", G("Number"))).V);
}
}
if (Truthy((Get(D_646, "seats") is var _t1035 && !Truthy(_t1035) ? _t1035 : Get(Get(D_646, "seats"), "length")))) {
Set(res_632, "seats", Invoke(Get(D_646, "seats"), "map", Fn((V _arrowThis1043, int _argc1036, V s_1042, V _a1039, V _a1040, V _a1041, V[] _rest1037) => {
V q_1044 = default;
q_1044 = Call(p_657, V.Undef, Get(s_1042, "x"), Get(s_1042, "h"), Get(s_1042, "z"));
return NewObj(2).Put("x", GetIdx(q_1044, 0D)).Put("y", GetIdx(q_1044, 1D)).V;
return default;
}, 1, "", true)));
}
if (Truthy((Get(D_646, "topH") is var _t1045 && Truthy(_t1045) ? _t1045 : Invoke(HOSTB_72, "test", Get(sp_627, "base"))))) {
V th_1046 = default;
V q_1047 = default;
th_1046 = Get(D_646, "topH");
if (!(Truthy(th_1046))) {
th_1046 = ((V)(0D));
Invoke(Invoke(D_646, "build", Invoke(X_619, "pal", D_646, ((V)(0D))), ((V)(""))), "forEach", Fn((V _arrowThis1055, int _argc1048, V s0_1054, V _a1051, V _a1052, V _a1053, V[] _rest1049) => {
return Invoke(Get(s0_1054, "pts"), "forEach", Fn((V _arrowThis1063, int _argc1056, V q_1062, V _a1059, V _a1060, V _a1061, V[] _rest1057) => {
if ((Gt(GetIdx(q_1062, 1D), th_1046) && (System.Math.Abs(ToNum(GetIdx(q_1062, 0D))) < (ToNum(Get(D_646, "w")) * 0.45)))) {
th_1046 = GetIdx(q_1062, 1D);
}
return default;
}, 1, "", true));
}, 1, "", true));
}
q_1047 = Call(p_657, V.Undef, ((V)(0D)), th_1046, (Get(D_646, "topZ") is var _t1064 && Truthy(_t1064) ? _t1064 : ((V)(0D))));
Set(res_632, "top", NewObj(3).Put("x", GetIdx(q_1047, 0D)).Put("y", GetIdx(q_1047, 1D)).Put("w", (Get(D_646, "topW") is var _t1065 && Truthy(_t1065) ? _t1065 : ((V)((ToNum(Get(D_646, "w")) * 0.6))))).V);
}
}
} catch (System.Exception _ex1066) {
V e_1067 = default;
e_1067 = Caught(_ex1066);
Set(res_632, "err", ((V)(ToStrS(((e_1067 is var _t1068 && !Truthy(_t1068) ? _t1068 : Get(e_1067, "message")) is var _t1069 && Truthy(_t1069) ? _t1069 : e_1067)))));
Set(res_632, "src", ((V)("")));
Invoke(G("console"), "warn", ((V)("reno draw")), Get(r_617, "id"), e_1067);
}
Set(res_632, "arch", ((V)(JsStrBuf.Begin().V(Get(sp_627, "base")).S((Truthy(Get(sp_627, "v")) ? JsStrBuf.Begin().S(".").V(Get(sp_627, "v")).End() : "")).End())));
Set(res_632, "band", band_629);
Invoke(MEMO_73, "set", key_626, res_632);
return res_632;
return default;
}, 2, "draw", false);
parseCSV_75 = Fn((V _self1070, int _argc1071, V t_1077, V _a1074, V _a1075, V _a1076, V[] _rest1072) => {
V rows_1078 = default;
V row_1079 = default;
JsStrBuf cur_1080 = null;
V q_1081 = default;
V H_1082 = default;
if (_self1070.IsNullish) _self1070 = GlobalV;
rows_1078 = Arr();
row_1079 = Arr();
cur_1080 = new JsStrBuf("");
q_1081 = (false ? V.True : V.False);
{
double i_1083 = 0;
i_1083 = 0D;
while (true) {
if (!(Lt(((V)(i_1083)), Get(t_1077, "length")))) break;
V ch_1085 = default;
ch_1085 = GetIdx(t_1077, i_1083);
if (Truthy(q_1081)) {
if (SEqS(ch_1085, "\"")) {
if (SEqS(GetIdx(t_1077, (i_1083 + 1D)), "\"")) {
cur_1080.S("\"");
i_1083++;
} else {
q_1081 = (false ? V.True : V.False);
}
} else {
cur_1080.V(ch_1085);
}
} else {
if (SEqS(ch_1085, "\"")) {
q_1081 = (true ? V.True : V.False);
} else {
if (SEqS(ch_1085, ",")) {
Invoke(row_1079, "push", ((V)(cur_1080.Str)));
cur_1080.Set("");
} else {
if ((SEqS(ch_1085, "\n") || SEqS(ch_1085, "\r"))) {
if ((SEqS(ch_1085, "\r") && SEqS(GetIdx(t_1077, (i_1083 + 1D)), "\n"))) {
i_1083++;
}
Invoke(row_1079, "push", ((V)(cur_1080.Str)));
cur_1080.Set("");
if (GtN(Get(row_1079, "length"), 1D)) {
Invoke(rows_1078, "push", row_1079);
}
row_1079 = Arr();
} else {
cur_1080.V(ch_1085);
}
}
}
}
i_1083++;
}
}
if (Truthy((((V)(cur_1080.Str)) is var _t1086 && Truthy(_t1086) ? _t1086 : Get(row_1079, "length")))) {
Invoke(row_1079, "push", ((V)(cur_1080.Str)));
if (GtN(Get(row_1079, "length"), 1D)) {
Invoke(rows_1078, "push", row_1079);
}
}
H_1082 = Invoke(Invoke(rows_1078, "shift"), "map", Fn((V _arrowThis1094, int _argc1087, V h_1093, V _a1090, V _a1091, V _a1092, V[] _rest1088) => {
return Invoke(h_1093, "trim");
}, 1, "", true));
return Invoke(Invoke(rows_1078, "map", Fn((V _arrowThis1110, int _argc1103, V r_1109, V _a1106, V _a1107, V _a1108, V[] _rest1104) => {
V o_1111 = default;
o_1111 = NewObj(0).V;
Invoke(H_1082, "forEach", Fn((V _arrowThis1120, int _argc1112, V h_1118, V i_1119, V _a1116, V _a1117, V[] _rest1113) => {
return SetK(o_1111, h_1118, Invoke((GetK(r_1109, i_1119) is var _t1121 && Truthy(_t1121) ? _t1121 : ((V)(""))), "trim"));
}, 2, "", true));
return NewObj(14).Put("id", Get(o_1111, "item_id")).Put("room", Get(o_1111, "room_code")).Put("roomName", Get(o_1111, "room_name")).Put("lv", ((V)(ToNum(Get(o_1111, "unlock_level"))))).Put("tier", ((V)(ToNum(Get(o_1111, "tier"))))).Put("tierName", Get(o_1111, "tier_name")).Put("rarity", Get(o_1111, "rarity")).Put("slot", ((V)(ToNum(Get(o_1111, "slot_index"))))).Put("cat", Get(o_1111, "category")).Put("slotName", Get(o_1111, "slot_name")).Put("name", Get(o_1111, "item_name")).Put("cost", ((V)(ToNum(Get(o_1111, "cost_coins"))))).Put("stat", Get(o_1111, "stat_type")).Put("bonus", Get(o_1111, "stat_bonus_display")).V;
return default;
}, 1, "", true)), "filter", Fn((V _arrowThis1102, int _argc1095, V r_1101, V _a1098, V _a1099, V _a1100, V[] _rest1096) => {
return Get(r_1101, "id");
}, 1, "", true));
return default;
}, 1, "parseCSV", false);
X_8 = Get(G("window"), "House3D");
if (!(Truthy(((((X_8 is var _t1122 && !Truthy(_t1122) ? _t1122 : Get(X_8, "EXT2")) is var _t1123 && !Truthy(_t1123) ? _t1123 : Get(X_8, "swatch")) is var _t1124 && !Truthy(_t1124) ? _t1124 : Get(X_8, "ARCH")) is var _t1125 && !Truthy(_t1125) ? _t1125 : Get(X_8, "SPEC"))))) {
Call(G("setTimeout"), V.Undef, boot_1126.v, ((V)(30D)));
return default;
}
if (Truthy(Get(G("window"), "RenoDraw"))) {
return default;
}
K_9 = Get(X_8, "K");
{ V _t1127 = K_9;
if (_t1127.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1127));
{ V _t1128 = Get(_t1127, "solid");
solid_10 = _t1128; }
{ V _t1129 = Get(_t1127, "box");
box_11 = _t1129; }
{ V _t1130 = Get(_t1127, "cush");
cush_12 = _t1130; }
{ V _t1131 = Get(_t1127, "cyl");
cyl_13 = _t1131; }
{ V _t1132 = Get(_t1127, "ball");
ball_14 = _t1132; }
{ V _t1133 = Get(_t1127, "slab");
slab_15 = _t1133; }
{ V _t1134 = Get(_t1127, "slabX");
slabX_16 = _t1134; }
{ V _t1135 = Get(_t1127, "arcW");
arcW_17 = _t1135; }
{ V _t1136 = Get(_t1127, "disc");
disc_18 = _t1136; }
{ V _t1137 = Get(_t1127, "pillowY");
pillowY_19 = _t1137; }
{ V _t1138 = Get(_t1127, "pillowZ");
pillowZ_20 = _t1138; }
{ V _t1139 = Get(_t1127, "prism");
prism_21 = _t1139; }
{ V _t1140 = Get(_t1127, "prismZ");
prismZ_22 = _t1140; }
{ V _t1141 = Get(_t1127, "shade");
shade_23 = _t1141; }
{ V _t1142 = Get(_t1127, "mix");
mix_24 = _t1142; }
{ V _t1143 = Get(_t1127, "f1");
f1_25 = _t1143; } }
NE_26 = Get(K_9, "NEON");
GOLD_27 = ((V)("#e2b14a"));
CH_28 = ((V)("#d5dde2"));
CR_29 = ((V)("#fffaf1"));
WH_30 = ((V)("#ffffff"));
DK_31 = ((V)("#36373c"));
GL_32 = ((V)("#cfe8f2"));
PI_33 = System.Math.PI;
em_34 = Fn((V _arrowThis1151, int _argc1144, V o_1150, V _a1147, V _a1148, V _a1149, V[] _rest1145) => {
return Object_assign(NewObj(2).Put("emit", ((V)(1D))).Put("noOut", ((V)(1D))).V, (o_1150 is var _t1152 && Truthy(_t1152) ? _t1152 : NewObj(0).V));
}, 1, "", true);
TB_35 = Arr(((V)("junk")), ((V)("cot")), ((V)("mod")), ((V)("royal")), ((V)("candy")));
CA_36 = NewObj(120).Put("burgundy", ((V)("#7f2030"))).Put("crimson", ((V)("#a8243a"))).Put("red", ((V)("#d9483b"))).Put("cherry", ((V)("#c23a3a"))).Put("cognac", ((V)("#a8592b"))).Put("leather", ((V)("#8a4f2c"))).Put("mustard", ((V)("#d8a531"))).Put("yellow", ((V)("#f2c94c"))).Put("yellowed", ((V)("#e8d79a"))).Put("orange", ((V)("#e88a3a"))).Put("terracotta", ((V)("#c8693f"))).Put("coral", ((V)("#ef8f7f"))).Put("pink", ((V)("#f0948e"))).Put("lavender", ((V)("#b9a6e0"))).Put("purple", ((V)("#7a4fb0"))).Put("plum", ((V)("#5b2a63"))).Put("navy", ((V)("#2f4870"))).Put("blue", ((V)("#5b8fd0"))).Put("cobalt", ((V)("#2f5fb0"))).Put("teal", ((V)("#3aa6a0"))).Put("mint", ((V)("#9fdcc4"))).Put("sage", ((V)("#9fb58c"))).Put("green", ((V)("#6aa65a"))).Put("emerald", ((V)("#1f6a4c"))).Put("olive", ((V)("#8a8f4a"))).Put("moss", ((V)("#6f8f4a"))).Put("eucalyptus", ((V)("#8fb39a"))).Put("jade", ((V)("#5fae8a"))).Put("charcoal", ((V)("#3e4046"))).Put("black", ((V)("#2c2d31"))).Put("obsidian", ((V)("#2a2630"))).Put("onyx", ((V)("#3a3438"))).Put("basalt", ((V)("#3c3c40"))).Put("slate", ((V)("#5c6670"))).Put("gray", ((V)("#9a9ea3"))).Put("grey", ((V)("#9a9ea3"))).Put("silver", ((V)("#c9d0d6"))).Put("platinum", ((V)("#e5e7ea"))).Put("white", ((V)("#f4f1ea"))).Put("cream", ((V)("#f3ead6"))).Put("ivory", ((V)("#f3ead6"))).Put("beige", ((V)("#d9c7a6"))).Put("eggshell", ((V)("#efe7d6"))).Put("off-white", ((V)("#ece4d2"))).Put("boucl\u00e9", ((V)("#efe8dc"))).Put("boucle", ((V)("#efe8dc"))).Put("linen", ((V)("#e9dfcc"))).Put("flax", ((V)("#e3d6bc"))).Put("cashmere", ((V)("#e8dcc8"))).Put("shearling", ((V)("#efe6d6"))).Put("sheepskin", ((V)("#f1ead8"))).Put("cotton", ((V)("#f4efe6"))).Put("silk", ((V)("#f2e6e0"))).Put("faux-fur", ((V)("#efe6da"))).Put("berber", ((V)("#efe6d4"))).Put("marble", ((V)("#efebe5"))).Put("calacatta", ((V)("#f2efea"))).Put("alabaster", ((V)("#f2ece2"))).Put("travertine", ((V)("#e1cfae"))).Put("limestone", ((V)("#e3d8c0"))).Put("terrazzo", ((V)("#e6ded2"))).Put("quartz", ((V)("#ece8e2"))).Put("quartzite", ((V)("#e8e2d8"))).Put("soapstone", ((V)("#7d8584"))).Put("stone", ((V)("#b9b4aa"))).Put("concrete", ((V)("#a9a8a2"))).Put("cinderblock", ((V)("#a7a6a0"))).Put("brick", ((V)("#b8664a"))).Put("pebble", ((V)("#b8b2a6"))).Put("tadelakt", ((V)("#e8d2b4"))).Put("plaster", ((V)("#ece2d0"))).Put("terra", ((V)("#c8693f"))).Put("jute", ((V)("#c9a873"))).Put("seagrass", ((V)("#b8a46a"))).Put("rattan", ((V)("#c99a5a"))).Put("wicker", ((V)("#c99a5a"))).Put("cane", ((V)("#d8b278"))).Put("coir", ((V)("#a9804c"))).Put("cardboard", ((V)("#c49a62"))).Put("rust", ((V)("#a0603a"))).Put("rusty", ((V)("#a0603a"))).Put("rusted", ((V)("#a0603a"))).Put("corrugated", ((V)("#a9b0b4"))).Put("tin", ((V)("#a9b0b4"))).Put("galvanized", ((V)("#b5bcc0"))).Put("foil", ((V)("#d5dde2"))).Put("plaid", ((V)("#b8714a"))).Put("gingham", ((V)("#e3946a"))).Put("leopard", ((V)("#c99a4a"))).Put("neon", ((V)("#4fe0d0"))).Put("rgb", ((V)("#6ac8ff"))).Put("led", ((V)("#6ac8ff"))).Put("uv", ((V)("#8f7bff"))).Put("holographic", ((V)("#8fe8ff"))).Put("hologram", ((V)("#8fe8ff"))).Put("holo", ((V)("#8fe8ff"))).Put("bioluminescent", ((V)("#7af0d0"))).Put("aurora", ((V)("#7ae8c8"))).Put("nebula", ((V)("#8f7bff"))).Put("plasma", ((V)("#b48cff"))).Put("crystal", ((V)("#d8f0ff"))).Put("glass", ((V)("#cfe8f2"))).Put("acrylic", ((V)("#d8eef5"))).Put("mirror", ((V)("#cfe8f2"))).Put("mirror-chrome", ((V)("#d5dde2"))).Put("liquid-metal", ((V)("#c9d0d6"))).Put("carbon-fiber", ((V)("#3a3c42"))).Put("foam", ((V)("#3a3a40"))).Put("lucite", ((V)("#d8eef5"))).Put("lacquered", ((V)("#2c2d31"))).Put("shagreen", ((V)("#9fbfb0"))).Put("murano", ((V)("#6b6f7a"))).Put("capiz", ((V)("#f4eee2"))).Put("porcelain", ((V)("#f4f2ee"))).Put("ceramic", ((V)("#efe8dc"))).Put("enamel", ((V)("#f1ece2"))).Put("fireclay", ((V)("#f4f1ea"))).Put("vinyl", ((V)("#d9483b"))).Put("felt", ((V)("#b9a088"))).Put("denim", ((V)("#4a6890"))).V;
CW_37 = NewObj(22).Put("walnut", ((V)("#6b4226"))).Put("teak", ((V)("#a86b36"))).Put("oak", ((V)("#d4a56a"))).Put("pine", ((V)("#e6c48e"))).Put("cedar", ((V)("#b8693f"))).Put("hinoki", ((V)("#e8cf9c"))).Put("cypress", ((V)("#d9b98a"))).Put("mahogany", ((V)("#6a2a1c"))).Put("rosewood", ((V)("#6e2d24"))).Put("redwood", ((V)("#9a4a2e"))).Put("birch", ((V)("#ead9b8"))).Put("bamboo", ((V)("#d8c27a"))).Put("burl", ((V)("#9a5a32"))).Put("plywood", ((V)("#d2b07a"))).Put("particleboard", ((V)("#c9ab7a"))).Put("ash", ((V)("#d8c4a2"))).Put("wooden", ((V)("#b98a58"))).Put("wood", ((V)("#b98a58"))).Put("butcher", ((V)("#d0a066"))).Put("timber", ((V)("#a87a48"))).Put("driftwood", ((V)("#b9ab96"))).Put("2x4", ((V)("#d8b886"))).V;
CM_38 = NewObj(16).Put("brass", ((V)("#d4a548"))).Put("gold", ((V)("#e2b14a"))).Put("golden", ((V)("#e2b14a"))).Put("24k", ((V)("#e2b14a"))).Put("gilded", ((V)("#e2b14a"))).Put("bronze", ((V)("#a8743a"))).Put("copper", ((V)("#c87a46"))).Put("chrome", ((V)("#d5dde2"))).Put("stainless", ((V)("#c9d3d8"))).Put("steel", ((V)("#9aa3a8"))).Put("iron", ((V)("#4a4a4e"))).Put("cast-iron", ((V)("#3e3e42"))).Put("wrought-iron", ((V)("#3a3a3e"))).Put("aluminum", ((V)("#c9cfd3"))).Put("aluminium", ((V)("#c9cfd3"))).Put("metal", ((V)("#a9b0b4"))).V;
words_39 = Fn((V _arrowThis1160, int _argc1153, V n_1159, V _a1156, V _a1157, V _a1158, V[] _rest1154) => {
return Invoke(Invoke(Invoke(Invoke(n_1159, "toLowerCase"), "replace", NewRegExp(RX141, "[^a-z0-9\\-\u00e9 ]+", "g"), ((V)(" "))), "split", NewRegExp(RX140, "\\s+", "")), "filter", G("Boolean"));
}, 1, "", true);
legs4_41 = Fn((V _arrowThis1173, int _argc1161, V x_1167, V z_1168, V h_1169, V col_1170, V[] _rest1162) => {
V r_1172 = default;
{ V _t1171 = (_argc1161 > 4 ? _rest1162[0] : V.Undef); if (_t1171.IsUndef) _t1171 = ((V)(3D));
r_1172 = _t1171; }
return Invoke(Arr(Arr(((V)((-ToNum(x_1167)))), ((V)((-ToNum(z_1168))))), Arr(x_1167, ((V)((-ToNum(z_1168))))), Arr(((V)((-ToNum(x_1167)))), z_1168), Arr(x_1167, z_1168)), "map", Fn((V _arrowThis1185, int _argc1174, V _a1176, V _a1177, V _a1178, V _a1179, V[] _rest1175) => {
V a_1182 = default;
V b_1184 = default;
{ V _t1180 = ListOf(_a1176);
{ V _t1181 = GetIdx(_t1180, 0D);
a_1182 = _t1181; }
{ V _t1183 = GetIdx(_t1180, 1D);
b_1184 = _t1183; }
}
return Call(cyl_13, V.Undef, a_1182, ((V)(0D)), b_1184, r_1172, h_1169, col_1170, NewObj(1).Put("n", ((V)(8D))).V);
}, 1, "", true));
}, 5, "", true);
metalOf_42 = Fn((V _arrowThis1193, int _argc1186, V k_1192, V _a1189, V _a1190, V _a1191, V[] _rest1187) => {
return (SEqS(k_1192, "royal") ? GOLD_27 : (SEqS(k_1192, "candy") ? ((V)("#fff1a0")) : (SEqS(k_1192, "junk") ? ((V)("#9aa1a6")) : (SEqS(k_1192, "mod") ? DK_31 : CH_28))));
}, 1, "", true);
holoBase_43 = Fn((V _arrowThis1203, int _argc1194, V o_1200, V y_1201, V r_1202, V _a1199, V[] _rest1195) => {
Invoke(o_1200, "push", Call(cyl_13, V.Undef, ((V)(0D)), y_1201, ((V)(0D)), r_1202, ((V)(4D)), ((V)("#3a3c48")), NewObj(1).Put("n", ((V)(18D))).V), Call(cyl_13, V.Undef, ((V)(0D)), Add(y_1201, ((V)(4D))), ((V)(0D)), ((V)((ToNum(r_1202) * 0.75))), ((V)(2D)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
return default;
}, 3, "", true);
N_44 = NewObj(38).Put("sheet", Fn((V _arrowThis1211, int _argc1204, V S_1210, V _a1207, V _a1208, V _a1209, V[] _rest1205) => {
return NewObj(4).Put("w", ((V)(150D))).Put("d", ((V)(8D))).Put("mount", ((V)("wall"))).Put("build", Fn((V _arrowThis1219, int _argc1212, V P_1218, V _a1215, V _a1216, V _a1217, V[] _rest1213) => {
return Arr(Call(slab_15, V.Undef, ((V)(0D)), ((V)(46D)), ((V)((-2D))), ((V)(150D)), ((V)(96D)), ((V)(2D)), ((V)("#f4efe4")), NewObj(4).Put("r", ((V)(2D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).Put("scr", NewObj(1).Put("r", ((V)(2D))).V).V), Call(slab_15, V.Undef, ((V)((-30D))), ((V)(60D)), ((V)((-0.6))), ((V)(2D)), ((V)(70D)), ((V)(0.6)), ((V)("#d8cfbe")), NewObj(2).Put("r", ((V)(1D))).Put("noOut", ((V)(1D))).V), Call(slab_15, V.Undef, ((V)(34D)), ((V)(52D)), ((V)((-0.6))), ((V)(2D)), ((V)(80D)), ((V)(0.6)), ((V)("#d8cfbe")), NewObj(2).Put("r", ((V)(1D))).Put("noOut", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)((-73D))), ((V)(139D)), ((V)(0D)), ((V)(2.6)), ((V)("#d9483b")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_14, V.Undef, ((V)(73D)), ((V)(139D)), ((V)(0D)), ((V)(2.6)), ((V)("#5b8fd0")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_14, V.Undef, ((V)((-73D))), ((V)(46D)), ((V)(0D)), ((V)(2.6)), ((V)("#f2c94c")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_14, V.Undef, ((V)(73D)), ((V)(46D)), ((V)(0D)), ((V)(2.6)), ((V)("#6aa65a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "build", true)).V;
}, 1, "sheet", true)).Put("projDev", Fn((V _arrowThis1227, int _argc1220, V S_1226, V _a1223, V _a1224, V _a1225, V[] _rest1221) => {
return NewObj(4).Put("w", ((V)(60D))).Put("d", ((V)(50D))).Put("glow", Fn((V _arrowThis1234, int _argc1228, V _a1230, V _a1231, V _a1232, V _a1233, V[] _rest1229) => {
return (SEqS(Get(S_1226, "k"), "candy") ? NewObj(3).Put("y", ((V)(60D))).Put("r", ((V)(60D))).Put("c", ((V)("url(#gNeon)"))).V : V.Null);
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1242, int _argc1235, V P_1241, V _a1238, V _a1239, V _a1240, V[] _rest1236) => {
V k_1243 = default;
V o_1244 = default;
V c_1245 = default;
k_1243 = Get(S_1226, "k");
o_1244 = Arr();
if (SEqS(k_1243, "junk")) {
InvokeSpread(o_1244, "push", new ArrBuilder().Spread(Call(legs4_41, V.Undef, ((V)(16D)), ((V)(14D)), ((V)(34D)), ((V)("#9a7550")), ((V)(2.6)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(0D)), ((V)(44D)), ((V)(4D)), ((V)(38D)), ((V)("#b08a5e")), NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(2D)), ((V)(40D)), ((V)(10D)), ((V)(30D)), ((V)("#3a3a3e")), NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(17.4)), ((V)(22D)), ((V)(3D)), ((V)(1D)), ((V)("#1d1d20")), NewObj(1).Put("r", ((V)(0.5))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(48D)), ((V)(0D)), ((V)(30D)), ((V)(18D)), ((V)(26D)), ((V)("#d6d0c4")), NewObj(1).Put("r", ((V)(4D))).V)).Add(Call(disc_18, V.Undef, ((V)((-4D))), ((V)(57D)), ((V)(13D)), ((V)(7D)), ((V)(4D)), ((V)("#2c2d31")))).Add(Call(disc_18, V.Undef, ((V)((-4D))), ((V)(57D)), ((V)(17D)), ((V)(4.6)), ((V)(0.8)), ((V)("#8fd0ff")), Call(em_34, V.Undef))).V);
return o_1244;
}
if (SEqS(k_1243, "candy")) {
Call(holoBase_43, V.Undef, o_1244, ((V)(0D)), ((V)(24D)));
Invoke(o_1244, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(10D)), ((V)(70D)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.4))), Arr(((V)(70D)), ((V)(0D)), ((V)(2.2))))).Put("op", ((V)(0.28))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(50D)), ((V)(0D)), ((V)(10D)), ((V)("#c9f4ff")), Call(em_34, V.Undef, NewObj(1).Put("op", ((V)(0.7))).V)), Call(ball_14, V.Undef, ((V)((-14D))), ((V)(66D)), ((V)(6D)), ((V)(4D)), ((V)("#ffd66b")), Call(em_34, V.Undef)), Call(ball_14, V.Undef, ((V)(14D)), ((V)(60D)), ((V)((-4D))), ((V)(3D)), ((V)("#a6f06a")), Call(em_34, V.Undef)));
return o_1244;
}
c_1245 = (SEqS(k_1243, "royal") ? ((V)("#2c2d31")) : (SEqS(k_1243, "mod") ? ((V)("#f1eee8")) : Get(P_1241, "a")));
if (!SEqS(k_1243, "cot")) {
Invoke(o_1244, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(52D)), ((V)((-4D))), ((V)(2.4)), ((V)(40D)), Call(metalOf_42, V.Undef, k_1243), NewObj(1).Put("n", ((V)(8D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(90D)), ((V)((-4D))), ((V)(24D)), ((V)(4D)), ((V)(14D)), Call(metalOf_42, V.Undef, k_1243), NewObj(1).Put("r", ((V)(2D))).V));
}
Invoke(o_1244, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((SEqS(k_1243, "cot") ? 0D : 28D))), ((V)(0D)), ((V)(50D)), ((V)(22D)), ((V)(42D)), c_1245, NewObj(2).Put("r", ((V)(8D))).Put("bev", ((V)(3D))).V), Call(disc_18, V.Undef, ((V)((-10D))), ((V)(((SEqS(k_1243, "cot") ? 0D : 28D) + 11D))), ((V)(21D)), ((V)(8D)), ((V)(4D)), ((V)("#2c2d31"))), Call(disc_18, V.Undef, ((V)((-10D))), ((V)(((SEqS(k_1243, "cot") ? 0D : 28D) + 11D))), ((V)(25D)), ((V)(5D)), ((V)(0.8)), ((V)("#8fd0ff")), Call(em_34, V.Undef)), Call(box_11, V.Undef, ((V)(14D)), ((V)(((SEqS(k_1243, "cot") ? 0D : 28D) + 22D))), ((V)(4D)), ((V)(12D)), ((V)(1.2)), ((V)(10D)), Call(shade_23, V.Undef, c_1245, ((V)(0.85))), NewObj(1).Put("r", ((V)(2D))).V));
if (SEqS(k_1243, "royal")) {
Invoke(o_1244, "push", Call(disc_18, V.Undef, ((V)(14D)), ((V)(39D)), ((V)(21D)), ((V)(7D)), ((V)(4D)), ((V)("#2c2d31"))), Call(disc_18, V.Undef, ((V)(14D)), ((V)(39D)), ((V)(25D)), ((V)(4.6)), ((V)(0.8)), ((V)("#8fd0ff")), Call(em_34, V.Undef)), Call(box_11, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(0D)), ((V)(52D)), ((V)(2D)), ((V)(44D)), GOLD_27, NewObj(1).Put("r", ((V)(8D))).V));
}
return o_1244;
return default;
}, 1, "build", true)).V;
}, 1, "projDev", true)).Put("popcorn", Fn((V _arrowThis1253, int _argc1246, V S_1252, V _a1249, V _a1250, V _a1251, V[] _rest1247) => {
return NewObj(4).Put("w", ((V)(70D))).Put("d", ((V)(54D))).Put("glow", Fn((V _arrowThis1260, int _argc1254, V _a1256, V _a1257, V _a1258, V _a1259, V[] _rest1255) => {
return (SEqS(Get(S_1252, "k"), "junk") ? V.Null : NewObj(2).Put("y", ((V)(80D))).Put("r", ((V)(50D))).V);
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1268, int _argc1261, V P_1267, V _a1264, V _a1265, V _a1266, V[] _rest1262) => {
V k_1269 = default;
V o_1270 = default;
V r_1271 = default;
V trim_1272 = default;
double y0_1273 = 0;
k_1269 = Get(S_1252, "k");
o_1270 = Arr();
if (SEqS(k_1269, "junk")) {
InvokeSpread(o_1270, "push", new ArrBuilder().Spread(Call(legs4_41, V.Undef, ((V)(13D)), ((V)(13D)), ((V)(38D)), ((V)("#8a8f94")), ((V)(2.4)))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(0D)), ((V)(20D)), ((V)(3D)), ((V)("#9aa1a6")), NewObj(1).Put("n", ((V)(14D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(41D)), ((V)(0D)), ((V)(48D)), ((V)(26D)), ((V)(34D)), ((V)("#efe9dc")), NewObj(1).Put("r", ((V)(4D))).V)).Add(Call(slab_15, V.Undef, ((V)((-4D))), ((V)(45D)), ((V)(17.4)), ((V)(30D)), ((V)(18D)), ((V)(1D)), ((V)("#3a3a3e")), NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)(16D)), ((V)(48D)), ((V)(17.6)), ((V)(6D)), ((V)(14D)), ((V)(1D)), ((V)("#c9c2b2")), NewObj(1).Put("r", ((V)(1D))).V)).Add(Call(ball_14, V.Undef, ((V)((-4D))), ((V)(46D)), ((V)(18.4)), ((V)(5D)), ((V)("#f4e2b8")), NewObj(3).Put("sy", ((V)(0.7))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)).V);
return o_1270;
}
r_1271 = (SEqS(k_1269, "royal") ? ((V)("#7f2030")) : (SEqS(k_1269, "candy") ? ((V)("#bfe4ff")) : (SEqS(k_1269, "mod") ? ((V)("#d9483b")) : Get(P_1267, "a"))));
trim_1272 = (SEqS(k_1269, "royal") ? GOLD_27 : ((V)((SEqS(k_1269, "candy") ? "#fff1a0" : "#f2c94c"))));
Invoke(o_1270, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((SEqS(k_1269, "cot") ? 0D : 10D))), ((V)(0D)), ((V)(56D)), ((V)(36D)), ((V)(40D)), r_1271, NewObj(2).Put("r", ((V)(4D))).Put("bev", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(((SEqS(k_1269, "cot") ? 0D : 10D) + 36D))), ((V)(0D)), ((V)(58D)), ((V)(3D)), ((V)(42D)), trim_1272, NewObj(1).Put("r", ((V)(3D))).V));
if (!SEqS(k_1269, "cot")) {
InvokeSpread(o_1270, "push", new ArrBuilder().Spread(Invoke(Arr(Arr(((V)((-22D))), ((V)(16D))), Arr(((V)(22D)), ((V)(16D))), Arr(((V)((-22D))), ((V)((-16D)))), Arr(((V)(22D)), ((V)((-16D))))), "map", Fn((V _arrowThis1285, int _argc1274, V _a1276, V _a1277, V _a1278, V _a1279, V[] _rest1275) => {
V x_1282 = default;
V z_1284 = default;
{ V _t1280 = ListOf(_a1276);
{ V _t1281 = GetIdx(_t1280, 0D);
x_1282 = _t1281; }
{ V _t1283 = GetIdx(_t1280, 1D);
z_1284 = _t1283; }
}
return Call(cyl_13, V.Undef, x_1282, ((V)(0D)), z_1284, ((V)(5D)), ((V)(10D)), ((V)("#2c2d31")), NewObj(1).Put("n", ((V)(10D))).V);
}, 1, "", true))).V);
}
y0_1273 = ((SEqS(k_1269, "cot") ? 0D : 10D) + 39D);
Invoke(o_1270, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(y0_1273)), ((V)(0D)), ((V)(50D)), ((V)(40D)), ((V)(34D)), GL_32, NewObj(3).Put("r", ((V)(2D))).Put("op", ((V)(0.45))).Put("mat", ((V)("cer"))).V));
{
double i_1286 = 0;
i_1286 = 0D;
while (true) {
if (!((i_1286 < 16D))) break;
Invoke(o_1270, "push", Call(ball_14, V.Undef, ((V)(((-18D) + ((i_1286 % 6D) * 7D)))), ((V)((y0_1273 + (System.Math.Floor((i_1286 / 6D)) * 5D)))), ((V)(((-10D) + ((i_1286 * 7D) % 20D)))), ((V)(3.4)), ((V)((NumTruthy((i_1286 % 3D)) ? "#fff4d0" : "#f2d27a"))), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
i_1286++;
}
}
Invoke(o_1270, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((y0_1273 + 40D))), ((V)(0D)), ((V)(56D)), ((V)(6D)), ((V)(40D)), r_1271, NewObj(1).Put("r", ((V)(5D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((y0_1273 + 46D))), ((V)(0D)), ((V)(12D)), ((V)(6D)), trim_1272, NewObj(2).Put("n", ((V)(12D))).Put("top", ((V)(6D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(((SEqS(k_1269, "cot") ? 0D : 10D) + 12D))), ((V)(20.4)), ((V)(40D)), ((V)(12D)), ((V)(0.8)), WH_30, NewObj(1).Put("r", ((V)(2D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(((SEqS(k_1269, "cot") ? 0D : 10D) + 15D))), ((V)(21D)), ((V)(30D)), ((V)(6D)), ((V)(0.6)), r_1271, NewObj(1).Put("r", ((V)(1D))).V));
return o_1270;
return default;
}, 1, "build", true)).V;
}, 1, "popcorn", true)).Put("icechest", Fn((V _arrowThis1295, int _argc1288, V S_1294, V _a1291, V _a1292, V _a1293, V[] _rest1289) => {
return NewObj(3).Put("w", ((V)(70D))).Put("d", ((V)(44D))).Put("build", Fn((V _arrowThis1303, int _argc1296, V P_1302, V _a1299, V _a1300, V _a1301, V[] _rest1297) => {
V k_1304 = default;
V c_1305 = default;
V l_1306 = default;
V o_1307 = default;
k_1304 = Get(S_1294, "k");
c_1305 = (SEqS(k_1304, "junk") ? ((V)("#f2efe6")) : Get(P_1302, "a"));
l_1306 = (SEqS(k_1304, "junk") ? ((V)("#ebe6da")) : Call(shade_23, V.Undef, Get(P_1302, "a"), ((V)(1.15))));
o_1307 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(66D)), ((V)(34D)), ((V)(40D)), c_1305, NewObj(2).Put("r", ((V)(5D))).Put("mat", (SEqS(k_1304, "junk") ? ((V)("cer")) : V.Undef)).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(0D)), ((V)(68D)), ((V)(7D)), ((V)(42D)), l_1306, NewObj(1).Put("r", ((V)(6D))).V));
if (SEqS(k_1304, "junk")) {
Invoke(o_1307, "push", Call(box_11, V.Undef, ((V)(18D)), ((V)(41D)), ((V)(0D)), ((V)(20D)), ((V)(2D)), ((V)(16D)), ((V)("#9fd2f2")), NewObj(1).Put("r", ((V)(3D))).V), Call(patch_45, V.Undef, ((V)((-16D))), ((V)(14D)), ((V)(20.6)), ((V)(16D)), ((V)(8D)), ((V)("#c9c2b2"))));
} else {
Invoke(o_1307, "push", Call(slabX_16, V.Undef, ((V)(0D)), ((V)(42D)), ((V)(0D)), ((V)(40D)), ((V)(4D)), ((V)(4D)), ((V)("#3a3a3e")), NewObj(1).Put("r", ((V)(2D))).V), Call(cyl_13, V.Undef, ((V)((-26D))), ((V)(41D)), ((V)(0D)), ((V)(2D)), ((V)(4D)), ((V)("#3a3a3e")), NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_13, V.Undef, ((V)(26D)), ((V)(41D)), ((V)(0D)), ((V)(2D)), ((V)(4D)), ((V)("#3a3a3e")), NewObj(1).Put("n", ((V)(6D))).V));
}
return o_1307;
return default;
}, 1, "build", true)).V;
}, 1, "icechest", true)).Put("minifridge", Fn((V _arrowThis1315, int _argc1308, V S_1314, V _a1311, V _a1312, V _a1313, V[] _rest1309) => {
return NewObj(4).Put("w", ((V)(56D))).Put("d", ((V)(50D))).Put("glow", Fn((V _arrowThis1322, int _argc1316, V _a1318, V _a1319, V _a1320, V _a1321, V[] _rest1317) => {
return (Truthy(Get(S_1314, "glass")) ? NewObj(3).Put("y", ((V)(30D))).Put("r", ((V)(40D))).Put("c", ((V)("url(#gNeon)"))).V : V.Null);
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1330, int _argc1323, V P_1329, V _a1326, V _a1327, V _a1328, V[] _rest1324) => {
V k_1331 = default;
V c_1332 = default;
V o_1333 = default;
k_1331 = Get(S_1314, "k");
c_1332 = (SEqS(k_1331, "junk") ? ((V)("#d8d2c6")) : (SEqS(k_1331, "royal") ? ((V)("#2c2d31")) : Get(P_1329, "a")));
o_1333 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(54D)), ((V)(70D)), ((V)(46D)), c_1332, NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).V));
if (Truthy(((Get(S_1314, "glass") is var _t1334 && Truthy(_t1334) ? _t1334 : (SEqS(k_1331, "royal") ? V.True : V.False)) is var _t1335 && Truthy(_t1335) ? _t1335 : (SEqS(k_1331, "candy") ? V.True : V.False)))) {
Invoke(o_1333, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(23.4)), ((V)(44D)), ((V)(56D)), ((V)(1D)), ((V)("#c9eef8")), NewObj(2).Put("r", ((V)(3D))).Put("op", ((V)(0.75))).V));
Invoke(Arr(((V)(16D)), ((V)(32D)), ((V)(48D))), "forEach", Fn((V _arrowThis1344, int _argc1336, V y_1342, V i_1343, V _a1340, V _a1341, V[] _rest1337) => {
return Invoke(Arr(((V)((-14D))), ((V)((-4D))), ((V)(6D)), ((V)(16D))), "forEach", Fn((V _arrowThis1353, int _argc1345, V x_1351, V j_1352, V _a1349, V _a1350, V[] _rest1346) => {
return Invoke(o_1333, "push", Call(cyl_13, V.Undef, x_1351, ((V)((ToNum(y_1342) - 4D))), ((V)(18D)), ((V)(3.2)), ((V)(9D)), GetIdx(NE_26, (ToNum(Add(i_1343, j_1352)) % 6D)), NewObj(1).Put("n", ((V)(8D))).V));
}, 2, "", true));
}, 2, "", true));
Invoke(o_1333, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(64D)), ((V)(23.8)), ((V)(44D)), ((V)(4D)), ((V)(0.8)), (SEqS(k_1331, "royal") ? GOLD_27 : ((V)("#d9483b"))), NewObj(1).Put("r", ((V)(1D))).V));
} else {
Invoke(o_1333, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(23.6)), ((V)(50D)), ((V)(62D)), ((V)(1.2)), Call(shade_23, V.Undef, c_1332, ((V)(1.06))), NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(20D)), ((V)(26D)), ((V)(25D)), ((V)(3D)), ((V)(18D)), ((V)(3D)), CH_28, NewObj(1).Put("r", ((V)(1.5))).V));
if (SEqS(k_1331, "junk")) {
Invoke(o_1333, "push", Call(box_11, V.Undef, ((V)((-8D))), ((V)(40D)), ((V)(24.4)), ((V)(12D)), ((V)(10D)), ((V)(1D)), ((V)("#a0603a")), NewObj(2).Put("r", ((V)(4D))).Put("op", ((V)(0.5))).V), Call(ball_14, V.Undef, ((V)((-16D))), ((V)(54D)), ((V)(24.6)), ((V)(4D)), ((V)("#e2554a")), NewObj(2).Put("sz", ((V)(0.3))).Put("k", ((V)(3D))).V));
}
}
return o_1333;
return default;
}, 1, "build", true)).V;
}, 1, "minifridge", true)).Put("tray", Fn((V _arrowThis1361, int _argc1354, V S_1360, V _a1357, V _a1358, V _a1359, V[] _rest1355) => {
return NewObj(3).Put("w", ((V)(52D))).Put("d", ((V)(40D))).Put("build", Fn((V _arrowThis1369, int _argc1362, V P_1368, V _a1365, V _a1366, V _a1367, V[] _rest1363) => {
V k_1370 = default;
V o_1371 = default;
k_1370 = Get(S_1360, "k");
o_1371 = Arr();
if (SEqS(k_1370, "junk")) {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1379, int _argc1372, V s_1378, V _a1375, V _a1376, V _a1377, V[] _rest1373) => {
Invoke(o_1371, "push", Call(prism_21, V.Undef, ((V)(((ToNum(s_1378) * 18D) - 1D))), ((V)(((ToNum(s_1378) * 18D) + 1D))), Arr(Arr(((V)((-14D))), ((V)(0D))), Arr(((V)((-12D))), ((V)(0D))), Arr(((V)(12D)), ((V)(40D))), Arr(((V)(14D)), ((V)(40D)))), ((V)("#9aa1a6"))), Call(prism_21, V.Undef, ((V)(((ToNum(s_1378) * 18D) - 1D))), ((V)(((ToNum(s_1378) * 18D) + 1D))), Arr(Arr(((V)(12D)), ((V)(0D))), Arr(((V)(14D)), ((V)(0D))), Arr(((V)((-12D))), ((V)(40D))), Arr(((V)((-14D))), ((V)(40D)))), ((V)("#9aa1a6"))));
return default;
}, 1, "", true));
Invoke(o_1371, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(50D)), ((V)(3D)), ((V)(36D)), ((V)("#d9483b")), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(43D)), ((V)(0D)), ((V)(36D)), ((V)(1D)), ((V)(24D)), ((V)("#e8d79a")), NewObj(1).Put("r", ((V)(2D))).V), Call(ball_14, V.Undef, ((V)(8D)), ((V)(43D)), ((V)(2D)), ((V)(5D)), ((V)("#c49a62")), NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
return o_1371;
}
if (SEqS(k_1370, "cot")) {
Invoke(o_1371, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(52D)), ((V)(3D)), ((V)(30D)), Get(P_1368, "w"), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)((-24D))), ((V)(3D)), ((V)(0D)), ((V)(3D)), ((V)(6D)), ((V)(30D)), Get(P_1368, "wD")), Call(box_11, V.Undef, ((V)(24D)), ((V)(3D)), ((V)(0D)), ((V)(3D)), ((V)(6D)), ((V)(30D)), Get(P_1368, "wD")), Call(cyl_13, V.Undef, ((V)((-8D))), ((V)(3D)), ((V)(0D)), ((V)(5D)), ((V)(8D)), CR_29, NewObj(1).Put("n", ((V)(10D))).V), Call(box_11, V.Undef, ((V)(12D)), ((V)(3D)), ((V)(2D)), ((V)(14D)), ((V)(2D)), ((V)(12D)), ((V)("#e3946a")), NewObj(1).Put("r", ((V)(1D))).V));
return o_1371;
}
Invoke(o_1371, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(50D)), ((V)(3D)), ((V)(34D)), (SEqS(k_1370, "candy") ? ((V)("#bfe4ff")) : Get(P_1368, "w")), NewObj(1).Put("r", ((V)(6D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(50D)), ((V)(4D)), ((V)(34D)), (SEqS(k_1370, "royal") ? GOLD_27 : Call(shade_23, V.Undef, Get(P_1368, "w"), ((V)(0.85)))), NewObj(2).Put("r", ((V)(6D))).Put("rings", Arr(Arr(((V)(3D)), ((V)(0D))), Arr(((V)(7D)), ((V)(0D))))).V), Call(cyl_13, V.Undef, ((V)((-10D))), ((V)(3D)), ((V)(0D)), ((V)(5D)), ((V)(10D)), (SEqS(k_1370, "candy") ? ((V)("#ffd66b")) : CR_29), NewObj(1).Put("n", ((V)(10D))).V), Call(cyl_13, V.Undef, ((V)(10D)), ((V)(3D)), ((V)(4D)), ((V)(4D)), ((V)(12D)), ((V)("#a6d8ff")), NewObj(2).Put("n", ((V)(10D))).Put("op", ((V)(0.8))).V));
if (SEqS(k_1370, "candy")) {
Invoke(o_1371, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)((-14D))), ((V)(0D)), ((V)(8D)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(2).Put("sy", ((V)(0.4))).Put("op", ((V)(0.5))).V)));
}
return o_1371;
return default;
}, 1, "build", true)).V;
}, 1, "tray", true)).Put("bistro", Fn((V _arrowThis1387, int _argc1380, V S_1386, V _a1383, V _a1384, V _a1385, V[] _rest1381) => {
return NewObj(5).Put("w", ((V)(50D))).Put("d", ((V)(50D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis1394, int _argc1388, V _a1390, V _a1391, V _a1392, V _a1393, V[] _rest1389) => {
return (SEqS(Get(S_1386, "k"), "candy") ? NewObj(3).Put("y", ((V)(40D))).Put("r", ((V)(40D))).Put("c", ((V)("url(#gNeon)"))).V : V.Null);
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1402, int _argc1395, V P_1401, V _a1398, V _a1399, V _a1400, V[] _rest1396) => {
V k_1403 = default;
V top_1404 = default;
V m_1405 = default;
double h_1406 = 0;
V o_1407 = default;
k_1403 = Get(S_1386, "k");
top_1404 = (SEqS(k_1403, "candy") ? ((V)("#bfe4ff")) : (SEqS(k_1403, "royal") ? Get(P_1401, "a") : (SEqS(k_1403, "mod") ? Get(P_1401, "a") : Get(P_1401, "w"))));
m_1405 = Call(metalOf_42, V.Undef, k_1403);
h_1406 = (Truthy(Get(S_1386, "tall")) ? 78D : 48D);
o_1407 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(18D)), ((V)(3D)), m_1405, NewObj(1).Put("n", ((V)(16D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(3D)), ((V)((h_1406 - 6D))), m_1405, NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((h_1406 - 3D))), ((V)(0D)), ((V)(24D)), ((V)(4D)), top_1404, NewObj(2).Put("n", ((V)(18D))).Put("mat", (Truthy(Invoke(NewRegExp(RX142, "marble|stone", ""), "test", Get(S_1386, "nm"))) ? ((V)("cer")) : V.Undef)).V));
if (SEqS(k_1403, "royal")) {
Invoke(o_1407, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)((h_1406 - 4D))), ((V)(0D)), ((V)(25D)), ((V)(1.4)), GOLD_27, NewObj(1).Put("n", ((V)(18D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((h_1406 * 0.45))), ((V)(0D)), ((V)(5D)), ((V)(10D)), GOLD_27, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(5D)), ((V)(0D)), ((V)(1.2))), Arr(((V)(10D)), ((V)(0D)), ((V)(0.6))))).V));
}
if (SEqS(k_1403, "candy")) {
Invoke(o_1407, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(10D)), ((V)((h_1406 - 12D))), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(1).Put("op", ((V)(0.35))).V)));
}
Invoke(o_1407, "push", Call(cyl_13, V.Undef, ((V)((-6D))), ((V)((h_1406 + 1D))), ((V)(3D)), ((V)(3.4)), ((V)(9D)), (SEqS(k_1403, "royal") ? GOLD_27 : ((V)("#a6d8ff"))), NewObj(2).Put("n", ((V)(10D))).Put("op", ((V)(0.85))).V));
return o_1407;
return default;
}, 1, "build", true)).V;
}, 1, "bistro", true)).Put("petbed", Fn((V _arrowThis1415, int _argc1408, V S_1414, V _a1411, V _a1412, V _a1413, V[] _rest1409) => {
return NewObj(4).Put("w", ((V)(70D))).Put("d", ((V)(60D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis1423, int _argc1416, V P_1422, V _a1419, V _a1420, V _a1421, V[] _rest1417) => {
V k_1424 = default;
V a_1425 = default;
V o_1426 = default;
k_1424 = Get(S_1414, "k");
a_1425 = Get(P_1422, "a");
o_1426 = Arr();
if (SEqS(k_1424, "junk")) {
if (Truthy(Invoke(NewRegExp(RX143, "box", ""), "test", Get(S_1414, "nm")))) {
return Invoke(Invoke(Invoke(N_44, "cardbox", S_1414), "build", P_1422), "concat", Arr(Call(cush_12, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(40D)), ((V)(6D)), ((V)(28D)), ((V)("#e8dcc0")))));
}
Invoke(o_1426, "push", Call(cush_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(60D)), ((V)(7D)), ((V)(46D)), a_1425), Call(cush_12, V.Undef, ((V)((-6D))), ((V)(7D)), ((V)((-2D))), ((V)(46D)), ((V)(6D)), ((V)(30D)), Call(shade_23, V.Undef, a_1425, ((V)(1.1)))), Call(cush_12, V.Undef, ((V)(4D)), ((V)(13D)), ((V)((-4D))), ((V)(30D)), ((V)(5D)), ((V)(20D)), Call(shade_23, V.Undef, a_1425, ((V)(0.95)))));
return o_1426;
}
if (SEqS(k_1424, "cot")) {
Invoke(o_1426, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(34D)), ((V)(18D)), Get(P_1422, "w"), NewObj(4).Put("rz", ((V)(28D))).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(18D)), ((V)(0D)), ((V)(1D))))).Put("mat", ((V)("wood"))).V));
}
Invoke(o_1426, "push", Call(arcW_17, V.Undef, ((V)(0D)), ((V)((SEqS(k_1424, "cot") ? 8D : 0D))), ((V)(0D)), ((V)(32D)), ((V)(26D)), ((V)(12D)), ((V)(14D)), ((V)(0D)), ((V)((PI_33 * 2D))), (SEqS(k_1424, "cot") ? ((V)("#f4efe6")) : a_1425), NewObj(2).Put("n", ((V)(16D))).Put("soft", ((V)(1D))).V), Call(cush_12, V.Undef, ((V)(0D)), ((V)((SEqS(k_1424, "cot") ? 8D : 0D))), ((V)(0D)), ((V)(44D)), ((V)(10D)), ((V)(34D)), Call(shade_23, V.Undef, a_1425, ((V)(1.12)))));
if (SEqS(k_1424, "cot")) {
{
double i_1427 = 0;
i_1427 = 0D;
while (true) {
if (!((i_1427 < 5D))) break;
Invoke(o_1426, "push", Call(ball_14, V.Undef, ((V)(((-12D) + (i_1427 * 6D)))), ((V)(18D)), ((V)(((-4D) + ((i_1427 % 2D) * 8D)))), ((V)(1.8)), ((V)("#d9483b")), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("sy", ((V)(0.4))).V));
i_1427++;
}
}
}
if (SEqS(k_1424, "royal")) {
Invoke(Arr(Arr(((V)((-30D))), ((V)((-24D)))), Arr(((V)(30D)), ((V)((-24D)))), Arr(((V)((-30D))), ((V)(24D))), Arr(((V)(30D)), ((V)(24D)))), "forEach", Fn((V _arrowThis1440, int _argc1429, V _a1431, V _a1432, V _a1433, V _a1434, V[] _rest1430) => {
V x_1437 = default;
V z_1439 = default;
{ V _t1435 = ListOf(_a1431);
{ V _t1436 = GetIdx(_t1435, 0D);
x_1437 = _t1436; }
{ V _t1438 = GetIdx(_t1435, 1D);
z_1439 = _t1438; }
}
return Invoke(o_1426, "push", Call(cyl_13, V.Undef, x_1437, ((V)(0D)), z_1439, ((V)(2D)), ((V)(64D)), GOLD_27, NewObj(1).Put("n", ((V)(8D))).V));
}, 1, "", true));
Invoke(o_1426, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(64D)), ((V)(0D)), ((V)(66D)), ((V)(3D)), ((V)(54D)), GOLD_27, NewObj(1).Put("r", ((V)(3D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(40D)), ((V)((-24D))), ((V)(60D)), ((V)(24D)), ((V)(1D)), Get(P_1422, "a"), NewObj(2).Put("r", ((V)(2D))).Put("soft", ((V)(1D))).V));
}
if (SEqS(k_1424, "candy")) {
Invoke(o_1426, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)((-16D))), ((V)(0D)), ((V)(14D)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(3).Put("sx", ((V)(2D))).Put("sy", ((V)(0.3))).Put("op", ((V)(0.35))).V)));
}
if (SEqS(k_1424, "mod")) {
Invoke(o_1426, "push", Call(ball_14, V.Undef, ((V)(10D)), ((V)(10D)), ((V)((-6D))), ((V)(6D)), Get(P_1422, "b"), NewObj(1).Put("k", ((V)(4D))).V));
}
return o_1426;
return default;
}, 1, "build", true)).V;
}, 1, "petbed", true)).Put("cardbox", Fn((V _arrowThis1448, int _argc1441, V S_1447, V _a1444, V _a1445, V _a1446, V[] _rest1442) => {
return NewObj(3).Put("w", ((V)(60D))).Put("d", ((V)(46D))).Put("build", Fn((V _arrowThis1456, int _argc1449, V P_1455, V _a1452, V _a1453, V _a1454, V[] _rest1450) => {
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(56D)), ((V)(30D)), ((V)(42D)), ((V)("#c49a62")), NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(29.5)), ((V)(0D)), ((V)(50D)), ((V)(0.6)), ((V)(36D)), ((V)("#8a6a42")), NewObj(1).Put("r", ((V)(1D))).V), Call(prism_21, V.Undef, ((V)((-28D))), ((V)((-27D))), Arr(Arr(((V)((-21D))), ((V)(30D))), Arr(((V)(21D)), ((V)(30D))), Arr(((V)(21D)), ((V)(40D))), Arr(((V)((-21D))), ((V)(34D)))), ((V)("#d2aa70"))), Call(slab_15, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(21D)), ((V)(56D)), ((V)(6D)), ((V)(1D)), ((V)("#d2aa70")), NewObj(2).Put("r", ((V)(0D))).Put("yaw", ((V)(0D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(21.4)), ((V)(56D)), ((V)(5D)), ((V)(0.6)), ((V)("#d8c8a0")), NewObj(1).Put("r", ((V)(0D))).V), Call(box_11, V.Undef, ((V)(28D)), ((V)(30D)), ((V)(0D)), ((V)(1D)), ((V)(12D)), ((V)(40D)), ((V)("#d2aa70")), NewObj(1).Put("r", ((V)(0D))).V));
}, 1, "build", true)).V;
}, 1, "cardbox", true)).Put("crate", Fn((V _arrowThis1464, int _argc1457, V S_1463, V _a1460, V _a1461, V _a1462, V[] _rest1458) => {
return NewObj(3).Put("w", ((V)(46D))).Put("d", ((V)(46D))).Put("build", Fn((V _arrowThis1472, int _argc1465, V P_1471, V _a1468, V _a1469, V _a1470, V[] _rest1466) => {
V c_1473 = default;
V o_1474 = default;
c_1473 = (SEqS(Get(S_1463, "k"), "junk") ? ((V)((Truthy(Invoke(NewRegExp(RX144, "red", ""), "test", Get(S_1463, "nm"))) ? "#d9483b" : "#3f7fbf"))) : Get(P_1471, "a"));
o_1474 = Arr();
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1482, int _argc1475, V s_1481, V _a1478, V _a1479, V _a1480, V[] _rest1476) => {
Invoke(o_1474, "push", Call(box_11, V.Undef, ((V)((ToNum(s_1481) * 20D))), ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(40D)), ((V)(42D)), c_1473, NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((ToNum(s_1481) * 20D))), ((V)(42D)), ((V)(40D)), ((V)(4D)), c_1473, NewObj(1).Put("r", ((V)(1D))).V));
return default;
}, 1, "", true));
Invoke(o_1474, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(0D)), ((V)(44D)), ((V)(4D)), ((V)(44D)), Call(shade_23, V.Undef, c_1473, ((V)(1.08))), NewObj(1).Put("r", ((V)(2D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(22.4)), ((V)(26D)), ((V)(6D)), ((V)(0.6)), Call(shade_23, V.Undef, c_1473, ((V)(0.6))), NewObj(1).Put("r", ((V)(3D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(22.4)), ((V)(26D)), ((V)(6D)), ((V)(0.6)), Call(shade_23, V.Undef, c_1473, ((V)(0.6))), NewObj(1).Put("r", ((V)(3D))).V));
if (Truthy(Invoke(NewRegExp(RX145, "neon|sticker", ""), "test", Get(S_1463, "nm")))) {
Invoke(o_1474, "push", Call(disc_18, V.Undef, ((V)((-8D))), ((V)(18D)), ((V)(22.6)), ((V)(4D)), ((V)(0.5)), GetIdx(NE_26, 0D), Call(em_34, V.Undef)), Call(disc_18, V.Undef, ((V)(8D)), ((V)(28D)), ((V)(22.6)), ((V)(3D)), ((V)(0.5)), GetIdx(NE_26, 2D), Call(em_34, V.Undef)));
}
return o_1474;
return default;
}, 1, "build", true)).V;
}, 1, "crate", true)).Put("console", Fn((V _arrowThis1490, int _argc1483, V S_1489, V _a1486, V _a1487, V _a1488, V[] _rest1484) => {
return NewObj(3).Put("w", ((V)(150D))).Put("d", ((V)(40D))).Put("build", Fn((V _arrowThis1498, int _argc1491, V P_1497, V _a1494, V _a1495, V _a1496, V[] _rest1492) => {
V k_1499 = default;
V top_1500 = default;
V m_1501 = default;
V o_1502 = default;
k_1499 = Get(S_1489, "k");
top_1500 = (SEqS(k_1499, "mod") ? GL_32 : (SEqS(k_1499, "royal") ? Get(P_1497, "w") : (SEqS(k_1499, "candy") ? Get(P_1497, "a") : Get(P_1497, "w"))));
m_1501 = Call(metalOf_42, V.Undef, k_1499);
o_1502 = Arr();
if (SEqS(k_1499, "junk")) {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1510, int _argc1503, V s_1509, V _a1506, V _a1507, V _a1508, V[] _rest1504) => {
return Invoke(o_1502, "push", Call(prism_21, V.Undef, ((V)(((ToNum(s_1509) * 60D) - 2D))), ((V)(((ToNum(s_1509) * 60D) + 2D))), Arr(Arr(((V)((-16D))), ((V)(0D))), Arr(((V)((-12D))), ((V)(0D))), Arr(((V)(0D)), ((V)(56D))), Arr(((V)(12D)), ((V)(0D))), Arr(((V)(16D)), ((V)(0D))), Arr(((V)(2D)), ((V)(62D))), Arr(((V)((-2D))), ((V)(62D)))), ((V)("#c9a46a"))));
}, 1, "", true));
Invoke(o_1502, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(60D)), ((V)(0D)), ((V)(150D)), ((V)(4D)), ((V)(36D)), ((V)("#d2b07a")), NewObj(1).Put("r", ((V)(1D))).V), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(120D)), ((V)(4D)), ((V)(4D)), ((V)("#b89058"))));
return o_1502;
}
if (SEqS(k_1499, "mod")) {
InvokeSpread(o_1502, "push", new ArrBuilder().Spread(Call(legs4_41, V.Undef, ((V)(68D)), ((V)(14D)), ((V)(62D)), m_1501, ((V)(1.6)))).Add(Call(slabX_16, V.Undef, ((V)(0D)), ((V)(10D)), ((V)((-14D))), ((V)(136D)), ((V)(2D)), ((V)(2D)), m_1501)).Add(Call(slabX_16, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(14D)), ((V)(136D)), ((V)(2D)), ((V)(2D)), m_1501)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(62D)), ((V)(0D)), ((V)(150D)), ((V)(2.4)), ((V)(38D)), top_1500, NewObj(2).Put("r", ((V)(2D))).Put("op", ((V)(0.7))).V)).V);
return o_1502;
}
if (SEqS(k_1499, "candy")) {
Invoke(o_1502, "push", Call(prismZ_22, V.Undef, ((V)((-16D))), ((V)(16D)), Arr(Arr(((V)((-70D))), ((V)(0D))), Arr(((V)((-40D))), ((V)(0D))), Arr(((V)(0D)), ((V)(44D))), Arr(((V)(40D)), ((V)(0D))), Arr(((V)(70D)), ((V)(0D))), Arr(((V)(74D)), ((V)(62D))), Arr(((V)((-74D))), ((V)(62D)))), ((V)("#c9d0d6")), NewObj(1).Put("mat", ((V)("metal"))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(62D)), ((V)(0D)), ((V)(152D)), ((V)(4D)), ((V)(38D)), ((V)("#d5dde2")), NewObj(1).Put("r", ((V)(18D))).V));
return o_1502;
}
Invoke(o_1502, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(146D)), ((V)(58D)), ((V)(36D)), (SEqS(k_1499, "royal") ? Get(P_1497, "w") : Get(P_1497, "w")), NewObj(2).Put("r", ((V)(3D))).Put("bev", ((V)(2D))).V));
Invoke(Arr(((V)((-48D))), ((V)(0D)), ((V)(48D))), "forEach", Fn((V _arrowThis1519, int _argc1511, V x_1517, V i_1518, V _a1515, V _a1516, V[] _rest1512) => {
return Invoke(o_1502, "push", Call(slab_15, V.Undef, x_1517, ((V)(6D)), ((V)(18.4)), ((V)(44D)), ((V)(46D)), ((V)(1D)), (SEqS(k_1499, "cot") ? ((V)("#e6d2a8")) : Call(shade_23, V.Undef, Get(P_1497, "w"), ((V)(1.08)))), NewObj(2).Put("r", ((V)(2D))).Put("mat", (SEqS(k_1499, "cot") ? ((V)("fab")) : V.Undef)).V), Call(ball_14, V.Undef, Add(x_1517, ((V)((SEqN(i_1518, 1D) ? 0D : 0D)))), ((V)(30D)), ((V)(19.5)), ((V)(2.2)), (SEqS(k_1499, "royal") ? GOLD_27 : ((V)("#3a3a3e"))), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 2, "", true));
if (SEqS(k_1499, "royal")) {
InvokeSpread(o_1502, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(58D)), ((V)(0D)), ((V)(150D)), ((V)(3D)), ((V)(38D)), GOLD_27, NewObj(1).Put("r", ((V)(3D))).V)).Spread(Invoke(Arr(((V)((-66D))), ((V)(66D))), "map", Fn((V _arrowThis1527, int _argc1520, V x_1526, V _a1523, V _a1524, V _a1525, V[] _rest1521) => {
return Call(cyl_13, V.Undef, x_1526, ((V)((-6D))), ((V)(14D)), ((V)(3D)), ((V)(6D)), GOLD_27, NewObj(1).Put("n", ((V)(8D))).V);
}, 1, "", true))).V);
}
Invoke(o_1502, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(58D)), ((V)(0D)), ((V)(148D)), ((V)(3D)), ((V)(37D)), Call(shade_23, V.Undef, Get(P_1497, "w"), ((V)(0.9))), NewObj(1).Put("r", ((V)(3D))).V));
return o_1502;
return default;
}, 1, "build", true)).V;
}, 1, "console", true)).Put("cattree", Fn((V _arrowThis1535, int _argc1528, V S_1534, V _a1531, V _a1532, V _a1533, V[] _rest1529) => {
return NewObj(3).Put("w", ((V)(70D))).Put("d", ((V)(60D))).Put("build", Fn((V _arrowThis1543, int _argc1536, V P_1542, V _a1539, V _a1540, V _a1541, V[] _rest1537) => {
V c_1544 = default;
V w_1545 = default;
V o_1546 = default;
c_1544 = Get(P_1542, "a");
w_1545 = ((V)("#e6d4b0"));
o_1546 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(66D)), ((V)(6D)), ((V)(56D)), c_1544, NewObj(2).Put("r", ((V)(6D))).Put("soft", ((V)(1D))).V));
Invoke(Arr(Arr(((V)((-18D))), ((V)(0D)), ((V)(70D))), Arr(((V)(16D)), ((V)((-8D))), ((V)(110D)))), "forEach", Fn((V _arrowThis1560, int _argc1547, V _a1549, V _a1550, V _a1551, V _a1552, V[] _rest1548) => {
V x_1555 = default;
V z_1557 = default;
V h_1559 = default;
{ V _t1553 = ListOf(_a1549);
{ V _t1554 = GetIdx(_t1553, 0D);
x_1555 = _t1554; }
{ V _t1556 = GetIdx(_t1553, 1D);
z_1557 = _t1556; }
{ V _t1558 = GetIdx(_t1553, 2D);
h_1559 = _t1558; }
}
return Invoke(o_1546, "push", Call(cyl_13, V.Undef, x_1555, ((V)(6D)), z_1557, ((V)(6D)), h_1559, w_1545, NewObj(2).Put("n", ((V)(12D))).Put("mat", ((V)("wood"))).V));
}, 1, "", true));
Invoke(o_1546, "push", Call(cush_12, V.Undef, ((V)((-18D))), ((V)(76D)), ((V)(0D)), ((V)(40D)), ((V)(6D)), ((V)(36D)), c_1544), Call(cush_12, V.Undef, ((V)(16D)), ((V)(116D)), ((V)((-8D))), ((V)(36D)), ((V)(6D)), ((V)(32D)), Call(shade_23, V.Undef, c_1544, ((V)(1.1)))), Call(box_11, V.Undef, ((V)((-18D))), ((V)(40D)), ((V)(14D)), ((V)(30D)), ((V)(22D)), ((V)(24D)), Call(shade_23, V.Undef, c_1544, ((V)(0.9))), NewObj(2).Put("r", ((V)(8D))).Put("soft", ((V)(1D))).V), Call(disc_18, V.Undef, ((V)((-18D))), ((V)(50D)), ((V)(26.2)), ((V)(7D)), ((V)(0.6)), ((V)("#3a2a20"))), Call(ball_14, V.Undef, ((V)(28D)), ((V)(80D)), ((V)(6D)), ((V)(4D)), ((V)("#f2c94c")), NewObj(1).Put("k", ((V)(3D))).V), Call(cyl_13, V.Undef, ((V)(28D)), ((V)(84D)), ((V)(6D)), ((V)(0.6)), ((V)(30D)), ((V)("#8a6a48")), NewObj(1).Put("n", ((V)(4D))).V));
return o_1546;
return default;
}, 1, "build", true)).V;
}, 1, "cattree", true)).Put("hearth", Fn((V _arrowThis1568, int _argc1561, V S_1567, V _a1564, V _a1565, V _a1566, V[] _rest1562) => {
return NewObj(5).Put("w", ((V)(130D))).Put("d", ((V)(46D))).Put("glow", Fn((V _arrowThis1575, int _argc1569, V _a1571, V _a1572, V _a1573, V _a1574, V[] _rest1570) => {
return NewObj(2).Put("y", ((V)(30D))).Put("r", ((V)(70D))).V;
}, 0, "glow", true)).Put("fx", Fn((V _arrowThis1583, int _argc1576, V c_1582, V _a1579, V _a1580, V _a1581, V[] _rest1577) => {
return Invoke(H_46, "fire", c_1582, Get(S_1567, "_fl"), (SEqS(Get(S_1567, "k"), "junk") ? V.True : V.False));
}, 1, "fx", true)).Put("build", Fn((V _arrowThis1591, int _argc1584, V P_1590, V _a1587, V _a1588, V _a1589, V[] _rest1585) => {
V k_1592 = default;
V o_1593 = default;
V FL_1594 = default;
V fl_1595 = default;
V br_1596 = default;
V mt_1597 = default;
k_1592 = Get(S_1567, "k");
o_1593 = Arr();
FL_1594 = Set(S_1567, "_fl", Arr());
fl_1595 = Fn((V _arrowThis1608, int _argc1598, V x_1604, V y_1605, V z_1606, V s_1607, V[] _rest1599) => {
return Invoke(FL_1594, "push", Arr(x_1604, y_1605, z_1606, s_1607));
}, 4, "", true);
if (SEqS(k_1592, "mod")) {
Invoke(o_1593, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)(6D)), ((V)(50D)), ((V)("#3e4046")), NewObj(1).Put("r", ((V)(4D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(30D)), ((V)(46D)), ((V)("#2c2d31")), NewObj(2).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(30D)), ((V)(0D)), ((V)(1.05))), Arr(((V)(46D)), ((V)(0D)), ((V)(0.3))))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(52D)), ((V)(0D)), ((V)(7D)), ((V)(90D)), ((V)("#2c2d31")), NewObj(1).Put("n", ((V)(10D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(16D)), ((V)(34D)), ((V)(20D)), ((V)(14D)), ((V)("#1d1d20")), NewObj(1).Put("r", ((V)(10D))).V));
Call(fl_1595, V.Undef, ((V)((-4D))), ((V)(13D)), ((V)(22D)), ((V)(0.9)));
Call(fl_1595, V.Undef, ((V)(7D)), ((V)(13D)), ((V)(21D)), ((V)(0.7)));
return o_1593;
}
if (SEqS(k_1592, "candy")) {
Invoke(o_1593, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(60D)), ((V)(8D)), ((V)(44D)), ((V)("#2a2630")), NewObj(1).Put("r", ((V)(4D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(20D)), ((V)(100D)), ((V)("#cfe8f2")), NewObj(3).Put("n", ((V)(16D))).Put("op", ((V)(0.35))).Put("mat", ((V)("cer"))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(6D)), ((V)(70D)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(2).Put("op", ((V)(0.4))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(70D)), ((V)(0D)), ((V)(2D))))).V)));
Call(fl_1595, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(1.3)));
Call(fl_1595, V.Undef, ((V)((-6D))), ((V)(22D)), ((V)(4D)), ((V)(0.9)));
Call(fl_1595, V.Undef, ((V)(6D)), ((V)(30D)), ((V)((-2D))), ((V)(0.8)));
return o_1593;
}
br_1596 = ((V)((SEqS(k_1592, "junk") ? "#b8664a" : (SEqS(k_1592, "royal") ? "#f3ead6" : "#f4f1ea"))));
mt_1597 = ((V)((SEqS(k_1592, "royal") ? "#efebe5" : (SEqS(k_1592, "cot") ? "#3e3e42" : "#a87a58"))));
Invoke(o_1593, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(126D)), ((V)(96D)), ((V)(40D)), br_1596, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)((SEqS(k_1592, "junk") ? "paint" : "cer")))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(20.5)), ((V)(70D)), ((V)(56D)), ((V)(1D)), ((V)("#2c1c14")), NewObj(1).Put("r", ((V)(6D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(96D)), ((V)(2D)), ((V)(134D)), ((V)(6D)), ((V)(46D)), mt_1597, NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(140D)), ((V)(6D)), ((V)(62D)), Call(shade_23, V.Undef, br_1596, ((V)(0.85))), NewObj(1).Put("r", ((V)(2D))).V));
if (SEqS(k_1592, "junk")) {
{
double r_1609 = 0;
r_1609 = 0D;
while (true) {
if (!((r_1609 < 6D))) break;
Invoke(o_1593, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)((8D + (r_1609 * 15D)))), ((V)(20.2)), ((V)(126D)), ((V)(1D)), ((V)(0.4)), ((V)("#e6d0b8")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
r_1609++;
}
}
Invoke(o_1593, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(24D)), ((V)(30D)), ((V)(24D)), ((V)(10D)), ((V)("#d5dde2")), NewObj(1).Put("r", ((V)(3D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(29.2)), ((V)(22D)), ((V)(16D)), ((V)(0.6)), ((V)("#ff8a3a")), Call(em_34, V.Undef)), Call(ball_14, V.Undef, ((V)(30D)), ((V)(102D)), ((V)(4D)), ((V)(6D)), ((V)("#a9b0b4")), NewObj(1).Put("k", ((V)(3D))).V));
} else {
if (SEqS(k_1592, "cot")) {
Invoke(o_1593, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(22D)), ((V)(64D)), ((V)(44D)), ((V)(2D)), ((V)("#2c2c30")), NewObj(1).Put("r", ((V)(8D))).V));
}
Invoke(o_1593, "push", Call(cyl_13, V.Undef, ((V)((-14D))), ((V)(4D)), ((V)(28D)), ((V)(4D)), ((V)(30D)), ((V)("#8a5a34")), NewObj(2).Put("n", ((V)(8D))).Put("yaw", ((V)(0D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(30D)), ((V)(44D)), ((V)(7D)), ((V)(10D)), ((V)("#8a5a34")), NewObj(1).Put("r", ((V)(3D))).V));
Call(fl_1595, V.Undef, ((V)((-8D))), ((V)(10D)), ((V)(30D)), ((V)(1D)));
Call(fl_1595, V.Undef, ((V)(8D)), ((V)(10D)), ((V)(29D)), ((V)(0.8)));
if (SEqS(k_1592, "royal")) {
InvokeSpread(o_1593, "push", new ArrBuilder().Spread(Invoke(Arr(((V)((-50D))), ((V)(50D))), "map", Fn((V _arrowThis1618, int _argc1611, V x_1617, V _a1614, V _a1615, V _a1616, V[] _rest1612) => {
return Call(cyl_13, V.Undef, x_1617, ((V)(0D)), ((V)(21D)), ((V)(5D)), ((V)(96D)), GOLD_27, NewObj(1).Put("n", ((V)(10D))).V);
}, 1, "", true))).Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(102D)), ((V)(10D)), ((V)(7D)), GOLD_27)).V);
}
}
return o_1593;
return default;
}, 1, "build", true)).V;
}, 1, "hearth", true)).Put("divider", Fn((V _arrowThis1626, int _argc1619, V S_1625, V _a1622, V _a1623, V _a1624, V[] _rest1620) => {
return NewObj(3).Put("w", ((V)(110D))).Put("d", ((V)(20D))).Put("build", Fn((V _arrowThis1634, int _argc1627, V P_1633, V _a1630, V _a1631, V _a1632, V[] _rest1628) => {
V k_1635 = default;
V o_1636 = default;
V m_1637 = default;
V fr_1638 = default;
k_1635 = Get(S_1625, "k");
o_1636 = Arr();
m_1637 = Call(metalOf_42, V.Undef, k_1635);
if (SEqS(k_1635, "junk")) {
Invoke(o_1636, "push", Call(slabX_16, V.Undef, ((V)(0D)), ((V)(150D)), ((V)(0D)), ((V)(112D)), ((V)(2.4)), ((V)(2.4)), ((V)("#9aa1a6")), NewObj(1).Put("r", ((V)(1D))).V));
{
double i_1639 = 0;
i_1639 = 0D;
while (true) {
if (!((i_1639 < 6D))) break;
Invoke(o_1636, "push", Call(slab_15, V.Undef, ((V)(((-46D) + (i_1639 * 18D)))), ((V)(4D)), ((V)((((i_1639 % 2D) * 3D) - 1.5))), ((V)(20D)), ((V)(144D)), ((V)(1.2)), ((V)("#cfe8f2")), NewObj(3).Put("r", ((V)(2D))).Put("op", ((V)(0.8))).Put("rb", ((V)(0D))).V));
i_1639++;
}
}
Invoke(o_1636, "push", Call(slab_15, V.Undef, ((V)(30D)), ((V)(30D)), ((V)(3D)), ((V)(20D)), ((V)(40D)), ((V)(1.4)), ((V)("#b9ab92")), NewObj(2).Put("r", ((V)(6D))).Put("op", ((V)(0.5))).V));
return o_1636;
}
fr_1638 = ((V)((SEqS(k_1635, "royal") ? "#b8693f" : (SEqS(k_1635, "mod") ? "#c9d3d8" : (SEqS(k_1635, "candy") ? "#8fe8ff" : "#e6e6e2")))));
Invoke(o_1636, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(110D)), ((V)(4D)), ((V)(18D)), fr_1638, NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)((-54D))), ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(154D)), ((V)(6D)), fr_1638, NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(54D)), ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(154D)), ((V)(6D)), fr_1638, NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(150D)), ((V)(0D)), ((V)(112D)), ((V)(4D)), ((V)(6D)), fr_1638, NewObj(1).Put("r", ((V)(1D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(104D)), ((V)(146D)), ((V)(1.4)), ((V)((SEqS(k_1635, "royal") ? "#f6efe0" : (SEqS(k_1635, "cot") ? "#e8eef0" : "#d8f0f8")))), NewObj(3).Put("r", ((V)(1D))).Put("op", ((V)((SEqS(k_1635, "royal") ? 0.95 : 0.55)))).Put("rb", ((V)(1D))).V));
if (SEqS(k_1635, "royal")) {
Invoke(Arr(((V)((-26D))), ((V)(0D)), ((V)(26D))), "forEach", Fn((V _arrowThis1648, int _argc1641, V x_1647, V _a1644, V _a1645, V _a1646, V[] _rest1642) => {
return Invoke(o_1636, "push", Call(box_11, V.Undef, x_1647, ((V)(4D)), ((V)(1.4)), ((V)(2D)), ((V)(146D)), ((V)(1.2)), ((V)("#b8693f")), NewObj(1).Put("r", ((V)(0D))).V));
}, 1, "", true));
Invoke(Arr(((V)(40D)), ((V)(80D)), ((V)(120D))), "forEach", Fn((V _arrowThis1656, int _argc1649, V y_1655, V _a1652, V _a1653, V _a1654, V[] _rest1650) => {
return Invoke(o_1636, "push", Call(slabX_16, V.Undef, ((V)(0D)), y_1655, ((V)(1.4)), ((V)(104D)), ((V)(2D)), ((V)(1.2)), ((V)("#b8693f")), NewObj(1).Put("r", ((V)(0D))).V));
}, 1, "", true));
}
if ((SEqS(k_1635, "mod") || SEqS(k_1635, "candy"))) {
Invoke(o_1636, "push", Call(slab_15, V.Undef, ((V)((-30D))), ((V)(60D)), ((V)(1.2)), ((V)(4D)), ((V)(70D)), ((V)(0.4)), WH_30, NewObj(3).Put("r", ((V)(1D))).Put("op", ((V)(0.6))).Put("noOut", ((V)(1D))).V));
}
if (SEqS(k_1635, "candy")) {
Invoke(o_1636, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0.8)), ((V)(104D)), ((V)(146D)), ((V)(0.5)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(3).Put("r", ((V)(1D))).Put("op", ((V)(0.25))).Put("rb", ((V)(1D))).V)));
}
if (SEqS(k_1635, "cot")) {
Invoke(o_1636, "push", Call(box_11, V.Undef, ((V)(40D)), ((V)(60D)), ((V)(4D)), ((V)(3D)), ((V)(20D)), ((V)(3D)), m_1637, NewObj(1).Put("r", ((V)(1.5))).V));
}
return o_1636;
return default;
}, 1, "build", true)).V;
}, 1, "divider", true)).Put("onsen", Fn((V _arrowThis1664, int _argc1657, V S_1663, V _a1660, V _a1661, V _a1662, V[] _rest1658) => {
return NewObj(3).Put("w", ((V)(150D))).Put("d", ((V)(110D))).Put("build", Fn((V _arrowThis1672, int _argc1665, V P_1671, V _a1668, V _a1669, V _a1670, V[] _rest1666) => {
V k_1673 = default;
V wd_1674 = default;
V o_1675 = default;
k_1673 = Get(S_1663, "k");
wd_1674 = (SEqS(k_1673, "candy") ? ((V)("#ece8e2")) : Get(P_1671, "w"));
o_1675 = Arr();
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1683, int _argc1676, V s_1682, V _a1679, V _a1680, V _a1681, V[] _rest1677) => {
Invoke(o_1675, "push", Call(box_11, V.Undef, ((V)((ToNum(s_1682) * 71D))), ((V)(0D)), ((V)(0D)), ((V)(8D)), ((V)(54D)), ((V)(110D)), wd_1674, NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((ToNum(s_1682) * 51D))), ((V)(150D)), ((V)(54D)), ((V)(8D)), wd_1674, NewObj(1).Put("r", ((V)(1D))).V));
return default;
}, 1, "", true));
Invoke(o_1675, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(136D)), ((V)(42D)), ((V)(96D)), wd_1674, NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(42D)), ((V)(0D)), ((V)(136D)), ((V)(6D)), ((V)(96D)), ((V)((SEqS(k_1673, "candy") ? "#7ad8ff" : "#9fd8ee"))), (SEqS(k_1673, "candy") ? Call(em_34, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("op", ((V)(0.9))).V) : NewObj(3).Put("r", ((V)(1D))).Put("op", ((V)(0.85))).Put("mat", ((V)("gloss"))).V)), Call(box_11, V.Undef, ((V)(0D)), ((V)(54D)), ((V)(0D)), ((V)(154D)), ((V)(3D)), ((V)(114D)), Call(shade_23, V.Undef, wd_1674, ((V)(1.12))), NewObj(2).Put("r", ((V)(2D))).Put("rings", Arr(Arr(((V)(54D)), ((V)(0D))), Arr(((V)(57D)), ((V)(0D))))).V));
if (SEqS(k_1673, "candy")) {
Invoke(o_1675, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(55.4)), ((V)(150D)), ((V)(54D)), ((V)(1D)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(2).Put("op", ((V)(0.35))).Put("r", ((V)(0D))).V)), Call(ball_14, V.Undef, ((V)((-40D))), ((V)(46D)), ((V)((-20D))), ((V)(8D)), WH_30, NewObj(3).Put("sy", ((V)(0.5))).Put("op", ((V)(0.8))).Put("k", ((V)(3D))).V), Call(ball_14, V.Undef, ((V)(30D)), ((V)(46D)), ((V)(10D)), ((V)(10D)), WH_30, NewObj(3).Put("sy", ((V)(0.4))).Put("op", ((V)(0.7))).Put("k", ((V)(3D))).V));
} else {
InvokeSpread(o_1675, "push", new ArrBuilder().Spread(Invoke(Arr(Arr(((V)((-40D))), ((V)((-20D)))), Arr(((V)(30D)), ((V)(14D)))), "map", Fn((V _arrowThis1695, int _argc1684, V _a1686, V _a1687, V _a1688, V _a1689, V[] _rest1685) => {
V x_1692 = default;
V z_1694 = default;
{ V _t1690 = ListOf(_a1686);
{ V _t1691 = GetIdx(_t1690, 0D);
x_1692 = _t1691; }
{ V _t1693 = GetIdx(_t1690, 1D);
z_1694 = _t1693; }
}
return Call(ball_14, V.Undef, x_1692, ((V)(48D)), z_1694, ((V)(9D)), WH_30, Call(em_34, V.Undef, NewObj(3).Put("sy", ((V)(1.6))).Put("op", ((V)(0.35))).Put("k", ((V)(4D))).V));
}, 1, "", true))).Add(Call(slabX_16, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(55.2)), ((V)(150D)), ((V)(3D)), ((V)(1D)), Call(shade_23, V.Undef, wd_1674, ((V)(0.7))))).Add(Call(slabX_16, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(55.2)), ((V)(150D)), ((V)(3D)), ((V)(1D)), Call(shade_23, V.Undef, wd_1674, ((V)(0.7))))).V);
}
return o_1675;
return default;
}, 1, "build", true)).V;
}, 1, "onsen", true)).Put("toilet", Fn((V _arrowThis1703, int _argc1696, V S_1702, V _a1699, V _a1700, V _a1701, V[] _rest1697) => {
return NewObj(3).Put("w", ((V)(56D))).Put("d", ((V)(70D))).Put("build", Fn((V _arrowThis1711, int _argc1704, V P_1710, V _a1707, V _a1708, V _a1709, V[] _rest1705) => {
V k_1712 = default;
V c_1713 = default;
V o_1714 = default;
double @base_1715 = 0;
k_1712 = Get(S_1702, "k");
c_1713 = ((V)((SEqS(k_1712, "royal") ? "#f4f2ee" : (SEqS(k_1712, "candy") ? "#f4f2ee" : "#f4f2ee"))));
o_1714 = Arr();
@base_1715 = ((SEqS(k_1712, "mod") || SEqS(k_1712, "candy")) ? 14D : 0D);
if (!(NumTruthy(@base_1715))) {
Invoke(o_1714, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(8D)), ((V)(12D)), ((V)(24D)), c_1713, NewObj(4).Put("rz", ((V)(14D))).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.1))), Arr(((V)(24D)), ((V)(0D)), ((V)(0.8))))).Put("mat", ((V)("cer"))).V));
}
Invoke(o_1714, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(10D)), ((V)(22D)), ((V)(14D)), c_1713, NewObj(4).Put("rz", ((V)(26D))).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.75))), Arr(((V)(14D)), ((V)(0D)), ((V)(1D))))).Put("mat", ((V)("cer"))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(10D)), ((V)(22D)), ((V)(3D)), (SEqS(k_1712, "junk") ? ((V)("#c9a46a")) : (SEqS(k_1712, "royal") ? ((V)("#f6efe0")) : WH_30)), NewObj(2).Put("rz", ((V)(26D))).Put("n", ((V)(18D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(38.4)), ((V)(10D)), ((V)(15D)), ((V)(0.8)), ((V)("#9fd2f2")), NewObj(3).Put("rz", ((V)(18D))).Put("n", ((V)(16D))).Put("noOut", ((V)(1D))).V));
if (SEqS(k_1712, "junk")) {
Invoke(o_1714, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(24D)), ((V)((-22D))), ((V)(6D)), ((V)(100D)), ((V)("#9aa1a6")), NewObj(1).Put("n", ((V)(8D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(120D)), ((V)((-24D))), ((V)(46D)), ((V)(24D)), ((V)(18D)), c_1713, NewObj(2).Put("r", ((V)(3D))).Put("mat", ((V)("cer"))).V), Call(cyl_13, V.Undef, ((V)(18D)), ((V)(80D)), ((V)((-14D))), ((V)(0.6)), ((V)(40D)), ((V)("#8a8f94")), NewObj(1).Put("n", ((V)(4D))).V), Call(ball_14, V.Undef, ((V)(18D)), ((V)(76D)), ((V)((-14D))), ((V)(2.4)), ((V)("#3a3a3e")), NewObj(1).Put("k", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(24D)), ((V)((-22D))), ((V)(36D)), ((V)(4D)), ((V)(6D)), ((V)("#a0603a")), NewObj(2).Put("r", ((V)(1D))).Put("op", ((V)(0.6))).V));
return o_1714;
}
if (SEqS(k_1712, "mod")) {
Invoke(o_1714, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-30D))), ((V)(54D)), ((V)(110D)), ((V)(6D)), ((V)("#3e4046")), NewObj(2).Put("r", ((V)(3D))).Put("rb", ((V)(3D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(76D)), ((V)((-26.6))), ((V)(20D)), ((V)(12D)), ((V)(1D)), ((V)("#d5dde2")), NewObj(1).Put("r", ((V)(3D))).V));
return o_1714;
}
Invoke(o_1714, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(26D)), ((V)((-22D))), ((V)(46D)), ((V)((SEqS(k_1712, "candy") ? 40D : 46D))), ((V)(18D)), c_1713, NewObj(3).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).Put("mat", ((V)("cer"))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)((SEqS(k_1712, "candy") ? 66D : 72D))), ((V)((-22D))), ((V)(48D)), ((V)(4D)), ((V)(20D)), (SEqS(k_1712, "royal") ? GOLD_27 : c_1713), NewObj(1).Put("r", ((V)(6D))).V));
if (SEqS(k_1712, "royal")) {
Invoke(o_1714, "push", Call(box_11, V.Undef, ((V)(22D)), ((V)(44D)), ((V)((-2D))), ((V)(5D)), ((V)(6D)), ((V)(16D)), ((V)("#3e4046")), NewObj(1).Put("r", ((V)(2D))).V), Call(disc_18, V.Undef, ((V)(22D)), ((V)(47D)), ((V)(6D)), ((V)(1.4)), ((V)(0.6)), ((V)("#6ac8ff")), Call(em_34, V.Undef)), Call(box_11, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(10D)), ((V)(44D)), ((V)(1D)), ((V)(44D)), GOLD_27, NewObj(2).Put("r", ((V)(18D))).Put("rings", Arr(Arr(((V)(38D)), ((V)(0D))), Arr(((V)(39.2)), ((V)(0D))))).V));
}
if (SEqS(k_1712, "cot")) {
Invoke(o_1714, "push", Call(ball_14, V.Undef, ((V)(20D)), ((V)(64D)), ((V)((-12D))), ((V)(2.6)), CH_28, NewObj(1).Put("k", ((V)(3D))).V));
}
if (SEqS(k_1712, "candy")) {
Invoke(o_1714, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)((-8D))), ((V)(0D)), ((V)(20D)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(3).Put("sx", ((V)(1.4))).Put("sy", ((V)(0.25))).Put("op", ((V)(0.4))).V)), Call(slab_15, V.Undef, ((V)(0D)), ((V)(50D)), ((V)((-12.6))), ((V)(30D)), ((V)(6D)), ((V)(0.6)), ((V)("#8f7bff")), Call(em_34, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)));
}
return o_1714;
return default;
}, 1, "build", true)).V;
}, 1, "toilet", true)).Put("sauna", Fn((V _arrowThis1723, int _argc1716, V S_1722, V _a1719, V _a1720, V _a1721, V[] _rest1717) => {
return NewObj(4).Put("w", ((V)(130D))).Put("d", ((V)(110D))).Put("glow", Fn((V _arrowThis1730, int _argc1724, V _a1726, V _a1727, V _a1728, V _a1729, V[] _rest1725) => {
return (SEqS(Get(S_1722, "k"), "candy") ? NewObj(3).Put("y", ((V)(50D))).Put("r", ((V)(80D))).Put("c", ((V)("url(#gNeon)"))).V : V.Null);
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1738, int _argc1731, V P_1737, V _a1734, V _a1735, V _a1736, V[] _rest1732) => {
V k_1739 = default;
V o_1740 = default;
V st_1741 = default;
k_1739 = Get(S_1722, "k");
o_1740 = Arr();
st_1741 = Fn((V _arrowThis1752, int _argc1742, V x_1748, V y_1749, V z_1750, V s_1751, V[] _rest1743) => {
return Invoke(o_1740, "push", Call(ball_14, V.Undef, x_1748, y_1749, z_1750, ((V)((10D * ToNum(s_1751)))), WH_30, Call(em_34, V.Undef, NewObj(3).Put("sy", ((V)(1.3))).Put("op", ((V)(0.35))).Put("k", ((V)(4D))).V)));
}, 4, "", true);
if (SEqS(k_1739, "junk")) {
Invoke(o_1740, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(20D)), ((V)(30D)), ((V)("#9aa1a6")), NewObj(3).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.85))), Arr(((V)(30D)), ((V)(0D)), ((V)(1D))))).Put("mat", ((V)("metal"))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(20D)), ((V)(2D)), ((V)("#b5bcc0")), NewObj(1).Put("n", ((V)(14D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)), ((V)(17D)), ((V)(1D)), ((V)("#9fd2f2")), NewObj(2).Put("n", ((V)(14D))).Put("noOut", ((V)(1D))).V), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(20D)), ((V)(20D)), ((V)(1.2)), ((V)(1.2)), ((V)(PI_33)), ((V)((PI_33 * 2D))), ((V)("#6b6f74")), NewObj(1).Put("n", ((V)(8D))).V));
Call(st_1741, V.Undef, ((V)((-4D))), ((V)(34D)), ((V)(0D)), ((V)(0.8)));
Call(st_1741, V.Undef, ((V)(6D)), ((V)(50D)), ((V)((-4D))), ((V)(0.9)));
return o_1740;
}
if (SEqS(k_1739, "cot")) {
Invoke(o_1740, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(74D)), ((V)(104D)), ((V)(74D)), ((V)("#9fb58c")), NewObj(3).Put("r", ((V)(16D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(70D)), ((V)(37.6)), ((V)(30D)), ((V)(30D)), ((V)(1D)), ((V)("#2c2d31")), NewObj(1).Put("r", ((V)(14D))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(76D)), ((V)(36D)), ((V)(12D)), ((V)("#f2d0b0")), NewObj(2).Put("sz", ((V)(0.6))).Put("k", ((V)(4D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(37.4)), ((V)(1.4)), ((V)(64D)), ((V)(0.6)), ((V)("#d5dde2")), NewObj(1).Put("r", ((V)(0D))).V));
Call(st_1741, V.Undef, ((V)((-16D))), ((V)(110D)), ((V)(0D)), ((V)(0.8)));
return o_1740;
}
if (SEqS(k_1739, "mod")) {
V sl_1753 = default;
sl_1753 = Arr();
{
double i_1754 = 0;
i_1754 = 0D;
while (true) {
if (!((i_1754 < 10D))) break;
double a_1756 = 0;
a_1756 = ((PI_33 * i_1754) / 9D);
Invoke(sl_1753, "push", Call(solid_10, V.Undef, NewObj(8).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(60D)))).Put("a", ((V)(56D))).Put("b", ((V)(56D))).Put("n", ((V)(20D))).Put("rings", Arr(Arr(((V)((-60D))), ((V)(0D))), Arr(((V)(60D)), ((V)(0D))))).Put("col", Get(P_1737, "w")).V));
break;
i_1754++;
}
}
InvokeSpread(o_1740, "push", new ArrBuilder().Spread(sl_1753).Spread(Invoke(Arr(((V)((-60D))), ((V)(60D))), "map", Fn((V _arrowThis1764, int _argc1757, V x_1763, V _a1760, V _a1761, V _a1762, V[] _rest1758) => {
return Call(slabX_16, V.Undef, x_1763, ((V)(2D)), ((V)(0D)), ((V)(6D)), ((V)(116D)), ((V)(116D)), Call(shade_23, V.Undef, Get(P_1737, "w"), ((V)(0.8))), NewObj(1).Put("r", ((V)(56D))).V);
}, 1, "", true))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(100D)), ((V)(8D)), ((V)(60D)), Call(shade_23, V.Undef, Get(P_1737, "w"), ((V)(0.7))), NewObj(1).Put("r", ((V)(2D))).V)).V);
Invoke(Arr(((V)((-30D))), ((V)(0D)), ((V)(30D))), "forEach", Fn((V _arrowThis1772, int _argc1765, V x_1771, V _a1768, V _a1769, V _a1770, V[] _rest1766) => {
return Invoke(o_1740, "push", Call(slabX_16, V.Undef, x_1771, ((V)(2D)), ((V)(0D)), ((V)(2.4)), ((V)(118D)), ((V)(118D)), Call(shade_23, V.Undef, Get(P_1737, "w"), ((V)(0.62))), NewObj(1).Put("r", ((V)(58D))).V));
}, 1, "", true));
return o_1740;
}
if (SEqS(k_1739, "royal")) {
Invoke(o_1740, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(126D)), ((V)(150D)), ((V)(100D)), Get(P_1737, "w"), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(150D)), ((V)(0D)), ((V)(132D)), ((V)(6D)), ((V)(106D)), Call(shade_23, V.Undef, Get(P_1737, "w"), ((V)(0.8))), NewObj(1).Put("r", ((V)(3D))).V), Call(slab_15, V.Undef, ((V)((-14D))), ((V)(10D)), ((V)(50.4)), ((V)(70D)), ((V)(130D)), ((V)(1.2)), ((V)("#f2b866")), NewObj(2).Put("r", ((V)(2D))).Put("op", ((V)(0.6))).V), Call(slab_15, V.Undef, ((V)((-14D))), ((V)(30D)), ((V)(49D)), ((V)(64D)), ((V)(18D)), ((V)(12D)), Call(shade_23, V.Undef, Get(P_1737, "w"), ((V)(0.85))), NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(40D)), ((V)(70D)), ((V)(51D)), ((V)(4D)), ((V)(26D)), ((V)(3D)), GOLD_27, NewObj(1).Put("r", ((V)(2D))).V), Call(slab_15, V.Undef, ((V)((-14D))), ((V)(110D)), ((V)(50.8)), ((V)(50D)), ((V)(18D)), ((V)(0.6)), ((V)("#e8a080")), Call(em_34, V.Undef, NewObj(2).Put("r", ((V)(4D))).Put("op", ((V)(0.45))).V)));
Call(st_1741, V.Undef, ((V)((-30D))), ((V)(60D)), ((V)(40D)), ((V)(0.9)));
return o_1740;
}
Invoke(o_1740, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(44D)), ((V)("#f1eee8")), NewObj(6).Put("sx", ((V)(0.8))).Put("sz", ((V)(1.3))).Put("sy", ((V)(1.1))).Put("k", ((V)(7D))).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(22D)), ((V)(32D)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(4).Put("sx", ((V)(0.6))).Put("sy", ((V)(0.7))).Put("sz", ((V)(0.4))).Put("op", ((V)(0.55))).V)), Call(ball_14, V.Undef, ((V)((-10D))), ((V)(40D)), ((V)(34D)), ((V)(6D)), ((V)("#c9f4ff")), Call(em_34, V.Undef)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((-6D))), ((V)(0D)), ((V)(30D)), ((V)(6D)), ((V)("#3a3c48")), NewObj(2).Put("rz", ((V)(50D))).Put("n", ((V)(18D))).V));
return o_1740;
return default;
}, 1, "build", true)).V;
}, 1, "sauna", true)).Put("greenwall", Fn((V _arrowThis1780, int _argc1773, V S_1779, V _a1776, V _a1777, V _a1778, V[] _rest1774) => {
return NewObj(3).Put("w", ((V)(120D))).Put("d", ((V)(14D))).Put("build", Fn((V _arrowThis1788, int _argc1781, V P_1787, V _a1784, V _a1785, V _a1786, V[] _rest1782) => {
V k_1789 = default;
V o_1790 = default;
k_1789 = Get(S_1779, "k");
o_1790 = Arr(Call(slab_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-4D))), ((V)(120D)), ((V)(120D)), ((V)(6D)), ((V)("#8a5a34")), NewObj(2).Put("r", ((V)(3D))).Put("rb", ((V)(3D))).V));
{
double i_1791 = 0;
i_1791 = 0D;
while (true) {
if (!((i_1791 < 26D))) break;
Invoke(o_1790, "push", Call(ball_14, V.Undef, ((V)(((-50D) + ((i_1791 * 23D) % 100D)))), ((V)((8D + ((i_1791 * 37D) % 104D)))), ((V)(0D)), ((V)((7D + ((i_1791 % 3D) * 2D)))), GetIdx(Arr(((V)("#5fa84a")), ((V)("#6fbf54")), ((V)("#4f9a3e")), ((V)("#7ac860"))), (i_1791 % 4D)), NewObj(3).Put("sz", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V));
i_1791++;
}
}
if (!SEqS(k_1789, "junk")) {
Invoke(o_1790, "push", Call(cyl_13, V.Undef, ((V)(40D)), ((V)(90D)), ((V)(6D)), ((V)(2D)), ((V)(30D)), ((V)("#d8c27a")), NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_13, V.Undef, ((V)(40D)), ((V)(88D)), ((V)(9D)), ((V)(1.4)), ((V)(1D)), ((V)("#9fd2f2")), NewObj(1).Put("n", ((V)(6D))).V), Call(box_11, V.Undef, ((V)(30D)), ((V)(0D)), ((V)(8D)), ((V)(40D)), ((V)(14D)), ((V)(20D)), ((V)("#b9b4aa")), NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(30D)), ((V)(14D)), ((V)(8D)), ((V)(36D)), ((V)(1D)), ((V)(16D)), ((V)("#9fd8ee")), NewObj(1).Put("r", ((V)(3D))).V));
}
return o_1790;
return default;
}, 1, "build", true)).V;
}, 1, "greenwall", true)).Put("washer", Fn((V _arrowThis1800, int _argc1793, V S_1799, V _a1796, V _a1797, V _a1798, V[] _rest1794) => {
return NewObj(3).Put("w", ((V)(66D))).Put("d", ((V)(60D))).Put("build", Fn((V _arrowThis1808, int _argc1801, V P_1807, V _a1804, V _a1805, V _a1806, V[] _rest1802) => {
V k_1809 = default;
V c_1810 = default;
k_1809 = Get(S_1799, "k");
c_1810 = (SEqS(k_1809, "royal") ? Get(P_1807, "w") : ((V)("#f1eee8")));
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(62D)), ((V)(84D)), ((V)(56D)), c_1810, NewObj(2).Put("r", ((V)(4D))).Put("bev", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(70D)), ((V)(28.4)), ((V)(58D)), ((V)(12D)), ((V)(1D)), (SEqS(k_1809, "royal") ? Call(shade_23, V.Undef, c_1810, ((V)(0.85))) : ((V)("#d5dde2"))), NewObj(1).Put("r", ((V)(2D))).V), Call(disc_18, V.Undef, ((V)(16D)), ((V)(76D)), ((V)(28.8)), ((V)(3D)), ((V)(1D)), ((V)("#3e4046"))), Call(disc_18, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(28D)), ((V)(22D)), ((V)(2D)), (SEqS(k_1809, "royal") ? GOLD_27 : ((V)("#c9d3d8")))), Call(disc_18, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(30D)), ((V)(16D)), ((V)(1D)), ((V)("#7aa6c2")), NewObj(1).Put("op", ((V)(0.85))).V), Call(ball_14, V.Undef, ((V)((-6D))), ((V)(34D)), ((V)(30D)), ((V)(7D)), WH_30, NewObj(3).Put("sz", ((V)(0.3))).Put("k", ((V)(3D))).Put("op", ((V)(0.6))).V));
return default;
}, 1, "build", true)).V;
}, 1, "washer", true)).Put("hotplate", Fn((V _arrowThis1818, int _argc1811, V S_1817, V _a1814, V _a1815, V _a1816, V[] _rest1812) => {
return NewObj(3).Put("w", ((V)(44D))).Put("d", ((V)(40D))).Put("build", Fn((V _arrowThis1826, int _argc1819, V P_1825, V _a1822, V _a1823, V _a1824, V[] _rest1820) => {
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(40D)), ((V)(9D)), ((V)(36D)), ((V)("#d8d2c6")), NewObj(1).Put("r", ((V)(3D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(9D)), ((V)((-2D))), ((V)(13D)), ((V)(1.6)), ((V)("#3a3a3e")), NewObj(1).Put("n", ((V)(16D))).V), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(10.6)), ((V)((-2D))), ((V)(10D)), ((V)(10D)), ((V)(1.4)), ((V)(0.8)), ((V)(0D)), ((V)((PI_33 * 2D))), ((V)("#e2554a")), NewObj(1).Put("n", ((V)(14D))).V), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(10.6)), ((V)((-2D))), ((V)(5.5)), ((V)(5.5)), ((V)(1.4)), ((V)(0.8)), ((V)(0D)), ((V)((PI_33 * 2D))), ((V)("#e2554a")), NewObj(1).Put("n", ((V)(12D))).V), Call(disc_18, V.Undef, ((V)(12D)), ((V)(4D)), ((V)(18D)), ((V)(2.4)), ((V)(1.4)), ((V)("#2c2d31"))), Call(cyl_13, V.Undef, ((V)((-14D))), ((V)(0D)), ((V)((-16D))), ((V)(0.8)), ((V)(1D)), ((V)("#3a3a3e")), NewObj(1).Put("n", ((V)(4D))).V));
}, 1, "build", true)).V;
}, 1, "hotplate", true)).Put("dishwasher", Fn((V _arrowThis1834, int _argc1827, V S_1833, V _a1830, V _a1831, V _a1832, V[] _rest1828) => {
return NewObj(3).Put("w", ((V)(64D))).Put("d", ((V)(56D))).Put("build", Fn((V _arrowThis1842, int _argc1835, V P_1841, V _a1838, V _a1839, V _a1840, V[] _rest1836) => {
V k_1843 = default;
V o_1844 = default;
V c_1845 = default;
k_1843 = Get(S_1833, "k");
o_1844 = Arr();
if (SEqS(k_1843, "junk")) {
Invoke(o_1844, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(14D)), ((V)("#7fb8d8")), NewObj(3).Put("rz", ((V)(20D))).Put("n", ((V)(18D))).Put("mat", ((V)("paint"))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(14D)), ((V)((-6D))), ((V)(60D)), ((V)(2D)), ((V)(30D)), ((V)("#d8d2c6")), NewObj(1).Put("r", ((V)(2D))).V));
Invoke(Arr(((V)((-20D))), ((V)((-10D))), ((V)(0D)), ((V)(10D)), ((V)(20D))), "forEach", Fn((V _arrowThis1854, int _argc1846, V x_1852, V i_1853, V _a1850, V _a1851, V[] _rest1847) => {
return Invoke(o_1844, "push", Call(disc_18, V.Undef, x_1852, ((V)(34D)), ((V)(((-6D) + ((ToNum(i_1853) % 2D) * 2D)))), ((V)(13D)), ((V)(1.6)), (NumTruthy((ToNum(i_1853) % 2D)) ? WH_30 : ((V)("#f2d27a")))));
}, 2, "", true));
{
double i_1855 = 0;
i_1855 = 0D;
while (true) {
if (!((i_1855 < 6D))) break;
Invoke(o_1844, "push", Call(slabX_16, V.Undef, ((V)(0D)), ((V)((16D + (i_1855 * 1D)))), ((V)(((-20D) + (i_1855 * 6D)))), ((V)(58D)), ((V)(1D)), ((V)(1D)), ((V)("#d8d2c6")), NewObj(1).Put("r", ((V)(0D))).V));
i_1855++;
}
}
return o_1844;
}
if (SEqS(k_1843, "cot")) {
Invoke(o_1844, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(50D)), ((V)(40D)), ((V)(44D)), ((V)("#f1eee8")), NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(22.4)), ((V)(42D)), ((V)(26D)), ((V)(1D)), ((V)("#bfe4ff")), NewObj(2).Put("r", ((V)(4D))).Put("op", ((V)(0.7))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(32D)), ((V)(22.6)), ((V)(42D)), ((V)(5D)), ((V)(0.6)), ((V)("#3e4046")), NewObj(1).Put("r", ((V)(2D))).V));
return o_1844;
}
c_1845 = (SEqS(k_1843, "royal") ? Get(P_1841, "w") : ((V)((SEqS(k_1843, "candy") ? "#2a2630" : "#c9d3d8"))));
Invoke(o_1844, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(62D)), ((V)(78D)), ((V)(54D)), c_1845, NewObj(2).Put("r", ((V)(3D))).Put("bev", ((V)(2D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(70D)), ((V)(27.4)), ((V)(60D)), ((V)(6D)), ((V)(0.8)), ((V)((SEqS(k_1843, "candy") ? "#8fe8ff" : "#3e4046"))), NewObj(2).Put("r", ((V)(1D))).Put("emit", ((V)((SEqS(k_1843, "candy") ? 1D : 0D)))).V), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(62D)), ((V)(30D)), ((V)(44D)), ((V)(3D)), ((V)(3D)), (SEqS(k_1843, "royal") ? GOLD_27 : CH_28), NewObj(1).Put("r", ((V)(1.5))).V));
if (SEqS(k_1843, "royal")) {
Invoke(o_1844, "push", Call(slabX_16, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(27.6)), ((V)(58D)), ((V)(1.4)), ((V)(0.8)), Call(shade_23, V.Undef, c_1845, ((V)(0.7)))), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(30D)), ((V)(30D)), ((V)(3D)), ((V)(3D)), GOLD_27, NewObj(1).Put("r", ((V)(1.5))).V));
}
if (SEqS(k_1843, "candy")) {
Invoke(o_1844, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)(80D)), ((V)(0D)), ((V)(8D)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(1).Put("sy", ((V)(0.5))).V)));
{
double i_1857 = 0;
i_1857 = 0D;
while (true) {
if (!((i_1857 < 4D))) break;
Invoke(o_1844, "push", Call(disc_18, V.Undef, ((V)(((-18D) + (i_1857 * 12D)))), ((V)(84D)), ((V)((-14D))), ((V)(8D)), ((V)(1.4)), ((V)("#f4f2ee"))));
i_1857++;
}
}
}
return o_1844;
return default;
}, 1, "build", true)).V;
}, 1, "dishwasher", true)).Put("cart", Fn((V _arrowThis1866, int _argc1859, V S_1865, V _a1862, V _a1863, V _a1864, V[] _rest1860) => {
return NewObj(3).Put("w", ((V)(60D))).Put("d", ((V)(42D))).Put("build", Fn((V _arrowThis1874, int _argc1867, V P_1873, V _a1870, V _a1871, V _a1872, V[] _rest1868) => {
V k_1875 = default;
V m_1876 = default;
V top_1877 = default;
V o_1878 = default;
k_1875 = Get(S_1865, "k");
m_1876 = (SEqS(k_1875, "junk") ? ((V)("#d8d2c6")) : (SEqS(k_1875, "cot") ? Get(P_1873, "w") : (SEqS(k_1875, "mod") ? GOLD_27 : ((V)((SEqS(k_1875, "royal") ? "#c87a46" : "#d5dde2"))))));
top_1877 = (SEqS(k_1875, "royal") ? ((V)("#efebe5")) : (SEqS(k_1875, "mod") ? GL_32 : m_1876));
o_1878 = Arr();
if (SEqS(k_1875, "candy")) {
InvokeSpread(o_1878, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(50D)), ((V)(44D)), ((V)(36D)), ((V)("#f1eee8")), NewObj(2).Put("r", ((V)(12D))).Put("mat", ((V)("cer"))).V)).Add(Call(slab_15, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(18.6)), ((V)(30D)), ((V)(12D)), ((V)(1D)), ((V)("#2a2630")), NewObj(1).Put("r", ((V)(5D))).V)).Add(Call(disc_18, V.Undef, ((V)((-6D))), ((V)(40D)), ((V)(19.8)), ((V)(2.2)), ((V)(0.6)), ((V)("#8fe8ff")), Call(em_34, V.Undef))).Add(Call(disc_18, V.Undef, ((V)(6D)), ((V)(40D)), ((V)(19.8)), ((V)(2.2)), ((V)(0.6)), ((V)("#8fe8ff")), Call(em_34, V.Undef))).Add(Call(slabX_16, V.Undef, ((V)(0D)), ((V)(48D)), ((V)(0D)), ((V)(70D)), ((V)(4D)), ((V)(4D)), ((V)("#c9d0d6")), NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(54D)), ((V)(0D)), ((V)(46D)), ((V)(3D)), ((V)(32D)), ((V)("#d5dde2")), NewObj(1).Put("r", ((V)(4D))).V)).Add(Call(cyl_13, V.Undef, ((V)((-8D))), ((V)(57D)), ((V)(0D)), ((V)(5D)), ((V)(12D)), ((V)("#f2c94c")), NewObj(1).Put("n", ((V)(10D))).V)).Spread(Invoke(Arr(Arr(((V)((-18D))), ((V)(12D))), Arr(((V)(18D)), ((V)(12D))), Arr(((V)((-18D))), ((V)((-12D)))), Arr(((V)(18D)), ((V)((-12D))))), "map", Fn((V _arrowThis1890, int _argc1879, V _a1881, V _a1882, V _a1883, V _a1884, V[] _rest1880) => {
V x_1887 = default;
V z_1889 = default;
{ V _t1885 = ListOf(_a1881);
{ V _t1886 = GetIdx(_t1885, 0D);
x_1887 = _t1886; }
{ V _t1888 = GetIdx(_t1885, 1D);
z_1889 = _t1888; }
}
return Call(ball_14, V.Undef, x_1887, ((V)(0D)), z_1889, ((V)(5D)), ((V)("#3a3c48")), NewObj(1).Put("k", ((V)(3D))).V);
}, 1, "", true))).V);
return o_1878;
}
Invoke(Arr(Arr(((V)((-26D))), ((V)((-18D)))), Arr(((V)(26D)), ((V)((-18D)))), Arr(((V)((-26D))), ((V)(18D))), Arr(((V)(26D)), ((V)(18D)))), "forEach", Fn((V _arrowThis1902, int _argc1891, V _a1893, V _a1894, V _a1895, V _a1896, V[] _rest1892) => {
V x_1899 = default;
V z_1901 = default;
{ V _t1897 = ListOf(_a1893);
{ V _t1898 = GetIdx(_t1897, 0D);
x_1899 = _t1898; }
{ V _t1900 = GetIdx(_t1897, 1D);
z_1901 = _t1900; }
}
return Invoke(o_1878, "push", Call(cyl_13, V.Undef, x_1899, ((V)(6D)), z_1901, ((V)(1.8)), ((V)(74D)), m_1876, NewObj(1).Put("n", ((V)(8D))).V), Call(ball_14, V.Undef, x_1899, ((V)(0D)), z_1901, ((V)(3.4)), ((V)("#3a3a3e")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "", true));
Invoke(Arr(((V)(10D)), ((V)(40D)), ((V)(76D))), "forEach", Fn((V _arrowThis1911, int _argc1903, V y_1909, V i_1910, V _a1907, V _a1908, V[] _rest1904) => {
return Invoke(o_1878, "push", Call(box_11, V.Undef, ((V)(0D)), y_1909, ((V)(0D)), ((V)(56D)), ((V)(3D)), ((V)(40D)), (SEqN(i_1910, 2D) ? top_1877 : m_1876), NewObj(2).Put("r", ((V)(2D))).Put("op", ((V)(((SEqS(k_1875, "mod") && SEqN(i_1910, 2D)) ? 0.7 : 1D)))).V));
}, 2, "", true));
if (SEqS(k_1875, "royal")) {
Invoke(Arr(Arr(((V)((-10D))), ((V)(0D))), Arr(((V)(10D)), ((V)(0D)))), "forEach", Fn((V _arrowThis1921, int _argc1912, V _a1914, V _a1915, V _a1916, V _a1917, V[] _rest1913) => {
V x_1920 = default;
{ V _t1918 = ListOf(_a1914);
{ V _t1919 = GetIdx(_t1918, 0D);
x_1920 = _t1919; }
}
return Invoke(o_1878, "push", Call(cyl_13, V.Undef, x_1920, ((V)(92D)), ((V)((-14D))), ((V)(9D)), ((V)(5D)), ((V)("#c87a46")), NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_13, V.Undef, x_1920, ((V)(116D)), ((V)((-14D))), ((V)(0.8)), ((V)(1D)), ((V)("#c87a46"))));
}, 1, "", true));
Invoke(o_1878, "push", Call(slabX_16, V.Undef, ((V)(0D)), ((V)(110D)), ((V)((-18D))), ((V)(60D)), ((V)(2D)), ((V)(2D)), ((V)("#c87a46"))));
}
Invoke(o_1878, "push", Call(cyl_13, V.Undef, ((V)((-12D))), ((V)(79D)), ((V)(0D)), ((V)(4D)), ((V)(10D)), ((V)((SEqS(k_1875, "mod") ? "#d9483b" : "#a6d8ff"))), NewObj(2).Put("n", ((V)(10D))).Put("op", ((V)(0.9))).V), Call(box_11, V.Undef, ((V)(10D)), ((V)(43D)), ((V)(0D)), ((V)(22D)), ((V)(10D)), ((V)(18D)), ((V)((SEqS(k_1875, "cot") ? "#f1eee8" : "#e3946a"))), NewObj(1).Put("r", ((V)(2D))).V), Call(ball_14, V.Undef, ((V)(14D)), ((V)(79D)), ((V)(4D)), ((V)(5D)), ((V)("#f2c94c")), NewObj(1).Put("k", ((V)(3D))).V));
return o_1878;
return default;
}, 1, "build", true)).V;
}, 1, "cart", true)).Put("coffeeMk", Fn((V _arrowThis1929, int _argc1922, V S_1928, V _a1925, V _a1926, V _a1927, V[] _rest1923) => {
return NewObj(3).Put("w", ((V)(40D))).Put("d", ((V)(34D))).Put("build", Fn((V _arrowThis1937, int _argc1930, V P_1936, V _a1933, V _a1934, V _a1935, V[] _rest1931) => {
V k_1938 = default;
V c_1939 = default;
V o_1940 = default;
k_1938 = Get(S_1928, "k");
c_1939 = (SEqS(k_1938, "junk") ? ((V)("#3a3a3e")) : (SEqS(k_1938, "royal") ? ((V)("#2c2d31")) : (SEqS(k_1938, "candy") ? ((V)("#f1eee8")) : Get(P_1936, "a"))));
o_1940 = Arr();
if ((SEqS(k_1938, "mod") || SEqS(k_1938, "royal"))) {
Invoke(o_1940, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(44D)), ((V)(38D)), ((V)(30D)), (SEqS(k_1938, "mod") ? CH_28 : c_1939), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(0D)), ((V)(44D)), ((V)(4D)), ((V)(30D)), (SEqS(k_1938, "royal") ? GOLD_27 : ((V)("#9aa3a8"))), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(12D)), ((V)(30D)), ((V)(8D)), ((V)(10D)), ((V)("#9aa3a8")), NewObj(1).Put("r", ((V)(2D))).V), Call(cyl_13, V.Undef, ((V)((-6D))), ((V)(4D)), ((V)(12D)), ((V)(3D)), ((V)(8D)), CR_29, NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_13, V.Undef, ((V)(6D)), ((V)(4D)), ((V)(12D)), ((V)(3D)), ((V)(8D)), CR_29, NewObj(1).Put("n", ((V)(8D))).V), Call(disc_18, V.Undef, ((V)((-10D))), ((V)(32D)), ((V)(15.2)), ((V)(3D)), ((V)(1D)), ((V)("#3e4046"))), Call(disc_18, V.Undef, ((V)(10D)), ((V)(32D)), ((V)(15.2)), ((V)(3D)), ((V)(1D)), ((V)("#3e4046"))), Call(cyl_13, V.Undef, ((V)(26D)), ((V)(0D)), ((V)(0D)), ((V)(7D)), ((V)(30D)), ((V)("#3e4046")), NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(20D)), ((V)(0D)), ((V)(1D))), Arr(((V)(30D)), ((V)(0D)), ((V)(1.3))))).V), Call(cyl_13, V.Undef, ((V)(26D)), ((V)(30D)), ((V)(0D)), ((V)(7D)), ((V)(12D)), ((V)("#c49a62")), NewObj(2).Put("n", ((V)(10D))).Put("op", ((V)(0.8))).V));
return o_1940;
}
Invoke(o_1940, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-4D))), ((V)(30D)), ((V)(44D)), ((V)(22D)), c_1939, NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(2D)), ((V)(30D)), ((V)(6D)), ((V)(30D)), c_1939, NewObj(1).Put("r", ((V)(4D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(8D)), ((V)(9D)), ((V)(18D)), ((V)("#cfe8f2")), NewObj(3).Put("n", ((V)(12D))).Put("op", ((V)(0.6))).Put("mat", ((V)("cer"))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(8D)), ((V)(8.6)), ((V)(9D)), ((V)("#5a3a20")), NewObj(1).Put("n", ((V)(12D))).V), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(8D)), ((V)(22D)), ((V)(2D)), ((V)(18D)), c_1939, NewObj(1).Put("r", ((V)(1D))).V));
if (SEqS(k_1938, "junk")) {
Invoke(o_1940, "push", Call(slab_15, V.Undef, ((V)(4D)), ((V)(8D)), ((V)(17.2)), ((V)(1D)), ((V)(12D)), ((V)(0.4)), WH_30, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}
if (SEqS(k_1938, "candy")) {
Invoke(o_1940, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)(52D)), ((V)(2D)), ((V)(8D)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(1).Put("op", ((V)(0.6))).V)), Call(disc_18, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(7.4)), ((V)(3D)), ((V)(0.6)), ((V)("#8f7bff")), Call(em_34, V.Undef)));
}
return o_1940;
return default;
}, 1, "build", true)).V;
}, 1, "coffeeMk", true)).Put("pergola", Fn((V _arrowThis1948, int _argc1941, V S_1947, V _a1944, V _a1945, V _a1946, V[] _rest1942) => {
return NewObj(3).Put("w", ((V)(170D))).Put("d", ((V)(130D))).Put("build", Fn((V _arrowThis1956, int _argc1949, V P_1955, V _a1952, V _a1953, V _a1954, V[] _rest1950) => {
V k_1957 = default;
V o_1958 = default;
V c_1959 = default;
k_1957 = Get(S_1947, "k");
o_1958 = Arr();
if (SEqS(k_1957, "junk")) {
Invoke(Arr(Arr(((V)((-70D))), ((V)((-50D)))), Arr(((V)(70D)), ((V)((-50D)))), Arr(((V)((-60D))), ((V)(50D))), Arr(((V)(64D)), ((V)(50D)))), "forEach", Fn((V _arrowThis1972, int _argc1960, V _a1962, V i_1966, V _a1964, V _a1965, V[] _rest1961) => {
V x_1969 = default;
V z_1971 = default;
{ V _t1967 = ListOf(_a1962);
{ V _t1968 = GetIdx(_t1967, 0D);
x_1969 = _t1968; }
{ V _t1970 = GetIdx(_t1967, 1D);
z_1971 = _t1970; }
}
return Invoke(o_1958, "push", Call(cyl_13, V.Undef, x_1969, ((V)(0D)), z_1971, ((V)(2D)), ((V)((90D + ((ToNum(i_1966) % 2D) * 8D)))), ((V)("#c9a46a")), NewObj(1).Put("n", ((V)(6D))).V));
}, 2, "", true));
Invoke(o_1958, "push", Call(solid_10, V.Undef, NewObj(10).Put("ax", ((V)("y"))).Put("sh", ((V)("rr"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("a", ((V)(78D))).Put("b", ((V)(58D))).Put("r", ((V)(4D))).Put("rings", Arr(Arr(((V)(92D)), ((V)(0D))), Arr(((V)(96D)), ((V)((-6D)))))).Put("col", ((V)("#3f7fbf"))).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).V), Call(slab_15, V.Undef, ((V)((-50D))), ((V)(70D)), ((V)(58D)), ((V)(30D)), ((V)(26D)), ((V)(1D)), ((V)("#3f7fbf")), NewObj(2).Put("r", ((V)(4D))).Put("soft", ((V)(1D))).V));
return o_1958;
}
if (SEqS(k_1957, "cot")) {
V C_1973 = default;
Invoke(o_1958, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(6D)), ((V)("#3e3e42")), NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(2.4)), ((V)(120D)), ((V)("#f4efe6")), NewObj(1).Put("n", ((V)(8D))).V));
C_1973 = Arr(((V)("#5b8fd0")), WH_30);
{
double i_1974 = 0;
i_1974 = 0D;
while (true) {
if (!((i_1974 < 8D))) break;
double a0_1976 = 0;
double a1_1977 = 0;
a0_1976 = (((i_1974 / 8D) * PI_33) * 2D);
a1_1977 = ((((i_1974 + 1D) / 8D) * PI_33) * 2D);
Invoke(o_1958, "push", Call(solid_10, V.Undef, NewObj(13).Put("ax", ((V)("y"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("a", ((V)(82D))).Put("b", ((V)(82D))).Put("th", ((V)(80D))).Put("a0", ((V)(a0_1976))).Put("a1", ((V)(a1_1977))).Put("n", ((V)(3D))).Put("rings", Arr(Arr(((V)(100D)), ((V)(0D)), ((V)(1D))), Arr(((V)(128D)), ((V)(0D)), ((V)(0.04))))).Put("col", GetIdx(C_1973, (i_1974 % 2D))).Put("cv", ((V)(0D))).Put("mat", ((V)("fab"))).V));
i_1974++;
}
}
return o_1958;
}
if (SEqS(k_1957, "candy")) {
Invoke(o_1958, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)("#cfe8f2")), NewObj(5).Put("sy", ((V)(1D))).Put("k", ((V)(7D))).Put("n", ((V)(20D))).Put("op", ((V)(0.32))).Put("mat", ((V)("cer"))).V), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)(80D)), ((V)(3D)), ((V)(4D)), ((V)(0D)), ((V)((PI_33 * 2D))), ((V)("#d5dde2")), NewObj(1).Put("n", ((V)(20D))).V));
{
double i_1978 = 0;
i_1978 = 0D;
while (true) {
if (!((i_1978 < 4D))) break;
Invoke(o_1958, "push", Call(solid_10, V.Undef, NewObj(12).Put("ax", ((V)("y"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("a", ((V)(80D))).Put("b", ((V)(80D))).Put("th", ((V)(2D))).Put("a0", ((V)(((i_1978 * PI_33) / 2D)))).Put("a1", ((V)((((i_1978 * PI_33) / 2D) + 0.06)))).Put("n", ((V)(1D))).Put("rings", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(80D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(140D)), ((V)(0D)), ((V)(0.05))))).Put("col", ((V)("#d5dde2"))).Put("cv", ((V)(0D))).V));
i_1978++;
}
}
return o_1958;
}
c_1959 = (SEqS(k_1957, "royal") ? ((V)("#c9cfd3")) : Get(P_1955, "w"));
Invoke(Arr(Arr(((V)((-74D))), ((V)((-54D)))), Arr(((V)(74D)), ((V)((-54D)))), Arr(((V)((-74D))), ((V)(54D))), Arr(((V)(74D)), ((V)(54D)))), "forEach", Fn((V _arrowThis1991, int _argc1980, V _a1982, V _a1983, V _a1984, V _a1985, V[] _rest1981) => {
V x_1988 = default;
V z_1990 = default;
{ V _t1986 = ListOf(_a1982);
{ V _t1987 = GetIdx(_t1986, 0D);
x_1988 = _t1987; }
{ V _t1989 = GetIdx(_t1986, 1D);
z_1990 = _t1989; }
}
return Invoke(o_1958, "push", Call(box_11, V.Undef, x_1988, ((V)(0D)), z_1990, ((V)(9D)), ((V)(134D)), ((V)(9D)), c_1959, NewObj(1).Put("r", ((V)(1D))).V));
}, 1, "", true));
Invoke(Arr(((V)((-60D))), ((V)(60D))), "forEach", Fn((V _arrowThis1999, int _argc1992, V z_1998, V _a1995, V _a1996, V _a1997, V[] _rest1993) => {
return Invoke(o_1958, "push", Call(slabX_16, V.Undef, ((V)(0D)), ((V)(128D)), z_1998, ((V)(166D)), ((V)(8D)), ((V)(6D)), c_1959, NewObj(1).Put("r", ((V)(1D))).V));
}, 1, "", true));
{
double i_2000 = 0;
i_2000 = 0D;
while (true) {
if (!((i_2000 < 8D))) break;
Invoke(o_1958, "push", Call(box_11, V.Undef, ((V)(((-70D) + (i_2000 * 20D)))), ((V)(136D)), ((V)(0D)), ((V)((SEqS(k_1957, "royal") ? 14D : 5D))), ((V)(4D)), ((V)(132D)), Call(shade_23, V.Undef, c_1959, ((V)(1.06))), NewObj(1).Put("r", ((V)(1D))).V));
i_2000++;
}
}
if (SEqS(k_1957, "mod")) {
{
double i_2002 = 0;
i_2002 = 0D;
while (true) {
if (!((i_2002 < 14D))) break;
Invoke(o_1958, "push", Call(ball_14, V.Undef, ((V)(((-70D) + ((i_2002 * 37D) % 140D)))), ((V)((108D + ((i_2002 % 3D) * 8D)))), ((V)(((-54D) + ((i_2002 * 53D) % 108D)))), ((V)(6D)), ((V)((NumTruthy((i_2002 % 2D)) ? "#b9a6e0" : "#9a86d0"))), NewObj(3).Put("sy", ((V)(1.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
i_2002++;
}
}
}
if (SEqS(k_1957, "royal")) {
Invoke(o_1958, "push", Call(slab_15, V.Undef, ((V)((-74D))), ((V)(20D)), ((V)(56D)), ((V)(14D)), ((V)(108D)), ((V)(2D)), ((V)("#f4efe6")), NewObj(2).Put("r", ((V)(3D))).Put("soft", ((V)(1D))).V), Call(slab_15, V.Undef, ((V)(74D)), ((V)(20D)), ((V)(56D)), ((V)(14D)), ((V)(108D)), ((V)(2D)), ((V)("#f4efe6")), NewObj(2).Put("r", ((V)(3D))).Put("soft", ((V)(1D))).V));
}
return o_1958;
return default;
}, 1, "build", true)).V;
}, 1, "pergola", true)).Put("firepit", Fn((V _arrowThis2011, int _argc2004, V S_2010, V _a2007, V _a2008, V _a2009, V[] _rest2005) => {
return NewObj(6).Put("w", ((V)(90D))).Put("d", ((V)(90D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis2018, int _argc2012, V _a2014, V _a2015, V _a2016, V _a2017, V[] _rest2013) => {
return NewObj(2).Put("y", ((V)(26D))).Put("r", ((V)(60D))).V;
}, 0, "glow", true)).Put("fx", Fn((V _arrowThis2026, int _argc2019, V c_2025, V _a2022, V _a2023, V _a2024, V[] _rest2020) => {
return Invoke(H_46, "fire", c_2025, Get(S_2010, "_fl"));
}, 1, "fx", true)).Put("build", Fn((V _arrowThis2034, int _argc2027, V P_2033, V _a2030, V _a2031, V _a2032, V[] _rest2028) => {
V k_2035 = default;
V o_2036 = default;
V FL_2037 = default;
V fl_2038 = default;
k_2035 = Get(S_2010, "k");
o_2036 = Arr();
FL_2037 = Set(S_2010, "_fl", Arr());
fl_2038 = Fn((V _arrowThis2049, int _argc2039, V x_2045, V y_2046, V z_2047, V s_2048, V[] _rest2040) => {
return Invoke(FL_2037, "push", Arr(x_2045, y_2046, z_2047, s_2048));
}, 4, "", true);
if (SEqS(k_2035, "junk")) {
{
double i_2050 = 0;
i_2050 = 0D;
while (true) {
if (!((i_2050 < 10D))) break;
double a_2052 = 0;
a_2052 = (((i_2050 / 10D) * PI_33) * 2D);
Invoke(o_2036, "push", Call(box_11, V.Undef, ((V)((FdLibm.Cos(a_2052) * 32D))), ((V)(0D)), ((V)((FdLibm.Sin(a_2052) * 26D))), ((V)(18D)), ((V)(9D)), ((V)(10D)), ((V)((NumTruthy((i_2050 % 3D)) ? "#b8664a" : "#a85a40"))), NewObj(2).Put("r", ((V)(1D))).Put("yaw", ((V)((-a_2052)))).V));
i_2050++;
}
}
Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "forEach", Fn((V _arrowThis2060, int _argc2053, V i_2059, V _a2056, V _a2057, V _a2058, V[] _rest2054) => {
return Invoke(o_2036, "push", Call(cyl_13, V.Undef, ((V)(((-8D) + (ToNum(i_2059) * 8D)))), ((V)(0D)), ((V)(0D)), ((V)(2D)), ((V)(22D)), ((V)("#8a5a34")), NewObj(1).Put("n", ((V)(6D))).V));
}, 1, "", true));
Call(fl_2038, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0D)), ((V)(1D)));
return o_2036;
}
if (SEqS(k_2035, "cot")) {
InvokeSpread(o_2036, "push", new ArrBuilder().Spread(Call(legs4_41, V.Undef, ((V)(26D)), ((V)(26D)), ((V)(14D)), ((V)("#3e3e42")), ((V)(2D)))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(40D)), ((V)(16D)), ((V)("#3e3e42")), NewObj(3).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.5))), Arr(((V)(16D)), ((V)(0D)), ((V)(1D))))).Put("mat", ((V)("metal"))).V)).V);
Call(fl_2038, V.Undef, ((V)((-6D))), ((V)(24D)), ((V)(0D)), ((V)(1.1)));
Call(fl_2038, V.Undef, ((V)(8D)), ((V)(24D)), ((V)(4D)), ((V)(0.8)));
return o_2036;
}
if (SEqS(k_2035, "mod")) {
Invoke(o_2036, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(28D)), ((V)(30D)), ((V)("#c8693f")), NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(18D)), ((V)(0D)), ((V)(1D))), Arr(((V)(30D)), ((V)(0D)), ((V)(0.55))))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(11D)), ((V)(60D)), ((V)("#c8693f")), NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(60D)), ((V)(0D)), ((V)(0.7))))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(22D)), ((V)(26D)), ((V)(18D)), ((V)(8D)), ((V)("#2c1c14")), NewObj(1).Put("r", ((V)(9D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((-2D))), ((V)(0D)), ((V)(30D)), ((V)(4D)), ((V)("#3e3e42")), NewObj(1).Put("n", ((V)(16D))).V));
Call(fl_2038, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(24D)), ((V)(0.7)));
return o_2036;
}
if (SEqS(k_2035, "royal")) {
Invoke(o_2036, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(110D)), ((V)(36D)), ((V)(60D)), ((V)("#a9a8a2")), NewObj(2).Put("r", ((V)(3D))).Put("mat", ((V)("cer"))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(0D)), ((V)(116D)), ((V)(4D)), ((V)(66D)), ((V)("#3e4046")), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(80D)), ((V)(3D)), ((V)(14D)), ((V)("#2c2d31")), NewObj(1).Put("r", ((V)(2D))).V));
Invoke(Arr(((V)((-30D))), ((V)((-10D))), ((V)(10D)), ((V)(30D))), "forEach", Fn((V _arrowThis2069, int _argc2061, V x_2067, V i_2068, V _a2065, V _a2066, V[] _rest2062) => {
return Call(fl_2038, V.Undef, x_2067, ((V)(42D)), ((V)(0D)), ((V)((0.8 + ((ToNum(i_2068) % 2D) * 0.2)))));
}, 2, "", true));
return o_2036;
}
Invoke(o_2036, "push", Call(prismZ_22, V.Undef, ((V)((-10D))), ((V)(10D)), Arr(Arr(((V)((-12D))), ((V)(0D))), Arr(((V)(12D)), ((V)(0D))), Arr(((V)(6D)), ((V)(120D))), Arr(((V)((-6D))), ((V)(120D)))), ((V)("#2a2630")), NewObj(1).Put("mat", ((V)("gloss"))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(40D)), ((V)(4D)), ((V)("#7ad8ff")), NewObj(2).Put("n", ((V)(18D))).Put("op", ((V)(0.6))).V));
Call(fl_2038, V.Undef, ((V)(0D)), ((V)(120D)), ((V)(0D)), ((V)(1.2)));
Call(fl_2038, V.Undef, ((V)(0D)), ((V)(128D)), ((V)(0D)), ((V)(0.8)));
return o_2036;
return default;
}, 1, "build", true)).V;
}, 1, "firepit", true)).Put("bbq", Fn((V _arrowThis2077, int _argc2070, V S_2076, V _a2073, V _a2074, V _a2075, V[] _rest2071) => {
return NewObj(4).Put("w", ((V)(110D))).Put("d", ((V)(60D))).Put("fx", Fn((V _arrowThis2085, int _argc2078, V c_2084, V _a2081, V _a2082, V _a2083, V[] _rest2079) => {
return Invoke(H_46, "fire", c_2084, Get(S_2076, "_fl"));
}, 1, "fx", true)).Put("build", Fn((V _arrowThis2093, int _argc2086, V P_2092, V _a2089, V _a2090, V _a2091, V[] _rest2087) => {
V k_2094 = default;
V o_2095 = default;
V FL_2096 = default;
V fl_2097 = default;
k_2094 = Get(S_2076, "k");
o_2095 = Arr();
FL_2096 = Set(S_2076, "_fl", Arr());
fl_2097 = Fn((V _arrowThis2108, int _argc2098, V x_2104, V y_2105, V z_2106, V s_2107, V[] _rest2099) => {
return Invoke(FL_2096, "push", Arr(x_2104, y_2105, z_2106, ((V)((ToNum(s_2107) * 0.85)))));
}, 4, "", true);
if (SEqS(k_2094, "junk")) {
InvokeSpread(o_2095, "push", new ArrBuilder().Spread(Call(legs4_41, V.Undef, ((V)(16D)), ((V)(10D)), ((V)(8D)), ((V)("#6b6f74")), ((V)(2D)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(50D)), ((V)(18D)), ((V)(30D)), ((V)("#7a6a5a")), NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("metal"))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)), ((V)(52D)), ((V)(1.4)), ((V)(32D)), ((V)("#3a3a3e")), NewObj(1).Put("r", ((V)(1D))).V)).Add(Call(ball_14, V.Undef, ((V)((-10D))), ((V)(26D)), ((V)(0D)), ((V)(5D)), ((V)("#a0603a")), NewObj(1).Put("sy", ((V)(0.5))).V)).Add(Call(ball_14, V.Undef, ((V)(8D)), ((V)(26D)), ((V)(4D)), ((V)(5D)), ((V)("#c08050")), NewObj(1).Put("sy", ((V)(0.5))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(15.4)), ((V)(30D)), ((V)(6D)), ((V)(1D)), ((V)("#ff8a3a")), Call(em_34, V.Undef, NewObj(2).Put("r", ((V)(2D))).Put("op", ((V)(0.6))).V))).V);
return o_2095;
}
if (SEqS(k_2094, "mod")) {
InvokeSpread(o_2095, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(104D)), ((V)(56D)), ((V)(54D)), ((V)("#c9d3d8")), NewObj(1).Put("r", ((V)(3D))).V)).Spread(Invoke(Arr(((V)((-34D))), ((V)(0D)), ((V)(34D))), "map", Fn((V _arrowThis2116, int _argc2109, V x_2115, V _a2112, V _a2113, V _a2114, V[] _rest2110) => {
return Call(slab_15, V.Undef, x_2115, ((V)(6D)), ((V)(27.4)), ((V)(30D)), ((V)(40D)), ((V)(1D)), ((V)("#d5dde2")), NewObj(1).Put("r", ((V)(2D))).V);
}, 1, "", true))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(56D)), ((V)(0D)), ((V)(70D)), ((V)(4D)), ((V)(54D)), ((V)("#9aa3a8")), NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(solid_10, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("rr"))).Put("c", Arr(((V)((-4D))), ((V)(70D)))).Put("a", ((V)(26D))).Put("b", ((V)(14D))).Put("r", ((V)(12D))).Put("rb", ((V)(0D))).Put("rings", Arr(Arr(((V)((-34D))), ((V)(0D))), Arr(((V)(34D)), ((V)(0D))))).Put("col", ((V)("#c9d3d8"))).V)).Add(Call(slabX_16, V.Undef, ((V)(0D)), ((V)(72D)), ((V)(26D)), ((V)(50D)), ((V)(3D)), ((V)(3D)), ((V)("#3e4046")), NewObj(1).Put("r", ((V)(1.5))).V)).Add(Call(box_11, V.Undef, ((V)((-46D))), ((V)(56D)), ((V)(0D)), ((V)(22D)), ((V)(2D)), ((V)(50D)), ((V)("#9aa3a8")), NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)(46D)), ((V)(56D)), ((V)(0D)), ((V)(22D)), ((V)(2D)), ((V)(50D)), ((V)("#9aa3a8")), NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(cyl_13, V.Undef, ((V)((-50D))), ((V)(60D)), ((V)(34D)), ((V)(4D)), ((V)(3D)), ((V)("#3e4046")), NewObj(1).Put("n", ((V)(8D))).V)).V);
return o_2095;
}
if (SEqS(k_2094, "royal")) {
InvokeSpread(o_2095, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(120D)), ((V)(60D)), ((V)(60D)), ((V)("#b9b4aa")), NewObj(2).Put("r", ((V)(3D))).Put("mat", ((V)("cer"))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(60D)), ((V)(0D)), ((V)(124D)), ((V)(5D)), ((V)(64D)), ((V)("#3c3c40")), NewObj(1).Put("r", ((V)(3D))).V)).Add(Call(ball_14, V.Undef, ((V)(30D)), ((V)(65D)), ((V)((-6D))), ((V)(26D)), ((V)("#b8664a")), NewObj(4).Put("sy", ((V)(1D))).Put("sz", ((V)(0.9))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).V)).Add(Call(box_11, V.Undef, ((V)(30D)), ((V)(66D)), ((V)(18D)), ((V)(20D)), ((V)(14D)), ((V)(6D)), ((V)("#2c1c14")), NewObj(1).Put("r", ((V)(7D))).V)).Add(Call(box_11, V.Undef, ((V)((-30D))), ((V)(65D)), ((V)(0D)), ((V)(44D)), ((V)(2D)), ((V)(40D)), ((V)("#3a3a3e")), NewObj(1).Put("r", ((V)(2D))).V)).Spread(Invoke(Arr(((V)((-48D))), ((V)((-30D))), ((V)((-12D)))), "map", Fn((V _arrowThis2124, int _argc2117, V x_2123, V _a2120, V _a2121, V _a2122, V[] _rest2118) => {
return Call(slab_15, V.Undef, x_2123, ((V)(10D)), ((V)(30.4)), ((V)(14D)), ((V)(40D)), ((V)(1D)), Get(P_2092, "w"), NewObj(1).Put("r", ((V)(2D))).V);
}, 1, "", true))).V);
Call(fl_2097, V.Undef, ((V)(30D)), ((V)(66D)), ((V)(22D)), ((V)(0.7)));
return o_2095;
}
Invoke(o_2095, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(120D)), ((V)(60D)), ((V)(60D)), ((V)("#f1eee8")), NewObj(2).Put("r", ((V)(8D))).Put("mat", ((V)("cer"))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(60D)), ((V)(0D)), ((V)(124D)), ((V)(4D)), ((V)(64D)), ((V)("#2a2630")), NewObj(1).Put("r", ((V)(8D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(64D)), ((V)((-20D))), ((V)(100D)), ((V)(60D)), ((V)(4D)), ((V)("#cfe8f2")), NewObj(2).Put("r", ((V)(4D))).Put("op", ((V)(0.4))).V), Call(cyl_13, V.Undef, ((V)((-30D))), ((V)(64D)), ((V)(0D)), ((V)(14D)), ((V)(2D)), ((V)("#3a3c48")), NewObj(1).Put("n", ((V)(16D))).V), Call(cyl_13, V.Undef, ((V)(20D)), ((V)(64D)), ((V)(0D)), ((V)(3D)), ((V)(40D)), ((V)("#c9d0d6")), NewObj(1).Put("n", ((V)(8D))).V), Call(slabX_16, V.Undef, ((V)(20D)), ((V)(100D)), ((V)(0D)), ((V)(44D)), ((V)(3D)), ((V)(3D)), ((V)("#c9d0d6"))), Call(ball_14, V.Undef, ((V)(20D)), ((V)(92D)), ((V)(0D)), ((V)(8D)), ((V)("#c08050")), NewObj(1).Put("sx", ((V)(1.6))).V), Call(slab_15, V.Undef, ((V)((-30D))), ((V)(20D)), ((V)(30.4)), ((V)(40D)), ((V)(30D)), ((V)(1D)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(2).Put("r", ((V)(4D))).Put("op", ((V)(0.5))).V)));
return o_2095;
return default;
}, 1, "build", true)).V;
}, 1, "bbq", true)).Put("bucket", Fn((V _arrowThis2132, int _argc2125, V S_2131, V _a2128, V _a2129, V _a2130, V[] _rest2126) => {
return NewObj(4).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis2140, int _argc2133, V P_2139, V _a2136, V _a2137, V _a2138, V[] _rest2134) => {
V k_2141 = default;
V c_2142 = default;
V o_2143 = default;
k_2141 = Get(S_2131, "k");
c_2142 = (Truthy(Invoke(NewRegExp(RX147, "cobalt|ceramic|barrel", ""), "test", Get(S_2131, "nm"))) ? ((V)("#2f5fb0")) : (Truthy(Invoke(NewRegExp(RX146, "galvanized|watering|rusty", ""), "test", Get(S_2131, "nm"))) ? ((V)("#a9b0b4")) : (SEqS(k_2141, "junk") ? ((V)("#f1eee8")) : Get(P_2139, "a"))));
o_2143 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(34D)), c_2142, NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.85))), Arr(((V)(34D)), ((V)(0D)), ((V)(1D))))).V), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(0D)), ((V)(17D)), ((V)(17D)), ((V)(2D)), ((V)(2D)), ((V)(0D)), ((V)((PI_33 * 2D))), Call(shade_23, V.Undef, c_2142, ((V)(1.1))), NewObj(1).Put("n", ((V)(16D))).V));
if (Truthy(Invoke(NewRegExp(RX148, "ceramic|barrel|cobalt", ""), "test", Get(S_2131, "nm")))) {
Invoke(o_2143, "push", Call(arcW_17, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(16D)), ((V)(16D)), ((V)(1D)), ((V)(3D)), ((V)(0D)), ((V)((PI_33 * 2D))), WH_30, NewObj(1).Put("n", ((V)(16D))).V), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(0D)), ((V)(17D)), ((V)(17D)), ((V)(1D)), ((V)(3D)), ((V)(0D)), ((V)((PI_33 * 2D))), WH_30, NewObj(1).Put("n", ((V)(16D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(0D)), ((V)(16D)), ((V)(2D)), c_2142, NewObj(1).Put("n", ((V)(16D))).V));
} else {
Invoke(o_2143, "push", Call(arcW_17, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(18D)), ((V)(18D)), ((V)(0.8)), ((V)(0.8)), ((V)(PI_33)), ((V)((PI_33 * 2D))), ((V)("#6b6f74")), NewObj(1).Put("n", ((V)(8D))).V));
}
if (Truthy(Invoke(NewRegExp(RX149, "watering", ""), "test", Get(S_2131, "nm")))) {
Invoke(o_2143, "push", Call(cyl_13, V.Undef, ((V)(20D)), ((V)(6D)), ((V)(0D)), ((V)(2.4)), ((V)(30D)), c_2142, NewObj(2).Put("n", ((V)(6D))).Put("yaw", ((V)(0D))).V), Call(box_11, V.Undef, ((V)(26D)), ((V)(30D)), ((V)(0D)), ((V)(8D)), ((V)(4D)), ((V)(8D)), c_2142, NewObj(1).Put("r", ((V)(2D))).V));
}
return o_2143;
return default;
}, 1, "build", true)).V;
}, 1, "bucket", true)).Put("stump", Fn((V _arrowThis2151, int _argc2144, V S_2150, V _a2147, V _a2148, V _a2149, V[] _rest2145) => {
return NewObj(4).Put("w", ((V)(46D))).Put("d", ((V)(46D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis2159, int _argc2152, V P_2158, V _a2155, V _a2156, V _a2157, V[] _rest2153) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(20D)), ((V)(36D)), ((V)("#8a5a34")), NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.25))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))), Arr(((V)(36D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(0D)), ((V)(20D)), ((V)(1D)), ((V)("#e6c48e")), NewObj(1).Put("n", ((V)(14D))).V), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(36.6)), ((V)(0D)), ((V)(12D)), ((V)(12D)), ((V)(1D)), ((V)(0.6)), ((V)(0D)), ((V)((PI_33 * 2D))), ((V)("#b8864e")), NewObj(2).Put("n", ((V)(12D))).Put("noOut", ((V)(1D))).V), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(36.6)), ((V)(0D)), ((V)(6D)), ((V)(6D)), ((V)(1D)), ((V)(0.6)), ((V)(0D)), ((V)((PI_33 * 2D))), ((V)("#b8864e")), NewObj(2).Put("n", ((V)(10D))).Put("noOut", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)(10D)), ((V)(34D)), ((V)(14D)), ((V)(4D)), ((V)("#6fbf54")), NewObj(2).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).V));
}, 1, "build", true)).V;
}, 1, "stump", true)).Put("tirebed", Fn((V _arrowThis2167, int _argc2160, V S_2166, V _a2163, V _a2164, V _a2165, V[] _rest2161) => {
return NewObj(4).Put("w", ((V)(60D))).Put("d", ((V)(60D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis2175, int _argc2168, V P_2174, V _a2171, V _a2172, V _a2173, V[] _rest2169) => {
return new ArrBuilder().Add(Call(arcW_17, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(28D)), ((V)(28D)), ((V)(12D)), ((V)(14D)), ((V)(0D)), ((V)((PI_33 * 2D))), ((V)("#2c2d31")), NewObj(1).Put("n", ((V)(18D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(17D)), ((V)(12D)), ((V)("#5a3a20")), NewObj(1).Put("n", ((V)(14D))).V)).Spread(Invoke(Arr(Arr(((V)((-6D))), ((V)(0D))), Arr(((V)(6D)), ((V)(4D))), Arr(((V)(0D)), ((V)((-6D))))), "map", Fn((V _arrowThis2188, int _argc2176, V _a2178, V i_2182, V _a2180, V _a2181, V[] _rest2177) => {
V x_2185 = default;
V z_2187 = default;
{ V _t2183 = ListOf(_a2178);
{ V _t2184 = GetIdx(_t2183, 0D);
x_2185 = _t2184; }
{ V _t2186 = GetIdx(_t2183, 1D);
z_2187 = _t2186; }
}
return Call(ball_14, V.Undef, x_2185, ((V)(12D)), z_2187, ((V)(6D)), GetK(Arr(((V)("#5fa84a")), ((V)("#6fbf54")), ((V)("#4f9a3e"))), i_2182), NewObj(3).Put("sy", ((V)(1.4))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
}, 2, "", true))).Add(Call(ball_14, V.Undef, ((V)(8D)), ((V)(18D)), ((V)((-2D))), ((V)(3D)), ((V)("#f2c94c")), NewObj(1).Put("k", ((V)(3D))).V)).V;
}, 1, "build", true)).V;
}, 1, "tirebed", true)).Put("linens", Fn((V _arrowThis2196, int _argc2189, V S_2195, V _a2192, V _a2193, V _a2194, V[] _rest2190) => {
return NewObj(3).Put("w", ((V)(90D))).Put("d", ((V)(60D))).Put("build", Fn((V _arrowThis2204, int _argc2197, V P_2203, V _a2200, V _a2201, V _a2202, V[] _rest2198) => {
V k_2205 = default;
V a_2206 = default;
V b_2207 = default;
V o_2208 = default;
k_2205 = Get(S_2195, "k");
a_2206 = Get(P_2203, "a");
b_2207 = Get(P_2203, "b");
o_2208 = Arr(Call(cush_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(90D)), ((V)(10D)), ((V)(56D)), a_2206), Call(cush_12, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(86D)), ((V)(10D)), ((V)(52D)), Call(shade_23, V.Undef, a_2206, ((V)(1.08)))), Call(cush_12, V.Undef, ((V)(0D)), ((V)(20D)), ((V)(2D)), ((V)(80D)), ((V)(8D)), ((V)(46D)), b_2207));
Invoke(o_2208, "push", Call(pillowZ_20, V.Undef, ((V)((-18D))), ((V)(28D)), ((V)((-6D))), ((V)(40D)), ((V)(26D)), ((V)(14D)), (SEqS(k_2205, "junk") ? ((V)("#e8e2d4")) : WH_30)), Call(pillowZ_20, V.Undef, ((V)(20D)), ((V)(28D)), ((V)((-4D))), ((V)(40D)), ((V)(26D)), ((V)(14D)), (SEqS(k_2205, "junk") ? ((V)("#d8d2c4")) : Call(shade_23, V.Undef, b_2207, ((V)(1.15))))));
if (Truthy(((SEqS(k_2205, "mod") ? V.True : V.False) is var _t2209 && Truthy(_t2209) ? _t2209 : Invoke(NewRegExp(RX150, "knit", ""), "test", Get(S_2195, "nm"))))) {
{
double i_2210 = 0;
i_2210 = 0D;
while (true) {
if (!((i_2210 < 4D))) break;
Invoke(o_2208, "push", Call(cyl_13, V.Undef, ((V)(((-30D) + (i_2210 * 20D)))), ((V)(20D)), ((V)(24D)), ((V)(4D)), ((V)(2D)), Call(shade_23, V.Undef, b_2207, ((V)(0.9))), NewObj(2).Put("n", ((V)(8D))).Put("rz", ((V)(3D))).V));
i_2210++;
}
}
}
if (SEqS(k_2205, "royal")) {
Invoke(o_2208, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(24D)), ((V)(82D)), ((V)(1.4)), ((V)(2D)), GOLD_27, NewObj(1).Put("r", ((V)(0.6))).V));
}
if (SEqS(k_2205, "candy")) {
Invoke(o_2208, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)((-12D))), ((V)(0D)), ((V)(18D)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(3).Put("sx", ((V)(2D))).Put("sy", ((V)(0.3))).Put("op", ((V)(0.35))).V)));
}
return o_2208;
return default;
}, 1, "build", true)).V;
}, 1, "linens", true)).Put("garmrack", Fn((V _arrowThis2219, int _argc2212, V S_2218, V _a2215, V _a2216, V _a2217, V[] _rest2213) => {
return NewObj(3).Put("w", ((V)(110D))).Put("d", ((V)(46D))).Put("build", Fn((V _arrowThis2227, int _argc2220, V P_2226, V _a2223, V _a2224, V _a2225, V[] _rest2221) => {
V o_2228 = default;
o_2228 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(100D)), ((V)(3D)), ((V)(40D)), ((V)("#6b6f74")), NewObj(1).Put("r", ((V)(2D))).V), Call(cyl_13, V.Undef, ((V)((-48D))), ((V)(3D)), ((V)(0D)), ((V)(1.8)), ((V)(130D)), ((V)("#9aa1a6")), NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_13, V.Undef, ((V)(48D)), ((V)(3D)), ((V)(0D)), ((V)(1.8)), ((V)(130D)), ((V)("#9aa1a6")), NewObj(1).Put("n", ((V)(6D))).V), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(132D)), ((V)(0D)), ((V)(100D)), ((V)(2.4)), ((V)(2.4)), ((V)("#9aa1a6")), NewObj(1).Put("r", ((V)(1D))).V));
Invoke(Arr(((V)("#5b8fd0")), ((V)("#e3946a")), ((V)("#9fb58c")), ((V)("#f2c94c"))), "forEach", Fn((V _arrowThis2237, int _argc2229, V c_2235, V i_2236, V _a2233, V _a2234, V[] _rest2230) => {
return Invoke(o_2228, "push", Call(slab_15, V.Undef, ((V)(((-30D) + (ToNum(i_2236) * 20D)))), ((V)(70D)), ((V)(((ToNum(i_2236) % 2D) * 2D))), ((V)(18D)), ((V)(56D)), ((V)(4D)), c_2235, NewObj(3).Put("r", ((V)(4D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(cyl_13, V.Undef, ((V)(((-30D) + (ToNum(i_2236) * 20D)))), ((V)(126D)), ((V)(0D)), ((V)(0.6)), ((V)(6D)), ((V)("#6b6f74")), NewObj(1).Put("n", ((V)(4D))).V));
}, 2, "", true));
return o_2228;
return default;
}, 1, "build", true)).V;
}, 1, "garmrack", true)).Put("cheval", Fn((V _arrowThis2245, int _argc2238, V S_2244, V _a2241, V _a2242, V _a2243, V[] _rest2239) => {
return NewObj(3).Put("w", ((V)(70D))).Put("d", ((V)(40D))).Put("build", Fn((V _arrowThis2253, int _argc2246, V P_2252, V _a2249, V _a2250, V _a2251, V[] _rest2247) => {
V k_2254 = default;
V fr_2255 = default;
V o_2256 = default;
k_2254 = Get(S_2244, "k");
fr_2255 = (Truthy(((SEqS(k_2254, "royal") ? V.True : V.False) is var _t2257 && Truthy(_t2257) ? _t2257 : Invoke(NewRegExp(RX151, "gild|brass|gold", ""), "test", Get(S_2244, "nm")))) ? GOLD_27 : (SEqS(k_2254, "candy") ? ((V)("#d5dde2")) : Get(P_2252, "w")));
o_2256 = Arr();
if (!SEqS(k_2254, "candy")) {
Invoke(o_2256, "push", Call(prism_21, V.Undef, ((V)((-28D))), ((V)((-24D))), Arr(Arr(((V)((-16D))), ((V)(0D))), Arr(((V)((-12D))), ((V)(0D))), Arr(((V)(0D)), ((V)(130D))), Arr(((V)((-4D))), ((V)(130D)))), fr_2255), Call(prism_21, V.Undef, ((V)(24D)), ((V)(28D)), Arr(Arr(((V)((-16D))), ((V)(0D))), Arr(((V)((-12D))), ((V)(0D))), Arr(((V)(0D)), ((V)(130D))), Arr(((V)((-4D))), ((V)(130D)))), fr_2255));
}
Invoke(o_2256, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(2D)), ((V)(50D)), ((V)(140D)), ((V)(5D)), fr_2255, NewObj(2).Put("r", ((V)(((SEqS(k_2254, "mod") || SEqS(k_2254, "royal")) ? 25D : 6D)))).Put("rb", ((V)(6D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(18D)), ((V)(4.8)), ((V)(42D)), ((V)(132D)), ((V)(0.8)), ((V)("#cfe8f2")), NewObj(3).Put("r", ((V)(((SEqS(k_2254, "mod") || SEqS(k_2254, "royal")) ? 21D : 4D)))).Put("rb", ((V)(4D))).Put("mat", ((V)("gloss"))).V), Call(slab_15, V.Undef, ((V)((-10D))), ((V)(60D)), ((V)(5.4)), ((V)(8D)), ((V)(60D)), ((V)(0.4)), WH_30, NewObj(3).Put("r", ((V)(3D))).Put("op", ((V)(0.6))).Put("noOut", ((V)(1D))).V));
if (SEqS(k_2254, "royal")) {
Invoke(o_2256, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)(152D)), ((V)(2D)), ((V)(7D)), GOLD_27), Call(slab_15, V.Undef, ((V)(0D)), ((V)(18D)), ((V)(5.2)), ((V)(42D)), ((V)(132D)), ((V)(0.4)), ((V)("#ffe9a0")), Call(em_34, V.Undef, NewObj(3).Put("r", ((V)(21D))).Put("rb", ((V)(4D))).Put("op", ((V)(0.15))).V)));
}
if (SEqS(k_2254, "candy")) {
Invoke(o_2256, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(18D)), ((V)(5.6)), ((V)(42D)), ((V)(132D)), ((V)(0.4)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(3).Put("r", ((V)(4D))).Put("rb", ((V)(4D))).Put("op", ((V)(0.3))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(2D)), ((V)(22D)), ((V)(4D)), ((V)("#3a3c48")), NewObj(1).Put("n", ((V)(16D))).V));
}
return o_2256;
return default;
}, 1, "build", true)).V;
}, 1, "cheval", true)).Put("decks", Fn((V _arrowThis2265, int _argc2258, V S_2264, V _a2261, V _a2262, V _a2263, V[] _rest2259) => {
return NewObj(4).Put("w", ((V)(110D))).Put("d", ((V)(56D))).Put("glow", Fn((V _arrowThis2272, int _argc2266, V _a2268, V _a2269, V _a2270, V _a2271, V[] _rest2267) => {
return (SEqS(Get(S_2264, "k"), "candy") ? NewObj(3).Put("y", ((V)(60D))).Put("r", ((V)(70D))).Put("c", ((V)("url(#gNeon)"))).V : V.Null);
}, 0, "glow", true)).Put("build", Fn((V _arrowThis2280, int _argc2273, V P_2279, V _a2276, V _a2277, V _a2278, V[] _rest2274) => {
V k_2281 = default;
V c_2282 = default;
V o_2283 = default;
double n_2284 = 0;
V xs_2285 = default;
k_2281 = Get(S_2264, "k");
c_2282 = ((V)((SEqS(k_2281, "royal") ? "#2c2d31" : (SEqS(k_2281, "cot") ? "#3e4046" : "#2c2d31"))));
o_2283 = Arr();
if (SEqS(k_2281, "cot")) {
InvokeSpread(o_2283, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(70D)), ((V)(5D)), ((V)(40D)), c_2282, NewObj(1).Put("r", ((V)(4D))).V)).Spread(Invoke(Arr(((V)((-22D))), ((V)(22D))), "map", Fn((V _arrowThis2293, int _argc2286, V x_2292, V _a2289, V _a2290, V _a2291, V[] _rest2287) => {
return Call(cyl_13, V.Undef, x_2292, ((V)(5D)), ((V)((-2D))), ((V)(11D)), ((V)(1.6)), ((V)("#555860")), NewObj(1).Put("n", ((V)(16D))).V);
}, 1, "", true))).Spread(Invoke(Arr(((V)((-12D))), ((V)((-4D))), ((V)(4D)), ((V)(12D))), "map", Fn((V _arrowThis2301, int _argc2294, V x_2300, V _a2297, V _a2298, V _a2299, V[] _rest2295) => {
return Call(slab_15, V.Undef, x_2300, ((V)(5D)), ((V)(10D)), ((V)(4D)), ((V)(6D)), ((V)(4D)), GetIdx(NE_26, ((ToNum(Add(x_2300, ((V)(12D)))) / 8D) % 6D)), NewObj(2).Put("r", ((V)(1D))).Put("emit", ((V)(1D))).V);
}, 1, "", true))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(5D)), ((V)((-16D))), ((V)(50D)), ((V)(1D)), ((V)(8D)), ((V)("#6b6f74")), NewObj(1).Put("r", ((V)(1D))).V)).V);
return o_2283;
}
Invoke(o_2283, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(110D)), ((V)(40D)), ((V)(54D)), ((V)((SEqS(k_2281, "royal") ? "#3e4046" : "#555860"))), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(112D)), ((V)(6D)), ((V)(56D)), c_2282, NewObj(1).Put("r", ((V)(4D))).V));
n_2284 = (SEqS(k_2281, "royal") ? 4D : 2D);
xs_2285 = ((n_2284 == 4D) ? Arr(((V)((-42D))), ((V)((-18D))), ((V)(18D)), ((V)(42D))) : Arr(((V)((-30D))), ((V)(30D))));
Invoke(xs_2285, "forEach", Fn((V _arrowThis2309, int _argc2302, V x_2308, V _a2305, V _a2306, V _a2307, V[] _rest2303) => {
return Invoke(o_2283, "push", Call(cyl_13, V.Undef, x_2308, ((V)(46D)), ((V)(0D)), ((V)(((n_2284 == 4D) ? 10D : 15D))), ((V)(2D)), ((V)("#1d1d20")), NewObj(1).Put("n", ((V)(16D))).V), Call(cyl_13, V.Undef, x_2308, ((V)(48D)), ((V)(0D)), ((V)(3D)), ((V)(0.6)), (SEqS(k_2281, "royal") ? GOLD_27 : ((V)("#d9483b"))), NewObj(1).Put("n", ((V)(8D))).V));
}, 1, "", true));
InvokeSpread(o_2283, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(46D)), ((V)(0D)), ((V)(((n_2284 == 4D) ? 14D : 22D))), ((V)(3D)), ((V)(40D)), (SEqS(k_2281, "royal") ? GOLD_27 : ((V)("#3e4046"))), NewObj(1).Put("r", ((V)(2D))).V)).Spread(Invoke(Arr(((V)((-6D))), ((V)(0D)), ((V)(6D))), "map", Fn((V _arrowThis2317, int _argc2310, V x_2316, V _a2313, V _a2314, V _a2315, V[] _rest2311) => {
return Call(slab_15, V.Undef, x_2316, ((V)(46D)), ((V)(14D)), ((V)(2D)), ((V)(6D)), ((V)(2D)), ((V)("#d5dde2")), NewObj(1).Put("r", ((V)(1D))).V);
}, 1, "", true))).V);
if (SEqS(k_2281, "candy")) {
InvokeSpread(o_2283, "push", new ArrBuilder().Spread(Invoke(Arr(((V)((-30D))), ((V)(0D)), ((V)(30D))), "map", Fn((V _arrowThis2326, int _argc2318, V x_2324, V i_2325, V _a2322, V _a2323, V[] _rest2319) => {
return Call(slab_15, V.Undef, x_2324, ((V)(56D)), ((V)((-10D))), ((V)(26D)), ((V)(30D)), ((V)(0.6)), GetIdx(NE_26, (ToNum(i_2325) * 2D)), Call(em_34, V.Undef, NewObj(2).Put("r", ((V)(3D))).Put("op", ((V)(0.6))).V));
}, 2, "", true))).V);
}
if (SEqS(k_2281, "mod")) {
Invoke(o_2283, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(27.4)), ((V)(100D)), ((V)(30D)), ((V)(1D)), ((V)("#8f7bff")), Call(em_34, V.Undef, NewObj(2).Put("r", ((V)(3D))).Put("op", ((V)(0.5))).V)));
}
return o_2283;
return default;
}, 1, "build", true)).V;
}, 1, "decks", true)).Put("fan", Fn((V _arrowThis2334, int _argc2327, V S_2333, V _a2330, V _a2331, V _a2332, V[] _rest2328) => {
return NewObj(3).Put("w", ((V)(50D))).Put("d", ((V)(40D))).Put("build", Fn((V _arrowThis2342, int _argc2335, V P_2341, V _a2338, V _a2339, V _a2340, V[] _rest2336) => {
V o_2343 = default;
o_2343 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(4D)), ((V)("#d8d2c6")), NewObj(1).Put("n", ((V)(14D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(2.4)), ((V)(70D)), ((V)("#d8d2c6")), NewObj(1).Put("n", ((V)(8D))).V), Call(disc_18, V.Undef, ((V)(0D)), ((V)(86D)), ((V)((-4D))), ((V)(18D)), ((V)(8D)), ((V)("#d8d2c6")), NewObj(1).Put("op", ((V)(0.5))).V), Call(disc_18, V.Undef, ((V)(0D)), ((V)(86D)), ((V)(4D)), ((V)(5D)), ((V)(3D)), ((V)("#9aa1a6"))));
{
double i_2344 = 0;
i_2344 = 0D;
while (true) {
if (!((i_2344 < 4D))) break;
Invoke(o_2343, "push", Call(slab_15, V.Undef, ((V)((FdLibm.Cos((((i_2344 * PI_33) / 2D) + 0.4)) * 9D))), ((V)(((86D + (FdLibm.Sin((((i_2344 * PI_33) / 2D) + 0.4)) * 9D)) - 3D))), ((V)(2D)), ((V)(10D)), ((V)(6D)), ((V)(0.6)), ((V)("#9fd2f2")), NewObj(1).Put("r", ((V)(3D))).V));
i_2344++;
}
}
if (Truthy(Invoke(NewRegExp(RX152, "bubble", ""), "test", Get(S_2333, "nm")))) {
Invoke(Arr(Arr(((V)((-24D))), ((V)(100D)), ((V)(10D)), ((V)(7D))), Arr(((V)((-36D))), ((V)(116D)), ((V)(4D)), ((V)(5D))), Arr(((V)((-20D))), ((V)(124D)), ((V)(0D)), ((V)(4D)))), "forEach", Fn((V _arrowThis2361, int _argc2346, V _a2348, V _a2349, V _a2350, V _a2351, V[] _rest2347) => {
V x_2354 = default;
V y_2356 = default;
V z_2358 = default;
V r_2360 = default;
{ V _t2352 = ListOf(_a2348);
{ V _t2353 = GetIdx(_t2352, 0D);
x_2354 = _t2353; }
{ V _t2355 = GetIdx(_t2352, 1D);
y_2356 = _t2355; }
{ V _t2357 = GetIdx(_t2352, 2D);
z_2358 = _t2357; }
{ V _t2359 = GetIdx(_t2352, 3D);
r_2360 = _t2359; }
}
return Invoke(o_2343, "push", Call(ball_14, V.Undef, x_2354, y_2356, z_2358, r_2360, ((V)("#cfe8f2")), NewObj(2).Put("op", ((V)(0.55))).Put("k", ((V)(4D))).V));
}, 1, "", true));
}
return o_2343;
return default;
}, 1, "build", true)).V;
}, 1, "fan", true)).Put("dart", Fn((V _arrowThis2369, int _argc2362, V S_2368, V _a2365, V _a2366, V _a2367, V[] _rest2363) => {
return NewObj(3).Put("w", ((V)(60D))).Put("d", ((V)(8D))).Put("build", Fn((V _arrowThis2377, int _argc2370, V P_2376, V _a2373, V _a2374, V _a2375, V[] _rest2371) => {
return new ArrBuilder().Add(Call(disc_18, V.Undef, ((V)(0D)), ((V)(70D)), ((V)((-4D))), ((V)(30D)), ((V)(4D)), ((V)("#2c2d31")))).Add(Call(disc_18, V.Undef, ((V)(0D)), ((V)(70D)), ((V)(0D)), ((V)(24D)), ((V)(0.6)), ((V)("#f2e6c8")))).Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D)), ((V)(5D))), "map", Fn((V _arrowThis2385, int _argc2378, V i_2384, V _a2381, V _a2382, V _a2383, V[] _rest2379) => {
return Call(disc_18, V.Undef, ((V)(0D)), ((V)(70D)), ((V)((0.6 + (ToNum(i_2384) * 0.2)))), ((V)((24D - (ToNum(i_2384) * 4D)))), ((V)(0.2)), ((V)((NumTruthy((ToNum(i_2384) % 2D)) ? "#d9483b" : "#2f6a4c"))), NewObj(1).Put("noOut", ((V)(1D))).V);
}, 1, "", true))).Add(Call(disc_18, V.Undef, ((V)(0D)), ((V)(70D)), ((V)(1.8)), ((V)(2D)), ((V)(0.4)), ((V)("#d9483b")))).Add(Call(cyl_13, V.Undef, ((V)(8D)), ((V)(74D)), ((V)(4D)), ((V)(0.8)), ((V)(1D)), ((V)("#f2c94c")))).Add(Call(slab_15, V.Undef, ((V)(8D)), ((V)(72D)), ((V)(3D)), ((V)(1D)), ((V)(10D)), ((V)(6D)), ((V)("#f2c94c")), NewObj(1).Put("r", ((V)(0D))).V)).Add(Call(slab_15, V.Undef, ((V)(20D)), ((V)(60D)), ((V)((-3.6))), ((V)(16D)), ((V)(10D)), ((V)(0.4)), ((V)("#a0603a")), NewObj(2).Put("r", ((V)(2D))).Put("op", ((V)(0.4))).V)).V;
}, 1, "build", true)).V;
}, 1, "dart", true)).Put("holo", Fn((V _arrowThis2393, int _argc2386, V S_2392, V _a2389, V _a2390, V _a2391, V[] _rest2387) => {
return NewObj(5).Put("w", ((V)(70D))).Put("d", ((V)(70D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis2400, int _argc2394, V _a2396, V _a2397, V _a2398, V _a2399, V[] _rest2395) => {
return NewObj(3).Put("y", ((V)(50D))).Put("r", ((V)(70D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis2408, int _argc2401, V P_2407, V _a2404, V _a2405, V _a2406, V[] _rest2402) => {
V o_2409 = default;
o_2409 = Arr();
Call(holoBase_43, V.Undef, o_2409, ((V)(0D)), ((V)(28D)));
Invoke(o_2409, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(22D)), ((V)(80D)), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(80D)), ((V)(0D)), ((V)(1.4))))).Put("op", ((V)(0.2))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(26D)), ((V)(26D)), ((V)(1D)), ((V)(1.4)), ((V)(0D)), ((V)((PI_33 * 2D))), ((V)("#8fe8ff")), Call(em_34, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(60D)), ((V)(0D)), ((V)(30D)), ((V)(30D)), ((V)(1D)), ((V)(1.4)), ((V)(0D)), ((V)((PI_33 * 2D))), ((V)("#b48cff")), Call(em_34, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
if (Truthy(Invoke(NewRegExp(RX153, "mascot|dancer|idol", ""), "test", Get(S_2392, "nm")))) {
Invoke(o_2409, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(0D)), ((V)(16D)), ((V)("#b48cff")), Call(em_34, V.Undef, NewObj(1).Put("op", ((V)(0.6))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(56D)), ((V)(0D)), ((V)(11D)), ((V)("#c9f4ff")), Call(em_34, V.Undef, NewObj(1).Put("op", ((V)(0.7))).V)));
} else {
if (Truthy(Invoke(NewRegExp(RX154, "arena|sport", ""), "test", Get(S_2392, "nm")))) {
Invoke(o_2409, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(0D)), ((V)(10D)), ((V)("#ffd66b")), Call(em_34, V.Undef, NewObj(1).Put("op", ((V)(0.8))).V)), Call(cyl_13, V.Undef, ((V)(30D)), ((V)(0D)), ((V)((-20D))), ((V)(3D)), ((V)(70D)), ((V)("#c9d0d6")), NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_13, V.Undef, ((V)(30D)), ((V)(70D)), ((V)((-20D))), ((V)(6D)), ((V)(20D)), ((V)("#3e4046")), NewObj(2).Put("n", ((V)(10D))).Put("yaw", ((V)(0D))).V));
} else {
Invoke(o_2409, "push", Call(ball_14, V.Undef, ((V)((-8D))), ((V)(30D)), ((V)(0D)), ((V)(9D)), ((V)("#c9f4ff")), Call(em_34, V.Undef, NewObj(1).Put("op", ((V)(0.7))).V)), Call(box_11, V.Undef, ((V)(8D)), ((V)(26D)), ((V)(4D)), ((V)(14D)), ((V)(22D)), ((V)(14D)), ((V)("#8f7bff")), Call(em_34, V.Undef, NewObj(2).Put("op", ((V)(0.5))).Put("r", ((V)(2D))).V)), Call(ball_14, V.Undef, ((V)(4D)), ((V)(62D)), ((V)((-4D))), ((V)(6D)), ((V)("#ffd66b")), Call(em_34, V.Undef)));
}
}
return o_2409;
return default;
}, 1, "build", true)).V;
}, 1, "holo", true)).Put("cups", Fn((V _arrowThis2417, int _argc2410, V S_2416, V _a2413, V _a2414, V _a2415, V[] _rest2411) => {
return NewObj(3).Put("w", ((V)(50D))).Put("d", ((V)(40D))).Put("build", Fn((V _arrowThis2425, int _argc2418, V P_2424, V _a2421, V _a2422, V _a2423, V[] _rest2419) => {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)((-10D))), ((V)(0D)), ((V)(0D)), ((V)(6D)), ((V)(16D)), ((V)("#d9483b")), NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.75))), Arr(((V)(16D)), ((V)(0D)), ((V)(1D))))).V)).Add(Call(cyl_13, V.Undef, ((V)((-10D))), ((V)(16D)), ((V)(0D)), ((V)(6D)), ((V)(1.4)), WH_30, NewObj(1).Put("n", ((V)(12D))).V)).Add(Call(cyl_13, V.Undef, ((V)(6D)), ((V)(0D)), ((V)(6D)), ((V)(6D)), ((V)(16D)), ((V)("#d9483b")), NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.75))), Arr(((V)(16D)), ((V)(0D)), ((V)(1D))))).V)).Add(Call(cyl_13, V.Undef, ((V)(6D)), ((V)(16D)), ((V)(6D)), ((V)(6D)), ((V)(1.4)), WH_30, NewObj(1).Put("n", ((V)(12D))).V)).Add(Call(cyl_13, V.Undef, ((V)(8D)), ((V)(0D)), ((V)((-10D))), ((V)(6D)), ((V)(16D)), ((V)("#d9483b")), NewObj(3).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.75))), Arr(((V)(16D)), ((V)(0D)), ((V)(1D))))).Put("yaw", ((V)(0D))).V)).Spread(Invoke(Arr(Arr(((V)(18D)), ((V)(4D)), ((V)("#a6f06a"))), Arr(((V)(22D)), ((V)(2D)), ((V)("#4fe0d0"))), Arr(((V)((-22D))), ((V)(6D)), ((V)("#ffd66b")))), "map", Fn((V _arrowThis2439, int _argc2426, V _a2428, V _a2429, V _a2430, V _a2431, V[] _rest2427) => {
V x_2434 = default;
V z_2436 = default;
V c_2438 = default;
{ V _t2432 = ListOf(_a2428);
{ V _t2433 = GetIdx(_t2432, 0D);
x_2434 = _t2433; }
{ V _t2435 = GetIdx(_t2432, 1D);
z_2436 = _t2435; }
{ V _t2437 = GetIdx(_t2432, 2D);
c_2438 = _t2437; }
}
return Call(box_11, V.Undef, x_2434, ((V)(0D)), z_2436, ((V)(3D)), ((V)(2D)), ((V)(22D)), c_2438, Call(em_34, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V));
}, 1, "", true))).V;
}, 1, "build", true)).V;
}, 1, "cups", true)).Put("popbucket", Fn((V _arrowThis2447, int _argc2440, V S_2446, V _a2443, V _a2444, V _a2445, V[] _rest2441) => {
return NewObj(4).Put("w", ((V)(36D))).Put("d", ((V)(36D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis2455, int _argc2448, V P_2454, V _a2451, V _a2452, V _a2453, V[] _rest2449) => {
V o_2456 = default;
o_2456 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(12D)), ((V)(26D)), WH_30, NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.75))), Arr(((V)(26D)), ((V)(0D)), ((V)(1D))))).V));
{
double i_2457 = 0;
i_2457 = 0D;
while (true) {
if (!((i_2457 < 4D))) break;
Invoke(o_2456, "push", Call(slab_15, V.Undef, ((V)((FdLibm.Cos(((i_2457 * 0.5) - 0.8)) * 10.5))), ((V)(1D)), ((V)(((FdLibm.Sin(((i_2457 * 0.5) - 0.8)) * 10.5) + 0D))), ((V)(3.6)), ((V)(24D)), ((V)(0.4)), ((V)("#d9483b")), NewObj(2).Put("r", ((V)(0D))).Put("yaw", ((V)(0D))).V));
i_2457++;
}
}
{
double i_2459 = 0;
i_2459 = 0D;
while (true) {
if (!((i_2459 < 9D))) break;
Invoke(o_2456, "push", Call(ball_14, V.Undef, ((V)(((-8D) + ((i_2459 % 4D) * 5D)))), ((V)((25D + (System.Math.Floor((i_2459 / 4D)) * 3D)))), ((V)(((-4D) + ((i_2459 * 3D) % 9D)))), ((V)(3D)), ((V)((NumTruthy((i_2459 % 3D)) ? "#fff4d0" : "#f2d27a"))), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
i_2459++;
}
}
Invoke(o_2456, "push", Call(box_11, V.Undef, ((V)(18D)), ((V)(0D)), ((V)(6D)), ((V)(14D)), ((V)(1D)), ((V)(8D)), ((V)("#f2c94c")), NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(20D)), ((V)(1D)), ((V)(10D)), ((V)(14D)), ((V)(1D)), ((V)(8D)), ((V)("#e88a3a")), NewObj(1).Put("r", ((V)(1D))).V));
return o_2456;
return default;
}, 1, "build", true)).V;
}, 1, "popbucket", true)).V;
patch_45 = Fn((V _arrowThis2473, int _argc2461, V x_2467, V y_2468, V z_2469, V w_2470, V[] _rest2462) => {
V h_2471 = default;
V col_2472 = default;
h_2471 = (_argc2461 > 4 ? _rest2462[0] : V.Undef);
col_2472 = (_argc2461 > 5 ? _rest2462[1] : V.Undef);
return Call(box_11, V.Undef, x_2467, y_2468, z_2469, w_2470, h_2471, ((V)(1.2)), col_2472, NewObj(1).Put("r", ((V)(2D))).V);
}, 6, "", true);
H_46 = NewObj(6).Put("em", em_34).Put("patch", patch_45).Put("legs4", legs4_41).Put("metalOf", metalOf_42).Put("holoBase", holoBase_43).Put("fire", Fn((V _self2474, int _argc2475, V c_2481, V L_2482, V heater_2483, V _a2480, V[] _rest2476) => {
JsStrBuf f_2484 = null;
V OUT_2485 = default;
V MID_2486 = default;
V INN_2487 = default;
if (_self2474.IsNullish) _self2474 = GlobalV;
f_2484 = new JsStrBuf("");
OUT_2485 = ((V)("M-7 0C-9 -6 -6 -11 -3 -15C-3 -10 -1 -9 0 -13C1 -18 0 -21 -1 -25C4 -21 7 -15 5 -10C7 -11 8 -13 8 -15C10 -9 9 -3 7 0Z"));
MID_2486 = ((V)("M-5 0C-6 -5 -4 -8 -2 -11C-1 -8 0 -8 1 -11C4 -8 5 -4 4 0Z"));
INN_2487 = ((V)("M-3 0C-3.5 -3 -2 -5 -0.5 -7C0.5 -5 2 -4 2.4 0Z"));
Invoke((L_2482 is var _t2517 && Truthy(_t2517) ? _t2517 : Arr()), "forEach", Fn((V _arrowThis2504, int _argc2488, V _a2490, V i_2494, V _a2492, V _a2493, V[] _rest2489) => {
V q_2505 = default;
double u_2506 = 0;
V d_2507 = default;
V b_2508 = default;
V x_2497 = default;
V y_2499 = default;
V z_2501 = default;
V s_2503 = default;
{ V _t2495 = ListOf(_a2490);
{ V _t2496 = GetIdx(_t2495, 0D);
x_2497 = _t2496; }
{ V _t2498 = GetIdx(_t2495, 1D);
y_2499 = _t2498; }
{ V _t2500 = GetIdx(_t2495, 2D);
z_2501 = _t2500; }
{ V _t2502 = GetIdx(_t2495, 3D);
s_2503 = _t2502; }
}
q_2505 = Invoke(c_2481, "p", x_2497, y_2499, z_2501);
u_2506 = ((ToNum(Get(c_2481, "k")) * ToNum(s_2503)) * 0.95);
d_2507 = Invoke(((V)((0.5 + ((ToNum(i_2494) % 3D) * 0.14)))), "toFixed", ((V)(2D)));
b_2508 = Invoke(((V)(((-ToNum(i_2494)) * 0.23))), "toFixed", ((V)(2D)));
f_2484.S("<g transform=\"translate(").V(Call(f1_25, V.Undef, GetIdx(q_2505, 0D))).S(" ").V(Call(f1_25, V.Undef, GetIdx(q_2505, 1D))).S(") scale(").V(Call(f1_25, V.Undef, ((V)(u_2506)))).S(")\"><ellipse cx=\"0\" cy=\"-9\" rx=\"15\" ry=\"13\" fill=\"#ffb347\" opacity=\"0.25\"><animate attributeName=\"opacity\" values=\"0.16;0.34;0.2;0.3;0.16\" dur=\"1.4s\" begin=\"").V(b_2508).S("s\" repeatCount=\"indefinite\"/></ellipse>").S("<g><animateTransform attributeName=\"transform\" type=\"scale\" values=\"1 1;0.9 1.16;1.07 0.9;0.96 1.1;1 1\" dur=\"").V(d_2507).S("s\" begin=\"").V(b_2508).S("s\" repeatCount=\"indefinite\"/><path d=\"").V(OUT_2485).S("\" fill=\"#ff7a22\"/><path d=\"").V(MID_2486).S("\" fill=\"#ffb53a\"/><path d=\"").V(INN_2487).S("\" fill=\"#fff1b0\"/></g>").V(Invoke(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis2516, int _argc2509, V j_2515, V _a2512, V _a2513, V _a2514, V[] _rest2510) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").N(((ToNum(j_2515) * 3D) - 3D)).S("\" cy=\"-14\" r=\"0.9\" fill=\"#ffd66b\"><animate attributeName=\"cy\" values=\"-12;-40\" dur=\"").N((1.4 + (ToNum(j_2515) * 0.3))).S("s\" begin=\"").N((((-ToNum(j_2515)) * 0.5) + ToNum(b_2508))).S("s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"1;0\" dur=\"").N((1.4 + (ToNum(j_2515) * 0.3))).S("s\" begin=\"").N((((-ToNum(j_2515)) * 0.5) + ToNum(b_2508))).S("s\" repeatCount=\"indefinite\"/></circle>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
return default;
}, 2, "", true));
if (Truthy(heater_2483)) {
V q_2518 = default;
V u_2519 = default;
q_2518 = Invoke(c_2481, "p", ((V)(0D)), ((V)(18D)), ((V)(29.4)));
u_2519 = Get(c_2481, "k");
f_2484.S("<rect x=\"").V(Call(f1_25, V.Undef, ((V)((ToNum(GetIdx(q_2518, 0D)) - (10D * ToNum(u_2519))))))).S("\" y=\"").V(Call(f1_25, V.Undef, ((V)((ToNum(GetIdx(q_2518, 1D)) - (7D * ToNum(u_2519))))))).S("\" width=\"").V(Call(f1_25, V.Undef, ((V)((20D * ToNum(u_2519)))))).S("\" height=\"").V(Call(f1_25, V.Undef, ((V)((13D * ToNum(u_2519)))))).S("\" rx=\"").V(Call(f1_25, V.Undef, ((V)((2D * ToNum(u_2519)))))).S("\" fill=\"#ff6a2a\"><animate attributeName=\"opacity\" values=\"0.35;0.85;0.5;0.8;0.35\" dur=\"2.2s\" repeatCount=\"indefinite\"/></rect>");
}
return NewObj(1).Put("over", ((V)(f_2484.Str))).V;
return default;
}, 3, "fire", false)).V;
M_47 = NewObj(7).Put("MOV", Arr(((V)("s:wall")), ((V)("s:floor")), ((V)("s:ceil")), ((V)("s:door")), ((V)("s:light")), Arr(((V)("s:ylight")), ((V)("neonSign@retro")), ((V)("sconce")), ((V)("sconce")), ((V)("crystal"))), Arr(((V)("sheet")), ((V)("wallTV")), ((V)("wallTV")), ((V)("projector")), ((V)("projector"))), ((V)("projDev")), Arr(((V)("speaker*0.7")), ((V)("sub")), ((V)("speaker")), ((V)("spkTower")), ((V)("speaker"))), Arr(((V)("chaise")), ((V)("sofa")), ((V)("sofa")), ((V)("longSofa")), ((V)("pit"))), Arr(((V)("chair")), ((V)("pouf")), ((V)("armchair")), ((V)("armchair")), ((V)("armchair"))), ((V)("petbed")), ((V)("coffee")), Arr(((V)("tray")), ((V)("tray")), ((V)("bistro")), ((V)("bistro")), ((V)("cart"))), ((V)("popcorn")), Arr(((V)("icechest")), ((V)("minifridge")), ((V)("minifridge+glass@retro")), ((V)("minifridge+glass")), ((V)("minifridge+glass"))), Arr(((V)("shelf")), ((V)("bookcase")), ((V)("tvstand")), ((V)("bookcase")), ((V)("holo"))), Arr(((V)("rug2.oval")), ((V)("rug2.runner")), ((V)("rug2.shag")), ((V)("rug2")), ((V)("rug2.spiral"))), Arr(((V)("poster.movie")), ((V)("gallery")), ((V)("poster.movie")), ((V)("gallery")), ((V)("gallery"))), Arr(((V)("tbBox")), ((V)("popbucket")), ((V)("tbBooks")), ((V)("tbTrophy")), ((V)("holo*0.45"))))).Put("LIV", Arr(((V)("s:wall")), ((V)("s:floor")), ((V)("s:ceil")), ((V)("s:win")), ((V)("hearth")), ((V)("s:light")), ((V)("lamp")), Arr(((V)("sofa")), ((V)("sofa")), ((V)("lsofa")), ((V)("pit")), ((V)("sofa"))), Arr(((V)("chair")), ((V)("armchair")), ((V)("armchair")), ((V)("armchair")), ((V)("armchair"))), Arr(((V)("cardbox*0.7")), ((V)("pouf")), ((V)("pouf")), ((V)("pouf")), ((V)("pouf"))), Arr(((V)("#spoolTable")), ((V)("coffee")), ((V)("coffee")), ((V)("coffee")), ((V)("coffee"))), Arr(((V)("crate")), ((V)("bistro")), ((V)("nightstand")), ((V)("bistro")), ((V)("bistro"))), ((V)("console")), Arr(((V)("shelf")), ((V)("bookcase")), ((V)("bookcase")), ((V)("bookcase")), ((V)("bookcase"))), Arr(((V)("miniTV")), ((V)("wallTV")), ((V)("#radio")), ((V)("tvstand")), ((V)("holo"))), Arr(((V)("petbed")), ((V)("petbed")), ((V)("cattree")), ((V)("petbed")), ((V)("petbed"))), Arr(((V)("mat")), ((V)("rug2.hex")), ((V)("rug2")), ((V)("rug2.zig")), ((V)("rug2.spiral"))), Arr(((V)("plant")), ((V)("plant")), ((V)("monstera")), ((V)("bonsai")), ((V)("bonsai"))), Arr(((V)("poster")), ((V)("mirror")), ((V)("gallery")), ((V)("mirror")), ((V)("poster.sunset"))), Arr(((V)("tbBooks")), ((V)("tbCandles")), ((V)("tbBooks")), ((V)("tbVase")), ((V)("tbGlobe"))))).Put("BTH", Arr(((V)("s:wall")), ((V)("s:floor")), ((V)("s:ceil")), ((V)("divider")), Arr(((V)("tub")), ((V)("tub")), ((V)("tub")), ((V)("onsen")), ((V)("onsen"))), ((V)("shower")), ((V)("toilet")), ((V)("bsink")), ((V)("mirror")), Arr(((V)("sconce")), ((V)("sconce")), ((V)("lantern*0.7")), ((V)("sconce")), ((V)("sconce"))), Arr(((V)("stool")), ((V)("stool")), ((V)("stool")), ((V)("bench")), ((V)("chaise"))), Arr(((V)("tbSoap")), ((V)("tray")), ((V)("bistro")), ((V)("cart")), ((V)("tray"))), Arr(((V)("rack")), ((V)("rack")), ((V)("rack")), ((V)("washer")), ((V)("wardrobe*0.8"))), ((V)("sauna")), Arr(((V)("tub*0.5")), ((V)("tub*0.5")), ((V)("onsen*0.45")), ((V)("sauna*0.55")), ((V)("onsen*0.5"))), Arr(((V)("mat")), ((V)("rug2.oval")), ((V)("mat")), ((V)("rug2.runner")), ((V)("rug2.shag"))), Arr(((V)("plant*0.7")), ((V)("plant")), ((V)("plant")), ((V)("greenwall")), ((V)("bonsai"))), Arr(((V)("basket")), ((V)("basket")), ((V)("dresser*0.7")), ((V)("washer")), ((V)("wardrobe"))), Arr(((V)("poster")), ((V)("gallery")), ((V)("poster")), ((V)("poster")), ((V)("poster.sunset"))), Arr(((V)("tbSoap")), ((V)("tbCup")), ((V)("tbCandles")), ((V)("tbPerfume")), ((V)("tbPerfume"))))).Put("KIT", Arr(((V)("s:wall")), ((V)("s:floor")), ((V)("s:ceil")), ((V)("s:win")), Arr(((V)("minifridge")), ((V)("fridge")), ((V)("fridge")), ((V)("fridge")), ((V)("fridge"))), Arr(((V)("hotplate")), ((V)("stove")), ((V)("stove")), ((V)("stove")), ((V)("stove"))), ((V)("counter+sink")), ((V)("dishwasher")), ((V)("counter")), Arr(((V)("table")), ((V)("cart")), ((V)("table")), ((V)("counter")), ((V)("counter"))), Arr(((V)("stool")), ((V)("chair")), ((V)("chair")), ((V)("chair")), ((V)("chair"))), ((V)("stool")), ((V)("cart")), ((V)("coffeeMk")), Arr(((V)("tbToaster")), ((V)("tbMixer")), ((V)("tbToaster")), ((V)("tbMixer")), ((V)("holo*0.45"))), Arr(((V)("wallShelf")), ((V)("wallShelf")), ((V)("hutch")), ((V)("hutch")), ((V)("hutch"))), ((V)("s:light")), ((V)("bowl")), Arr(((V)("poster")), ((V)("poster.fruit")), ((V)("wallShelf")), ((V)("gallery")), ((V)("poster.stars"))), Arr(((V)("tbJar")), ((V)("tbFruit")), ((V)("tbTeapot")), ((V)("tbJar")), ((V)("tbGlobe"))))).Put("YRD", Arr(((V)("s:fence")), ((V)("s:ground")), ((V)("pergola")), Arr(((V)("house")), ((V)("house")), ((V)("house")), ((V)("house")), ((V)("pergola@royal"))), Arr(((V)("pool")), ((V)("pool")), ((V)("fountain")), ((V)("pool")), ((V)("pool"))), ((V)("firepit")), Arr(((V)("bbq")), ((V)("#kettleGrill")), ((V)("bbq")), ((V)("bbq")), ((V)("bbq"))), Arr(((V)("chair")), ((V)("chair")), ((V)("lsofa")), ((V)("chaise")), ((V)("chaise"))), Arr(((V)("hammock")), ((V)("hammock")), ((V)("swing")), ((V)("swing")), ((V)("hammock"))), ((V)("bench")), Arr(((V)("table")), ((V)("table")), ((V)("bistro")), ((V)("table")), ((V)("table"))), Arr(((V)("bucket")), ((V)("stump")), ((V)("bucket")), ((V)("bistro")), ((V)("bistro"))), Arr(((V)("lantern")), ((V)("solar")), ((V)("s:ylight")), ((V)("solar")), ((V)("lantern"))), Arr(((V)("tirebed")), ((V)("flowerBed")), ((V)("flowerPot")), ((V)("flowerBed")), ((V)("bonsai"))), ((V)("tree")), Arr(((V)("cardbox*0.7")), ((V)("house*0.5")), ((V)("seesaw*0.6")), ((V)("house*0.6")), ((V)("dome*0.6"))), Arr(((V)("ringToss")), ((V)("toss")), ((V)("pong")), ((V)("golf")), ((V)("holo"))), Arr(((V)("mat")), ((V)("rug2.stripe")), ((V)("rug2.zig")), ((V)("rug2")), ((V)("rug2.rainbow"))), Arr(((V)("gnome")), ((V)("spinner")), ((V)("birdbath")), ((V)("urn")), ((V)("spinner"))), Arr(((V)("bucket*0.6")), ((V)("bucket*0.6")), ((V)("tiki*0.6")), ((V)("tbTeapot")), ((V)("tbGlobe"))))).Put("BED", Arr(((V)("s:wall")), ((V)("s:floor")), ((V)("s:ceil")), ((V)("s:win")), ((V)("bed")), ((V)("linens")), Arr(((V)("cardbox*0.7")), ((V)("nightstand")), ((V)("nightstand")), ((V)("nightstand")), ((V)("nightstand"))), Arr(((V)("tableLamp")), ((V)("tableLamp")), ((V)("sconce")), ((V)("tableLamp")), ((V)("tableLamp"))), ((V)("s:light")), Arr(((V)("garmrack")), ((V)("wardrobe")), ((V)("wardrobe")), ((V)("wardrobe")), ((V)("wardrobe"))), Arr(((V)("dresser*0.8")), ((V)("dresser")), ((V)("dresser")), ((V)("dresser")), ((V)("dresser"))), Arr(((V)("tray")), ((V)("desk")), ((V)("desk")), ((V)("desk")), ((V)("desk"))), Arr(((V)("stool")), ((V)("pouf")), ((V)("armchair")), ((V)("armchair")), ((V)("armchair"))), Arr(((V)("chest")), ((V)("bench")), ((V)("bench")), ((V)("bench")), ((V)("bench"))), Arr(((V)("mirror")), ((V)("cheval")), ((V)("cheval")), ((V)("cheval")), ((V)("cheval"))), ((V)("petbed")), Arr(((V)("mat")), ((V)("rug2.shag")), ((V)("rug2.runner")), ((V)("rug2")), ((V)("rug2.oval"))), Arr(((V)("tbClock")), ((V)("tbRadio")), ((V)("tbClock")), ((V)("projDev")), ((V)("holo*0.45"))), Arr(((V)("poster.stars")), ((V)("gallery")), ((V)("gallery")), ((V)("poster")), ((V)("poster.sunset"))), Arr(((V)("tbCup")), ((V)("tbPerfume")), ((V)("tbBooks")), ((V)("tbCandles")), ((V)("tbSnow"))))).Put("CLB", Arr(((V)("s:wall")), ((V)("s:floor")), ((V)("s:ceil")), ((V)("s:door")), ((V)("dj")), Arr(((V)("speaker@junk")), ((V)("decks")), ((V)("decks")), ((V)("decks")), ((V)("holo"))), Arr(((V)("speaker")), ((V)("speaker")), ((V)("spkWall")), ((V)("spkTower")), ((V)("sub"))), Arr(((V)("s:light")), ((V)("s:light")), ((V)("spot")), ((V)("laser")), ((V)("crystal"))), Arr(((V)("fan")), ((V)("smokeSpk")), ((V)("smokeSpk")), ((V)("smokeSpk")), ((V)("smokeSpk"))), Arr(((V)("icechest")), ((V)("bar")), ((V)("bar")), ((V)("bar")), ((V)("bar"))), Arr(((V)("sofa@retro")), ((V)("lsofa")), ((V)("usofa")), ((V)("usofa")), ((V)("pit"))), Arr(((V)("crate")), ((V)("stool@retro")), ((V)("gcube")), ((V)("stool")), ((V)("gcube"))), Arr(((V)("#spoolTable")), ((V)("bistro+tall")), ((V)("coffee")), ((V)("coffee")), ((V)("coffee"))), Arr(((V)("stool")), ((V)("bistro")), ((V)("bistro+tall")), ((V)("bistro")), ((V)("bistro"))), Arr(((V)("dart")), ((V)("pinball")), ((V)("arcade")), ((V)("pong")), ((V)("holo"))), Arr(((V)("cardbox*0.6")), ((V)("stage*0.45")), ((V)("decks*0.5")), ((V)("pouf")), ((V)("stage*0.45"))), Arr(((V)("mat")), ((V)("rug2.runner")), ((V)("rug2")), ((V)("rug2.runner")), ((V)("rug2.rainbow"))), Arr(((V)("beanpile")), ((V)("lamp@retro")), ((V)("gcube")), ((V)("chaise")), ((V)("chaise"))), Arr(((V)("poster.stars")), ((V)("neonSign")), ((V)("gallery")), ((V)("ledWall")), ((V)("infinity"))), Arr(((V)("cups")), ((V)("tbJar")), ((V)("tbCandles")), ((V)("tbTrophy")), ((V)("tbGlobe"))))).V;
RETRO_48 = NewRegExp(RX155, "\\bretro\\b|diner|70s|jukebox|vintage red|cola|neon pinball|'now showing'", "i");
FLOAT_49 = NewRegExp(RX156, "levitat|floating|hover|zero-g|anti-grav|suspended magnetic|magnetic cloud", "i");
HOLO_50 = NewRegExp(RX157, "holo|hologra|bioluminescent|plasma|quantum|aurora|nebula", "i");
specFor_52 = Fn((V _arrowThis2527, int _argc2520, V r_2526, V _a2523, V _a2524, V _a2525, V[] _rest2521) => {
V e_2528 = default;
e_2528 = (GetK(M_47, Get(r_2526, "room")) is var _t2529 && !Truthy(_t2529) ? _t2529 : GetIdx(GetK(M_47, Get(r_2526, "room")), (ToNum(Get(r_2526, "slot")) - 1D)));
if (!(Truthy(e_2528))) {
return Call(parseSpec_51, V.Undef, ((V)("box")));
}
return Call(parseSpec_51, V.Undef, ((e_2528.O is JsArray) ? GetIdx(e_2528, (ToNum(Get(r_2526, "tier")) - 1D)) : e_2528));
return default;
}, 1, "", true);
pd_53 = Fn((V _arrowThis2541, int _argc2530, V d_2536, V f_2537, V s_2538, V w_2539, V[] _rest2531) => {
V o_2540 = default;
o_2540 = (_argc2530 > 4 ? _rest2531[0] : V.Undef);
return NewObj(5).Put("d", d_2536).Put("f", f_2537).Put("s", (s_2538 is var _t2542 && Truthy(_t2542) ? _t2542 : ((V)("none")))).Put("w", (w_2539 is var _t2543 && Truthy(_t2543) ? _t2543 : ((V)(0D)))).Put("o", (o_2540.IsNullish ? ((V)(1D)) : o_2540)).V;
}, 5, "", true);
rr_54 = Fn((V _arrowThis2555, int _argc2544, V x_2550, V y_2551, V w_2552, V h_2553, V[] _rest2545) => {
V r_2554 = default;
r_2554 = (_argc2544 > 4 ? _rest2545[0] : V.Undef);
r_2554 = ((V)(Min(ToNum(r_2554), (ToNum(w_2552) / 2D), (ToNum(h_2553) / 2D))));
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_25, V.Undef, Add(x_2550, r_2554))).S(" ").V(Call(f1_25, V.Undef, y_2551)).S("H").V(Call(f1_25, V.Undef, ((V)((ToNum(Add(x_2550, w_2552)) - ToNum(r_2554)))))).S("A").V(r_2554).S(" ").V(r_2554).S(" 0 0 1 ").V(Call(f1_25, V.Undef, Add(x_2550, w_2552))).S(" ").V(Call(f1_25, V.Undef, Add(y_2551, r_2554))).S("V").V(Call(f1_25, V.Undef, ((V)((ToNum(Add(y_2551, h_2553)) - ToNum(r_2554)))))).S("A").V(r_2554).S(" ").V(r_2554).S(" 0 0 1 ").V(Call(f1_25, V.Undef, ((V)((ToNum(Add(x_2550, w_2552)) - ToNum(r_2554)))))).S(" ").V(Call(f1_25, V.Undef, Add(y_2551, h_2553))).S("H").V(Call(f1_25, V.Undef, Add(x_2550, r_2554))).S("A").V(r_2554).S(" ").V(r_2554).S(" 0 0 1 ").V(Call(f1_25, V.Undef, x_2550)).S(" ").V(Call(f1_25, V.Undef, ((V)((ToNum(Add(y_2551, h_2553)) - ToNum(r_2554)))))).S("V").V(Call(f1_25, V.Undef, Add(y_2551, r_2554))).S("A").V(r_2554).S(" ").V(r_2554).S(" 0 0 1 ").V(Call(f1_25, V.Undef, Add(x_2550, r_2554))).S(" ").V(Call(f1_25, V.Undef, y_2551)).S("Z").End()));
return default;
}, 5, "", true);
circ_55 = Get(K_9, "circ");
ell_56 = Get(K_9, "ell");
has_57 = Fn((V _arrowThis2564, int _argc2556, V n_2562, V re_2563, V _a2560, V _a2561, V[] _rest2557) => {
return Invoke(re_2563, "test", n_2562);
}, 2, "", true);
rnd_58 = Fn((V _arrowThis2572, int _argc2565, V s_2571, V _a2568, V _a2569, V _a2570, V[] _rest2566) => {
double h_2573 = 0;
h_2573 = 0D;
{
foreach (V _k2574 in new JsIter(s_2571)) {
V c_2575 = default;
c_2575 = _k2574;
h_2573 = ((double)(ToInt32(ToNum(Add(((V)((h_2573 * 31D))), Invoke(c_2575, "charCodeAt", ((V)(0D)))))) | ToInt32(0D)));
}
}
return Fn((V _arrowThis2582, int _argc2576, V _a2578, V _a2579, V _a2580, V _a2581, V[] _rest2577) => {
h_2573 = ((double)(ToInt32(((h_2573 * 1103515245D) + 12345D)) | ToInt32(0D)));
return ((V)((((double)(ToInt32(((double)(ToUint32(h_2573) >> (int)(ToUint32(8D) & 31)))) & ToInt32(65535D))) / 65536D)));
return default;
}, 0, "", true);
return default;
}, 1, "", true);
swPolys_64 = Fn((V _arrowThis2592, int _argc2583, V id_2589, V spec_2590, V arch_2591, V _a2588, V[] _rest2584) => {
SetK(Get(X_8, "SURF"), id_2589, NewObj(1).Put("arch", arch_2591).V);
SetK(Get(X_8, "SPEC"), id_2589, spec_2590);
return Invoke(X_8, "swatch", id_2589);
return default;
}, 3, "", true);
SD_66 = ((V)("<radialGradient id=\"hiW\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff\" stop-opacity=\"0.85\"/><stop offset=\"1\" stop-color=\"#fff\" stop-opacity=\"0\"/></radialGradient><radialGradient id=\"gWarm\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff2b0\" stop-opacity=\"0.6\"/><stop offset=\"1\" stop-color=\"#fff2b0\" stop-opacity=\"0\"/></radialGradient><radialGradient id=\"gNeon\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#ffe9a0\" stop-opacity=\"0.75\"/><stop offset=\"1\" stop-color=\"#ffe9a0\" stop-opacity=\"0\"/></radialGradient><linearGradient id=\"hsSky\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#9fd2f2\"/><stop offset=\"1\" stop-color=\"#e6f4fb\"/></linearGradient><linearGradient id=\"hsWood\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#e2ad74\"/><stop offset=\"1\" stop-color=\"#b97a42\"/></linearGradient><radialGradient id=\"bMirror\" cx=\"35%\" cy=\"30%\" r=\"80%\"><stop offset=\"0\" stop-color=\"#f4fbfd\"/><stop offset=\"1\" stop-color=\"#a9d3e3\"/></radialGradient><radialGradient id=\"dBall\" cx=\"35%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#fff\"/><stop offset=\"0.5\" stop-color=\"#c9cde8\"/><stop offset=\"1\" stop-color=\"#6c72a8\"/></radialGradient><radialGradient id=\"hsGold\" cx=\"35%\" cy=\"30%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#fff6c8\"/><stop offset=\"0.5\" stop-color=\"#ffd66b\"/><stop offset=\"1\" stop-color=\"#d99a20\"/></radialGradient><radialGradient id=\"hsClock\" cx=\"38%\" cy=\"32%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#fffdf7\"/><stop offset=\"1\" stop-color=\"#efe2cc\"/></radialGradient>"));
esc_67 = Fn((V _arrowThis2600, int _argc2593, V s_2599, V _a2596, V _a2597, V _a2598, V[] _rest2594) => {
return Invoke(Invoke(((V)(ToStrS(s_2599))), "replace", NewRegExp(RX159, "&", "g"), ((V)("&amp;"))), "replace", NewRegExp(RX158, "\"", "g"), ((V)("&quot;")));
}, 1, "", true);
svgOf_68 = Fn((V _arrowThis2610, int _argc2601, V vb_2607, V polys_2608, V gids_2609, V _a2606, V[] _rest2602) => {
V G_2611 = default;
V d_2612 = default;
G_2611 = Invoke(X_8, "grads", (gids_2609 is var _t2613 && Truthy(_t2613) ? _t2613 : Arr()));
d_2612 = Add(SD_66, (Get(X_8, "MDEFS") is var _t2614 && Truthy(_t2614) ? _t2614 : ((V)(""))));
Invoke(Get(G_2611, "lin"), "forEach", Fn((V _arrowThis2622, int _argc2615, V g_2621, V _a2618, V _a2619, V _a2620, V[] _rest2616) => {
return (d_2612 = ((V)(JsStrBuf.Begin().V(d_2612).S("<linearGradient id=\"").V(Get(g_2621, "id")).S("\" x1=\"0\" y1=\"0\" x2=\"").V(Get(g_2621, "x2")).S("\" y2=\"").V(Get(g_2621, "y2")).S("\"><stop offset=\"0\" stop-color=\"").V(Get(g_2621, "c0")).S("\"/><stop offset=\"1\" stop-color=\"").V(Get(g_2621, "c1")).S("\"/></linearGradient>").End())));
}, 1, "", true));
Invoke(Get(G_2611, "rad"), "forEach", Fn((V _arrowThis2630, int _argc2623, V g_2629, V _a2626, V _a2627, V _a2628, V[] _rest2624) => {
return (d_2612 = ((V)(JsStrBuf.Begin().V(d_2612).S("<radialGradient id=\"").V(Get(g_2629, "id")).S("\" cx=\"36%\" cy=\"30%\" r=\"78%\"><stop offset=\"0\" stop-color=\"").V(Get(g_2629, "c0")).S("\"/><stop offset=\"1\" stop-color=\"").V(Get(g_2629, "c1")).S("\"/></radialGradient>").End())));
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, ((V)(JsStrBuf.Begin().S("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"").V(vb_2607).S("\"><defs>").V(d_2612).S("</defs>").V(Call(pstr_69, V.Undef, polys_2608)).S("</svg>").End())))).End()));
return default;
}, 3, "", true);
pstr_69 = Fn((V _arrowThis2638, int _argc2631, V polys_2637, V _a2634, V _a2635, V _a2636, V[] _rest2632) => {
JsStrBuf b_2639 = null;
b_2639 = new JsStrBuf("");
Invoke(polys_2637, "forEach", Fn((V _arrowThis2647, int _argc2640, V p_2646, V _a2643, V _a2644, V _a2645, V[] _rest2641) => {
return ((V)(b_2639.V((!Get(p_2646, "raw").IsNullish ? Get(p_2646, "raw") : ((V)(JsStrBuf.Begin().S("<path d=\"").V(Get(p_2646, "d")).S("\" fill=\"").V(Call(esc_67, V.Undef, Get(p_2646, "f"))).S("\" stroke=\"").V(Call(esc_67, V.Undef, Get(p_2646, "s"))).S("\" stroke-width=\"").V(Get(p_2646, "w")).S("\" opacity=\"").V(Get(p_2646, "o")).S("\" stroke-linejoin=\"round\" stroke-linecap=\"round\"/>").End())))).Str));
}, 1, "", true));
return ((V)(b_2639.Str));
return default;
}, 1, "", true);
svgDoc_70 = Fn((V _arrowThis2657, int _argc2648, V vb_2654, V gids_2655, V body_2656, V _a2653, V[] _rest2649) => {
V G_2658 = default;
V d_2659 = default;
G_2658 = Invoke(X_8, "grads", (gids_2655 is var _t2660 && Truthy(_t2660) ? _t2660 : Arr()));
d_2659 = Add(SD_66, (Get(X_8, "MDEFS") is var _t2661 && Truthy(_t2661) ? _t2661 : ((V)(""))));
Invoke(Get(G_2658, "lin"), "forEach", Fn((V _arrowThis2669, int _argc2662, V g_2668, V _a2665, V _a2666, V _a2667, V[] _rest2663) => {
return (d_2659 = ((V)(JsStrBuf.Begin().V(d_2659).S("<linearGradient id=\"").V(Get(g_2668, "id")).S("\" x1=\"0\" y1=\"0\" x2=\"").V(Get(g_2668, "x2")).S("\" y2=\"").V(Get(g_2668, "y2")).S("\"><stop offset=\"0\" stop-color=\"").V(Get(g_2668, "c0")).S("\"/><stop offset=\"1\" stop-color=\"").V(Get(g_2668, "c1")).S("\"/></linearGradient>").End())));
}, 1, "", true));
Invoke(Get(G_2658, "rad"), "forEach", Fn((V _arrowThis2677, int _argc2670, V g_2676, V _a2673, V _a2674, V _a2675, V[] _rest2671) => {
return (d_2659 = ((V)(JsStrBuf.Begin().V(d_2659).S("<radialGradient id=\"").V(Get(g_2676, "id")).S("\" cx=\"36%\" cy=\"30%\" r=\"78%\"><stop offset=\"0\" stop-color=\"").V(Get(g_2676, "c0")).S("\"/><stop offset=\"1\" stop-color=\"").V(Get(g_2676, "c1")).S("\"/></radialGradient>").End())));
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"").V(vb_2654).S("\"><defs>").V(d_2659).S("</defs>").V(body_2656).S("</svg>").End()));
return default;
}, 3, "", true);
projOf_71 = Fn((V _arrowThis2686, int _argc2678, V Z_2684, V ra_2685, V _a2682, V _a2683, V[] _rest2679) => {
double t_2687 = 0;
double c_2688 = 0;
double s_2689 = 0;
double k_2690 = 0;
t_2687 = ((ToNum((ra_2685.IsNullish ? ((V)((-30D))) : ra_2685)) * PI_33) / 180D);
c_2688 = FdLibm.Cos(t_2687);
s_2689 = FdLibm.Sin(t_2687);
k_2690 = (ToNum(Get(X_8, "FS")) * ToNum(Z_2684));
return Fn((V _arrowThis2700, int _argc2691, V x_2697, V y_2698, V z_2699, V _a2696, V[] _rest2692) => {
return Arr(((V)((((ToNum(x_2697) * c_2688) + (ToNum(z_2699) * s_2689)) * k_2690))), ((V)(((((((-ToNum(x_2697)) * s_2689) + (ToNum(z_2699) * c_2688)) * k_2690) * ToNum(Get(X_8, "SA"))) - ((ToNum(y_2698) * k_2690) * ToNum(Get(X_8, "CA")))))));
}, 3, "", true);
return default;
}, 2, "", true);
HOSTB_72 = NewRegExp(RX160, "^(table|coffee|bistro|counter|diningTable|luxCounter|nightstand|#spoolTable|cart|bar|desk|dresser)$", "");
MEMO_73 = New(G("Map"));
Set(G("window"), "RenoDraw", NewObj(11).Put("draw", draw_74).Put("parseCSV", parseCSV_75).Put("MAP", M_47).Put("N", N_44).Put("H", H_46).Put("projOf", projOf_71).Put("svgDoc", svgDoc_70).Put("pstr", pstr_69).Put("colorsOf", colorsOf_40).Put("MEMO", MEMO_73).Put("rr", rr_54).V);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
