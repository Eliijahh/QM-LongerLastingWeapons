using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using DecreaseWeaponsDegradation.Patches;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Configuration;

namespace DecreaseWeaponsDegradation
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class DecreaseWeaponsDegradation : BaseUnityPlugin
    {
        private const string modGUID = "Eliijahh.DecreaseWeaponsDegradation";
        private const string modName = "Decrease Weapons Durability";
        private const string modVersion = "1.0.0.2";

        public static ConfigEntry<float> WeaponsDegradationMultiplier;
        private readonly Harmony harmony = new Harmony(modGUID);

        private static DecreaseWeaponsDegradation Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if(Instance == null) 
            {
                Instance = this;
            }

            WeaponsDegradationMultiplier = Config.Bind("General", "WeaponsDegradationMultiplier", 0.5f, "The multiplier to increase or decrease the weapons degradation rate. When set to 1, there is no change from unmodded.");

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("The Decrease Weapons Degradation mod has awakened.");

            harmony.PatchAll();
        }
    }
}
