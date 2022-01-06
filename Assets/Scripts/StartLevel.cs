using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    public MyScriptableObject datas;

    public void begin()
    {
        datas.index = 0;
        datas.score = 0;
        SceneManager.LoadScene(datas.sceneList[datas.index]);
    }

}
