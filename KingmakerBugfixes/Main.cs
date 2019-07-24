using Harmony12;
using UnityModManagerNet;

namespace Bugfixes
{
    public class Main
    {
        public static UnityModManager.ModEntry.ModLogger Logger;

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            Logger = modEntry.Logger;
            modEntry.OnToggle = OnToggle;
            return true;
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool active)
        {
            HarmonyInstance harmony = HarmonyInstance.Create(modEntry.Info.Id);
            if (active)
            {
                harmony.PatchAll();
            }
            else
            {
                harmony.UnpatchAll();
            }
            return true;
        }
    }
}
