using UnityEngine;

public abstract class UnpreppedIngredient : MonoBehaviour
{

    public GameObject preppedPrefab;

    public GameObject poofParticle;

    protected virtual void IngredientPrepped(){
        //TODO: Play poof particle effect to hide the transition
        Instantiate(preppedPrefab, gameObject.transform.position, gameObject.transform.rotation);

        Instantiate(poofParticle, gameObject.transform.position, gameObject.transform.rotation);
        
        Destroy(gameObject);
    }
}

public enum INGREDIENT_PREP {
    CHOP,
    COOK
}

public interface Choppable {
    public void ChopIngredient();
}

public interface Cookable{
    public void StartCooking();

    public void StopCooking();
}