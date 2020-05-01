using Game.Models;
using UnityEngine;

namespace Game {
	public class SpawnNotesStrategy : MonoBehaviour {
		
		
		public Transform[] linesToSpawn; 

		private void Start() {
			EventsDelegator.Singleton.target = ProcessNote;
		}

		private void ProcessNote(Note note) {
		}
	}
}