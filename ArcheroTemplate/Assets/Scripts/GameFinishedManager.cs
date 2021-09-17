using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameFinishedManager : MonoBehaviour
{
    [SerializeField] GameObject gameFinishedPanel;
    [SerializeField] TMP_Text result;
    [SerializeField] TMP_Text wave;
    [SerializeField] TMP_Text coins;

    [SerializeField] ReachedInRun reached;


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
        wave.text = "Highest wave: " + (reached.wave + 1) + "." + (reached.subwave + 1);
        reached.coins /= 2;
        coins.text = "Coins gathered: " + reached.coins;
        print(reached.coins + " coins");

        EconomyDataController.SetSoftCoins(EconomyDataController.GetSoftCoins() + reached.coins);

        gameFinishedPanel.SetActive(true);
    }

    private void AllWaveFinished()
    {
        //SceneManager.LoadScene("GameFinished");
        result.text = "Success!";
        wave.text = "All waves defeated";
        coins.text = "Coins gathered: " + reached.coins;

        EconomyDataController.SetSoftCoins(EconomyDataController.GetSoftCoins() + reached.coins);

        gameFinishedPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        GameEvents.PlayerDied.RemoveListener(PlayerDied);
        GameEvents.AllWaveFinished.RemoveListener(AllWaveFinished);
    }
}
