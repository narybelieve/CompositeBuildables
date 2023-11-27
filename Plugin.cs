using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace DegasiPlanterMod;

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
        
        // Initialize custom buildables
        InitializeBuildables();

        // register harmony patches, if there are any
        Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }
    
    private void InitializeBuildables()
    {
        Buildables.SmallFernPalmClone.Register();
        Buildables.MediumFernPalmClone.Register();
        Buildables.FernPalmClone.Register();
        
        Buildables.LanternTreeClone.Register();
        
        Buildables.TropicalPlant6bClone.Register(); // Spindly tall plant. Not a default growable.
        Buildables.TropicalPlant10aClone.Register(); // Vine fill. Not a default growable.
        
        Buildables.VoxelShrubClone.Register();
        
        Buildables.JaffaCupClone.Register();
        Buildables.GrubBasketClone.Register();
        
        Buildables.SpeckledRattlerClone.Register();
        Buildables.PinkCapClone.Register();
        
        Buildables.RedTippedFernClone.Register(); // "LandPlant1" in DecorationsMod. Not a default growable.
        
        Buildables.DegasiPlanterAssembly.Register(); // Uses Planter as core as it has the right origin
    }
}