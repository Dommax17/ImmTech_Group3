using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaintingManager : MonoBehaviour
{
    [Header("Paintings")]
    [SerializeField] GameObject painting1;
    [SerializeField] GameObject painting2;
    [SerializeField] GameObject painting4;
    [Header("Sockets (Contents)")]
    [SerializeField] GameObject socket1;
    [SerializeField] GameObject socket2;
    [SerializeField] GameObject socket4;

    public void Update()
    {
        CheckSockets();
    }

    public void UpdateSocket(int socket, GameObject item)
    {
        if(socket == 1)
        {
            socket1 = item;
        }
        else if(socket == 2)
        {
            socket2 = item;
        }
        else if(socket == 4)
        {
            socket4 = item;
        }
    }

    public void CheckSockets()
    {
        if (socket1 == painting1 && socket2 == painting2 && socket4 == painting4)
        {
            //what happens once all are placed?
            socket1.SetActive(false);
            socket2.SetActive(false);
            socket4.SetActive(false);
        }
    }
}