using UnityEngine;

public class UnpreppedIngredient : IngredientParent
{

    public GameObject preppedPrefab;

    //public INGREDIENT_PREP prepType;

    public float prepTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum INGREDIENT_PREP {
    CHOP,
    COOK,
    TURN_IN
}