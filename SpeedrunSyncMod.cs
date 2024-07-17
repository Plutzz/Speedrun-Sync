using Modding;
using RandomizerMod.RandomizerData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BossTrackerMod
{
    public class SpeedrunSyncMod : Mod, IGlobalSettings<GlobalSettings>
    {
        internal static SpeedrunSyncMod Instance;
        new public string GetName() => "Speedrun Sync";
        public override string GetVersion() => "1.2.0.1";

        public static GlobalSettings GS = new();
        public void OnLoadGlobal(GlobalSettings gs) => GS = gs;
        public GlobalSettings OnSaveGlobal() => GS;

        internal Dictionary<string, Func<List<VanillaDef>>> Interops = new();
        public SpeedrunSync SpeedrunSync;
        public SpeedrunSyncMod()
        {
            Instance = this;
        }
        public override void Initialize()
        {
            if (ModHooks.GetMod("ItemSyncMod") is not Mod) return;

            Interop.FindInteropMods();
            SpeedrunSync = new SpeedrunSync();
            Menu.Hook();
        }
    }
}