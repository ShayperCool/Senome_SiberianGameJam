using SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    

    private int _a=0;
    public void OpenScene(int idScene)
    {
        SceneManager.LoadScene(idScene);
    }

    public void StartGame(string nameScene)
    {
        BlinkSceneLoader.Singleton.LoadScene(nameScene);
    }

    public void RestsartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
