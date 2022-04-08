using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Audio;

public class PaintingManager : MonoBehaviour
{
    [Header("Code")]
    [SerializeField] GameObject code;
    [Header("Paintings")]
    [SerializeField] GameObject painting1;
    [SerializeField] GameObject painting2;
    [SerializeField] GameObject painting4;
    [Header("Sockets (Contents)")]
    [SerializeField] GameObject socket1;
    [SerializeField] GameObject socket2;
    [SerializeField] GameObject socket4;
    [Header("ToDisable")]
    [SerializeField] GameObject painting3;
    [SerializeField] GameObject vSocket1;
    [SerializeField] GameObject vSocket2;
    [SerializeField] GameObject vSocket3;
    [SerializeField] GameObject vSocket4;

    [SerializeField] bool done = false;

    [Header("Monologue")]
    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource monologue;

    public void Start()
    {
        code.SetActive(false);
    }

    public void Update()
    {
        CheckSockets();
    }

    public void UpdateSocket(int socket, GameObject item)
    {
        if (socket == 1)
        {
            socket1 = item;
        }
        else if (socket == 2)
        {
            socket2 = item;
        }
        else if (socket == 4)
        {
            socket4 = item;
        }
    }

    public void CheckSockets()
    {
        if (socket1 == painting1 && socket2 == painting2 && socket4 == painting4)
        {
            if (!done)
            {
                //what happens once all are placed?
                //show piece of code under clock
                code.SetActive(true);
                //play audio queue for completion
                code.GetComponent<AudioSource>().Play();
                monologue.clip = clip;
                monologue.Play();
                //disable grab on paintings
                vSocket1.SetActive(false);
                painting1.SetActive(false);
                vSocket2.SetActive(false);
                painting2.SetActive(false);
                vSocket3.SetActive(false);
                painting3.SetActive(false);
                vSocket4.SetActive(false);
                painting4.SetActive(false);
                done = true;
            }
        }
    }
}