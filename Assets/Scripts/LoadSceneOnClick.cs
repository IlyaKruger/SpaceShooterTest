using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public int level;
    public void LoadByIndex(int sceneIndex)
    {
        LevelData.targetLevel = level;
        SceneManager.LoadScene(sceneIndex);
    }
}
