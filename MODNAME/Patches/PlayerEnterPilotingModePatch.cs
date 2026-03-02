using HarmonyLib;

namespace MODNAME.Patches
{
    // https://harmony.pardeike.net/articles/patching.html
    [HarmonyPatch(typeof(Player), nameof(Player.EnterPilotingMode))]
    internal static class PlayerEnterPilotingModePatch
    {
        [HarmonyPrefix]
        private static bool Prefix(Player __instance__, PilotingChair chair, bool keepCinematicState = false)
        {
            // Runs before the player enters piloting mode
            // Can be cancelled by returning false
            return true; // Return true to continue with the original method, false to skip it
        }

        [HarmonyPostfix]
        private static void Postfix(Player __instance__, PilotingChair chair, bool keepCinematicState = false)
        {
            // Runs after the player enters piloting mode
        }
    }
}
