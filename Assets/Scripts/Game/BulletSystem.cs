using System;
using UnityEngine;

namespace Game {
	public class BulletSystem : MonoBehaviour {
		
		public static BulletSystem Singleton { get; set; }
		
		public GameObject playerBullet;
		public GameObject enemyBullet;
		public Transform enemy;
		public Transform player;


		private void Start() {
			InitSingleton();
		}

		private void InitSingleton() {
			if (Singleton)
				Destroy(gameObject);
			else
				Singleton = this;
		}

		public void PlayerAttack() {
			var b = Instantiate(playerBullet, Vector3.zero, Quaternion.identity);
		}

		public void EnemyAttack() {
			var b = Instantiate(enemyBullet, Vector3.zero, Quaternion.identity);
		}
		
	}
}