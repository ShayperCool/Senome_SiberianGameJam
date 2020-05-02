using Game.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
	public class SpawnNotesStrategy : MonoBehaviour {

		public GameObject canvas;
		public GameObject[] lines;
		public GameObject notePrefab;
		public Sprite[] spritesNote;

		private void Start() {
			EventsDelegator.Singleton.target = ProcessNote;
			notePrefab.GetComponent<Image>().sprite = spritesNote[0];
		}

		private void ProcessNote(Note note) {
			if (note.name == "Empty") return;
			//int idLine = Random.Range(0, lines.Length);
			int idTrack = GameManager.Singleton.currentSequenceTrackNote;
			int idLine = GameManager.Singleton.sequenceTrackNote[idTrack];
			GameManager.Singleton.IncreaseCurrentTrack();
			GameObject _note = Instantiate(notePrefab, notePrefab.transform.position = new Vector2(lines[idLine-1].transform.localPosition.x, 330f), Quaternion.identity) as GameObject;
			_note.transform.SetParent(gameObject.transform, false);
		}
	}
}