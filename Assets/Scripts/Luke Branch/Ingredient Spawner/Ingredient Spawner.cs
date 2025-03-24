using UnityEngine;
using System.Collections.Generic;

public class IngredientSpawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> ingredients;

    public BoxCollider spawnBox;

    public float minSpawnTime, maxSpawnTime, xVeloMax, yVeloMax, xVeloMin, yVeloMin;

    private float spawnDelay;

    private float spawnTimer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer + spawnDelay < Time.time)
        {
            SpawnIngredient();
        }
    }

    void SpawnIngredient()
    {
        Vector3 spawnPosition = RandomPointInBounds(spawnBox.bounds);

        int randomIndex = Random.Range(0, ingredients.Count);

        GameObject ingredient = Instantiate(ingredients[randomIndex], spawnPosition, Quaternion.identity);
        ingredient.GetComponent<Rigidbody>().linearVelocity = RandomStartVelocity();

        spawnTimer = Time.time;

        spawnDelay = Random.Range(minSpawnTime, maxSpawnTime);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredient"))  // Check if the object has the tag "ingredient"
        {
            Destroy(other.gameObject);
        }
    }

    Vector3 RandomStartVelocity()
    {
        return new Vector3(Random.Range(-xVeloMax, xVeloMax), Random.Range(yVeloMin, yVeloMax), 0);
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
