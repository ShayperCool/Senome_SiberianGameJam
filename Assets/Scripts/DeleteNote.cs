using System;
using Game;
using Game.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteNote : MonoBehaviour {
	public static event Action attack;
	public static event Action damage;
	
	public KeyCode keyToDelete = KeyCode.Q;
	private List<Collider2D> _colliders = new List<Collider2D>();
	private Dictionary<Collider2D, bool> _collidersDictionary = new Dictionary<Collider2D, bool>();

	void Update() {
		if (Input.GetKeyDown(keyToDelete)) {
			if (_colliders.Count != 0) {
				var collider = _colliders[0];
				GameManager.Singleton.currentNumberAttacks++;
				attack?.Invoke();
				if (GameManager.Singleton.currentNumberAttacks >= GameManager.Singleton.numberAttacks) {
					GameManager.Singleton.imageMaxCombo.SetActive(false);
					GameManager.Singleton.hpBoss -= GameManager.Singleton.damageBoss;
					GameManager.Singleton.currentNumberAttacks = 0;
				}
				_collidersDictionary[collider] = true;
				Destroy(collider.gameObject);
				_colliders.RemoveAt(0);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "notes") {
			_colliders.Add(collision);
			_collidersDictionary.Add(collision, false);
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (_collidersDictionary[collision] == false) {
			GameManager.Singleton.currentNumberMiss++;
			if (GameManager.Singleton.currentNumberMiss >= GameManager.Singleton.numberMiss) {
				GameManager.Singleton.imageMaxComboBoss.SetActive(false);
				GameManager.Singleton.imageMaxCombo.SetActive(false);
				GameManager.Singleton.currentNumberAttacks = 0;
				GameManager.Singleton.currentNumberMiss = 0;
				GameManager.Singleton.hpPerson -= GameManager.Singleton.damagePerson;
				damage?.Invoke();
			}
			Destroy(collision.gameObject);
			_colliders.Remove(collision);
		}
		_collidersDictionary.Remove(collision);
	}
}