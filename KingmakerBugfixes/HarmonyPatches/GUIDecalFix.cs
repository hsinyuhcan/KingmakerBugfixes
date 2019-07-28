using DG.Tweening;
using Harmony12;
using Kingmaker.Visual.Decals;

namespace Bugfixes.HarmonyPatches
{
    internal static class GUIDecalFix
    {
        // fix the ability circle will not show up properly when you first time select an ability on an unit via hotkey  
        [HarmonyPatch(typeof(GUIDecal), "InitAnimator")]
        static class GUIDecal_InitAnimator_Patch
        {
            [HarmonyPostfix]
            static void Postfix(Tweener ___m_AppearAnimation, Tweener ___m_DisappearAnimation)
            {
                ___m_AppearAnimation.Pause();
                ___m_DisappearAnimation.Pause();
            }
        }
    }
}
