using System;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

namespace Game {
	public class TrackPlayerSolo : MonoBehaviour {
		public AnimationClip clip;
		public TrackPlayer player;
		public AudioSource audio;
		public GameObject buttonNextLevel;
		public GameObject hero, heroAnimat;
		public float offset, offsetMusic, offsetVideo, offsetButton;
		public GameObject video;

		private void Start()
		{
			video.SetActive(false);
			buttonNextLevel.SetActive(false);
			StartCoroutine(StartSoloPlay(offset));
			StartCoroutine(OffsetMusic(offsetMusic));
			StartCoroutine(OffsetVideo(offsetVideo));			
			StartCoroutine(OffsetButton(offsetButton));
			hero.SetActive(true);
			heroAnimat.SetActive(false);
		}

		private void Update()
		{
			
		}

		private IEnumerator StartSoloPlay(float offsett)
		{
			yield return new WaitForSeconds(offsett);
			player.PlayTrack(clip);
		}
		
		private IEnumerator OffsetMusic(float offsett)
		{
			offsett += offset;
			yield return new WaitForSeconds(offsett);
			audio.Play();
			hero.SetActive(false);
			heroAnimat.SetActive(true);
		}

		private IEnumerator OffsetVideo(float offsett)
		{
			offsett += offsetMusic+offset;
			yield return new WaitForSeconds(offsett);
			video.SetActive(true);
			hero.SetActive(false);
			heroAnimat.SetActive(true);
		}

		private IEnumerator OffsetButton(float offsett)
		{
			offsett += offsetMusic + offset + offsetButton;
			yield return new WaitForSeconds(offsett);
			buttonNextLevel.SetActive(true);
		}
	}
}