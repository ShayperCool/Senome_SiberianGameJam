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
                    GameManager.Singleton.imageMaxCombo.SetActive(false);
                    GameManager.Singleton.hpBoss -= GameManager.Singleton.damageBoss; 
                    GameManager.Singleton.currentNumberAttacks = 0;
                }
                
            }
            _isDestroyed = false;
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
            GameManager.Singleton.currentNumberMiss++;
            if (GameManager.Singleton.currentNumberMiss >= GameManager.Singleton.numberMiss)
            {
                GameManager.Singleton.imageMaxComboBoss.SetActive(false);
                GameManager.Singleton.imageMaxCombo.SetActive(false);
                GameManager.Singleton.currentNumberAttacks = 0;
                GameManager.Singleton.currentNumberMiss = 0;
                GameManager.Singleton.hpPerson -= GameManager.Singleton.damagePerson;
            }
        }
        Destroy(collision.gameObject);
    }


}
