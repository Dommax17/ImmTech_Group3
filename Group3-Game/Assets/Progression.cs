using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Progression : MonoBehaviour
{
    [Header("Current State")]
    [SerializeField] int currentState = 0;
    [SerializeField] bool update = false;
    [Header("Clock")]
    [SerializeField] AudioSource ringing;
    [Header("Door")]
    [SerializeField] AudioSource doorKnocking;
    [SerializeField] AudioSource doorDialogue;
    [SerializeField] GameObject light;
    [Header("Safe")]
    [SerializeField] Safe safeObject;
    [SerializeField] bool safeOpen;
    [Header("Choice")]
    [SerializeField] GameObject choiceVisual;
    [SerializeField] Choices choiceObject;
    [SerializeField] bool choice1;
    [SerializeField] bool choice2;

    public void Start()
    {
        ringing.Play();
        safeObject.DisableButtons();
    }

    public void Update()
    {
        safeOpen = safeObject.isOpen;
        if (update)
        {
            if (currentState == 0)
            {
                ClockProgress();
                update = false;
            }
            else if (currentState == 1)
            {
                DoorProgress();
                update = false;
            }
            else if(currentState == 2)
            {
                SafeProgress();
                update = false;
            }
            else if(currentState == 3)
            {
                ChoiceProgress();
                update = false;
            }
        }
    }

    //Stop ringing and knock on door.
    public void ClockProgress()
    {
        if (currentState == 0)
        {
            ringing.Stop();
            doorKnocking.Play();
            currentState = 1;
        }
    }

    //Stop Knocking and play dialogue.
    public void DoorProgress()
    {
        if (currentState == 1)
        {
            doorKnocking.Stop();
            light.SetActive(false);
            StartCoroutine(waitTime(2f));
            doorDialogue.Play();
            safeObject.EnableButtons();
            currentState = 2;
        }
    }

    //If safe is open show choices
    //Need to add dialogue here.
    public void SafeProgress()
    {
        if(currentState == 2)
        { 
            choiceVisual.SetActive(true);
            currentState = 3;
        }
    }

    //Trigger if a choice has been made.
    public void ChoiceProgress()
    {
        if (choice1 && currentState == 3)
        {
            choiceObject.choice1 = true;
            currentState = 4;
        }
        else if(choice2 && currentState == 3)
        {
            choiceObject.choice2 = true;
            currentState = 4;
        }
    }

    public void MakeChoice(int choice)
    {
        if (choice == 1)
        {
            choice1 = true;
        }
        else if (choice == 2)
        {
            choice2 = true;
        }
    }

    IEnumerator waitTime(float timer)
    {
        yield return new WaitForSeconds(timer);
    }
}
