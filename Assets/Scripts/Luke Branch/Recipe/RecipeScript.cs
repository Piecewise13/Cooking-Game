using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "RecipeScript", menuName = "Scriptable Objects/RecipeScript")]
public class RecipeScript : ScriptableObject
{
    
    public List<Ingredient> recipeIngredientList;

    public override bool Equals(object other)
    {
        var otherRecipe = other as Dictionary<IngredientType, int>;

        if(otherRecipe == null){
            return false;
        }

        foreach (Ingredient ingredient in recipeIngredientList){
            if(ingredient.count != otherRecipe[ingredient.ingredientType]){
                return false;
            }
        }

        return true;
    }

}

[Serializable]
public struct Ingredient{
    public IngredientType ingredientType;

    public int count;
}

public enum IngredientType {
    LETTUCE
}
