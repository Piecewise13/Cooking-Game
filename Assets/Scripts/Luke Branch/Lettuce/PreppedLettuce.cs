using UnityEngine;

public class PreppedLettuce : MonoBehaviour
{

    private IngredientType ingredientType = IngredientType.LETTUCE; 

    public GameObject platedPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IngredientType GetType(){
        return ingredientType;
    }
}
