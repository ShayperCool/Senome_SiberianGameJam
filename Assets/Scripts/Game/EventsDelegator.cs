using System;
using Game.Models;
using UnityEngine;

namespace Game {
	public class EventsDelegator : MonoBehaviour {

		public static EventsDelegator Singleton { get; private set; }
		public Action<Note> target;
		
		private void Awake() {
			InitSingleton();
		}

		private void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}


		public void OnNote(Note note) {

			target?.Invoke(note);
		}
	}
}