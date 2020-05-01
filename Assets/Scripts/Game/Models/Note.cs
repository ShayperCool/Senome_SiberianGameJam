using UnityEngine;

namespace Game.Models {
	[CreateAssetMenu(fileName = "New Note", menuName = "Create Note", order = 0)]
	public class Note : ScriptableObject {
		public int pointsCount = 0;
		public Sprite sprite;
		public float duration;
	}
}