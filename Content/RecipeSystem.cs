using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Newtonsoft.Json;
using BiomeBlockRecipes.Common;
using BiomeBlockRecipes.Configs;

namespace BiomeBlockRecipes.Content
{
    public class RecipeSystem : ModSystem
    {
        private static BiomeBlockRecipesConfig Config => ModContent.GetInstance<BiomeBlockRecipesConfig>();
        private List<BiomeVariantData> biomeVariants;

        public override void Load()
        {
            LoadBiomeData();
        }

        private void LoadBiomeData()
        {
            try
            {
                string jsonPath = Path.Combine(Mod.GetFilePathNoExtension("Content/BiomeVariants"), ".json");
                string jsonContent = File.ReadAllText(jsonPath);
                biomeVariants = JsonConvert.DeserializeObject<List<BiomeVariantData>>(jsonContent);
                Mod.Logger.Info($"Loaded {biomeVariants.Count} biome variant families from JSON");
            }
            catch (Exception ex)
            {
                Mod.Logger.Error($"Failed to load BiomeVariants.json: {ex.Message}");
                biomeVariants = new List<BiomeVariantData>();
            }
        }

        public override void AddRecipes()
        {
            if (biomeVariants == null || biomeVariants.Count == 0)
            {
                Mod.Logger.Warn("No biome variants loaded, skipping recipe generation");
                return;
            }

            // Add four-way biome conversions from JSON
            AddBiomeConversionRecipes();

            // Add special solution conversions (Yellow, White, Brown)
            if (Config.BlockConversionAmount > 0)
            {
                AddSpecialSolutionRecipes();
            }

            // Add Grass -> Mushroom seed conversion
            if (Config.SeedConversionAmount > 0)
            {
                AddMushroomSeedRecipe();
            }
        }

        #region JSON-Based Biome Conversions

        private void AddBiomeConversionRecipes()
        {
            int[] solutions = { ItemID.GreenSolution, ItemID.PurpleSolution, ItemID.RedSolution, ItemID.BlueSolution };
            string[] solutionNames = { "Green (Pure)", "Purple (Corrupt)", "Red (Crimson)", "Blue (Hallowed)" };

            foreach (var variant in biomeVariants)
            {
                int amount = variant.GetAmount(Config);
                
                // Skip if amount is disabled
                if (amount <= 0) continue;

                // Get all available variant IDs
                int[] variantIDs = {
                    variant.PureID,
                    variant.CorruptID ?? -1,
                    variant.CrimsonID ?? -1,
                    variant.HallowedID ?? -1
                };

                int[] targetIDs = {
                    variant.PureID,
                    variant.CorruptID ?? -1,
                    variant.CrimsonID ?? -1,
                    variant.HallowedID ?? -1
                };

                // Create recipes for each solution/target combination
                for (int targetIndex = 0; targetIndex < 4; targetIndex++)
                {
                    int targetID = targetIDs[targetIndex];
                    
                    // Skip if this variant doesn't exist (null in JSON)
                    if (targetID == -1) continue;

                    foreach (int sourceID in variantIDs)
                    {
                        // Skip if source doesn't exist or is the same as target
                        if (sourceID == -1 || sourceID == targetID) continue;

                        AddConversionRecipe(sourceID, targetID, solutions[targetIndex], amount);
                    }
                }
            }
        }

        #endregion

        #region Special Solution Conversions

        private void AddSpecialSolutionRecipes()
        {
            int amount = Config.BlockConversionAmount;

            // ===== YELLOW SOLUTION (Desert Conversions) =====
            AddConversionRecipe(ItemID.DirtBlock, ItemID.SandBlock, ItemID.SandSolution, amount);
            AddConversionRecipe(ItemID.StoneBlock, ItemID.Sandstone, ItemID.SandSolution, amount);
            AddConversionRecipe(ItemID.SnowBlock, ItemID.SandBlock, ItemID.SandSolution, amount);
            AddConversionRecipe(ItemID.IceBlock, ItemID.HardenedSand, ItemID.SandSolution, amount);

            // ===== WHITE SOLUTION (Snow Conversions) =====
            AddConversionRecipe(ItemID.DirtBlock, ItemID.SnowBlock, ItemID.SnowSolution, amount);
            AddConversionRecipe(ItemID.StoneBlock, ItemID.IceBlock, ItemID.SnowSolution, amount);
            AddConversionRecipe(ItemID.SandBlock, ItemID.SnowBlock, ItemID.SnowSolution, amount);

            // ===== BROWN SOLUTION (Forest/Dirt Conversions) =====
            AddConversionRecipe(ItemID.SandBlock, ItemID.DirtBlock, ItemID.DirtSolution, amount);
            AddConversionRecipe(ItemID.SnowBlock, ItemID.DirtBlock, ItemID.DirtSolution, amount);
            AddConversionRecipe(ItemID.Sandstone, ItemID.StoneBlock, ItemID.DirtSolution, amount);
            AddConversionRecipe(ItemID.IceBlock, ItemID.StoneBlock, ItemID.DirtSolution, amount);
            AddConversionRecipe(ItemID.HardenedSand, ItemID.StoneBlock, ItemID.DirtSolution, amount);
        }

        private void AddMushroomSeedRecipe()
        {
            AddConversionRecipe(
                ItemID.GrassSeeds, 
                ItemID.MushroomGrassSeeds, 
                ItemID.DarkBlueSolution, 
                Config.SeedConversionAmount
            );
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Creates a single conversion recipe at the Steampunk Boiler.
        /// </summary>
        private void AddConversionRecipe(int inputItem, int outputItem, int solution, int amount)
        {
            if (amount <= 0) return;

            Recipe recipe = Recipe.Create(outputItem, amount);
            recipe.AddIngredient(inputItem, amount);
            recipe.AddIngredient(solution, Config.SolutionCost);
            recipe.AddTile(TileID.SteampunkBoiler);
            recipe.Register();
        }

        #endregion
    }
}