using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using System.IO;
using System.Reflection;

namespace BloonsLoader.API.Loader
{
    public static class ModLoader
    {
        /// <summary>
        /// List of loaded mods.
        /// </summary>
        public static Mod[] Mods;

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

            int modCount = 0;
            List<string> modsToLoad = FindMods();
            Assembly[] loadedMods = new Assembly[modCount];

            foreach (string mod in modsToLoad)
            {
                modCount++;
                Array.Resize(ref loadedMods, modCount + 1);
                loadedMods[modCount] = Assembly.LoadFile(mod);
            }

            modCount = 0;

            foreach (Assembly loadedMod in loadedMods)
                foreach (Type type in loadedMod.GetTypes())
                    if (type.IsAssignableFrom(typeof(Mod)))
                    {
                        modCount++;
                        Array.Resize(ref Mods, modCount + 1);
                        Mods[modCount] = Activator.CreateInstance(type) as Mod;
                        MelonLogger.Log($"Loaded mod: {Mods[modCount].DisplayName} version: {Mods[modCount].ModVersion}");
                    }

            MelonLogger.Log("Loaded mods.");
        }
    }
}