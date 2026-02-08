# BiomeBlockRecipes

A quality-of-life mod for Terraria (tModLoader) that adds crafting recipes to convert blocks, walls, and seeds between biome variants using Clentaminator solutions.

## Features

### 🔄 Four-Way Biome Conversions
Convert blocks and walls between **Pure**, **Corrupt**, **Crimson**, and **Hallowed** variants using the **Steampunk Boiler** with the appropriate solution:
- 🟢 Green Solution → Pure variants
- 🟣 Purple Solution → Corrupt variants  
- 🔴 Red Solution → Crimson variants
- 🔵 Blue Solution → Hallowed variants

### 🌿 Chlorophyte Extractinator Purification (NEW!)
Purify contaminated blocks **without solution** using the **Chlorophyte Extractinator**:
- Corrupt → Pure
- Crimson → Pure
- Hallowed → Pure

This feature mimics Terraria's vanilla extractinator behavior and provides a convenient way to cleanse infected blocks.

### 🏜️ Special Solution Conversions
Additional biome conversions with special solutions:
- 🟡 **Yellow Solution** (Sand/Desert): Dirt→Sand, Stone→Sandstone, Snow→Sand, Ice→Hardened Sand
- ⚪ **White Solution** (Snow): Dirt→Snow, Stone→Ice, Sand→Snow
- 🟤 **Brown Solution** (Forest): Sand→Dirt, Snow→Dirt, Sandstone→Stone, Ice→Stone, Hardened Sand→Stone

### 🍄 Mushroom Seed Conversion
Convert Grass Seeds to Mushroom Grass Seeds using Dark Blue Solution.

## Supported Items

### Blocks
- Stone / Ebonstone / Crimstone / Pearlstone
- Sand / Ebonsand / Crimsand / Pearlsand
- Ice / Purple Ice / Red Ice / Pink Ice
- Hardened Sand variants
- Sandstone variants

### Walls
- Stone Wall variants
- Grass Wall variants
- Hardened Sand Wall variants
- Sandstone Wall variants
- Cave-style decorative walls

### Seeds
- Grass Seeds / Corrupt Seeds / Crimson Seeds / Hallowed Seeds
- Mushroom Grass Seeds (via Dark Blue Solution)

## Configuration

All recipes are fully configurable through the in-game Mod Configuration menu:

### Conversion Amounts
- **Block Conversion Amount** (default: 500) - Number of blocks per recipe
- **Wall Conversion Amount** (default: 500) - Number of walls per recipe  
- **Seed Conversion Amount** (default: 50) - Number of seeds per recipe
- Set to 0 to disable specific recipe types

### Solution Settings
- **Solution Cost** (default: 1) - Number of solution items required per recipe

### Extractinator Settings
- **Enable Extractinator Recipes** (default: true) - Toggle Chlorophyte Extractinator purification recipes

> ⚠️ **Note:** All configuration changes require a world reload to take effect.

## Installation

1. Install [tModLoader](https://github.com/tModLoader/tModLoader) for Terraria
2. Subscribe to this mod in the Steam Workshop, or download from the [Releases](../../releases) page
3. Enable the mod in tModLoader's Mod menu
4. Create or load a world to generate recipes

## Usage Examples

### Steampunk Boiler Recipes
```
500 Ebonstone + 1 Green Solution = 500 Stone (at Steampunk Boiler)
500 Stone + 1 Purple Solution = 500 Ebonstone (at Steampunk Boiler)
500 Sand + 1 Red Solution = 500 Crimsand (at Steampunk Boiler)
```

### Chlorophyte Extractinator Recipes
```
500 Ebonstone = 500 Stone (at Chlorophyte Extractinator, no solution needed)
500 Crimsand = 500 Sand (at Chlorophyte Extractinator, no solution needed)
500 Pink Ice = 500 Ice (at Chlorophyte Extractinator, no solution needed)
```

### Special Conversions
```
500 Dirt + 1 Yellow Solution = 500 Sand (at Steampunk Boiler)
500 Sand + 1 Brown Solution = 500 Dirt (at Steampunk Boiler)
```

## Technical Details

- **Config Scope:** Server-side (syncs to all players in multiplayer)
- **Recipe Data:** Loaded from JSON configuration file
- **Crafting Stations:**
  - Steampunk Boiler (for solution-based conversions)
  - Chlorophyte Extractinator (for purification recipes)

## Contributing

Contributions are welcome! Please feel free to:
- Report bugs or suggest features via [Issues](../../issues)
- Submit pull requests for improvements
- Share your feedback and ideas

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Credits

- **Mod Author:** Grayjou
- **Game:** Terraria by Re-Logic
- **Mod Loader:** tModLoader

## Changelog

### v1.0.0
- Initial release with four-way biome conversions
- Chlorophyte Extractinator purification recipes
- Comprehensive configuration options
- Support for blocks, walls, and seeds
