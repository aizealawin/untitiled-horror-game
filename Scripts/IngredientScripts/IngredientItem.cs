using UnityEngine;

[RequireComponent(typeof(Collider))]
public class IngredientItem : MonoBehaviour, IInteractable
{

    [SerializeField] IngredientDefinition definition;
    [SerializeField] int quantity = 1;
    [SerializeField] bool pickDisableInsteadOfDestroy = true;

    public void Interact(GameObject instigator)
    {
        var inventory = instigator.GetComponentInParent<PlayerInventory>();
        if (inventory != null)
        {
            inventory.Add(definition, quantity);
        }
        else
        {
            Debug.LogWarning("No PlayerInventory found on instigator");
        }

        if (pickDisableInsteadOfDestroy)
            gameObject.SetActive(false);
        else
            Destroy(gameObject);
    }

    public bool CanInteract(GameObject instigator)
    {
        return true;
    }

    public IngredientDefinition Definition => definition;
    public int Quantity => quantity;
}
