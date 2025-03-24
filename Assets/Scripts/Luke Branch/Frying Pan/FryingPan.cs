using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public class FryingPan : MonoBehaviour
{
    XRSocketInteractor socket;


    public GameObject canvas;
    private Slider slider;

    private Cookable cookingObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
        slider = canvas.GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cookingObject != null){
            slider.value = cookingObject.PercentageCooked();
        }
    }

    public void IngredientInSocket(){
        GameObject ingredientInSocket = socket.firstInteractableSelected.transform.root.gameObject;

        Cookable ingredient = ingredientInSocket.GetComponent<Cookable>();

        if(ingredient == null){

            return;
        }

        cookingObject = ingredient;
        canvas.SetActive(true);

        ingredient.StartCooking();
    }

    public void IngredientLeftSocket(){
        GameObject ingredientInSocket = socket.firstInteractableSelected.transform.root.gameObject;

        Cookable ingredient = ingredientInSocket.GetComponent<Cookable>();

        if(ingredient == null){

            return;
        }

        print("out of socket");
        cookingObject = null;

        canvas.SetActive(false);

        ingredient.StopCooking();

    }
}
