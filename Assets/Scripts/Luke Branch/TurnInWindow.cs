using UnityEngine;

public class TurnInWindow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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

        //TODO: make this hook up to the order generator to make this order completed

        Destroy(rootTrans.gameObject);

        //TODO: Play sound effect
    }
}
