using BepInEx;
using EFT;
using SPT.Reflection.Patching;
using System.Reflection;

namespace SPTLeftStanceWallFix
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            new DisableLeftStanceFromHandsPatch().Enable();
        }
    }

    public class DisableLeftStanceFromHandsPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(LeftStanceController).GetMethod(nameof(LeftStanceController.DisableLeftStanceAnimFromHandsAction));
        }

        [PatchPrefix]
        private static bool PatchPrefix(LeftStanceController __instance)
        {
            return false; // bye bye!
        }
    }
}
