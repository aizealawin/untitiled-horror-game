using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private Dictionary<string, int> _items = new Dictionary<string, int>();

    public event Action OnInventoryChanged;

    public void Add(IngredientDefinition def, int amount = 1)
    {
        if (def == null) return;
        if (_items.ContainsKey(def.id)) _items[def.id] += amount;
        else _items[def.id] = amount;
        Debug.Log($"Added {amount}x {def.displayName} to inventory (total: {_items[def.id]})");
        OnInventoryChanged?.Invoke();
    }

    public bool Remove(IngredientDefinition def, int amount = 1)
    {
        if (def == null) return false;
        if (!_items.TryGetValue(def.id, out var current) || current < amount) return false;
        _items[def.id] = current - amount;
        if (_items[def.id] <= 0) _items.Remove(def.id);
        OnInventoryChanged?.Invoke();
        return true;
    }

    public int GetCount(IngredientDefinition def)
    {
        if (def == null) return 0;
        return _items.TryGetValue(def.id, out var count) ? count : 0;
    }

    public IReadOnlyDictionary<string, int> Items => _items;
}
