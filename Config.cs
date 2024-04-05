using Nautilus.Json;
using Nautilus.Options;
using Nautilus.Options.Attributes;

using UnityEngine; // Debug.Log

namespace CompositeBuildables;

public enum RecipeComplexityEnum {
  Simple,
  Fair,
  Complex
}

/// The Menu attribute allows us to set the title of our section within the "Mods" tab of the options menu.
[Menu("Composite Buildables")]
public class Config : ConfigFile
{
    [Choice,OnChange(nameof(UpdateRecipes))]
    public RecipeComplexityEnum RecipeComplexity;

    //[Slider("Lantern Fruit Spawn Time", 0, 100, DefaultValue = 50, Format = "{0:F2}")]
    //public float LanternFruitSpawnTime;
      // Would require a listener to update existing objects
    
    private void UpdateRecipes()
    {
        Debug.Log($"Choice value RecipeComplexity was changed to " + RecipeComplexity);
        
        DegasiPlanter.UpdateRecipe(this);
        DegasiPlanterRound.UpdateRecipe(this);
        DegasiPlanter2.UpdateRecipe(this);
        
        ScienceBench1.UpdateRecipe(this);
        ScienceBench2.UpdateRecipe(this);
        
        LabShelving.UpdateRecipe(this);
        
        MushroomTerrariumSmall.UpdateRecipe(this); 
        MushroomTerrariumLarge.UpdateRecipe(this); 
        
        TubularShelfSmall.UpdateRecipe(this);
    }
}
