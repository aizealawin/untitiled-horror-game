using Unity.VisualScripting;
using UnityEngine;

public class RayCasting : MonoBehaviour
{

    [SerializeField] float distanceFromTarget;
    [SerializeField] GameObject target;
    public GameObject CurrentTarget => target;
    public float CurrentDistance => distanceFromTarget;


    [SerializeField] float toTarget;
    [Header("Debug")]
    [SerializeField] bool showHitInConsole = false;
    [SerializeField] bool showHitOnScreen = false;

    // small on-screen label position
    [SerializeField] Vector2 onScreenPos = new Vector2(10, 10);
    string lastHitName = "";

    // creating layer mask
    [SerializeField] LayerMask layerMask;
    [SerializeField] float maxDistance = 10f;


    void Update()
    {
        // 
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance, layerMask))
        {
            toTarget = hit.distance;
            distanceFromTarget = hit.distance;

            // set the static target so other scripts can access it
            target = hit.collider != null ? hit.collider.gameObject : null;

            // prepare a readable hit description
            string hitName = target != null ? target.name : "(no gameobject)";
            string hitTag = target != null ? target.tag : "Untagged";
            lastHitName = hitName;

            if (showHitInConsole)
            {
                Debug.Log($"Raycast hit: {hitName} (tag: {hitTag}) at distance {hit.distance:0.00}m", target);
            }
        }
        else
        {
            // clear when nothing is hit
            target = null;
            lastHitName = "";
        }
    }

    void OnGUI()
    {
        if (!showHitOnScreen) return;

        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 14;
        style.normal.textColor = Color.white;

        string text = string.IsNullOrEmpty(lastHitName) ? "No hit" : $"Hit: {lastHitName} ({distanceFromTarget:0.00}m)";
        GUI.Label(new Rect(onScreenPos.x, onScreenPos.y, 400, 30), text, style);
    }
}
