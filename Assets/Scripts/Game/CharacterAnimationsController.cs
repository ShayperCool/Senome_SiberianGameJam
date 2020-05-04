using System.Collections;
using UnityEngine;

namespace Game {
	public class CharacterAnimationsController : MonoBehaviour {
		private static Animator _enemy;
		private static Animator _character;
		public float offset = 0.5f;
		private bool _isPlayer;

		public void Start() {
			_isPlayer = gameObject.CompareTag("Player");

			if (_isPlayer) {
				DeleteNote.CharacterAttack += Attack;
				_character = GetComponent<Animator>();
			}
			else {
				DeleteNote.EnemyAttack += Attack;
				_enemy = GetComponent<Animator>();
			}
		}


		public void Attack() {
			if (_isPlayer) {
				StartCoroutine(PlayHit(_enemy));
				_character.Play("attack");
				BulletSystem.Singleton.PlayerAttack();
			}
			else {
				_enemy.Play("attack");
				StartCoroutine(PlayHit(_character));
				BulletSystem.Singleton.EnemyAttack();
			}
		}

		private IEnumerator PlayHit(Animator animator) {
			yield return new WaitForSeconds(offset);
			animator.Play("hit");
		}
	}
}