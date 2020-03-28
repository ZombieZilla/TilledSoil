using Verse;

namespace Tilled_Soil_Zilla
{

    [StaticConstructorOnStartup]
    public class LaunchLog
    {
        static LaunchLog()
        {
            Log.Message("Fingers crossed!");
        }
    }

    [StaticConstructorOnStartup]
    public class TilledSoilSettings : ModSettings
    {
        public float fertility = 100;
        public float Fertility => fertility / 100f;
        public bool placeonanything = false;
        public bool requirecost = false;
        public int soilcost = 1;

        public virtual void ExposeData()
        {
            Scribe_Values.Look(ref this.fertility, "fertility", 100);
            Scribe_Values.Look(ref placeonanything, "PlaceOnAnything", false);
            Scribe_Values.Look(ref soilcost, "SoilCost", 1);
            Scribe_Values.Look(ref requirecost, "RequireCost", false);
            base.ExposeData();
        }
       // public void ResetSettings()
       // {
       //     fertility = 200f;
       //     placeonanything = false;
       //     requirecost = false;
       //     soilcost = 0;
      //  }
    }
}