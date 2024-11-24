using Nautilus.Json;
using Nautilus.Json.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeBuildables;

[Serializable]
public class MushroomGrowerSaveData
{
  public int version = 1;
  
  public float timeRemainingPink = -1f;
  public float timeRemainingRattler = -1f;
  public float timeRemainingJaffa = -1f;
}

[Serializable]
public class FruitPlantSaveData
{
  public int version = 1;
  
  public float timeLastFruit = -1f;
  public List<bool> pickedStates = new();
}

[FileName("CompositeBuildablesSaveData")]
internal class SaveCache : SaveDataCache
{
    public Dictionary<string, MushroomGrowerSaveData> mushroomGrowerSaves = new();
    public Dictionary<string, FruitPlantSaveData> fruitPlantSaves = new();
    
    public SaveCache()
    {
      OnFinishedLoading += (object _, JsonFileEventArgs _) => mushroomGrowerSaves.ForEach((entry) => Plugin.Logger.LogMessage($"key {entry.Key}, value {entry.Value}"));
      OnFinishedLoading += (object _, JsonFileEventArgs _) => fruitPlantSaves.ForEach((entry) => Plugin.Logger.LogMessage($"key {entry.Key}, value {entry.Value}"));
      
      OnStartedSaving += RefreshSaves;
    }
    
    public void RefreshSaves(object _, JsonFileEventArgs __) {
      mushroomGrowerSaves = new();
      fruitPlantSaves = new();
    }
}