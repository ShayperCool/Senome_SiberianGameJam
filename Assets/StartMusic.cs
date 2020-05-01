using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    public AudioSource audio;
    public float tools;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            StartCoroutine(toolsMusic());
        }
    }

    IEnumerator toolsMusic()
    {
        yield return new WaitForSeconds(tools);
        audio.Play();
    }
}
