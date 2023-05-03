using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SceneChange(string name){
        SceneManager.LoadScene(name);

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void AddScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);

    }
}

