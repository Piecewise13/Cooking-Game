using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class NonMovableGrabInteractable : XRGrabInteractable
{

    public GameObject platePrefab;
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        // Trigger the select event without allowing movement
        selectEntered.Invoke(args);
        print("Select (grab) detected on plate stack. xdd");
        if (args.interactorObject is XRBaseInteractor interactor)
        {
            SpawnPlate(interactor);
        }
    }

    protected override void Grab()
    {
        // Prevent movement completely
    }

    private void SpawnPlate(XRBaseInteractor interactor)
    {
        print("Spawning new plate...");
        if (platePrefab != null && interactor.attachTransform != null)
        {
            // Instantiate the plate at the interactor's hand position
            GameObject newPlate = Instantiate(platePrefab, interactor.attachTransform.position, interactor.attachTransform.rotation);

            // Get the necessary components
            XRGrabInteractable grabInteractable = newPlate.GetComponent<XRGrabInteractable>();
            Rigidbody plateRb = newPlate.GetComponent<Rigidbody>();

            if (grabInteractable != null)
            {
                // Make sure the interactor automatically selects (grabs) the plate
                interactor.selectEntered.Invoke(new SelectEnterEventArgs
                {
                    interactorObject = interactor,
                    interactableObject = grabInteractable
                });

                print("Forced grab on spawned plate.");
            }

            // Ensure physics is set correctly
            if (plateRb != null)
            {
                plateRb.isKinematic = false;  // Allow movement once grabbed
            }
        }
        else
        {
            Debug.LogWarning("Plate prefab or interactor attachTransform is not set.");
        }
    }
}