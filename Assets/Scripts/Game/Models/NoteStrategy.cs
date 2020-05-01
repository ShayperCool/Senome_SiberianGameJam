using System;
using UnityEngine;

namespace Game.Models {
	public abstract class NoteStrategy : MonoBehaviour {
		private void Start() {
			EventsDelegator.Singleton.target = ProcessNote;
		}

		private void ProcessNote(Note note) {
			if(note.name == "red")
				OnRedNote();
			else if(note.name == "blue")
				OnBlueNote();
		}

		protected abstract void OnRedNote();
		protected abstract void OnBlueNote();

	}
}