using System;
using System.Collections;
//using Ui.Menu;
//using Ui.Menu.MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneManagement {
	public class BlinkSceneLoader : MonoBehaviour {
		public static BlinkSceneLoader Singleton { get; private set; }
		public float blinkTime = 0.5f;

		public Image blinkImage;

		private float _timer;
		private float _sign = 1f;

		private void Start() {
			_timer = blinkTime;
			InitSingleton();
			DontDestroyOnLoad(gameObject);
			SceneManager.sceneLoaded += (Scene, Mode) => { _sign = -1f; };
		}

		private void InitSingleton() {
			if (Singleton) {
				Destroy(gameObject);
				return;
			}
			Singleton = this;
		}

		private void Update() {
			if (_timer >= blinkTime && _sign == 1f || _timer < 0f && _sign == -1f)
				return;

			_timer += Time.deltaTime / blinkTime * _sign;
			Color color = blinkImage.color;
			color.a = _timer / blinkTime;
			blinkImage.color = color;
		}

		public void LoadScene(string name) {
			StartCoroutine(LoadSceneCoroutine(name));
			_timer = 0f;
			_sign = 1f;
		}

		private IEnumerator LoadSceneCoroutine(string name) {
			yield return new WaitForSeconds(blinkTime);
			// if (name == "Game")
			// 	MainMenuController.Singleton.SaveAnimator();
			SceneManager.LoadScene(name);
		}
	}
}