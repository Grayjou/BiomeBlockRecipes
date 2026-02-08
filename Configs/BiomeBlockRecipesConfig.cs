using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace BiomeBlockRecipes.Configs
{
    public class BiomeBlockRecipesConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("ConversionAmounts")]
        [ReloadRequired]
        
        [DefaultValue(500)]
        [Range(0, 9999)]
        [Tooltip("Amount of blocks converted per recipe. Set to 0 to disable block recipes.\n[c/FFFF00:Changing this value requires a world reload]")]
        public int BlockConversionAmount;

        [DefaultValue(500)]
        [Range(0, 9999)]
        [Tooltip("Amount of walls converted per recipe. Set to 0 to disable wall recipes.\n[c/FFFF00:Changing this value requires a world reload]")]
        public int WallConversionAmount;

        [DefaultValue(50)]
        [Range(0, 9999)]
        [Tooltip("Amount of seeds converted per recipe. Set to 0 to disable seed recipes.\n[c/FFFF00:Changing this value requires a world reload]")]
        public int SeedConversionAmount;

        [Header("SolutionSettings")]
        [ReloadRequired]
        
        [DefaultValue(1)]
        [Range(1, 10)]
        [Tooltip("Number of solution items required per recipe.\n[c/FFFF00:Changing this value requires a world reload]")]
        public int SolutionCost;

        [Header("ExtractinatorSettings")]
        [ReloadRequired]
        
        [DefaultValue(true)]
        [Tooltip("Enable purification recipes at the Chlorophyte Extractinator (no solution required).\nConverts Corrupt/Crimson/Hallowed blocks to Pure variants.\n[c/FFFF00:Changing this value requires a world reload]")]
        public bool EnableExtractinatorRecipes;
    }
}