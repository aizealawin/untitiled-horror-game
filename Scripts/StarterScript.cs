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


    }


    void Update()
    {
        if (myNumber == 4 && myChoice == true)
        {
            myName = "Kusal";
            myGate.SetActive(true);
        }
        else
        {
            myName = "Not Kusal";
            myGate.SetActive(false);
        }
    }
}
