using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{

    [SerializeField] private GameObject ingredients;

    public BoxCollider spawnBox;

    public float minSpawnTime, maxSpawnTime;

    private  float spawnDelay;

    private float spawnTimer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer + spawnDelay < Time.time){
            SpawnIngredient();
        }
    }

    void SpawnIngredient(){
        Vector3 spawnPosition = RandomPointInBounds(spawnBox.bounds);

        GameObject ingredient = Instantiate(ingredients, spawnPosition, Quaternion.identity);

        spawnTimer = Time.time;

        spawnDelay = Random.Range(minSpawnTime, maxSpawnTime);
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other);
    }

    public static Vector3 RandomPointInBounds(Bounds bounds) {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
    );
}
}
