using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] bool fadeOnStart = true;
    public float fadeDuration = 3;
    [SerializeField] Color fadeColour;
    [SerializeField] Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        if(fadeOnStart)
        {
            FadeIn();
        }
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }

    public void FadeOut()
    {
        Fade(0, 1);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while(timer < fadeDuration)
        {
            Color newColour = fadeColour;
            newColour.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            rend.material.SetColor("_Color", newColour);

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColour2 = fadeColour;
        newColour2.a = alphaOut;
        rend.material.SetColor("_Color", newColour2);
    }
}
