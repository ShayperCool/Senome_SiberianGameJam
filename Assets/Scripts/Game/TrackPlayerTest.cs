using System;
using UnityEngine;

namespace Game {
	public class TrackPlayerTest : MonoBehaviour {
		public AnimationClip clip;
		public TrackPlayer player;
		public GameObject panelStart;
		private bool _isStart;
		private void Start()
		{
			panelStart.SetActive(true);
		}
		private void Update() {
			if (Input.GetKeyDown(KeyCode.Space))
			{
				panelStart.SetActive(false);
				player.PlayTrack(clip);
			}				
		}
	}
}