using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InteractionController : MonoBehaviour
{
    [SerializeField] RayCasting rayCaster;
    [SerializeField] float interactionRange = 2f;
    private PlayerInput playerInput;
    private InputAction interactAction;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        interactAction = playerInput.actions["Interact"];
        interactAction.performed += OnInteract;
    }

    void OnDestroy()
    {
        if (interactAction != null) interactAction.performed -= OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext ctx)
    {
        if (rayCaster == null) return;

        var target = rayCaster.CurrentTarget;
        if (target == null) return;

        if (rayCaster.CurrentDistance > interactionRange) return;

        var interactable = target.GetComponentInParent<IInteractable>();
        if (interactable != null && interactable.CanInteract(gameObject))
        {
            interactable.Interact(gameObject);
        }
    }
}
