using UnityEngine;
using System.Collections.Generic;

public class Cauldron : MonoBehaviour
{
    [System.Serializable]
    public class Recipe
    {
        public List<string> IngredientIds;
        public string resultName;
    }

    [SerializeField] List<Recipe> recipes = new List<Recipe>();

    private List<string> bucket = new List<string>();

    public void AddIngredient(IngredientDefinition def)
    {
        if (def == null) return;
        bucket.Add(def.id);
        Debug.Log($"Added {def.displayName} to cauldron. Current count: {bucket.Count}");
    }

    public void TryBrew()
    {
        foreach (var r in recipes)
        {
            if (MatchesRecipe(bucket, r.IngredientIds))
            {
                Debug.Log($"Brewed {r.resultName}.");
                bucket.Clear();
                return;
            }
        }
        Debug.Log("No matching recipe");
    }

    private bool MatchesRecipe(List<string> a, List<string> b)
    {
        if (a.Count != b.Count) return false;
        var da = new Dictionary<string, int>();
        var db = new Dictionary<string, int>();
        foreach (var x in a) { if (!da.ContainsKey(x)) da[x] = 0; da[x]++; }
        foreach (var x in b) { if (!db.ContainsKey(x)) db[x] = 0; db[x]++; }
        if (da.Count != db.Count) return false;
        foreach (var kv in da)
        {
            if (!db.TryGetValue(kv.Key, out var cnt) || cnt != kv.Value) return false;
        }
        return true;
    }
}
