using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
	public class GameManager : MonoBehaviour {
		public static GameManager Singleton { get; private set; }
		//Задержка запуска анимации спавн нот
		public float offset = 0f;
		public TrackPlayer track;
		public Text textHPPerson, textHPBoss;
		public int hpPerson = 100, hpBoss = 100;
		public int numberAttacks, currentNumberAttacks;
		
		private void Start() {
			InitSingleton();
		}

		void Update()
		{
			textHPBoss.text = hpBoss.ToString();
			textHPPerson.text = hpPerson.ToString();
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