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

public static class PinkCapClone
{
    public static PrefabInfo Info { get; } = PrefabInfo
        .WithTechType("PinkCapClone", "Pink Cap (Clone)", "Clone of standard plant.");
    
    public static void Register()
    {
        // create prefab:
        CustomPrefab prefab = new CustomPrefab(Info);

        // copy the built-in Indoor Planter
        
        //CloneTemplate clone = new CloneTemplate(Info, "7f9a765d-0b4e-4b3f-81b9-38b38beedf55"); // model is stored in object called "land_plant_small_03_01" - Single Pink Cap 
        //CloneTemplate clone = new CloneTemplate(Info, "e88e7a23-2a99-41c5-aed9-a2bfaca3619d"); // model is stored in object called "land_plant_small_03_02" - Double Pink Cap with one large and one small cap
        //CloneTemplate clone = new CloneTemplate(Info, "a7aef01f-0dc0-4d03-913d-d47d8d2ba407"); // model is stored in object called "land_plant_small_03_03" - Double Pink Cap with two large caps
        CloneTemplate clone = new CloneTemplate(Info, "c7faff7e-d9ff-41b4-9782-98d2e09d29c1"); // model is stored in object called "land_plant_small_03_04" - Pentuple Pink Cap with 3 large caps and 2 small
        //CloneTemplate clone = new CloneTemplate(Info, "b715508e-a7e4-47f0-a55b-bf6f65d24ac2"); // model is stored in object called "land_plant_small_03_05_vertical" - Triple Pink Cap with base angled towards a wall or cliff (overall shape is like a wall lamp with a shade)
        
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