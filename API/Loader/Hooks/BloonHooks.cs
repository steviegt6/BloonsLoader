using Assets.Scripts.Simulation.Bloons;
using BloonsLoader.API.Loader.Globals;
using Harmony;
using System;

namespace BloonsLoader.API.Loader.Hooks
{
    public static class BloonHooks
    {
        public static void AddDelegates(BloonManager bloonManager)
        {
            foreach (Mod mod in ModLoader.Mods)
                foreach (Type type in mod.Code.GetTypes())
                    if (type.IsSubclassOf(typeof(GlobalBloon)))
                    {
                        GlobalBloon global = Activator.CreateInstance(type) as GlobalBloon;

                        bloonManager.OnBloonLeaked.delegates.Add(new Il2CppSystem.Delegate(new IntPtr(global.OnBloonLeaked() *));
                        bloonManager.OnBloonDegrade.delegates.Add(global.OnBloonDegrade());
                        bloonManager.OnBloonSpawned.delegates.Add(global.OnBloonSpawned());
                    }
        }
    }

    [HarmonyPatch(typeof(BloonManager))]
    [HarmonyPatch(MethodType.Constructor)]
    public static class BloonManager_Patch
    {
        [HarmonyPostfix]
        public static void PostCtor(BloonManager __instance) => BloonHooks.AddDelegates(__instance);
    }
}