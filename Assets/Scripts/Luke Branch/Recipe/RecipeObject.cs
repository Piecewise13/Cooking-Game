using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "RecipeScript", menuName = "Scriptable Objects/RecipeScript")]
public class RecipeObject : ScriptableObject
{
    
    public List<Ingredient> recipeIngredientList;

    public GameObject finishedModel;

    public override bool Equals(object other)
    {
        var otherRecipe = other as Dictionary<PreppedIngredientType, int>;

        if(otherRecipe == null){
            return false;
        }

        foreach (Ingredient ingredient in recipeIngredientList){

            if(!otherRecipe.ContainsKey(ingredient.ingredientType)){
                return false;
            }

            if(ingredient.count != otherRecipe[ingredient.ingredientType]){
                return false;
            }
        }

        return true;
    }

}

[Serializable]
public struct Ingredient{
    public PreppedIngredientType ingredientType;

    public int count;
}

public enum PreppedIngredientType {
    LETTUCE,
    COOKED_PATTY,

    BUN
}
