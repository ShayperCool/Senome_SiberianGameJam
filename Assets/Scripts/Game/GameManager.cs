﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
	public class GameManager : MonoBehaviour {
		public static GameManager Singleton { get; private set; }
		//Задержка запуска анимации спавн нот
		public float offset = 0f;
		public TrackPlayer track;
		public Slider HPPerson, HPBoss, ComboSlider, ComboSliderBoss;
		public int hpPerson = 100, hpBoss = 100;
		public int damagePerson, damageBoss;
		public int numberAttacks, currentNumberAttacks, numberMiss, currentNumberMiss;
		public GameObject imageMaxCombo, imageMaxComboBoss;

		public bool isPlayingVideo = true;
		//последовательность дорожек
		//public int[] sequenceTrackNote;
		//public int currentSequenceTrackNote=0;


		private void Start() {
			ComboSlider.maxValue = numberAttacks;
			ComboSliderBoss.maxValue = numberMiss;
			imageMaxCombo.SetActive(false);
			imageMaxComboBoss.SetActive(false);
			InitSingleton();
		}

		void Update()
		{
			HPBoss.value = hpBoss;
			HPPerson.value = hpPerson;
			ComboSlider.value = currentNumberAttacks;
			ComboSliderBoss.value = currentNumberMiss;
			if (currentNumberAttacks == numberAttacks-1) imageMaxCombo.SetActive(true);
			if (currentNumberMiss == numberMiss-1) imageMaxComboBoss.SetActive(true);
		}

		private void InitSingleton() {
			Singleton = this;
		}

		public void StartBattle(AnimationClip clip) {
			track.PlayTrack(clip, offset);
		}
		
		public void IncreaseCurrentTrack()
		{
			//currentSequenceTrackNote++;
		}

	}
}