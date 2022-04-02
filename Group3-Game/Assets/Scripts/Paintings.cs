using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Paintings : MonoBehaviour
{
    [SerializeField] int painting;
    [SerializeField] XRSocketInteractor socket;
    [SerializeField] PaintingManager pm;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    public void Update()
    {

        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();

        pm.UpdateSocket(painting, objName.transform.gameObject);
    }
}


