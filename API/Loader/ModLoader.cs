using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace BloonsLoader.API.Loader
{
    public static class ModLoader
    {
        /// <summary>
        /// List of loaded mods.
        /// </summary>
        public static List<Mod> Mods;

        public static List<string> FindMods()
        {
            MelonLogger.Log("Finding mods.");

            string path = MelonLoaderBase.UserDataPath;
            path = Directory.GetParent(path).FullName + Path.DirectorySeparatorChar + "BloonsMods";
            List<string> mods = new List<string>();

            Directory.CreateDirectory(path);
            MelonLogger.Log("Mod directory: " + path);

            foreach (string file in Directory.GetFiles(path, "*.dll"))
                mods.Add(file);

            MelonLogger.Log("Mods found.");

            return mods;
        }

        public static void LoadMods()
        {
            MelonLogger.Log("Loading mods.");

            List<string> modsToLoad = FindMods();
            List<Assembly> loadedMods = new List<Assembly>();

            Mods = new List<Mod>();

            foreach (string mod in modsToLoad)
                loadedMods.Add(Assembly.LoadFile(mod));

            foreach (Assembly loadedMod in loadedMods)
                foreach (Type type in loadedMod.GetTypes())
                    if (type.IsSubclassOf(typeof(Mod)))
                    {
                        Mod mod = Activator.CreateInstance(type) as Mod;
                        Mods.Add(mod);
                        MelonLogger.Log($"Loaded mod: {mod.DisplayName} version: {mod.ModVersion}");
                    }

            MelonLogger.Log("Loaded mods.");
        }
    }
}