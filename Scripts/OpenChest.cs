using UnityEngine;
using UnityEngine.InputSystem;

public class OpenChest : MonoBehaviour
{
    [SerializeField] float internalDistance;
    [SerializeField] bool chestOpen = false;
    [SerializeField] GameObject chest;

    private PlayerInput playerInput;
    private InputAction interactAction;

    void Awake()
    {
        playerInput = FindFirstObjectByType<PlayerInput>();
        interactAction = playerInput.actions["Interact"];
        interactAction.performed += OnInteract;
    }

    void OnDestroy()
    {
        interactAction.performed -= OnInteract;
    }
    void Update()
    {
        // internalDistance = RayCasting.CurrentTarget;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        // if (RayCasting.target != null)
        // {
        //     if (chestOpen == false && internalDistance < 2f && RayCasting.target.name == "Chest")
        //     {
        //         chestOpen = true;
        //         chest.GetComponent<Animator>().Play("OpenChest");
        //     }
        // }
        // Debug.Log("Pressed");
    }
}
