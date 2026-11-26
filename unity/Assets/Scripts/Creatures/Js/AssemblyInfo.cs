// The rig runtime is its own assembly (SquishSquad.Rig.asmdef: no engine, so the generated code compiles apart from
// the game's). The game's code that reads the realm back (Creatures/RigTree, RigStage, Games/Yard/YardJs) uses its
// fast internals (JsArray.Len, JsObject.N), so the game's assembly sees them.
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SquishSquad.Runtime")]
