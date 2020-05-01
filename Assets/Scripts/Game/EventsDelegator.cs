using System;
using Game.Models;
using UnityEngine;

namespace Game {
	public class EventsDelegator : MonoBehaviour {

		public Action<Note> target;

		public void OnNote(Note note) {
			target?.Invoke(note);
		}
	
	}
}