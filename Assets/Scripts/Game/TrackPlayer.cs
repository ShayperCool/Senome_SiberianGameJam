using System;
using System.Collections;
using UnityEngine;

namespace Game {
	public class TrackPlayer : MonoBehaviour {
		private Animation _animation;
		
		private void Start() {
			_animation = GetComponent<Animation>();
		}

		public void PlayTrack(AnimationClip clip, float offset = 0f) {
			_animation.AddClip(clip, clip.name);
			_animation.clip = clip;
			StartCoroutine(RunWithOffset(offset));
		}

		private IEnumerator RunWithOffset(float offset) {
			yield return new WaitForSeconds(offset);
			_animation.Play();
		}
		
	}
}