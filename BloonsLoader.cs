using BloonsLoader.API.Loader;
using MelonLoader;

namespace BloonsLoader
{
    public class BloonsLoader : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Log("BloonsLoader started.");

            ModLoader.LoadMods();
        }

        public override void OnApplicationQuit()
        {
            MelonLogger.Log("BloonsLoader quit.");
        }
    }
}