using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public class FryingPan : MonoBehaviour
{
    XRSocketInteractor socket;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IngredientInSocket(){
        GameObject ingredientInSocket = socket.firstInteractableSelected.transform.root.gameObject;

        Cookable ingredient = ingredientInSocket.GetComponent<Cookable>();

        if(ingredient == null){

            return;
        }

        ingredient.StartCooking();
    }

    public void IngredientLeftSocket(){
        GameObject ingredientInSocket = socket.firstInteractableSelected.transform.root.gameObject;

        Cookable ingredient = ingredientInSocket.GetComponent<Cookable>();

        if(ingredient == null){

            return;
        }

        print("Stop cooking");

        ingredient.StopCooking();

    }
}
