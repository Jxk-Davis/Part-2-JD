using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SceneCTRL : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void LoadPrevScene() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int prevSceneIndex = (currentSceneIndex - 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(prevSceneIndex);
    }
}
//put this on object