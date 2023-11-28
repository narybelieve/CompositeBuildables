using Ingredient = CraftData.Ingredient;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Extensions;
using UnityEngine;

using BepInEx;
using Nautilus.Utility;

using UWE;

using System.Collections; // IEnumerator

namespace CompositeBuildables;

public static class DegasiPlanter
{
    static GameObject smallFernPalmObj;
    static GameObject mediumFernPalmObj;
    static GameObject fernPalmObj;
    static GameObject lanternTreeObj;
    static GameObject tropicalPlant6bObj;
    static GameObject tropicalPlant10aObj;
    static GameObject voxelShrubObj;
    static GameObject jaffaCupObj;
    static GameObject grubBasketObj;
    static GameObject redTippedFernObj;
    static GameObject pinkCapObj;
    static GameObject speckledRattlerObj;
  
    public static PrefabInfo Info { get; } = PrefabInfo
        .WithTechType("DegasiPlanterAssembly", "Degasi Planter (Assembly)", "Bart Torgal's planter from Degasi Base 1-a.")
        // set the icon to that of the vanilla locker:
        .WithIcon(SpriteManager.Get(TechType.PlanterBox));
    
    public static IEnumerator InitSmallFernPalm()
    {
        if(smallFernPalmObj == null) {
          // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
          IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("SmallFernPalmClone");
          yield return task;
          task.TryGetPrefab(out GameObject objTmp);
          smallFernPalmObj = objTmp;
        } else 
          yield break;
    }
    
    public static IEnumerator InitMediumFernPalm()
    {
        if(mediumFernPalmObj == null) {
          // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
          IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("MediumFernPalmClone");
          yield return task;
          task.TryGetPrefab(out GameObject objTmp);
          mediumFernPalmObj = objTmp;
        } else 
          yield break;
    }
    
    public static IEnumerator InitFernPalm()
    {
        if(fernPalmObj == null) {
          // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
          IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("FernPalmClone");
          yield return task;
          task.TryGetPrefab(out GameObject objTmp);
          fernPalmObj = objTmp;
        } else
          yield break;
    }
    
    public static IEnumerator InitLanternTree()
    {
        if(lanternTreeObj == null) {
          // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
          IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("LanternTreeClone");
          yield return task;
          task.TryGetPrefab(out GameObject objTmp);
          lanternTreeObj = objTmp;
        } else
          yield break;
    }
    
    public static IEnumerator InitTropicalPlant6b()
    {
        if(tropicalPlant6bObj == null) {
          // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
          IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("TropicalPlant6bClone");
          yield return task;
          task.TryGetPrefab(out GameObject objTmp);
          tropicalPlant6bObj = objTmp;
        } else
          yield break;
    }
    
    public static IEnumerator InitTropicalPlant10a()
    {
        if (tropicalPlant10aObj == null) {
          // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
          IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("TropicalPlant10aClone");
          yield return task;
          task.TryGetPrefab(out GameObject objTmp);
          tropicalPlant10aObj = objTmp;
        } else
          yield break;
    }
    
    public static IEnumerator InitVoxelShrub()
    {
        if (voxelShrubObj == null) {
          // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
          IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("VoxelShrubClone");
          yield return task;
          task.TryGetPrefab(out GameObject objTmp);
          voxelShrubObj = objTmp;
        } else
          yield break;
    }
    
    public static IEnumerator InitJaffaCup()
    {
        if (jaffaCupObj == null) {
          // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
          IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("JaffaCupClone");
          yield return task;
          task.TryGetPrefab(out GameObject objTmp);
          jaffaCupObj = objTmp;
        } else
          yield break;
    }
    
    public static IEnumerator InitGrubBasket()
    {
        if (grubBasketObj == null) {
          // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
          IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("GrubBasketClone");
          yield return task;
          task.TryGetPrefab(out GameObject objTmp);
          grubBasketObj = objTmp;
        } else
          yield break;
    }
    
    public static IEnumerator InitRedTippedFern()
    {
        if (redTippedFernObj == null) {
          // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
          IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("RedTippedFernClone");
          yield return task;
          task.TryGetPrefab(out GameObject objTmp);
          redTippedFernObj = objTmp;
        } else
          yield break;
    }
    
    public static IEnumerator InitPinkCap()
    {
        if (pinkCapObj == null) {
          // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
          IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("PinkCapClone");
          yield return task;
          task.TryGetPrefab(out GameObject objTmp);
          pinkCapObj = objTmp;
        } else
          yield break;
    }
    
    public static IEnumerator InitSpeckledRattler()
    {
        if (speckledRattlerObj == null) {
          // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
          IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("SpeckledRattlerClone");
          yield return task;
          task.TryGetPrefab(out GameObject objTmp);
          speckledRattlerObj = objTmp;
        } else
          yield break;
    }
    
    public static IEnumerator ModifyPrefabAsync(GameObject obj) {
      
      // Wait for other asynchronous initialization to complete

        yield return CoroutineHost.StartCoroutine(InitLanternTree());
        
        yield return CoroutineHost.StartCoroutine(InitSmallFernPalm());
        yield return CoroutineHost.StartCoroutine(InitMediumFernPalm());
        yield return CoroutineHost.StartCoroutine(InitFernPalm());
        
        yield return CoroutineHost.StartCoroutine(InitTropicalPlant6b());
        yield return CoroutineHost.StartCoroutine(InitTropicalPlant10a());
          
        yield return CoroutineHost.StartCoroutine(InitVoxelShrub());
          
        yield return CoroutineHost.StartCoroutine(InitJaffaCup());
        yield return CoroutineHost.StartCoroutine(InitGrubBasket());
        
        yield return CoroutineHost.StartCoroutine(InitRedTippedFern());
        
        yield return CoroutineHost.StartCoroutine(InitPinkCap());      
        yield return CoroutineHost.StartCoroutine(InitSpeckledRattler());
      
      // Configure placement rules
      
        ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.Submarine;

      // find the object that holds the model:
      
        GameObject planterModel = obj.transform.Find("model").gameObject; // Holds model called "Base_Interior_Planter_Tray_01"
      
      // add models from the cloned plant objects to the planter object
      
        lanternTreeObj.transform.Find("farming_plant_03").parent = planterModel.transform; // there are two farming_plant_03's. The higher-level one has 20 lantern fruits as children. 
        planterModel.transform.Find("farming_plant_03").position = planterModel.transform.position + new Vector3((float)0,(float)0.3945,(float)0);
        
        smallFernPalmObj.transform.Find("land_plant_middle_03_03").parent = planterModel.transform;
        planterModel.transform.Find("land_plant_middle_03_03").position = planterModel.transform.position + new Vector3((float)-0.0061,(float)0.3945,(float)0.035);
        
        mediumFernPalmObj.transform.Find("land_plant_middle_03_02").parent = planterModel.transform;
        planterModel.transform.Find("land_plant_middle_03_02").position = planterModel.transform.position + new Vector3((float)0.185,(float)0.3945,(float)-1);
        
        fernPalmObj.transform.Find("land_plant_middle_03_01").parent = planterModel.transform;
        planterModel.transform.Find("land_plant_middle_03_01").position = planterModel.transform.position + new Vector3((float)-0.71,(float)0.3945,(float)-0.481);
        
        // Spindly Tall Plant
        tropicalPlant6bObj.transform.Find("Tropical_plant_6b").parent = planterModel.transform;
        planterModel.transform.Find("Tropical_plant_6b").localScale = new Vector3((float)0.3503, (float)0.3503, (float)0.3503);
        planterModel.transform.Find("Tropical_plant_6b").position = planterModel.transform.position + new Vector3((float)0.509,(float)0.3945,(float)0.611);
        
        // Vine Fill
        tropicalPlant10aObj.transform.Find("Tropical_Plant_10a").parent = planterModel.transform;
        planterModel.transform.Find("Tropical_Plant_10a").localScale = new Vector3((float)0.3122, (float)0.3122, (float)0.3122);
        planterModel.transform.Find("Tropical_Plant_10a").position = planterModel.transform.position + new Vector3((float)0.053,(float)0.3945,(float)-0.009);
        
        voxelShrubObj.transform.Find("land_plant_small_01_01").parent = planterModel.transform;
        planterModel.transform.Find("land_plant_small_01_01").position = planterModel.transform.position + new Vector3((float)-0.4871,(float)0.3945,(float)0.35);
        
        jaffaCupObj.transform.Find("land_plant_middle_05_01").parent = planterModel.transform;
        planterModel.transform.Find("land_plant_middle_05_01").localScale = new Vector3((float)0.4366, (float)0.4366, (float)0.4366);
        planterModel.transform.Find("land_plant_middle_05_01").position = planterModel.transform.position + new Vector3((float)1.0079,(float)0.2945,(float)0.627);
        
        grubBasketObj.transform.Find("land_plant_middle_02").parent = planterModel.transform;
        planterModel.transform.Find("land_plant_middle_02").localScale = new Vector3((float)0.4366, (float)0.4366, (float)0.4366);
        planterModel.transform.Find("land_plant_middle_02").position = planterModel.transform.position + new Vector3((float)0.578,(float)0.3945,(float)-1.028);
        
        redTippedFernObj.transform.Find("land_plant_middle_06_01_LOD1").parent = planterModel.transform;
        planterModel.transform.Find("land_plant_middle_06_01_LOD1").localScale = new Vector3((float)0.6, (float)0.6, (float)0.6);
        planterModel.transform.Find("land_plant_middle_06_01_LOD1").position = planterModel.transform.position + new Vector3((float)-0.578,(float)0.2945,(float)-0.9);
        
        speckledRattlerObj.transform.Find("land_plant_small_02_02").parent = planterModel.transform; // TRIPLE Speckled Rattler
        planterModel.transform.Find("land_plant_small_02_02").localScale = new Vector3((float)0.02, (float)0.02, (float)0.02);
        planterModel.transform.Find("land_plant_small_02_02").position = planterModel.transform.position + new Vector3((float)-0.4871,(float)0.4945,(float)-0.05);
        
        pinkCapObj.transform.Find("land_plant_small_03_04").parent = planterModel.transform;
        planterModel.transform.Find("land_plant_small_03_04").position = planterModel.transform.position + new Vector3((float)0.6871,(float)0.4945,(float)-0.05);
      
      // Make skyApplier act on all of the added models
      
        var skyApplier = planterModel.EnsureComponent<SkyApplier>();
        skyApplier.anchorSky = Skies.Auto;
        skyApplier.renderers = planterModel.GetAllComponentsInChildren<Renderer>();

      // Disable animators so that plants don't "blow in the wind" indoors
        
        Animator[] allAnimators = planterModel.GetComponentsInChildren<Animator>();
        foreach (Animator a in allAnimators) {
          UnityEngine.Object.Destroy(a);
        }

      // add all components necessary for it to be built:
      
        PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlags, planterModel);
      
      // Remove the Planter object so that seeds can't be planted/grow in the composite object
      
        UnityEngine.Object.Destroy(obj.GetComponent<Planter>());
      
      // Copy the FruitPlant object from the Lantern Tree so that the fruits re-spawn when picked
      
        FruitPlant fruitPlant = obj.AddComponent<FruitPlant>();
        var oldFruitPlant = lanternTreeObj.GetComponent<FruitPlant>();
        
        fruitPlant.fruits = new PickPrefab[oldFruitPlant.fruits.Length];
        fruitPlant.fruitSpawnInterval = 1f;
        fruitPlant.fruitSpawnEnabled = true;
        fruitPlant.version = 91;
        fruitPlant.timeNextFruit = 1f;
        fruitPlant.initialized = false;
        for (int i = 0; i < fruitPlant.fruits.Length; i++) {
          fruitPlant.fruits[i] = oldFruitPlant.fruits[i];
        }
      
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

        // assign the created clone model to the prefab itself:
        planterPrefab.SetGameObject(planterClone);
          // Sets the internal variable GameObject planterPrefab._prefab to planterClone
          // Sets the internal variable PrefabFactoryAsync planterPrefab.Prefab to a function taking an argument obj and returning SyncPrefab(obj, prefab) where
          // IEnumerator SyncPrefab(IOut<GameObject> obj, GameObject prefab) {
          //  obj.Set(prefab);
          //  yield break; // indicates that the iterable IOut has no more elements
          // }

        // assign it to the correct tab in the builder tool:
        planterPrefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);

        // set recipe:
        planterPrefab.SetRecipe(new RecipeData(new Ingredient(TechType.Titanium, 4))); // same as default recipe

        // finally, register it into the game:
        planterPrefab.Register();
    }
}