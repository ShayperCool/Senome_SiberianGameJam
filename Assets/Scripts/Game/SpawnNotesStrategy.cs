using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
	public class SpawnNotesStrategy : MonoBehaviour {

		public GameObject canvas;
		public GameObject[] lines;
		public GameObject notePrefab;
		public Sprite[] spritesNote;
		private List<int> _linesIds = new List<int>{0, 1, 2, 3, 4, 5};
		
		private void Start() {
			EventsDelegator.Singleton.target = ProcessNote;
			notePrefab.GetComponent<Image>().sprite = spritesNote[0];
		}

		private void ProcessNote(Note note) {
			if (note.name == "Empty") return;
			if (note.name == "Guitar") 
				notePrefab.GetComponent<Image>().sprite = spritesNote[0];
			if (note.name == "Piano") 
				notePrefab.GetComponent<Image>().sprite = spritesNote[2];
			if (note.name == "Drum") 
				notePrefab.GetComponent<Image>().sprite = spritesNote[1];
			int idLine = _linesIds[Random.Range(0, lines.Length)];
			_linesIds.Remove(idLine);
			FreeLine(idLine);
			//int idTrack = GameManager.Singleton.currentSequenceTrackNote;
			//int idLine = GameManager.Singleton.sequenceTrackNote[idTrack];
			GameManager.Singleton.IncreaseCurrentTrack();
			GameObject _note = Instantiate(notePrefab, notePrefab.transform.position = new Vector2(lines[idLine].transform.localPosition.x, 330f), Quaternion.identity) as GameObject;
			_note.transform.SetParent(canvas.transform, false);
		}
		
		private async void FreeLine(int index){
			await Task.Delay(100);
			_linesIds.Add(index);
		}
	}
}