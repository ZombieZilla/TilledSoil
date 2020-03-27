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

    public class TilledSoilSettings : ModSettings
    {
        public float fertility = 100;
        public float Fertility => fertility / 100f;
        public bool needsoil = true;


        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref this.fertility, "fertility", 100, false);
            Scribe_Values.Look(ref needsoil, "NeedSoil", true);
        }
 
    }
}