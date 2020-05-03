using System;
using System.Collections;
using UnityEngine;

namespace Game {
	public class TrackPlayer : MonoBehaviour {

		private Animation _animation;
		public GameObject panelOver, panelWin;
		public float gameLength;

		private bool _isWin, _isOver;

		private void Start() {
			_animation = GetComponent<Animation>();
			panelOver.SetActive(false);
			panelWin.SetActive(false);
		}

		private void Update()
		{
			if (GameManager.Singleton.hpPerson <= 0 && !_isWin)
			{
				_animation.Stop();
				panelOver.SetActive(true);
				_isOver = true;
			}
			if (GameManager.Singleton.hpBoss <= 0 && !_isOver)
			{
				_isWin = true;
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
			if (GameManager.Singleton.hpPerson <= GameManager.Singleton.hpBoss && !_isWin)
			{
				_animation.Stop();
				panelOver.SetActive(true);
				_isOver=true;
			}
			if (GameManager.Singleton.hpPerson > GameManager.Singleton.hpBoss && !_isOver)
			{
				_animation.Stop();
				panelWin.SetActive(true);
				_isWin = true;
			}
		}

	}
}