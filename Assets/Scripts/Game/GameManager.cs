using System;
using UnityEngine;

namespace Game {
	public class GameManager : MonoBehaviour {
		public static GameManager Singleton { get; private set; }
		//Задержка запуска анимации спавн нот
		public float offset = 0f;
		public TrackPlayer track;
		
		
		private void Start() {
			InitSingleton();
		}

		private void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}

		public void StartBattle(AnimationClip clip) {
			track.PlayTrack(clip, offset);
		}
		
	}
}