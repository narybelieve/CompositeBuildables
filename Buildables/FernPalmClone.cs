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

public static class FernPalmClone
{
    public static PrefabInfo Info { get; } = PrefabInfo
        .WithTechType("FernPalmClone", "Fern Palm (Clone)", "Clone of standard plant.");
    
    public static void Register()
    {
        // create prefab:
        CustomPrefab prefab = new CustomPrefab(Info);

        // copy the built-in Indoor Planter
        
        CloneTemplate clone = new CloneTemplate(Info, "523879d5-3241-4a94-8588-cb3b38945119"); // model is stored in object called "land_plant_midle_03_01"
        
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