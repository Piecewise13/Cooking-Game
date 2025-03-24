
using System.Collections.Generic;
using UnityEngine;


public class PlateScript : MonoBehaviour
{

    private Dictionary<PreppedIngredientType, int> currentIngredients = new Dictionary<PreppedIngredientType, int>();

    private float modelHeight;

    public Transform foodModelTransform;

    public List<RecipeObject> recipeList;
    void OnCollisionEnter(Collision other)
    {
        //check to see if whatever is overlapping has the lettuce script
        PreppedIngredients preppedScript = other.transform.root.GetComponent<PreppedIngredients>();
        

        // if not, then ignore the item
        if(preppedScript == null){
            return;
        }

        if(!currentIngredients.ContainsKey(preppedScript.GetIngredientType())){
            currentIngredients[preppedScript.GetIngredientType()] = 0;
        }

        //add one lettuce to the plate
        currentIngredients[preppedScript.GetIngredientType()] += 1;

        Instantiate(preppedScript.platedPrefab, foodModelTransform.position + Vector3.up * modelHeight,  Quaternion.AngleAxis(Random.Range(0,360f), Vector3.up),foodModelTransform);

        CheckFinishedRecipe();

        modelHeight += preppedScript.platedHeight;

        //destroy the prepped lettuce
        Destroy(other.gameObject);
    }

    private void CheckFinishedRecipe()
    {
        foreach(RecipeObject recipe in recipeList){
            if(recipe.Equals(currentIngredients)){
                Instantiate(recipe.finishedModel, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    public Dictionary<PreppedIngredientType, int> GetPlatedIngredients(){
        return currentIngredients;
    }
}
