using UnityEngine;
using Verse;
using RimWorld;

namespace Tilled_Soil_Zilla
{
    [StaticConstructorOnStartup]
    public class TilledSoilMod : Mod
    {

        public static TilledSoilSettings settings;
      
        public TilledSoilMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<TilledSoilSettings>();
        }

        void ApplySettings()
        {

            BuildableDef fertility = TerrainDef.Named("TilledSoil");
            fertility.description = (Translator.Translate("somethingsomethingsomething"));
            fertility.fertility = settings.Fertility;
        }

        public override string SettingsCategory()
        {
            return "Tilled Soil";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {

            string str1 = settings.fertility.ToString();
      //      string str2 = settings.soilcost.ToString();
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
            // if (listingStandard.ButtonText("Reset", null))
            // {
            //    settings.fertility = 200;
            //    settings.placeonanything = false;
            //    settings.requirecost = false;
            //    settings.soilcost = 1;
            //}
            listingStandard.NewColumn();
            listingStandard.ColumnWidth = 200f;

            float previousfertility = settings.fertility;
            listingStandard.TextFieldNumeric(ref settings.fertility, ref str1, 70, 10000);
            if (settings.fertility != previousfertility)
            {
                ApplySettings(); 
            }

            listingStandard.Gap(10f);


     //       bool previousTerrainAffordanceDef = settings.placeonanything;
     //       listingStandard.CheckboxLabeled("", ref settings.placeonanything);
      //      TerrainAffordanceDef placeonanything = settings.placeonanything ? TerrainAffordanceDefOf.Light : TerrainAffordanceDefOf.GrowSoil;
     //       if (settings.placeonanything != previousTerrainAffordanceDef)
     //       {
       //         TerrainDef soilplacement = TerrainDef.Named("TilledSoil");
     //           soilplacement.description = Translator.Translate("TilledSoilDesc");
     //           soilplacement.terrainAffordanceNeeded = placeonanything;
     //       }
            listingStandard.Gap(10f);

     //       listingStandard.CheckboxLabeled("", ref settings.requirecost);
            //fucking broke shit
            //        bool previousTick = settings.tick;
            //        listingStandard.CheckboxLabeled("Requires Wood?", ref settings.tick, "Does the soil require anything to build?");
            //        int tick = true ? 1 : 0;
            //        if (settings.tick != previousTick)
            //        {
            //            BuildableDef tilled = TerrainDef.Named("TilledSoil");
            //            tilled.description = (Translator.Translate("TilledSoilDesc"));
            //            tilled.costStuffCount = tick;
            //        }
            listingStandard.Gap(10f);

    //        int previousCost = settings.soilcost;
    //        listingStandard.TextFieldNumeric(ref settings.soilcost, ref str2, 0, 100);
    //        if (settings.soilcost != previousCost)
    //        {
     //           BuildableDef cost = TerrainDef.Named("TilledSoil");
                //cost.description = (Translator.Translate("TilledSoilDesc"));
      //          cost.costStuffCount = settings.soilcost;
         //   }

            listingStandard.NewColumn();
            listingStandard.ColumnWidth = 500f;
            listingStandard.Label("100% = Normal soil, 140% = Rich soil, 200% is default.");
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
    