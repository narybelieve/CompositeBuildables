﻿using Ingredient = CraftData.Ingredient;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Handlers; // CraftDataHandler
using Nautilus.Extensions;
using UnityEngine;
using UnityEditor;

using BepInEx;
using Nautilus.Utility;

using UWE;

using System.Collections; // IEnumerator

namespace CompositeBuildables;

public static class DegasiPlanter2
{
    public static PrefabInfo Info { get; } = PrefabInfo
        .WithTechType("DegasiPlanter2", "Degasi Planter 2", "Variation of Bart Torgal's planter from Degasi Base 1-a.")
        // set the icon to that of the vanilla planter
        .WithIcon(SpriteManager.Get(TechType.PlanterBox));
        
    public static bool registered = false;
    
    public static IEnumerator ModifyPrefabAsync(GameObject obj) { // called on obj as obj is instantiated from this prefab
      
      // Wait for the PrefabFactory to complete asynchronous initialization
      
        yield return CoroutineHost.StartCoroutine(PrefabFactory.ensureInitialized());

      // Configure placement rules
      
        ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground;

      // Find the GameObject that holds the model for the object being instantiated
      
        GameObject planterModel = obj.transform.Find("model").gameObject; // Holds model called "Base_Interior_Planter_Tray_01"
        planterModel.transform.Rotate(new Vector3(0, 180, 0), Space.World); // rotate so that the "Front" faces the player while placing
      
      //----------------------------------------------------------------------------------------------------------------
      // Use PrefabFactory to add models. All prefabs referenced must be listed in PrefabFactory.prefabIdModelNameList
      //----------------------------------------------------------------------------------------------------------------
      
        // Alien Tree
        Transform model = PrefabFactory.AttachModelFromPrefabTo("1cc51be0-8ea9-4730-936f-23b562a9256f", planterModel.transform);
        model.localPosition = new Vector3((float)0,(float)0.3945,(float)0);
        model.localScale = new Vector3((float)0.35, (float)0.35, (float)0.35);
        foreach(Material mat in model.GetComponent<Renderer>().materials) {
          mat.SetColor("_Scale", new Color(0f, 0f, 0f, 0f));
        }
          
        // Small Fern Palm
        /*model = PrefabFactory.AttachModelFromPrefabTo("6d13066f-95c8-491b-965b-79ac3c67e6aa", planterModel.transform);
        model.position = planterModel.transform.position + new Vector3((float)-0.0061,(float)0.3945,(float)0.035);*/
        
        // Medium Fern Palm
        model = PrefabFactory.AttachModelFromPrefabTo("1d6d89dd-3e49-48b7-90e4-b521fbc3d36f", planterModel.transform);
        model.Rotate(new Vector3(0, 180, 0), Space.World);
        model.localPosition = new Vector3((float)0.185,(float)0.3757,(float)-1);
        
        // Fern Palm
        model = PrefabFactory.AttachModelFromPrefabTo("523879d5-3241-4a94-8588-cb3b38945119", planterModel.transform);
        model.Rotate(new Vector3(0, 180, 0), Space.World);
        model.localPosition = new Vector3((float)-0.71,(float)0.3757,(float)-0.481);
        
        // Spindly Tall Plant
        model = PrefabFactory.AttachModelFromPrefabTo("154a88c1-6c7f-44e4-974e-c52d2f48fa28", planterModel.transform);
        model.localScale = new Vector3((float)0.3503, (float)0.3503, (float)0.3503);
        model.Rotate(new Vector3(0, 180, 0), Space.World);
        model.localPosition = new Vector3((float)0.509,(float)0.3757,(float)0.611);
        
        // Vine Fill
        model = PrefabFactory.AttachModelFromPrefabTo("75ab087f-9934-4e2a-b025-02fc333a5c99", planterModel.transform);
        model.localScale = new Vector3((float)0.3122, (float)0.3122, (float)0.3122);
        model.Rotate(new Vector3(0, 180, 0), Space.World);
        model.localPosition = new Vector3((float)0.053,(float)0.3757,(float)-0.009);
        
        // Voxel Shrub
        model = PrefabFactory.AttachModelFromPrefabTo("28ec1137-da13-44f3-b76d-bac12ab766d1", planterModel.transform);
        model.localPosition = new Vector3((float)-0.4871,(float)0.3757,(float)0.35);
        model.Rotate(new Vector3(0, 180, 0), Space.World);
        model.GetComponent<Renderer>().material.SetColor("_Scale", new Color(0f, 0f, 0f, 0f));
        
        // Jaffa Cup
        model = PrefabFactory.AttachModelFromPrefabTo("35056c71-5da7-4e73-be60-3c22c5c9e75c", planterModel.transform);
        model.localScale = new Vector3((float)0.4366, (float)0.4366, (float)0.4366);
        model.localPosition = new Vector3((float)1.0079,(float)0.2805,(float)0.627);
        model.Rotate(new Vector3(0, 180, 0), Space.World);
        
        // Grub Basket
        model = PrefabFactory.AttachModelFromPrefabTo("28c73640-a713-424a-91c6-2f5d4672aaea", planterModel.transform);
        model.localScale = new Vector3((float)0.4366, (float)0.4366, (float)0.4366);
        model.localPosition = new Vector3((float)0.578,(float)0.3757,(float)-1.028);
        model.Rotate(new Vector3(0, 180, 0), Space.World);
        model.GetComponent<Renderer>().material.SetColor("_Scale", new Color(0f, 0f, 0f, 0f));
        
        // Red-Tipped Fern
        model = PrefabFactory.AttachModelFromPrefabTo("559fe0c7-1754-40f5-9453-b537900b3ac4", planterModel.transform);
        model.localScale = new Vector3((float)0.6, (float)0.6, (float)0.6);
        model.localPosition = new Vector3((float)-0.578,(float)0.2805,(float)-0.9);
        model.Rotate(new Vector3(0, 180, 0), Space.World);
        model.GetComponent<Renderer>().material.SetColor("_Scale", new Color(0f, 0f, 0f, 0f));
        
        // Speckled Rattler
        model = PrefabFactory.AttachModelFromPrefabTo("98be0944-e0b3-4fba-8f08-ca5d322c22f6", planterModel.transform);
        model.localScale = new Vector3((float)0.02, (float)0.02, (float)0.028);
        model.localPosition = new Vector3((float)-0.4871,(float)0.271,(float)-0.05);
        model.Rotate(new Vector3(0, 180, 0), Space.World);
        model.GetComponent<Renderer>().material.SetColor("_Scale", new Color(0f, 0f, 0f, 0f));
        
        // Pink Cap
        model = PrefabFactory.AttachModelFromPrefabTo("c7faff7e-d9ff-41b4-9782-98d2e09d29c1", planterModel.transform);
        model.localPosition = new Vector3((float)0.6871,(float)0.471,(float)-0.05);
        model.Rotate(new Vector3(0, 180, 0), Space.World);
        model.GetComponent<Renderer>().material.SetColor("_Scale", new Color(0f, 0f, 0f, 0f));
      
      // Make skyApplier act on all of the added models
      
        var skyApplier = planterModel.EnsureComponent<SkyApplier>();
        skyApplier.anchorSky = Skies.Auto;
        skyApplier.renderers = planterModel.GetAllComponentsInChildren<Renderer>();

      // Add all components necessary for it to be built:
      
        PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlags, planterModel);
      
      // Remove the Planter component so that seeds can't be planted/grow in the composite object
      
        UnityEngine.Object.Destroy(obj.GetComponent<Planter>());
        
      // Remove the StorageContainer component as it is unnecessary
      
        UnityEngine.Object.Destroy(obj.GetComponent<StorageContainer>());
        UnityEngine.Object.Destroy(obj.transform.Find("slots").gameObject);
        UnityEngine.Object.Destroy(obj.transform.Find("slots_big").gameObject);
        UnityEngine.Object.Destroy(obj.transform.Find("StorageRoot").gameObject);
        UnityEngine.Object.Destroy(obj.transform.Find("grownPlants").gameObject);
      
      // Return
      
        yield return obj;
    }
    
    public static void UpdateRecipe(Config config)
    {
      if(!registered) return;
      
      switch (config.RecipeComplexity) {
        case RecipeComplexityEnum.Simple:
          CraftDataHandler.SetRecipeData(Info.TechType, new RecipeData(
            new Ingredient(TechType.Titanium, 4)
          )); 
          break;
        case RecipeComplexityEnum.Standard:
          CraftDataHandler.SetRecipeData(Info.TechType, new RecipeData(
            new Ingredient(TechType.Titanium, 4)
          )); 
          break;
        case RecipeComplexityEnum.Complex:
          CraftDataHandler.SetRecipeData(Info.TechType, new RecipeData(
            new Ingredient(TechType.Titanium, 4), // Planter Box
            new Ingredient(TechType.FernPalmSeed, 2), // 2 Fern Palms
            new Ingredient(TechType.OrangePetalsPlantSeed, 1), // Grub Basket
            new Ingredient(TechType.OrangeMushroomSpore, 1), // Jaffa Cup
            new Ingredient(TechType.PinkMushroomSpore, 1), // Pink Cap
            new Ingredient(TechType.PurpleRattleSpore, 1), // Speckled Rattler
            new Ingredient(TechType.PinkFlowerSeed, 1) // Voxel Shrub
          )); 
          break;
      }
    }
    
    public static void Register(Config config)
    {
        // create prefab:
        CustomPrefab planterPrefab = new CustomPrefab(Info);
          // Initializes planterPrefab.Info to the argument Info
        
        CloneTemplate planterClone = new CloneTemplate(Info, "87f5d3e6-e00b-4cf3-be39-0a9c7e951b84"); // model is stored in object called "model"
          // CloneTemplate(PrefabInfo Info, string classIdToClone) calls CloneTemplate(Info, TechType.None, classIDToClone, null)
          // CloneTemplate(PrefabInfo info, TechType techTypeToClone, string classIdToClone, AssetReferenceGameObject prefabToClone) calls PrefabTemplate(info) and then sets _techTypeToClone through _spawnType
          // PrefabTemplate(info) sets the internal variable PrefabInfo info to argument info
          
        // modify the cloned model:
        planterClone.ModifyPrefabAsync += ModifyPrefabAsync;

        // assign the created clone to the prefab itself:
        planterPrefab.SetGameObject(planterClone);
          // Sets the internal variable GameObject planterPrefab._prefab to planterClone
          // Sets the internal variable PrefabFactoryAsync planterPrefab.Prefab to a function taking an argument obj and returning SyncPrefab(obj, prefab) where
          // IEnumerator SyncPrefab(IOut<GameObject> obj, GameObject prefab) {
          //  obj.Set(prefab);
          //  yield break; // indicates that the iterable IOut has no more elements
          // }

        // assign it to the correct tab in the builder tool:
        planterPrefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);
        
        planterPrefab.SetUnlock(TechType.PlanterBox);

        // finally, register it into the game:
        planterPrefab.Register();
        registered = true;
        
        // Set Recipe Data
        UpdateRecipe(config);
    }
}