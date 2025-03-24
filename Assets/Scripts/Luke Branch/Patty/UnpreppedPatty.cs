using UnityEngine.XR;
using UnityEngine;
using Unity.Mathematics;

public class UnpreppedPatty : UnpreppedIngredient, Cookable
{

    public float timeToCook;

    private float cookedTime;

    private bool isOnFryingPan = false;


    // Update is called once per frame
    void Update()
    {
        if (!isOnFryingPan)
        {
            return;
        }

        cookedTime += Time.deltaTime;
        if (cookedTime < timeToCook)
        {
            return;
        }

        base.IngredientPrepped();

    }

    public void StartCooking(){
        isOnFryingPan = true;
    }

    public void StopCooking(){
        isOnFryingPan = false;
    }

    public float PercentageCooked()
    {
        return cookedTime / (timeToCook);
    }
}


