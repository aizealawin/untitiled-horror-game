using UnityEngine;

public class StarterScript : MonoBehaviour
{
    [SerializeField] int myNumber;
    [SerializeField] string myName;
    [SerializeField] bool myChoice;

    int myOtherNumber;

    [SerializeField] GameObject myGate;
    [SerializeField] GameObject name1;
    [SerializeField] GameObject name2;


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
            name1.GetComponent<TMPro.TMP_Text>().text = $"My Number: {myNumber} My Name: {myName}";
            name2.GetComponent<TMPro.TMP_Text>().text = $"____________";

        }
        else
        {
            myName = "Not Kusal";
            myGate.SetActive(false);
            name2.GetComponent<TMPro.TMP_Text>().text = $"{myName} is active.";
            name1.GetComponent<TMPro.TMP_Text>().text = "I am stinky";
        }
    }
}
