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
        socket = gameObject.GetComponent<XRSocketInteractor>();
        socket.onSelectEntered.AddListener(UpdateInventory);
    }

    public void UpdateInventory(XRBaseInteractable obj)
    {

        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();

        pm.UpdateSocket(painting, objName.transform.gameObject);
    }
}


