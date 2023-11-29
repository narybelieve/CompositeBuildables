using Ingredient = CraftData.Ingredient;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Extensions;
using UnityEngine;
using UnityEditor;

using BepInEx;
using Nautilus.Utility;

using UWE;

using System.Collections; // IEnumerator

namespace CompositeBuildables;

public static class DegasiPlanter
{
    public static PrefabInfo Info { get; } = PrefabInfo
        .WithTechType("DegasiPlanter", "Degasi Planter", "Bart Torgal's planter from Degasi Base 1-a.")
        // set the icon to that of the vanilla locker:
        .WithIcon(SpriteManager.Get(TechType.PlanterBox));
    
    public static IEnumerator ModifyPrefabAsync(GameObject obj) { // called on obj as obj is instantiated from this prefab
      
      // Wait for the PrefabFactory to complete asynchronous initialization
      
        yield return CoroutineHost.StartCoroutine(PrefabFactory.ensureInitialized());

      // Configure placement rules
      
        ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.Submarine;

      // Find the GameObject that holds the model for the object being instantiated
      
        GameObject planterModel = obj.transform.Find("model").gameObject; // Holds model called "Base_Interior_Planter_Tray_01"
      
      //----------------------------------------------------------------------------------------------------------------
      // Use PrefabFactory to add models. All prefabs referenced must be listed in PrefabFactory.prefabIdModelNameList
      //----------------------------------------------------------------------------------------------------------------
      
        // Lantern Tree is special - we need to steal its model AND deep copy its FruitPlant component
        
          // Get the object
          GameObject lanternTreeObj = PrefabFactory.InstantiatePrefabInactive("8fa4a413-57fa-47a3-828d-de2255dbce4f");
          
          // Steal and re-position its model
          lanternTreeObj.transform.Find(PrefabFactory.GetModelName("8fa4a413-57fa-47a3-828d-de2255dbce4f")).parent = planterModel.transform;
          planterModel.transform.Find(PrefabFactory.GetModelName("8fa4a413-57fa-47a3-828d-de2255dbce4f")).position = planterModel.transform.position + new Vector3((float)0,(float)0.3945,(float)0);
          
          FruitPlantClone fruitPlant = obj.transform.Find("model").gameObject.AddComponent<FruitPlantClone>(); // See FruitPlantClone for why the built-in FruitPlant can't be used here
          var oldFruitPlant = lanternTreeObj.GetComponent<FruitPlant>();
          
          fruitPlant.fruits = new PickPrefab[oldFruitPlant.fruits.Length];
          fruitPlant.fruitSpawnInterval = 1f;
          //fruitPlant.fruitSpawnEnabled = true; 
          for (int i = 0; i < fruitPlant.fruits.Length; i++) {
            fruitPlant.fruits[i] = oldFruitPlant.fruits[i];
          }
          
          Object.Destroy(lanternTreeObj);
      
        // Small Fern Palm
        /*model = PrefabFactory.AttachModelFromPrefabTo("6d13066f-95c8-491b-965b-79ac3c67e6aa", planterModel);
        model.position = planterModel.transform.position + new Vector3((float)-0.0061,(float)0.3945,(float)0.035);*/
        
        // Medium Fern Palm
        Transform model = PrefabFactory.AttachModelFromPrefabTo("1d6d89dd-3e49-48b7-90e4-b521fbc3d36f", planterModel);
        model.position = planterModel.transform.position + new Vector3((float)0.185,(float)0.3945,(float)-1);
        
        // Fern Palm
        model = PrefabFactory.AttachModelFromPrefabTo("523879d5-3241-4a94-8588-cb3b38945119", planterModel);
        model.position = planterModel.transform.position + new Vector3((float)-0.71,(float)0.3945,(float)-0.481);
        
        // Spindly Tall Plant
        model = PrefabFactory.AttachModelFromPrefabTo("154a88c1-6c7f-44e4-974e-c52d2f48fa28", planterModel);
        model.localScale = new Vector3((float)0.3503, (float)0.3503, (float)0.3503);
        model.position = planterModel.transform.position + new Vector3((float)0.509,(float)0.3945,(float)0.611);
        
        // Vine Fill
        model = PrefabFactory.AttachModelFromPrefabTo("75ab087f-9934-4e2a-b025-02fc333a5c99", planterModel);
        model.localScale = new Vector3((float)0.3122, (float)0.3122, (float)0.3122);
        model.position = planterModel.transform.position + new Vector3((float)0.053,(float)0.3945,(float)-0.009);
        
        // Voxel Shrub
        model = PrefabFactory.AttachModelFromPrefabTo("28ec1137-da13-44f3-b76d-bac12ab766d1", planterModel);
        model.position = planterModel.transform.position + new Vector3((float)-0.4871,(float)0.3945,(float)0.35);
        
        // Jaffa Cup
        model = PrefabFactory.AttachModelFromPrefabTo("35056c71-5da7-4e73-be60-3c22c5c9e75c", planterModel);
        model.localScale = new Vector3((float)0.4366, (float)0.4366, (float)0.4366);
        model.position = planterModel.transform.position + new Vector3((float)1.0079,(float)0.2945,(float)0.627);
        
        // Grub Basket
        model = PrefabFactory.AttachModelFromPrefabTo("28c73640-a713-424a-91c6-2f5d4672aaea", planterModel);
        model.localScale = new Vector3((float)0.4366, (float)0.4366, (float)0.4366);
        model.position = planterModel.transform.position + new Vector3((float)0.578,(float)0.3945,(float)-1.028);
        
        // Red-Tipped Fern
        model = PrefabFactory.AttachModelFromPrefabTo("559fe0c7-1754-40f5-9453-b537900b3ac4", planterModel);
        model.localScale = new Vector3((float)0.6, (float)0.6, (float)0.6);
        model.position = planterModel.transform.position + new Vector3((float)-0.578,(float)0.2945,(float)-0.9);
        
        // Speckled Rattler
        model = PrefabFactory.AttachModelFromPrefabTo("98be0944-e0b3-4fba-8f08-ca5d322c22f6", planterModel);
        model.localScale = new Vector3((float)0.02, (float)0.02, (float)0.02);
        model.position = planterModel.transform.position + new Vector3((float)-0.4871,(float)0.4945,(float)-0.05);
        
        // Pink Cap
        model = PrefabFactory.AttachModelFromPrefabTo("c7faff7e-d9ff-41b4-9782-98d2e09d29c1", planterModel);
        model.position = planterModel.transform.position + new Vector3((float)0.6871,(float)0.4945,(float)-0.05);
      
      // Make skyApplier act on all of the added models
      
        var skyApplier = planterModel.EnsureComponent<SkyApplier>();
        skyApplier.anchorSky = Skies.Auto;
        skyApplier.renderers = planterModel.GetAllComponentsInChildren<Renderer>();

      // Disable animators so that plants don't "blow in the wind" indoors
        
        Animator[] allAnimators = planterModel.GetComponentsInChildren<Animator>();
        foreach (Animator a in allAnimators) {
          UnityEngine.Object.Destroy(a); // This doesn't give an error, but it doesn't work. The old way didn't work either. The objects seem to have no animators.
        }

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
    
    public static void Register()
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

        // set recipe:
        planterPrefab.SetRecipe(new RecipeData(new Ingredient(TechType.Titanium, 4))); // same as default recipe

        // finally, register it into the game:
        planterPrefab.Register();
    }
}