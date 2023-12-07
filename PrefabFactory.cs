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
using System.Collections.Generic; // List

using System.Threading.Tasks; // Task.WhenAll

namespace CompositeBuildables;

public static class PrefabFactory
{
    private static List<string> prefabIdModelNameList = new List<string>{ 
      //========================================================================================================
      // FLATTENED LIST OF PAIRS
      //  -> Even-indexed items: prefab ID (see https://github.com/SubnauticaModding/Nautilus/blob/master/Nautilus/Documentation/resources/SN1-PrefabPaths.json), 
      //  -> Odd-indexed items: corresponding model name
      //========================================================================================================
    
      //-----------------------------------------------------------------------
      // LAB PROPS
      //-----------------------------------------------------------------------
      
        // Counter
        "42eae67f-f31a-45a0-95bf-27e189de65a0", "biodome_lab_counter_01", // ? Prefab seems to be named biodome_lab_counter_01_cab1
        
        // Tubular Laboratory Shelves
        "a36047b0-1533-4718-8879-d6ba9229c978", "biodome_lab_tube_01",
        
        // Rectangular Laboratory Shelves
        "33acd899-72fe-4a98-85f9-b6811974fbeb", "biodome_lab_shelf_01", 
            // Subobjects:
            //  "biodome_lab_shelf_01" = the shelf
            //  "biodome_lab_shelf_01_thing" = the vertical arm thing
            //  "biodome_lab_shelf_01_thing_glass" = some barely visible glass near the arm thing
            // To make this into a shelf with ends, place two of the lab_shelf_01 items at right angles at the ends and remove their "thing" models
        
        // Rectangular Laboratory Shelves
        "33acd899-72fe-4a98-85f9-b6811974fbeb", "biodome_lab_shelf_01", 
        
        // Robotic Arm? Decorationsmod uses its own asset
        "68e7dcd8-fe09-4dac-b966-85463c3c58af", "biodome_Robot_Arm",
        
        // Microscope
        "2cee55bc-6136-47c5-a1ed-14c8f3203856", "discovery_lab_props_01", 
        
        // Fluid Analyzer
        "9c5f22de-5049-48bb-ad1e-0d78c894210e", "discovery_lab_props_02", 
        
        // Sample Analyzer
        "3fd9050b-4baf-4a78-a883-e774c648887c", "discovery_lab_props_03", 
        
        // Cylindrical Test Tube (named "Cylindrical sample flask" in Decorations mod)
        "7f601dd4-0645-414d-bb62-5b0b62985836", "biodome_lab_containers_tube_01",
        
        // Cylindrical Bell Jar (named "Inverted cylindrical sample container" in Decorations mod)
        "a227d6b6-d64c-4bf0-b919-2db02d67d037", "biodome_lab_containers_tube_02",
        
        // Large Square Jar with Lid (named "Large sample flask" in Decorations mod)
        "e7f9c5e7-3906-4efd-b239-28783bce17a5", "biodome_lab_containers_close_01",
        
        // Small Square Jar with Lid  (named "Small sample flask" in Decorations mod)
        "e3e00261-92fc-4f52-bad2-4f0e5802a43d", "biodome_lab_containers_close_02",
        
        // Clipboard
        "a7519acf-6dec-429e-82ed-bbcf7a616c50", "docking_clerical_clipboard1", 
        
        // Hatching Enzymes
        "fab9bc63-1916-4434-a9c6-231f421ffbb5", "model", // 
        
        // Polyaniline
        "7e164f67-f4e7-41fc-98a5-7a84ccaa1d09", "Polyaniline",
        
        // Bleach
        "fbfacd7b-32a8-4065-8c25-b0a703f2683b", "model",
        
        // Hydrochloric Acid
        "74912c22-a383-48c7-8e9e-34b515c6aebb", "Hydrochloric_acid",
        
        // Benzene
        "986b31ea-3c9d-498c-9f38-2af8ffe86ed7", "Benzene",
        
        // Lubricant
        "96b1b863-2ff7-451b-aa38-8b3a06e72d63", "model",
        
      //-----------------------------------------------------------------------
      // SMALL PLANTER POTS
      //-----------------------------------------------------------------------
        
        // Basic Plant Pot
        "c59c1abc-4e00-4480-8d8d-f337a81ba2d6", "model", 
        
        // Composite Plant Pot
        "5c8cb04b-9f30-49e7-8687-0cbb338fc7fa", "model", 
        
        // Chic Plant Pot 
        "0fbf203a-a940-4b6e-ac63-0fe2737d84c2", "model",
      
      //-----------------------------------------------------------------------
      // LARGE PLANTS (TREES)
      //-----------------------------------------------------------------------
      
        // Lantern Tree
        "8fa4a413-57fa-47a3-828d-de2255dbce4f", "farming_plant_03",
      
        // Fern Palms
      
          // Small
          "6d13066f-95c8-491b-965b-79ac3c67e6aa", "land_plant_middle_03_03",
          // Medium
          "1d6d89dd-3e49-48b7-90e4-b521fbc3d36f", "land_plant_middle_03_02",
          // Large
          "523879d5-3241-4a94-8588-cb3b38945119", "land_plant_middle_03_01",
          
      //-----------------------------------------------------------------------
      // MEDIUM PLANTS
      //-----------------------------------------------------------------------
          
        // Jaffa Cup
        
          // Large
          "35056c71-5da7-4e73-be60-3c22c5c9e75c", "land_plant_middle_05_01",
          // Medium. No Stem
          "08c1c77c-6ca3-49d1-9e4f-608e87d6f90c", "land_plant_middle_05_02",
          // Small. No Stem
          "8e4e640e-4c04-4168-a0cc-4ec86b709345", "land_plant_middle_05_03",
          
          // Spore. No model - used for MushroomTerrariumSmall only
          "ff727b98-8d85-416a-9ee7-4beda86d2ba2", "",
        
        // Grub Basket
        "28c73640-a713-424a-91c6-2f5d4672aaea", "land_plant_middle_02",
      
      //-----------------------------------------------------------------------
      // SMALL PLANTS
      //-----------------------------------------------------------------------
      
        // Speckled Rattler. Note that these models are huge and need a scale of ~0.02
        
          // Single
          "28818d8a-5e50-41f0-8e14-44cb89a0b611", "land_plant_small_02_01",
          // Triple
          "98be0944-e0b3-4fba-8f08-ca5d322c22f6", "land_plant_small_02_02",
          
        // Pink Cap
        
          // Single
          "7f9a765d-0b4e-4b3f-81b9-38b38beedf55", "land_plant_small_03_01",
          // Double Cap (one large, one small)
          "e88e7a23-2a99-41c5-aed9-a2bfaca3619d", "land_plant_small_03_02",
          // Double Cap (two large)
          "a7aef01f-0dc0-4d03-913d-d47d8d2ba407", "land_plant_small_03_03",
          // Quintuple Cap (3 large, 2 small)
          "c7faff7e-d9ff-41b4-9782-98d2e09d29c1", "land_plant_small_03_04",
          // Triple Cap for mounting on vertical wall 
          "b715508e-a7e4-47f0-a55b-bf6f65d24ac2", "land_plant_small_03_05",
          
        // Voxel Shrub
        
          // Sprout (100% green)
          "e97c72ec-4999-48fa-b8b2-6d3f8791a7e8", "land_plant_small_01_03",
          // Bud (4 petals)
          "2cab613d-2fc0-4012-ae6e-99f42d4262fd", "land_plant_small_01_02",
          // Full-Grown (4 flowers)
          "28ec1137-da13-44f3-b76d-bac12ab766d1", "land_plant_small_01_01",
      
      //-----------------------------------------------------------------------
      // UN-BUILDABLE PLANTS
      //-----------------------------------------------------------------------
      
        // Red-Tipped Fern
        "559fe0c7-1754-40f5-9453-b537900b3ac4", "land_plant_middle_06_01_LOD1",
        
        // Spindly tall plant
        "154a88c1-6c7f-44e4-974e-c52d2f48fa28", "Tropical_plant_6b",
        
        // Vine Fill
        "75ab087f-9934-4e2a-b025-02fc333a5c99", "Tropical_Plant_10a",
        
        // Land Tree 1
        "1cc51be0-8ea9-4730-936f-23b562a9256f", "Land_tree_01_LOD0" // This model has other LODs, but this is probably because they are everywhere on the floating island. We can probably get away with just this one
    };
    private static List<GameObject> prefabObjList = new List<GameObject>();
    
    public static IEnumerator ensureInitialized() {
      if(prefabObjList.Count*2 < prefabIdModelNameList.Count) { // list not constructed
        for(int i = 0; i < prefabIdModelNameList.Count; i = i + 2) { // step by 2 as we are stepping through a flattned list of pairs (prefab ID, model name)
          string prefabID = prefabIdModelNameList[i];
          IPrefabRequest task = PrefabDatabase.GetPrefabAsync(prefabID);
          Debug.Log("CompositeBuildables.PrefabFactory: ensureInitialized with prefabID = " + prefabID);
          yield return task;
          if(task.TryGetPrefab(out GameObject objTmp)) {
            Debug.Log("CompositeBuildables.PrefabFactory: TryGetPrefab succeeded for " + prefabID);
            prefabObjList.Add(objTmp);
            foreach (Transform child in objTmp.transform) {
              Debug.Log("CompositeBuildables.PrefabFactory: \tPrefab " + prefabID + ".transform contains a model called " + child.name);
            }
          } else {
            Debug.Log("CompositeBuildables.PrefabFactory: TryGetPrefab failed for " + prefabID);
          }
        }
      }
    }
    
    private static int GetIndex(string prefabID) {
      return prefabIdModelNameList.FindIndex(str => str.Equals(prefabID))/2; // should always be an even entry, so dividing by 2 should never give an
    }
    
    public static string GetModelName(string prefabID) {
      return prefabIdModelNameList[2*GetIndex(prefabID)+1]; 
    }
    
    public static GameObject GetPrefabGameObject(string prefabID) {
      return prefabObjList[GetIndex(prefabID)];
    }
    
    public static GameObject InstantiatePrefabInactive(string prefabID) {
      // Find the prefab
      var prefab = prefabObjList[GetIndex(prefabID)];
      // Determine whether the prefab is currently active
      bool prefabOriginallyActive = prefab.activeSelf;
      // Deactivate the prefab (so that instantiate returns an inactive object) and call instantiate
      prefab.SetActive(false);
      GameObject result = GameObject.Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);
      // Restore the prefab's original activity state
      prefab.SetActive(prefabOriginallyActive);
      // Return the new instance
      return result;
    }
    
    public static Transform AttachModelFromPrefabTo(string prefabID, Transform to) { // returns the model which was moved
      GameObject victim = InstantiatePrefabInactive(prefabID); // gameObject we will harvest for its model and then destroy
      Transform result = victim.transform.Find(prefabIdModelNameList[2*GetIndex(prefabID)+1]);
      result.parent = to;
      UnityEngine.Object.Destroy(victim);
      return result; //to.transform.Find(prefabIdModelNameList[2*GetIndex(prefabID)+1]); // returns the model which was moved
    }
    
}