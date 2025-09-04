using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
  [Header("Input Action Assets")]
  [SerializeField] private InputActionAsset playerControls;
  [Header("Action Map Name Reference")]
  [SerializeField] private string actionMapName = "Player";
  [Header("Action Name References")]
  [SerializeField] private string movement = "Movement";
  [SerializeField] private string rotation = "Rotation";
  [SerializeField] private string jump = "Jump";
  [SerializeField] private string sprint = "Sprint";

  private InputAction movementAction;
  private InputAction rotationAction;
  private InputAction jumpAction;
  private InputAction sprintAction;

  public Vector2 MovementInput { get; private set; }
  public Vector2 RotationInput { get; private set; }
  public bool JumpTriggered { get; private set; }
  public bool SprintTriggered { get; private set; }

  private void Awake()
  {
    InputActionMap mapReference = playerControls.FindActionMap(actionMapName);

    movementAction = mapReference.FindAction(movement);
    rotationAction = mapReference.FindAction(rotation);
    jumpAction = mapReference.FindAction(jump);
    sprintAction = mapReference.FindAction(sprint);

    SubscribeActionValuesToInputEvents();
  }

  private void SubscribeActionValuesToInputEvents()
  {
    movementAction.performed += ctx => MovementInput = ctx.ReadValue<Vector2>();
    movementAction.canceled += ctx => MovementInput = Vector2.zero;

    rotationAction.performed += ctx => RotationInput = ctx.ReadValue<Vector2>();
    rotationAction.canceled += ctx => RotationInput = Vector2.zero;

    jumpAction.performed += ctx => JumpTriggered = true;
    jumpAction.canceled += ctx => JumpTriggered = false;

    sprintAction.performed += ctx => SprintTriggered = true;
    sprintAction.canceled += ctx => SprintTriggered = false;
  }

  private void OnEnable()
  {
    playerControls.FindActionMap(actionMapName).Enable();
  }

  private void OnDisable()
  {
    playerControls.FindActionMap(actionMapName).Disable();
  }
}
