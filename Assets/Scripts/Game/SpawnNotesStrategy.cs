using Game.Models;
using UnityEngine;

namespace Game {
	public class SpawnNotesStrategy : NoteStrategy {

		//Линии для спавна
		public Transform firstLine;
		public Transform secondLine;
		public Transform thirdLine;
		public Transform fourthLine;
		public Transform fifthLine;
		public Transform sixthLine;


		protected override void OnRedNote() {
			
		}

		protected override void OnBlueNote() {
		}
	}
}