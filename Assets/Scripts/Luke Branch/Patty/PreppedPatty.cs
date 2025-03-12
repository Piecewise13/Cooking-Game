using UnityEngine;

public class PreppedPatty : PreppedIngredients, Cookable
{

    //set to true because the only way for this to spawn is on the frying pan
    public bool isOnFryingPan = false;

    public float timeToBurn;

    private float burnTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOnFryingPan){
            return;
        }

        burnTime += Time.deltaTime;

        if(burnTime >= timeToBurn){
        ////TODO: make some sort of fire effect maybe
            Destroy(gameObject);
        }
    }

    public void StartCooking()
    {
        print("Cooked patty is cooking");
        isOnFryingPan = true;
    }

    public void StopCooking()
    {
        isOnFryingPan = false;
    }

    public float PercentageCooked()
    {
        return burnTime / timeToBurn;
    }
}
