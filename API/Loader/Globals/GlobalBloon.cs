using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Objects;
using BloonsLoader.API.Loader.Interfaces;
using Il2CppSystem;

namespace BloonsLoader.API.Loader.Globals
{
    /// <summary>
    /// Class that allows the modification of Bloons globally. <br />
    /// Also allows the modification of vanilla Bloons and Bloons added by other BloonsLoader mods (untested with Bloons from non-BloonsLoader mods).
    /// </summary>
    public abstract class GlobalBloon : IAutoloadable
    {
        public virtual bool Autoload() => true;

        public virtual void Load()
        {
        }

        public virtual void Unload()
        {
        }

        public virtual void ModifyStats(Bloon bloon)
        {
        }

        public virtual void OnBloonLeaked()
        {
        }

        public virtual void OnBloonDegrade()
        {
        }

        public virtual void OnBloonSpawned()
        {
        }
    }
}