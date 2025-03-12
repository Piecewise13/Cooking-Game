using UnityEngine;

public class TurnInWindow : MonoBehaviour
{

    private GameMasterScript gameMaster;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameMaster = FindAnyObjectByType<GameMasterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Transform rootTrans = other.transform.root;

        if(!rootTrans.CompareTag("FinishedRecipe")){
            return;
        }

        FinishedRecipe recipe = rootTrans.GetComponent<FinishedRecipe>();

        gameMaster.OrderTurnedIn(recipe);

        print("Recipe turned in");

        Destroy(rootTrans.gameObject);
        //TODO: Play sound effect
    }
}
