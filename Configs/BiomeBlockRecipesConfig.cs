using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace BiomeBlockRecipes.Configs
{
    public class BiomeBlockRecipesConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("ConversionAmounts")]
        
        [DefaultValue(500)]
        [Range(0, 9999)]
        [Slider]
        [Tooltip("Amount of blocks converted per recipe. Set to 0 to disable block recipes.")]
        public int BlockConversionAmount;

        [DefaultValue(500)]
        [Range(0, 9999)]
        [Slider]
        [Tooltip("Amount of walls converted per recipe. Set to 0 to disable wall recipes.")]
        public int WallConversionAmount;

        [DefaultValue(50)]
        [Range(0, 9999)]
        [Slider]
        [Tooltip("Amount of seeds converted per recipe. Set to 0 to disable seed recipes.")]
        public int SeedConversionAmount;

        [Header("SolutionSettings")]
        
        [DefaultValue(1)]
        [Range(1, 10)]
        [Slider]
        [Tooltip("Number of solution items required per recipe.")]
        public int SolutionCost;
    }
}