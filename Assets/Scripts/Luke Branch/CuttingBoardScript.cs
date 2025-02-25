using UnityEngine;

public class CuttingBoardScript : MonoBehaviour
{

    public Transform snapPoint;

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
        var lettuceScript = other.gameObject.GetComponent<UnpreppedLettuce>();

        if(lettuceScript == null){
            return;
        }

        lettuceScript.isOnCuttingBoard = true;

        other.gameObject.transform.position = snapPoint.transform.position;
    }

    void OnTriggerExit(Collider other)
    {
        var lettuceScript = other.gameObject.GetComponent<UnpreppedLettuce>();

        if(lettuceScript == null){
            return;
        }

        lettuceScript.isOnCuttingBoard = false;
    }

}
