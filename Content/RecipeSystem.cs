using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BiomeBlockRecipes.Configs;

namespace BiomeBlockRecipes.Content
{
    public class RecipeSystem : ModSystem
    {
        private static BiomeBlockRecipesConfig Config => ModContent.GetInstance<BiomeBlockRecipesConfig>();

        public override void AddRecipes()
        {
            // ===== BLOCK CONVERSIONS =====
            if (Config.BlockConversionAmount > 0)
            {
                AddBlockRecipes();
                AddSpecialSolutionRecipes();
            }

            // ===== WALL CONVERSIONS =====
            if (Config.WallConversionAmount > 0)
            {
                AddWallRecipes();
            }

            // ===== SEED CONVERSIONS =====
            if (Config.SeedConversionAmount > 0)
            {
                AddSeedRecipes();
            }
        }

        #region Block Recipes

        private void AddBlockRecipes()
        {
            int amount = Config.BlockConversionAmount;

            // Stone Family: Stone <-> Ebonstone <-> Crimstone <-> Pearlstone
            AddFourWayBiomeConversions(
                pure: ItemID.StoneBlock,
                corrupt: ItemID.EbonstoneBlock,
                crimson: ItemID.CrimstoneBlock,
                hallow: ItemID.PearlstoneBlock,
                amount: amount
            );

            // Sand Family: Sand <-> Ebonsand <-> Crimsand <-> Pearlsand
            AddFourWayBiomeConversions(
                pure: ItemID.SandBlock,
                corrupt: ItemID.EbonsandBlock,
                crimson: ItemID.CrimsandBlock,
                hallow: ItemID.PearlsandBlock,
                amount: amount
            );

            // Ice Family: Ice <-> Purple Ice <-> Red Ice <-> Pink Ice
            AddFourWayBiomeConversions(
                pure: ItemID.IceBlock,
                corrupt: ItemID.PurpleIceBlock,
                crimson: ItemID.RedIceBlock,
                hallow: ItemID.PinkIceBlock,
                amount: amount
            );

            // Hardened Sand Family
            AddFourWayBiomeConversions(
                pure: ItemID.HardenedSand,
                corrupt: ItemID.CorruptHardenedSand,
                crimson: ItemID.CrimsonHardenedSand,
                hallow: ItemID.HallowHardenedSand,
                amount: amount
            );

            // Sandstone Family
            AddFourWayBiomeConversions(
                pure: ItemID.Sandstone,
                corrupt: ItemID.CorruptSandstone,
                crimson: ItemID.CrimsonSandstone,
                hallow: ItemID.HallowSandstone,
                amount: amount
            );
        }

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

        #endregion

        #region Wall Recipes

        private void AddWallRecipes()
        {
            int amount = Config.WallConversionAmount;

            // Hardened Sand Walls
            AddFourWayBiomeConversions(
                pure: ItemID.HardenedSandWall,
                corrupt: ItemID.CorruptHardenedSandWall,
                crimson: ItemID.CrimsonHardenedSandWall,
                hallow: ItemID.HallowHardenedSandWall,
                amount: amount
            );

            // Sandstone Walls
            AddFourWayBiomeConversions(
                pure: ItemID.SandstoneWall,
                corrupt: ItemID.CorruptSandstoneWall,
                crimson: ItemID.CrimsonSandstoneWall,
                hallow: ItemID.HallowSandstoneWall,
                amount: amount
            );
        }

        #endregion

        #region Seed Recipes

        private void AddSeedRecipes()
        {
            int amount = Config.SeedConversionAmount;

            // Four-way grass seed conversions
            int[] biomeSeeds = { ItemID.GrassSeeds, ItemID.CorruptSeeds, ItemID.CrimsonSeeds, ItemID.HallowedSeeds };
            int[] solutions = { ItemID.GreenSolution, ItemID.PurpleSolution, ItemID.RedSolution, ItemID.BlueSolution };

            for (int i = 0; i < 4; i++)
            {
                foreach (int source in biomeSeeds)
                {
                    if (source != biomeSeeds[i])
                    {
                        AddConversionRecipe(source, biomeSeeds[i], solutions[i], amount);
                    }
                }
            }

            // Grass Seeds -> Mushroom Grass Seeds (Dark Blue Solution)
            AddConversionRecipe(ItemID.GrassSeeds, ItemID.MushroomGrassSeeds, ItemID.DarkBlueSolution, amount);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Adds all four-way biome conversions for a block/wall family (Pure, Corrupt, Crimson, Hallow).
        /// Creates 12 recipes total (each variant can convert to any of the other 3).
        /// </summary>
        private void AddFourWayBiomeConversions(int pure, int corrupt, int crimson, int hallow, int amount)
        {
            int[] variants = { pure, corrupt, crimson, hallow };
            int[] solutions = { ItemID.GreenSolution, ItemID.PurpleSolution, ItemID.RedSolution, ItemID.BlueSolution };

            for (int targetIndex = 0; targetIndex < 4; targetIndex++)
            {
                foreach (int source in variants)
                {
                    if (source != variants[targetIndex])
                    {
                        AddConversionRecipe(source, variants[targetIndex], solutions[targetIndex], amount);
                    }
                }
            }
        }

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