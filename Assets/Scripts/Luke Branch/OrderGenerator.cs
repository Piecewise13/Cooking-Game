using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;
using Random=UnityEngine.Random;

public class OrderGenerator : MonoBehaviour
{


    public AnimationCurve difficultyCurve;

    public List<RecipeSpawner> recipesToSpawn;

    private GameMasterScript master;

    private float placementOffset;

    public float placementDelta;

    private List<Order> orderPapers = new List<Order>();

    public Transform spawnLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        master = FindAnyObjectByType<GameMasterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < recipesToSpawn.Count; i++){
            if(recipesToSpawn[i].lastSpawn + (recipesToSpawn[i].baseSpawnRate * 
            difficultyCurve.Evaluate((float)master.currentDayNumber / (float)master.maxDayNumber)) 
            < Time.time){

                float p = Random.Range(0,1f);
                if(p < recipesToSpawn[i].spawnPercentage){
                    GenerateRecipe(recipesToSpawn[i]);
                    
                }

                RecipeSpawner spawner = recipesToSpawn[i];
                spawner.lastSpawn = Time.time;
                recipesToSpawn[i] = spawner;

            }
        }
    }


    void GenerateRecipe(RecipeSpawner recipe){
        //TODO: Create the object in the world that represents the order

        master.AddOrder(recipe.recipeObject);
        
        var order = Instantiate(recipe.orderPrefab, spawnLocation.position + spawnLocation.forward * placementOffset, Quaternion.identity);

        Order orderData;
        orderData.orderObject = order;
        orderData.recipe = recipe.recipeObject.recipeType;

        orderPapers.Add(orderData);

        placementOffset += placementDelta;

    }

    public void RemoveRecipe(FINISHED_RECIPES recipe){
        foreach(var order in orderPapers){
            if(order.recipe == recipe){
                Destroy(order.orderObject);
                orderPapers.Remove(order);
                return;
            }
        }
    }
}

[Serializable]
public struct RecipeSpawner{
    public RecipeObject recipeObject;

    public GameObject orderPrefab;

    public float baseSpawnRate;
    
    public float spawnPercentage;

    [HideInInspector] public float lastSpawn;
}

struct Order {
    public GameObject orderObject;
    public FINISHED_RECIPES recipe;
}