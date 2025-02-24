
using System.Collections.Generic;
using UnityEngine;


public class PlateScript : MonoBehaviour
{

    private Dictionary<IngredientType, int> currentIngredients;


    void OnTriggerEnter(Collider other)
    {
        PreppedLettuce lettuceScript = other.transform.root.GetComponent<PreppedLettuce>();

        if(lettuceScript == null){
            return;
        }

        currentIngredients[IngredientType.LETTUCE] += 1;

        Destroy(other);
    }
}
