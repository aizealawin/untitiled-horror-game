using UnityEngine;

public interface IInteractable
{
    void Interact(GameObject instigator);

    bool CanInteract(GameObject instigator);
}
