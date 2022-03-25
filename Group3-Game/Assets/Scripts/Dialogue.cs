using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[RequireComponent(typeof(AudioSource))]
public class Dialogue : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioMixerGroup mixer;
    [SerializeField] AudioClip[] audioClips;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixer;
        StartCoroutine(playDialogue());
    }

    IEnumerator playDialogue()
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            audioSource.clip = audioClips[i];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }
    }
}
