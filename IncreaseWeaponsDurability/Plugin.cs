using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using IncreaseWeaponsDurability.Patches;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreaseWeaponsDurability
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class IncreaseWeaponsDurability : BaseUnityPlugin
    {
        private const string modGUID = "Eliijahh.IncreaseWeaponsDurability";
        private const string modName = "Increase Weapons Durability";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static IncreaseWeaponsDurability Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if(Instance == null) 
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("The Increase Weapons Durability mod has awakened.");

            harmony.PatchAll();
        }
    }
}
