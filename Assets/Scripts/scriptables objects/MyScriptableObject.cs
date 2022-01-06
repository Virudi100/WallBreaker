using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create MyScriptableObject")]

public class MyScriptableObject : ScriptableObject
{
    public int score = 0;
    public string playerName = "NoName";
    public int index = 0;
    public int pBest = 0;

    public string[] sceneList;
    
}
