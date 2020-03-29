using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using System.Reflection;
using Verse.Sound;
using UnityEngine;

namespace Tilled_Soil_Zilla
{

    public class TilledSoilMod : Mod
    {

        public static TilledSoilSettings settings;

        public TilledSoilMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<TilledSoilSettings>();
        }

        public static void ApplySettings()
        {

            BuildableDef fertility = TerrainDef.Named("Ti" +
                "lledSoil");
            fertility.description = ("Tilled Soil, for planting and growing crops on.");
            fertility.fertility = settings.Fertility;

        }
        public static void ApplySettings2()
        {
            BuildableDef cost = TerrainDef.Named("TilledSoil");
            cost.costList = new List<ThingDefCountClass>() { new ThingDefCountClass(ThingDefOf.WoodLog, settings.soilcost) };
        }

        public override string SettingsCategory()
        {
            return "Tilled Soil";
        }
        
        public override void DoSettingsWindowContents(Rect inRect)
        {

            string str1 = settings.fertility.ToString();
            string str2 = settings.soilcost.ToString();
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.ColumnWidth = 200f;
            listingStandard.Label("Fertility %", -1f);
            listingStandard.Gap(10f);
            listingStandard.Label("Place on anything", -1f);
            listingStandard.Gap(10f);
            listingStandard.Label("Requires Wood", -1f);
            listingStandard.Gap(10f);
            listingStandard.Label("Construction cost in wood", -1f);
            listingStandard.Gap(10f);
            if (listingStandard.ButtonText("Reset", null))
            {
                settings.fertility = 120f;
                str1 = "100";
                settings.placeonanything = false;
                settings.requirecost = false;
                settings.soilcost = 1;
                str2 = "1";
            }
            listingStandard.NewColumn();
            listingStandard.ColumnWidth = 200f;

            float previousfertility = settings.fertility;
            listingStandard.TextFieldNumeric(ref settings.fertility, ref str1, 70, 10000);
            if (settings.fertility != previousfertility)
            {
                ApplySettings();
            }
            listingStandard.Gap(10f);

            bool previousTerrainAffordanceDef = settings.placeonanything;
            listingStandard.CheckboxLabeled("", ref settings.placeonanything);
            TerrainAffordanceDef placeonanything = settings.placeonanything ? TerrainAffordanceDefOf.Light : TerrainAffordanceDefOf.GrowSoil;
            if (settings.placeonanything != previousTerrainAffordanceDef)
            {
                TerrainDef soilplacement = TerrainDef.Named("TilledSoil");
                soilplacement.terrainAffordanceNeeded = placeonanything;
            }
            listingStandard.Gap(10f);

 
            bool previousState = settings.requirecost;
            listingStandard.CheckboxLabeled("", ref settings.requirecost);
            if (settings.requirecost != previousState)
            {
                BuildableDef togglecost = TerrainDef.Named("TilledSoil");
                togglecost.costList = new List<ThingDefCountClass>() { new ThingDefCountClass(null, 0) };
                //ApplySettings();
            }
            listingStandard.Gap(10f);

            int previousCost = settings.soilcost;
            listingStandard.TextFieldNumeric(ref settings.soilcost, ref str2, 0, 100);
           // if (settings.requirecost == true)
           // {
            //    ApplySettings2();
            //}
            listingStandard.NewColumn();
            listingStandard.ColumnWidth = 500f;
            listingStandard.Label("100% = Normal soil, 140% = Rich soil, 120% is default.");
            listingStandard.Gap(10f);
            listingStandard.Label("Toggles between placing on only soil and everything.");
            listingStandard.Gap(10f);
            listingStandard.Label("Does the Tilled Soil require wood to construct?");
            listingStandard.Gap(10f);
            listingStandard.Label("How much wood is required for 1 tile.");
            listingStandard.Gap(10f);
            listingStandard.Label("RESTART TO APPLY CHANGES");
            listingStandard.End();
            settings.Write();
        }
    }
}