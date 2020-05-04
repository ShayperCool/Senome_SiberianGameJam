using UnityEngine;

namespace Game {
	public class DestroyOnEnd : MonoBehaviour {
		public void End() {
			Destroy(gameObject);
		}
	}
}