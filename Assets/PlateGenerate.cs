using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PlateGenerate : MonoBehaviour
{

    public GameObject platePrefab;  // Prefab for the plate to spawn
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            // Subscribe to grab event
            grabInteractable.selectEntered.AddListener(HandleSelectEntered);
        }
        else
        {
            Debug.LogError("XRGrabInteractable component missing!");
        }
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(HandleSelectEntered);
        }
    }

    private void HandleSelectEntered(SelectEnterEventArgs args)
    {
        print("Select (grab) detected on plate stack.");
        if (args.interactorObject is XRBaseInteractor interactor)
        {
            SpawnPlate(interactor);
        }
    }

    private void SpawnPlate(XRBaseInteractor interactor)
    {
        print("Spawning new plate...");
        if (platePrefab != null && interactor.attachTransform != null)
        {
            GameObject newPlate = Instantiate(platePrefab, interactor.attachTransform.position, interactor.attachTransform.rotation);
        }
        else
        {
            Debug.LogWarning("Plate prefab or interactor attachTransform is not set.");
        }
    }
}