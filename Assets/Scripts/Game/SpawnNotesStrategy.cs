using Game.Models;
using UnityEngine;

namespace Game {
	public class SpawnNotesStrategy : NoteStrategy {

		//Линии для спавна
		public Transform[] linesToSpawn; 


		protected override void OnRedNote(Note note) {
			
		}

		protected override void OnBlueNote(Note note) {
		}
	}
}