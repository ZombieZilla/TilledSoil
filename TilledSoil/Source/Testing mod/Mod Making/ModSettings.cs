using Verse;

namespace Tilled_Soil_Zilla
{

    [StaticConstructorOnStartup]
    public class LaunchLog
    {
        static LaunchLog()
        {
            //Log.Message("Fingers crossed!");
            TilledSoilMod.ApplySettings();
            if (TilledSoilMod.settings.requirecost == true)
            {
                TilledSoilMod.ApplySettings2();
            }
            else
            {
                return;
            }

            
        }
    }

    [StaticConstructorOnStartup]
    public class TilledSoilSettings : ModSettings
    {
        public float fertility = 120;
        public float Fertility => fertility / 100f;
        public bool placeonanything = false;
        public bool requirecost = false;
        public int soilcost = 1;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref this.fertility, "fertility", 120);
            Scribe_Values.Look(ref placeonanything, "PlaceOnAnything", false);
            Scribe_Values.Look(ref requirecost, "RequireCost", false, true);
            Scribe_Values.Look(ref soilcost, "SoilCost", 1);
            base.ExposeData();
        }

        public void ResetSettings()
        { 
             fertility = 120;
             placeonanything = false;
             requirecost = false;
             soilcost = 1;
        }
    }
}