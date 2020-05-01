using System;
using UnityEngine;

namespace Game.Models {
	public abstract class NoteStrategy : MonoBehaviour {
		private void Start() {
			EventsDelegator.Singleton.target = ProcessNote;
		}

		private void ProcessNote(Note note) {
			if(note.name == "red")
				OnRedNote(note);
			else if(note.name == "blue")
				OnBlueNote(note);
		}

		protected abstract void OnRedNote(Note note);
		protected abstract void OnBlueNote(Note note);

	}
}