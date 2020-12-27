using System;
using System.Reflection;

namespace BloonsLoader.API
{
    /// <summary>
    /// Main mod class. <br />
    /// Used for basic interaction.
    /// </summary>
    public abstract class Mod
    {
        public abstract string DisplayName { get; }

        public abstract Version ModVersion { get; }

        public abstract string Description { get; }

        public Assembly Code { get; internal set; }

        /// <summary>
        /// Allows you to do things before loading has started. <br />
        /// This should not be used for much of anything, but the option is there if need be. <br />
        /// Called before content gets autoloaded.
        /// </summary>
        public virtual void PreLoad()
        {
        }

        /// <summary>
        /// Allows you to do things when your mod is first loaded.
        /// </summary>
        public virtual void Load()
        {
        }

        /// <summary>
        /// Allows you to do things once all mods have loaded their content.
        /// </summary>
        public virtual void PostLoad()
        {
        }
    }
}