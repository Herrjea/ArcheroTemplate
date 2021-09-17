using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    public void LoadScene(string otherScene)
    {
        GameFlowEvents.LoadScene.Invoke(otherScene);
    }

    public void LoadGame()
    {
        GameFlowEvents.LoadScene.Invoke("MainGame");

        GameEvents.EnterGame.Invoke();
    }

    public void LoadMenu()
    {
        GameFlowEvents.LoadScene.Invoke("MainMenu");

        GameEvents.EnterMenu.Invoke();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
