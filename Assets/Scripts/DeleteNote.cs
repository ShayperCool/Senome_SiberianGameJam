using Game;
using Game.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteNote : MonoBehaviour
{
    public KeyCode keyToDelete = KeyCode.Q;
    
    private Collider2D _collider;
    private bool _isDestroyed;

    void Update()
    {
        if (Input.GetKeyDown(keyToDelete))
        {
            if (_collider!=null)
            {
                GameManager.Singleton.currentNumberAttacks++;
                _isDestroyed = true; 
                Destroy(_collider.gameObject);

                if (GameManager.Singleton.currentNumberAttacks>=GameManager.Singleton.numberAttacks)
                { 
                    GameManager.Singleton.hpBoss -= 5; 
                    GameManager.Singleton.currentNumberAttacks = 0;
                }
                
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!_isDestroyed)
        {
            GameManager.Singleton.currentNumberAttacks = 0;
            GameManager.Singleton.hpPerson -= 5;
        }
        Destroy(collision.gameObject);
    }


}
