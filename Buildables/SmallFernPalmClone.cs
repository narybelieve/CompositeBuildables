﻿using Ingredient = CraftData.Ingredient;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Extensions;
using UnityEngine;

using BepInEx;
using Nautilus.Utility;

namespace DegasiPlanterMod.Buildables;

public static class SmallFernPalmClone
{
    public static PrefabInfo Info { get; } = PrefabInfo
        .WithTechType("SmallFernPalmClone", "Small Fern Palm (Clone)", "Clone of standard plant.");
    
    public static void Register()
    {
        // create prefab:
        CustomPrefab prefab = new CustomPrefab(Info);

        // copy the built-in Indoor Planter
        
        CloneTemplate clone = new CloneTemplate(Info, "6d13066f-95c8-491b-965b-79ac3c67e6aa"); // model is stored in object called "land_plant_middle_03_03"
        
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