using Nautilus.Json;
using Nautilus.Options;
using Nautilus.Options.Attributes;

namespace CompositeBuildables;

public enum RecipeComplexityEnum {
  Simple,
  Standard,
  Complex
}

/// The Menu attribute allows us to set the title of our section within the "Mods" tab of the options menu.
[Menu("Composite Buildables")]
public class Config : ConfigFile
{
    [Choice("Recipe Complexity"),OnChange(nameof(UpdateRecipes))]
    public RecipeComplexityEnum RecipeComplexity;

    private void UpdateRecipes()
    {
      Plugin.Logger.LogDebug("Choice value RecipeComplexity was changed to " + RecipeComplexity);
      
      DegasiPlanter.UpdateRecipe();
      DegasiPlanterRound.UpdateRecipe();
      //DegasiPlanter2.UpdateRecipe();
      
      ScienceBench1.UpdateRecipe();
      ScienceBench2.UpdateRecipe();
      
      LabShelving.UpdateRecipe();
      
      MushroomTerrariumSmall.UpdateRecipe(); 
      MushroomTerrariumLarge.UpdateRecipe(); 
      
      TubularShelfSmall.UpdateRecipe();
    }
    
    [Toggle("Newly placed Lantern Trees are fruited"), OnChange(nameof(UpdateLanternTreesSpawnFruited))]
    public bool LanternTreesSpawnFruited;
    
    private void UpdateLanternTreesSpawnFruited() {
      Plugin.Logger.LogDebug("Float value LanternFruitSpawnTime was changed to " + LanternTreesSpawnFruited);
    }
    
    [Slider("Lantern Fruit Spawn Time (s)", 0, 100, DefaultValue = 50, Format = "{0:F2}"),OnChange(nameof(UpdateLanternFruitSpawnTime))]
    public float LanternFruitSpawnTime;
    
    private void UpdateLanternFruitSpawnTime() {
      Plugin.Logger.LogDebug("Float value LanternFruitSpawnTime was changed to " + LanternFruitSpawnTime);
    }
    
    [Toggle("Mushroom Terrariums overflow into Bioreactors")]
    public bool MushroomsToReactors; 
    
    /*[Toggle("Pink Caps overflow into Bioreactors (37.5% of power)")]
    public bool PinkCapsToReactors; // Pink Caps account for 37.5% of potential power output
    
    [Toggle("Speckled Rattlers overflow into Bioreactors (37.5% of power)")]
    public bool RattlersToReactors; // Speckled Rattlers account for 37.5% of potential power output
    
    [Toggle("Jaffa Cups (4 slots) overflow into Bioreactors (25% of power)")]
    public bool JaffaToReactors; // Jaffa Cups account for 25% of potential power output*/
    
    [Slider("Mushroom Terrarium Production Speed Factor", 0, 20, DefaultValue = 0.25f, Format = "{0:F2}"),OnChange(nameof(UpdateLanternFruitSpawnTime))] // At 100%, overflow from 1 Small Terrarium powers 1 Bioreactor
    public float MushroomProductionSpeedFactor;
}
