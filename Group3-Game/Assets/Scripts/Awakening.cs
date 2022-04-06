using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Awakening : MonoBehaviour
{
    [SerializeField] GameObject lightBlocker;
    [SerializeField] GameObject sun;
    [SerializeField] AudioSource lightningSFX;
    [SerializeField] RadioInteractable radio;
    [SerializeField] bool trigger = false;

    public void Update()
    {
        if(trigger)
        {
            Awaken();
        }
    }

    public void Start()
    {
        lightBlocker.SetActive(true);
        sun.SetActive(false);
    }

    public void Awaken()
    {
        lightBlocker.SetActive(false);
        sun.SetActive(true);
        lightningSFX.Play();
        radio.UpdateMusic();
        trigger = false;
    }
}
