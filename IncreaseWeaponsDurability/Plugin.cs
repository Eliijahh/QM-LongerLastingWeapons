using BepInEx;
using HarmonyLib;
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
        private const string modNmae = "Increase Weapons Durability";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static IncreaseWeaponsDurability Instance;

        void Awake()
        {
            if(Instance == null) 
            {
                Instance = this;
            }
        }
    }
}
