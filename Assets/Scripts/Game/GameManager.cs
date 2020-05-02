using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
	public class GameManager : MonoBehaviour {
		public static GameManager Singleton { get; private set; }
		//Задержка запуска анимации спавн нот
		public float offset = 0f;
		public TrackPlayer track;
		public Slider HPPerson, HPBoss;
		public int hpPerson = 100, hpBoss = 100;
		public int numberAttacks, currentNumberAttacks;
		//последовательность дорожек
		public int[] sequenceTrackNote;
		public int currentSequenceTrackNote=0;


		private void Start() {
			InitSingleton();
		}

		void Update()
		{
			HPBoss.value = hpBoss;
			HPPerson.value = hpPerson;
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
		
		public void IncreaseCurrentTrack()
		{
			currentSequenceTrackNote++;
		}

	}
}