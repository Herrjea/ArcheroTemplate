using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameFinishedManager : MonoBehaviour
{
    [SerializeField] GameObject gameFinishedPanel;
    [SerializeField] TMP_Text result;
    [SerializeField] TMP_Text reached;
    [SerializeField] TMP_Text coins;


    void Start()
    {
        GameEvents.AllWaveFinished.AddListener(AllWaveFinished);
        GameEvents.PlayerDied.AddListener(PlayerDied);

        gameFinishedPanel.SetActive(false);
    }

    private void PlayerDied()
    {
        //SceneManager.LoadScene("GameFinished");
        result.text = "Defeated D=";
        reached.text = "Highest wave: " + 0;
        coins.text = "Coins gathered: " + 0;

        gameFinishedPanel.SetActive(true);
    }

    private void AllWaveFinished()
    {
        //SceneManager.LoadScene("GameFinished");
        result.text = "Success!";
        reached.text = "All waves defeated";
        coins.text = "Coins gathered: " + 0;

        gameFinishedPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        GameEvents.PlayerDied.RemoveListener(PlayerDied);
        GameEvents.AllWaveFinished.RemoveListener(AllWaveFinished);
    }
}
