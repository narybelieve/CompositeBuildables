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

namespace DegasiPlanterMod.Buildables;

public static class DegasiPlanterAssembly
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
        // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
        IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("SmallFernPalmClone");
        yield return task;
        task.TryGetPrefab(out GameObject objTmp);
        smallFernPalmObj = objTmp;
    }
    
    public static IEnumerator InitMediumFernPalm()
    {
        // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
        IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("MediumFernPalmClone");
        yield return task;
        task.TryGetPrefab(out GameObject objTmp);
        mediumFernPalmObj = objTmp;
    }
    
    public static IEnumerator InitFernPalm()
    {
        // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
        IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("FernPalmClone");
        yield return task;
        task.TryGetPrefab(out GameObject objTmp);
        fernPalmObj = objTmp;
    }
    
    public static IEnumerator InitLanternTree()
    {
        // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
        IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("LanternTreeClone");
        yield return task;
        task.TryGetPrefab(out GameObject objTmp);
        lanternTreeObj = objTmp;
    }
    
    public static IEnumerator InitTropicalPlant6b()
    {
        // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
        IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("TropicalPlant6bClone");
        yield return task;
        task.TryGetPrefab(out GameObject objTmp);
        tropicalPlant6bObj = objTmp;
    }
    
    public static IEnumerator InitTropicalPlant10a()
    {
        // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
        IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("TropicalPlant10aClone");
        yield return task;
        task.TryGetPrefab(out GameObject objTmp);
        tropicalPlant10aObj = objTmp;
    }
    
    public static IEnumerator InitVoxelShrub()
    {
        // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
        IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("VoxelShrubClone");
        yield return task;
        task.TryGetPrefab(out GameObject objTmp);
        voxelShrubObj = objTmp;
    }
    
    public static IEnumerator InitJaffaCup()
    {
        // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
        IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("JaffaCupClone");
        yield return task;
        task.TryGetPrefab(out GameObject objTmp);
        jaffaCupObj = objTmp;
    }
    
    public static IEnumerator InitGrubBasket()
    {
        // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
        IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("GrubBasketClone");
        yield return task;
        task.TryGetPrefab(out GameObject objTmp);
        grubBasketObj = objTmp;
    }
    
    public static IEnumerator InitRedTippedFern()
    {
        // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
        IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("RedTippedFernClone");
        yield return task;
        task.TryGetPrefab(out GameObject objTmp);
        redTippedFernObj = objTmp;
    }
    
    public static IEnumerator InitPinkCap()
    {
        // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
        IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("PinkCapClone");
        yield return task;
        task.TryGetPrefab(out GameObject objTmp);
        pinkCapObj = objTmp;
    }
    
    public static IEnumerator InitSpeckledRattler()
    {
        // Based on InitElectricalPrefab in VehicleUpgradeExample_BelowZero.cs
        IPrefabRequest task = UWE.PrefabDatabase.GetPrefabAsync("SpeckledRattlerClone");
        yield return task;
        task.TryGetPrefab(out GameObject objTmp);
        speckledRattlerObj = objTmp;
    }
    
    public static void Register()
    {
        if(lanternTreeObj == null)
          CoroutineHost.StartCoroutine(InitLanternTree());
        
        if(smallFernPalmObj == null)
          CoroutineHost.StartCoroutine(InitSmallFernPalm());
        
        if(mediumFernPalmObj == null)
          CoroutineHost.StartCoroutine(InitMediumFernPalm());
        
        if(fernPalmObj == null)
          CoroutineHost.StartCoroutine(InitFernPalm());
        
        if(tropicalPlant6bObj == null)
          CoroutineHost.StartCoroutine(InitTropicalPlant6b());
        
        if(tropicalPlant10aObj == null)
          CoroutineHost.StartCoroutine(InitTropicalPlant10a());
        
        if(voxelShrubObj == null)
          CoroutineHost.StartCoroutine(InitVoxelShrub());
        
        if(jaffaCupObj == null)
          CoroutineHost.StartCoroutine(InitJaffaCup());
        
        if(grubBasketObj == null)
          CoroutineHost.StartCoroutine(InitGrubBasket());
        
        if(redTippedFernObj == null)
          CoroutineHost.StartCoroutine(InitRedTippedFern());
        
        if(speckledRattlerObj == null)
          CoroutineHost.StartCoroutine(InitPinkCap());
        
        if(pinkCapObj == null)
          CoroutineHost.StartCoroutine(InitSpeckledRattler());
        
        // create prefab:
        CustomPrefab planterPrefab = new CustomPrefab(Info);

        // copy the model of a vanilla wreck piece (which looks like a taller locker):
        
        CloneTemplate planterClone = new CloneTemplate(Info, "87f5d3e6-e00b-4cf3-be39-0a9c7e951b84"); // model is stored in object called "model"
        
        // modify the cloned model:
        planterClone.ModifyPrefab += obj => // GH: lambda expression. "obj" is the input and the code below is the function which uses it. obj seems to be a GameObject based on context
        {
            // allow it to be placced inside bases and submarines on the ground, and can be rotated:
            ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.Submarine;

            // find the object that holds the model:
            GameObject planterModel = obj.transform.Find("model").gameObject; // Holds model called "Base_Interior_Planter_Tray_01"
            
            // add planterObj as a child of planterModel
            lanternTreeObj.transform.Find("farming_plant_03").parent = planterModel.transform;
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
            
            var skyApplier = planterModel.EnsureComponent<SkyApplier>();
            skyApplier.anchorSky = Skies.Auto;
            skyApplier.renderers = planterModel.GetAllComponentsInChildren<Renderer>();
            
            Animator[] allAnimators = planterModel.GetComponentsInChildren<Animator>();
            foreach (Animator a in allAnimators) {
              a.enabled = false;
            }

            // add all components necessary for it to be built:
            PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlags, planterModel);
        };

        // assign the created clone model to the prefab itself:
        planterPrefab.SetGameObject(planterClone);

        // assign it to the correct tab in the builder tool:
        planterPrefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);

        // set recipe:
        planterPrefab.SetRecipe(new RecipeData(new Ingredient(TechType.Titanium, 4))); // same as default recipe

        // finally, register it into the game:
        planterPrefab.Register();
    }
}