using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choices : MonoBehaviour
{
    [Header("Red")]
    [SerializeField] GameObject redBook;
    [SerializeField] GameObject redCanvas;
    [SerializeField] GameObject redLight;
    [SerializeField] BookFloat redFlying;
    [SerializeField] Rigidbody redRigidbody;
    [SerializeField] bool choice1 = false;

    [Header("Green")]
    [SerializeField] GameObject greenBook;
    [SerializeField] GameObject greenCanvas;
    [SerializeField] GameObject greenLight;
    [SerializeField] BookFloat greenFlying;
    [SerializeField] Rigidbody greenRigidbody;
    [SerializeField] bool choice2 = false;

    [Header("Ending")]
    [SerializeField] FadeScreen fader;

    // Update is called once per frame
    void Update()
    {
        if(choice1 || choice2)
        {
            RemoveFloat();
        }
    }

    public void RemoveFloat()
    {
        if(choice1)
        {
            greenBook.SetActive(false);
            redCanvas.SetActive(false);
            redLight.SetActive(false);
            greenLight.SetActive(false);
            redFlying.enabled = false;
            redRigidbody.freezeRotation = false;
        }
        else if(choice2)
        {
            redBook.SetActive(false);
            greenCanvas.SetActive(false);
            greenLight.SetActive(false);
            redLight.SetActive(false);
            greenFlying.enabled = false;
            greenRigidbody.freezeRotation = false;
        }
        choice1 = false;
        choice2 = false;
        Ending();
    }

    public void Ending()
    {
        StartCoroutine(GoToSceneRoutine(0));
    }

    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fader.FadeOut();
        yield return new WaitForSeconds(fader.fadeDuration);

        SceneManager.LoadScene(sceneIndex);
    }
}
