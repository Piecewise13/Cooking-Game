using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PlateGenerate : MonoBehaviour
{
    // The prefab of the plate to spawn.
    public GameObject platePrefab;

    // Reference to the current interactor that entered the trigger.
    private XRBaseInteractor currentInteractor;

    // Called when another collider enters the trigger.
    private void Start()
    {
       
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("entered trigger");
        XRBaseInteractor interactor = other.GetComponentInParent<XRBaseInteractor>();
        if (interactor != null)
        {
            // Subscribe to the interactor's selectEntered event.
            print("listening");
            interactor.selectEntered.AddListener(HandleSelectEntered);
            currentInteractor = interactor;
        }
    }

    // Called when another collider exits the trigger.
    private void OnTriggerExit(Collider other)
    {
        XRBaseInteractor interactor = other.GetComponentInParent<XRBaseInteractor>();
        if (interactor != null && interactor == currentInteractor)
        {
            // Unsubscribe from the interactor's selectEntered event.
            interactor.selectEntered.RemoveListener(HandleSelectEntered);
            currentInteractor = null;
        }
    }

    // Called when the select (grab) action is performed.
    private void HandleSelectEntered(SelectEnterEventArgs args)
    {
        print("select entered");
        if (args.interactorObject is XRBaseInteractor baseInteractor)
        {
            SpawnPlate(baseInteractor);
        }
        else
        {
            Debug.LogWarning("Could not cast interactorObject to XRBaseInteractor.");
        }
    }

    // Instantiates the plate at the interactor's attach transform and parents it there.
    private void SpawnPlate(XRBaseInteractor interactor)
    {
        if (platePrefab != null && interactor.attachTransform != null)
        {
            GameObject newPlate = Instantiate(platePrefab, interactor.attachTransform.position, interactor.attachTransform.rotation);
        }
        else
        {
            Debug.LogWarning("Plate prefab or interactor's attach transform is not assigned.");
        }
    }
}