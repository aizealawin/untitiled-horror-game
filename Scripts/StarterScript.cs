using System.Collections;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

public class StarterScript : MonoBehaviour
{
    [SerializeField] int myNumber;
    [SerializeField] string myName;
    [SerializeField] bool myChoice;

    int myOtherNumber;

    [SerializeField] GameObject myGate;
    [SerializeField] GameObject name1;
    [SerializeField] GameObject name2;
    [SerializeField] GameObject firstButton;


    [SerializeField] GameObject fadeIn;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject hiddenSphere;

    [SerializeField] AudioSource ding;

    void Start()
    {
        myNumber = 4;
        StartCoroutine(MySequence());


    }


    void Update()
    {
        if (myNumber == 4 && myChoice == true)
        {
            myName = "Kusal";
            // myGate.SetActive(true);
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

    public void OpenGate()
    {
        myGate.GetComponent<Animator>().Play("GateSwing", -1, 0f);
    }

    public void ChangeButtonState()
    {
        if (firstButton.activeSelf == true)
        {
            firstButton.SetActive(false);
        }
        else firstButton.SetActive(true);
    }

    public void PlayDing()
    {
        ding.Play();
    }

    IEnumerator MySequence()
    {
        yield return new WaitForSeconds(0.5f);
        fadeIn.SetActive(false);
        myGate.GetComponent<Animator>().Play("GateSwing");
        yield return new WaitForSeconds(4);
        firstButton.SetActive(false);
        yield return new WaitForSeconds(2);
        hiddenSphere.SetActive(true);
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);

    }
}
