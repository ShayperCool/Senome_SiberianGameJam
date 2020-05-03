using System;
using System.Collections;
using UnityEngine;

namespace Game {
	public class TrackPlayer : MonoBehaviour {

		private Animation _animation;
		public GameObject panelOver, panelWin;
		public float gameLength;

		private void Start() {
			_animation = GetComponent<Animation>();
			panelOver.SetActive(false);
			panelWin.SetActive(false);
		}

		private void Update()
		{
			if (GameManager.Singleton.hpPerson <= 0)
			{
				_animation.Stop();
				panelOver.SetActive(true);
			}
			if (GameManager.Singleton.hpBoss <= 0)
			{
				panelWin.SetActive(true);
				_animation.Stop();
			}
		}

		public void PlayTrack(AnimationClip clip, float offset = 0f) {
			_animation.AddClip(clip, clip.name);
			_animation.clip = clip;
			StartCoroutine(RunWithOffset(offset));
			StartCoroutine(stopGame());
		}

		private IEnumerator RunWithOffset(float offset) {
			yield return new WaitForSeconds(offset);
			_animation.Play();
		}

		IEnumerator stopGame()
		{
			yield return new WaitForSeconds(gameLength);
			if (GameManager.Singleton.hpPerson <= GameManager.Singleton.hpBoss)
			{
				_animation.Stop();
				panelOver.SetActive(true);
			}
			if (GameManager.Singleton.hpPerson > GameManager.Singleton.hpBoss)
			{
				_animation.Stop();
				panelWin.SetActive(true);
			}
		}

	}
}