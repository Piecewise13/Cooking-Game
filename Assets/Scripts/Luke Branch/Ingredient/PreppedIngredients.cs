using UnityEngine;

public class PreppedIngredients : MonoBehaviour
{

    public GameObject platedPrefab;
    [SerializeField] protected PreppedIngredientType ingredientType;

    public float platedHeight;


     public PreppedIngredientType GetIngredientType(){
        return ingredientType;
    }
}
