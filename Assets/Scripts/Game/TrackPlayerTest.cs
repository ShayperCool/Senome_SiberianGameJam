using System;
using UnityEngine;

namespace Game {
	public class TrackPlayerTest : MonoBehaviour {
		public AnimationClip clip;
		public TrackPlayer player;

		private void Update() {
			if (Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				player.PlayTrack(clip);
			}				
		}
	}
}