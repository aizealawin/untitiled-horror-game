using UnityEngine;

public class RayCasting : MonoBehaviour
{

    public static float distanceFromTarget;
    public static GameObject target;
    [SerializeField] float toTarget;


    void Update()
    {
        // 
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            toTarget = hit.distance;
            distanceFromTarget = hit.distance;
        }
    }
}
