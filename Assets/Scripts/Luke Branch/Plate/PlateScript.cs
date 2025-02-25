
using System.Collections.Generic;
using UnityEngine;


public class PlateScript : MonoBehaviour
{

    private Dictionary<IngredientType, int> currentIngredients = new Dictionary<IngredientType, int>();

    public Transform foodModelTransform;


    void OnTriggerEnter(Collider other)
    {
        //check to see if whatever is overlapping has the lettuce script
        PreppedLettuce lettuceScript = other.transform.root.GetComponent<PreppedLettuce>();

        // if not, then ignore the item
        if(lettuceScript == null){
            return;
        }

        if(!currentIngredients.ContainsKey(lettuceScript.GetType())){
            currentIngredients[lettuceScript.GetType()] = 0;
        }

        //add one lettuce to the plate
        currentIngredients[lettuceScript.GetType()] += 1;

        Instantiate(lettuceScript.platedPrefab, foodModelTransform.position,  Quaternion.AngleAxis(Random.Range(0,360f), Vector3.up),foodModelTransform);

        //destroy the prepped lettuce
        Destroy(other.gameObject);
    }

    public Dictionary<IngredientType, int> GetPlatedIngredients(){
        return currentIngredients;
    }
}
