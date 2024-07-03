using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DecreaseWeaponsDegradation.Patches
{
    [HarmonyPatch(typeof(BreakableItemComponent))]
    internal class BreakableItemComponentPatch
    {

        [HarmonyPatch("Break")]
        [HarmonyPrefix]
        static bool decreaseWeaponsDegradation(BreakableItemComponent __instance, ref int val) 
        {
            float degradationRateMultiplier = DecreaseWeaponsDegradation.WeaponsDegradationMultiplier.Value; // Use the configurable value

            if (__instance.Unbreakable)
            {
                return false;
            }
            float num = (float)val * degradationRateMultiplier / (float)__instance.MaxDurability;
            Traverse.Create(__instance).Property("CurrentPercent").SetValue(Mathf.Clamp01(__instance.CurrentPercent - num));

            return false;
        }
    }
}
