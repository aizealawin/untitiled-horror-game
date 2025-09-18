using UnityEngine;

public class GemCollect : MonoBehaviour
{

    [SerializeField] AudioSource ding;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        ding.Play();
        Destroy(gameObject);
    }
}
