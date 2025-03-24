using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderGenerator : MonoBehaviour
{


    public AnimationCurve difficultyCurve;

    public List<RecipeSpawner> recipesToSpawn;

    private GameMasterScript master;

    private float placementOffset;

    public float placementDelta;

    private List<Order> orderPapers = new List<Order>();

    public Transform spawnLocation;

    private float lastSpawn;
    private float nextSpawnTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        master = FindAnyObjectByType<GameMasterScript>();
        GenerateRecipe(recipesToSpawn[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (lastSpawn + nextSpawnTime < Time.time)
        {

            int rand = Random.Range(0, recipesToSpawn.Count);

            float p = Random.Range(0f, 1f);
            if (p < recipesToSpawn[rand].spawnPercentage)
            {
                GenerateRecipe(recipesToSpawn[rand]);

            }
            nextSpawnTime = recipesToSpawn[rand].baseSpawnRate;
            lastSpawn = Time.time;
        }
    }


    public void GenerateRecipe(RecipeSpawner recipe)
    {
        //TODO: Create the object in the world that represents the order

        master.AddOrder(recipe.recipeObject);

        var order = Instantiate(recipe.orderPrefab, spawnLocation.position + spawnLocation.forward * placementOffset, Quaternion.identity);

        Order orderData;
        orderData.orderObject = order;
        orderData.recipe = recipe.recipeObject.recipeType;

        orderPapers.Add(orderData);

        placementOffset += placementDelta;

    }

    public void RemoveRecipe(FINISHED_RECIPES recipe)
    {
        foreach (var order in orderPapers)
        {
            if (order.recipe == recipe)
            {
                Destroy(order.orderObject);
                orderPapers.Remove(order);
                return;
            }
        }
    }
}

[Serializable]
public struct RecipeSpawner
{
    public RecipeObject recipeObject;

    public GameObject orderPrefab;

    public float baseSpawnRate;

    public float spawnPercentage;
}

struct Order
{
    public GameObject orderObject;
    public FINISHED_RECIPES recipe;
}