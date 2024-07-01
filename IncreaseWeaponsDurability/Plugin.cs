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

namespace DecreaseWeaponsDegradation
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class DecreaseWeaponsDegradation : BaseUnityPlugin
    {
        private const string modGUID = "Eliijahh.DecreaseWeaponsDegradation";
        private const string modName = "Decrease Weapons Durability";
        private const string modVersion = "1.0.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static DecreaseWeaponsDegradation Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if(Instance == null) 
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("The Decrease Weapons Degradation mod has awakened.");

            harmony.PatchAll();
        }
    }
}
