using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    public AudioSource audio;
    public float tools;
    private bool _isStart = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isStart  && !GameManager.Singleton.isPlayingVideo)
        {
            _isStart = true;
            StartCoroutine(toolsMusic());

        }
    }

    IEnumerator toolsMusic()
    {
        yield return new WaitForSeconds(tools);
        audio.Play();
    }
}
