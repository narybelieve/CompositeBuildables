using Ingredient = CraftData.Ingredient;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Extensions;
using UnityEngine;

using BepInEx;
using Nautilus.Utility;

namespace DegasiPlanterMod.Buildables;

public static class VoxelShrubClone
{
    public static PrefabInfo Info { get; } = PrefabInfo
        .WithTechType("VoxelShrubClone", "Voxel Shrub (Clone)", "Clone of standard plant.");
    
    public static void Register()
    {
        // create prefab:
        CustomPrefab prefab = new CustomPrefab(Info);

        // copy the built-in Indoor Planter
        
        CloneTemplate clone = new CloneTemplate(Info, "28ec1137-da13-44f3-b76d-bac12ab766d1"); // model is stored in object called "land_plant_small_01_01" - large Voxel Shrub with 4 flowers
        //CloneTemplate clone = new CloneTemplate(Info, "2cab613d-2fc0-4012-ae6e-99f42d4262fd"); // model is stored in object called "land_plant_small_01_02" - short Voxel Shrub bud with 4 pink petals but mostly leaves
        //CloneTemplate clone = new CloneTemplate(Info, "e97c72ec-4999-48fa-b8b2-6d3f8791a7e8"); // model is stored in object called "land_plant_small_01_03" - short Voxel Shrub sprout with no pink petals
        
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