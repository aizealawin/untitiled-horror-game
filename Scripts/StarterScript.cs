using UnityEngine;

public class StarterScript : MonoBehaviour
{
    [SerializeField] int myNumber;
    [SerializeField] string myName;
    [SerializeField] bool myChoice;

    int myOtherNumber;

    [SerializeField] GameObject myGate;


    void Start()
    {
        myNumber = 4;
        myName = "Kusal";
        myChoice = true;
        myGate.SetActive(true);
    }


    void Update()
    {

    }
}
