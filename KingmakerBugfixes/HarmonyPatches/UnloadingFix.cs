using Harmony12;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Bugfixes
{
    [HarmonyPatch()]
    class UnloadingFix
    {
        public static MethodInfo TargetMethod()
        {
            return AccessTools.DeclaredMethod(AccessTools.TypeByName("Kingmaker.EntitySystem.Persistence.AreaDataStash"), "ClearAll");
        }

        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
            Type[] parameters = { typeof(string), typeof(bool) };
            MethodInfo deleteMethod = AccessTools.DeclaredMethod(typeof(System.IO.Directory), nameof(System.IO.Directory.Delete), parameters);

            for (int i = 0; i < codes.Count; i++)
            {
                // Locate the Directory.Delete call
                if (codes[i].opcode == OpCodes.Call && ((MethodInfo)codes[i].operand).ToString() == deleteMethod.ToString())
                {
                    // Replace it with a call to UnloadingFix.RenameDelete
                    MethodInfo renameDelete = AccessTools.DeclaredMethod(typeof(UnloadingFix), nameof(UnloadingFix.RenameDelete));
                    CodeInstruction renameDeleteInstruction = new CodeInstruction(OpCodes.Call, renameDelete);
                    codes[i] = renameDeleteInstruction;
                    break;
                }
            }

            return codes.AsEnumerable();
        }

        public static void RenameDelete(string path, bool recursive)
        {
            string destDirName = path + "tmp";
            Directory.Move(path, destDirName);
            Directory.Delete(destDirName, recursive);
        }
    }
}
