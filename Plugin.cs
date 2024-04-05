using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine; // Debug.Log

using Nautilus.Handlers; // OptionsPanelHandler

namespace CompositeBuildables;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency("com.snmodding.nautilus")]
public class Plugin : BaseUnityPlugin
{  
    public new static ManualLogSource Logger { get; private set; }
    
    private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

    private void Awake()
    {
        // set project-scoped logger instance
        Logger = base.Logger;
        
        // Initialize Mod Config
        Config config = OptionsPanelHandler.RegisterModOptions<Config>();
        
        // Initialize custom buildables
        InitializeBuildables(config);

        // register harmony patches, if there are any
        Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }
    
    private void InitializeBuildables(Config config)
    {
        StartCoroutine(PrefabFactory.ensureInitialized());
        
        DegasiPlanter.Register(config);
        DegasiPlanterRound.Register(config);
        DegasiPlanter2.Register(config); 
        
        ScienceBench1.Register(config);
        ScienceBench2.Register(config);
        
        LabShelving.Register(config);
        
        MushroomTerrariumSmall.Register(config); 
        MushroomTerrariumLarge.Register(config); 
        
        TubularShelfSmall.Register(config);
    }
}