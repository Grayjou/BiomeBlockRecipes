using System.Collections.Generic;
using Newtonsoft.Json;

namespace BiomeBlockRecipes.Common
{
    public class BiomeVariantData
    {
        [JsonProperty("Pure ID")]
        public int PureID { get; set; }

        [JsonProperty("Pure Name")]
        public string PureName { get; set; }

        [JsonProperty("Pure Internal Name")]
        public string PureInternalName { get; set; }

        [JsonProperty("Corrupt ID")]
        public int? CorruptID { get; set; }

        [JsonProperty("Corrupt Name")]
        public string CorruptName { get; set; }

        [JsonProperty("Corrupt Internal Name")]
        public string CorruptInternalName { get; set; }

        [JsonProperty("Crimson ID")]
        public int? CrimsonID { get; set; }

        [JsonProperty("Crimson Name")]
        public string CrimsonName { get; set; }

        [JsonProperty("Crimson Internal Name")]
        public string CrimsonInternalName { get; set; }

        [JsonProperty("Hallowed ID")]
        public int? HallowedID { get; set; }

        [JsonProperty("Hallowed Name")]
        public string HallowedName { get; set; }

        [JsonProperty("Hallowed Internal Name")]
        public string HallowedInternalName { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        /// <summary>
        /// Returns all non-null variant IDs for this item family
        /// </summary>
        public List<int> GetAllVariantIDs()
        {
            var ids = new List<int> { PureID };
            if (CorruptID.HasValue) ids.Add(CorruptID.Value);
            if (CrimsonID.HasValue) ids.Add(CrimsonID.Value);
            if (HallowedID.HasValue) ids.Add(HallowedID.Value);
            return ids;
        }

        /// <summary>
        /// Returns the appropriate amount based on item type
        /// </summary>
        public int GetAmount(Configs.BiomeBlockRecipesConfig config)
        {
            return Type switch
            {
                "Seed" => config.SeedConversionAmount,
                "Wall" => config.WallConversionAmount,
                "Block" => config.BlockConversionAmount,
                _ => config.BlockConversionAmount
            };
        }
    }
}