using Ingredient = CraftData.Ingredient;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Extensions;
using UnityEngine;

using BepInEx;
using Nautilus.Utility;

namespace CompositeBuildables;

public static class SpeckledRattlerClone
{
    public static PrefabInfo Info { get; } = PrefabInfo
        .WithTechType("SpeckledRattlerClone", "Speckled Rattler (Clone)", "Clone of standard plant.");
    
    public static void Register()
    {
        // create prefab:
        CustomPrefab prefab = new CustomPrefab(Info);

        // copy the built-in plant
        
        //CloneTemplate clone = new CloneTemplate(Info, "28818d8a-5e50-41f0-8e14-44cb89a0b611"); // model is stored in object called "land_plant_small_02_01" - single Speckled Rattler
        CloneTemplate clone = new CloneTemplate(Info, "98be0944-e0b3-4fba-8f08-ca5d322c22f6"); // model is stored in object called "land_plant_small_02_02" - triple Speckled Rattler
        
        // modify the cloned model:
        /*clone.ModifyPrefab += obj => // GH: lambda expression. "obj" is the input and the code below is the function which uses it. obj seems to be a GameObject based on context
        {
            // prohibit placement
            ConstructableFlags constructableFlags = ConstructableFlags.None;

            // find the object that holds the model:
            GameObject model = obj.transform.Find("model").gameObject; // Holds model called "Base_Interior_Planter_Tray_01"
            
            // add all components necessary for it to be built:
            PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlags, lanternModel);
        };*/

        // assign the created clone model to the prefab itself:
        prefab.SetGameObject(clone);

        // assign it to the correct tab in the builder tool:
        //prefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);

        // set recipe:
        //prefab.SetRecipe(new RecipeData(new Ingredient(TechType.Titanium, 4))); // same as default recipe

        // finally, register it into the game:
        prefab.Register();
    }
}