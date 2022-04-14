using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loder : MonoBehaviour
{

    public void loadLevel(int sceneIndex)
    {
        StartCoroutine(Loadscene(sceneIndex));
    }

    IEnumerator Loadscene(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while(!operation.isDone)
        {
            //float progress = <athf.cl
            yield return null;
        }
    }
}
