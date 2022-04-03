using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] AudioSource source;


    public void Start()
    {
        current = 0;
        passcode[0] = 3;
        passcode[1] = 7;
        passcode[2] = 2;
    }

    public void EnterCode(int input)
    {
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
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i].enabled = false;
            }
            //open safe & play sound
            //source.Play();
            anim.SetBool("isOpen", true);

        }
        else
        {
            current = 0;
        }
    }
}
