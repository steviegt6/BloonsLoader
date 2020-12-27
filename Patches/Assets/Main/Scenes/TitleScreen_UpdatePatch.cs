using Assets.Main.Scenes;
using BloonsLoader.API.Loader;
using Harmony;
using MelonLoader;
using System.Linq;
using TMPro;
using UnhollowerBaseLib;
using UnityEngine;
using UnityEngine.UI;

namespace BloonsLoader.Patches.Assets.Main.Scenes
{
    [HarmonyPatch(typeof(TitleScreen), nameof(TitleScreen.Update))]
    public static class TitleScreen_UpdatePatch
    {
        // Allow us to make one-time modifications
        public static bool FirstUpdate = false;

        [HarmonyPostfix]
        public static void PostUpdate(TitleScreen __instance)
        {
            if (!FirstUpdate)
            {
                // Move the text further to the side
                Vector3 buildInfoPos = __instance.buildInfo.transform.position;
                buildInfoPos.x *= 4;
                __instance.buildInfo.transform.position = buildInfoPos;

                __instance.buildInfo.text = "BloonsLoader v0.0.1.0\n" + __instance.buildInfo.text;

                // Color a specific word
                __instance.anEpicAdventureOf.text = "an epic modded adventure of monkeys vs bloons"; // Text splitting pre-handled

                FirstUpdate = true;
            }
        }
    }
}