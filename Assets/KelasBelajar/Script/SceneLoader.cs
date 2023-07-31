using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader sceneLoader;

    private void Awake()
    {
        sceneLoader = this;
    }
    public void SceneLoaders(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
