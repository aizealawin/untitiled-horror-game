using UnityEngine;

[CreateAssetMenu(menuName = "Ingredients/IngredientDefinition")]
public class IngredientDefinition : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite icon;
    public string description;
    public int maxStack = 1;
}

