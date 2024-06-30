using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace IncreaseWeaponsDurability.Patches
{
    [HarmonyPatch(typeof(BreakableItemComponent))]
    internal class BreakableItemComponentPatch
    {

        [HarmonyPatch("Break")]
        [HarmonyPrefix]
        static bool decreaseItemConsumption(BreakableItemComponent __instance, ref int val) 
        {
            if (__instance.Unbreakable)
            {
                return false;
            }
            float num = (float)val * 0.5f / (float)__instance.MaxDurability;
            Traverse.Create(__instance).Property("CurrentPercent").SetValue(Mathf.Clamp01(__instance.CurrentPercent - num));

            return false;
        }
    }
}
