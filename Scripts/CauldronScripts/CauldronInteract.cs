using UnityEngine;

public class CauldronInteract : MonoBehaviour, IInteractable
{
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] Cauldron cauldron;
    [SerializeField] IngredientDefinition[] acceptedDefs;
    [SerializeField] float allowedRange = 2f;

    public void Interact(GameObject instigator)
    {
        if (cauldron == null)
        {
            Debug.LogWarning("Cauldron reference missing on CauldronInteract.");
            return;
        }

        // Prefer to get PlayerInventory from the instigator (player) so the component is reusable
        var playerInventory = instigator.GetComponentInParent<PlayerInventory>();
        if (playerInventory == null)
        {
            Debug.LogWarning("No PlayerInventory found on instigator when interacting with cauldron.");
            return;
        }

        // Optionally, you could check distance here too if you want a second guard:
        var playerPos = instigator.transform.position;
        if (Vector3.Distance(playerPos, transform.position) > allowedRange)
        {
            Debug.Log("Too far from cauldron.");
            return;
        }

        // Transfer accepted ingredients (one each as in your previous logic)
        foreach (var def in acceptedDefs)
        {
            if (playerInventory.GetCount(def) > 0)
            {
                playerInventory.Remove(def, 1);
                cauldron.AddIngredient(def);
            }
        }
        cauldron.TryBrew();
    }

    public bool CanInteract(GameObject instigator)
    {
        // Example guard: only allow if within allowedRange
        return Vector3.Distance(instigator.transform.position, transform.position) <= allowedRange;
    }
}
