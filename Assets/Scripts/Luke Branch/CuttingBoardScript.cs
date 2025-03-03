using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CuttingBoardScript : MonoBehaviour
{

    public Transform snapPoint;

    private XRSocketInteractor socket;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IngredientOnBoard(){
        var lettuceScript = socket.firstInteractableSelected.transform.root.GetComponent<UnpreppedLettuce>();

        if(lettuceScript == null){
            return;
        }

        print("Lettuce on board");
        lettuceScript.isOnCuttingBoard = true;
    }

        public void IngredientLeavesBoard(){
        var lettuceScript = socket.firstInteractableSelected.transform.root.GetComponent<UnpreppedLettuce>();

        if(lettuceScript == null){
            return;
        }

        lettuceScript.isOnCuttingBoard = false;
    }

}
