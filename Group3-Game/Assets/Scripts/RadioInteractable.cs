using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RadioInteractable : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] AudioSource switchSource;
    [SerializeField] bool isOn = true;
    [SerializeField] bool updateButton = false;

    [Header("Music Management")]
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip normalClip;
    [SerializeField] AudioClip reverseClip;
    [SerializeField] bool reverse = false;
    [SerializeField] bool updateMusic = false;

    public void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(updateButton)
        {
            updateState();
        }

        if(updateMusic)
        {
            UpdateMusic();
        }
    }

    public void updateState()
    {
        if (isOn)
        {
            switchSource.Play();
            source.volume = 0;
        }
        else if (!isOn)
        {
            switchSource.Play();
            source.volume = 0.2f;
        }
        isOn = !isOn;
        updateButton = false;
    }

    public void UpdateMusic()
    {
        if (!reverse)
        {
            source.volume = 0;
            source.clip = reverseClip;
            source.Play();
            source.volume = 0.2f;
        }
        else if(reverse)
        {
            source.volume = 0;
            source.clip = normalClip;
            source.Play();
            source.volume = 0.2f;
        }
        reverse = !reverse;
        updateMusic = false;
    }

}
