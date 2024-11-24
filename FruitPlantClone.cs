using ProtoBuf;
using System;
using System.Collections.Generic;
using UnityEngine;
using UWE;

using Nautilus.Json;
namespace CompositeBuildables;

[ProtoContract]
public class FruitPlantClone : MonoBehaviour, IShouldSerialize // Clone of built-in FruitPlant class which removes [NonSerialized] from some members so that the prefab can set them
{
	private FruitPlantSaveData _saveData = new();
  public FruitPlantSaveData SaveData { get => _saveData; }
	
	public PickPrefab[] fruits;

	private const bool defaultFruitSpawnEnabled = false;

	private const float defaulttimeLastFruit = -1f;

	private const int currentVersion = 1;

	[NonSerialized]
	[ProtoMember(1)]
	public int version = 1;

	[NonSerialized]
	[ProtoMember(2)]
	public float timeLastFruit = -1f;
		// Using timeLastFruit instead of timeNextFruit means that updates to fruitSpawnInterval are reflected immediately (rather than only after the next fruit spawns)
		// The drawback is that there is an additional floating point addition (timeLastFruit + fruitSpawnInterval) per FruitPlant Update().

	//[NonSerialized]
	//[ProtoMember(3)]
	public const bool fruitSpawnEnabled = true;

	private List<PickPrefab> inactiveFruits = new List<PickPrefab>();

	private bool initialized;
	
	private void Start()
	{
		string id = GetComponent<PrefabIdentifier>().Id;
		if (!Plugin.SaveCache.fruitPlantSaves.TryGetValue(id, out var data))
    {
      // Start() has been called due to PLACING a FruitPlantClone. 
			if(!Plugin.config.LanternTreesSpawnFruited) {
				for(int i = 0; i < fruits.Length; i++) {
					fruits[i].SetPickedState(newPickedState: true);
					inactiveFruits.Add(fruits[i]);
				}
				timeLastFruit = DayNightCycle.main.timePassedAsFloat;
			} else {
				// Doing nothing causes the tree to spawn with fruit
			}
			_saveData = new();
			Plugin.Logger.LogDebug("FruitPlantClone " + id + " was placed");
    } else {
			// Start() has been called due to LOADING a FruitPlantClone 
			_saveData = data;
			for(int i = 0; i < fruits.Length; i++) {
				if(_saveData.pickedStates[i]) {
					fruits[i].SetPickedState(newPickedState: true);
					inactiveFruits.Add(fruits[i]);
				} else {
					fruits[i].SetPickedState(newPickedState: false);
				}
			}
			timeLastFruit = _saveData.timeLastFruit;
			Plugin.Logger.LogDebug("FruitPlantClone " + id + " was loaded");
    }
		if (fruitSpawnEnabled)
		{
			Initialize();
		}
	}
	
	public void OnEnable() {
		Plugin.SaveCache.OnStartedSaving += OnBeforeSave;
	}
	
	private void OnBeforeSave(object _, JsonFileEventArgs __) {
		string id = GetComponent<PrefabIdentifier>().Id;
		_saveData.pickedStates = new();
		for(int i = 0; i < fruits.Length; i++) {
			_saveData.pickedStates.Add(fruits[i].pickedState);
		}
		_saveData.timeLastFruit = timeLastFruit;
		
		Plugin.SaveCache.fruitPlantSaves[GetComponent<PrefabIdentifier>().Id] = SaveData;
  }
	
	private void OnDisable() {
    Plugin.SaveCache.OnStartedSaving -= OnBeforeSave;
	}
	
	private unsafe void Initialize()
	{
		if (!initialized)
		{
			inactiveFruits.Clear();
			for (int i = 0; i < fruits.Length; i++)
			{
				void* foo = null;
				fruits[i].pickedEvent.AddHandler(
					(UnityEngine.Object)this, 
					new UWE.Event<PickPrefab>.HandleFunction(OnFruitHarvest)
				);
				if (fruits[i].GetPickedState())
				{
					inactiveFruits.Add(fruits[i]);
				}
			}
			initialized = true;
		}
		/*if(!Plugin.config.LanternTreesSpawnFruited) {
			for(int i = 0; i < fruits.Length; i++) {
				fruits[i].SetPickedState(newPickedState: true);
				inactiveFruits.Add(fruits[i]);
			}
			timeLastFruit = DayNightCycle.main.timePassedAsFloat;
		}*/
	}
	
	private void Update()
	{
		if (fruitSpawnEnabled)
		{
			while (inactiveFruits.Count != 0 && DayNightCycle.main.timePassed >= (double)timeLastFruit + Plugin.config.LanternFruitSpawnTime)
			{
				PickPrefab random = SystemExtensions.GetRandom<PickPrefab>((IList<PickPrefab>)inactiveFruits);
				random.SetPickedState(newPickedState: false);
				inactiveFruits.Remove(random);
				timeLastFruit += Plugin.config.LanternFruitSpawnTime;
			}
		}
	}

	private void OnFruitHarvest(PickPrefab fruit)
	{
		if (inactiveFruits.Count == 0)
		{
			timeLastFruit = DayNightCycle.main.timePassedAsFloat;
		}
		inactiveFruits.Add(fruit);
	}

	/*private void OnGrown()
	{
		for (int i = 0; i < fruits.Length; i++)
		{
			fruits[i].SetPickedState(newPickedState: true);
		}
		initialized = false;
		Initialize();
		//fruitSpawnEnabled = true;
		timeLastFruit = DayNightCycle.main.timePassedAsFloat;
	}*/

	public bool ShouldSerialize()
	{
		if (version == 1 && !fruitSpawnEnabled)
		{
			return timeLastFruit != -1f;
		}
		return true;
	}
}