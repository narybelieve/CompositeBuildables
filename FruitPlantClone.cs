using ProtoBuf;
using System;
using System.Collections.Generic;
using UnityEngine;
using UWE;

namespace CompositeBuildables;

[ProtoContract]
public class FruitPlantClone : MonoBehaviour, IShouldSerialize // Clone of built-in FruitPlant class which removes [NonSerialized] from some members so that the prefab can set them
{
	public PickPrefab[] fruits;

	public float fruitSpawnInterval = 50f;

	private const bool defaultFruitSpawnEnabled = false;

	private const float defaultTimeNextFruit = -1f;

	private const int currentVersion = 1;

	[NonSerialized]
	[ProtoMember(1)]
	public int version = 1;

	[NonSerialized]
	[ProtoMember(2)]
	public float timeNextFruit = -1f;

	//[NonSerialized]
	//[ProtoMember(3)]
	public const bool fruitSpawnEnabled = true;

	private List<PickPrefab> inactiveFruits = new List<PickPrefab>();

	private bool initialized;
	
	private void Start()
	{
		if (fruitSpawnEnabled)
		{
			Initialize();
		}
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
	}

	private void Update()
	{
		if (fruitSpawnEnabled)
		{
			while (inactiveFruits.Count != 0 && DayNightCycle.main.timePassed >= (double)timeNextFruit)
			{
				PickPrefab random = SystemExtensions.GetRandom<PickPrefab>((IList<PickPrefab>)inactiveFruits);
				random.SetPickedState(newPickedState: false);
				inactiveFruits.Remove(random);
				timeNextFruit += fruitSpawnInterval;
			}
		}
	}

	private void OnFruitHarvest(PickPrefab fruit)
	{
		if (inactiveFruits.Count == 0)
		{
			timeNextFruit = DayNightCycle.main.timePassedAsFloat + fruitSpawnInterval;
		}
		inactiveFruits.Add(fruit);
	}

	private void OnGrown()
	{
		for (int i = 0; i < fruits.Length; i++)
		{
			fruits[i].SetPickedState(newPickedState: true);
		}
		initialized = false;
		Initialize();
		//fruitSpawnEnabled = true;
		timeNextFruit = DayNightCycle.main.timePassedAsFloat;
	}

	public bool ShouldSerialize()
	{
		if (version == 1 && !fruitSpawnEnabled)
		{
			return timeNextFruit != -1f;
		}
		return true;
	}
}