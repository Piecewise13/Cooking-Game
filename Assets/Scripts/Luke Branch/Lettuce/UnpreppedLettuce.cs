using Unity.VisualScripting;
using UnityEngine;

public class UnpreppedLettuce : MonoBehaviour
{

    public GameObject choppedLettuce; 

    public int health;

    public bool isOnCuttingBoard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void IngredientPrepped(){
        //TODO: Play poof particle effect to hide the transition
        Instantiate(choppedLettuce, gameObject.transform.position, gameObject.transform.rotation);

        Destroy(gameObject);
    }

    public void ChopIngredient(){
        print("Overlap");
        
        if(!isOnCuttingBoard){
            return;
        }

        print("Overlap knife");
        health -= 1;
        
        if(health <= 0){
            IngredientPrepped();
        }
    }
}