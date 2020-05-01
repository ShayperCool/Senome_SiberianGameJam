using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteNote : MonoBehaviour
{
    public KeyCode keyToDelete = KeyCode.Q;
    private Collider2D _collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToDelete))
        {
            if (_collider!=null)
            {
                Destroy(_collider.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "notes")
        {
            _collider = collision;
        }
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "notes" && Input.GetKeyDown(KeyCode.Q))
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}
    

}
