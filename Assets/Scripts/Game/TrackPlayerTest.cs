using System;
using UnityEngine;

namespace Game {
	public class TrackPlayerTest : MonoBehaviour {

		public static TrackPlayerTest Singleton { get; private set; }
		
		
		public AnimationClip clip;
		public TrackPlayer player;
		public GameObject panelStart;

		private bool _isPlayeng = true;

		private void Start()
		{
			panelStart.SetActive(true);
		}
		private void Update() {
			if (Input.GetKeyDown(KeyCode.Space) && _isPlayeng)
			{
				panelStart.SetActive(false);
				player.PlayTrack(clip);

			}
		}

	}
}