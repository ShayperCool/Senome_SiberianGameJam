using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public GameObject canvas;
    public GameObject[] lines;
    public GameObject note;
    public float Time;
    public bool Stop;

    public static bool isDelete;
    void Start()
    {
        StartCoroutine(Spawn());
        isDelete = false;
    }

    IEnumerator Spawn()
    {
        while (!Stop)
        {
            int idLine = Random.Range(0, lines.Length);
            GameObject _note = Instantiate(note, note.transform.position = new Vector2(lines[idLine].transform.localPosition.x, 350f), Quaternion.identity) as GameObject;
            _note.transform.SetParent(gameObject.transform, false);
            yield return new WaitForSeconds(Time);
        }
    }

}
