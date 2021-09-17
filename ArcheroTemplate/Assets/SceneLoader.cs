using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    public void LoadGame(string otherScene)
    {   
        GameFlowEvents.LoadScene.Invoke(otherScene);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
