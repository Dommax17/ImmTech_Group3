using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Awaken : MonoBehaviour
{
    [SerializeField] CanvasGroup blackout;
    [SerializeField] bool hidden = false;
    [SerializeField] float alpha = 1;

    public void Start()
    {
        hidden = true;
    }

    public void FixedUpdate()
    {
        if(hidden)
        {
                blackout.alpha -= 0.005f;
        }
        else if(!hidden)
        {
                    blackout.alpha += 0.005f;
        }

    }
}
