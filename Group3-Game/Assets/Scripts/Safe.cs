using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Safe : MonoBehaviour
{
    [Header("Code")]
    [SerializeField] int[] inputs;
    [SerializeField] int[] passcode;
    [SerializeField] int current;

    [Header("Safe Parts")]
    [SerializeField] Button[] buttons;

    [Header("Opening Safe")]
    [SerializeField] Animator anim;
    [SerializeField] AudioSource openSound;
    [SerializeField] AudioSource buttonSound;
    [SerializeField] GameObject book;
    [SerializeField] Progression progress;
    [SerializeField] GameObject lightEmit;
    public bool floaty = true;
    public bool isOpen;


    public void Start()
    {
        current = 0;
        passcode[0] = 3;
        passcode[1] = 7;
        passcode[2] = 2;
        book.GetComponent<XRGrabInteractable>().enabled = false;
    }

    public void EnterCode(int input)
    {
        buttonSound.Play();
        inputs[current] = input;
        if(current < 2)
        {
            current++;
        }
        else if(current == 2)
        {
            CheckCode();
        }
    }

    public void CheckCode()
    {
        //check if inputs == passcode
        if(inputs[0] == passcode[0] && inputs[1] == passcode[1] && inputs[2] == passcode[2])
        {
            //disable buttons
            DisableButtons();
            //spawn book then open safe & play sound
            lightEmit.SetActive(false);
            book.GetComponent<XRGrabInteractable>().enabled = true;
            openSound.Play();
            anim.SetBool("isOpen", true);
            isOpen = true;
            progress.SafeProgress();
        }
        else
        {
            current = 0;
        }
    }

    public void DisableFloat()
    {
        if (floaty)
        {
            book.GetComponent<BookFloat>().enabled = false;
        }
    }

    public void DisableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = false;
        }
    }

    public void EnableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = true;
        }
    }
}
