using UnityEngine;

public class KnifeScript : MonoBehaviour
{



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerExit(Collider other)
    {
        var lettuceScript = other.transform.root.GetComponent<UnpreppedLettuce>();

        if(lettuceScript == null){
            return;
        }

        print("Chopping Lettuce");

        lettuceScript.ChopIngredient();
        //AudioSource source = gameObject.GetComponent<AudioSource>();
        //source.Play();
        

    }
}
