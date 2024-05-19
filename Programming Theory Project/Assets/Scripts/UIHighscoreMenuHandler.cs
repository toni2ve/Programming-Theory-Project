using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHighscoreMenuHandler : MonoBehaviour
{
    public TMP_Text playerNameLabel;
    public TMP_Text playerNameHighscoreLbl;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            playerNameLabel.SetText(GameManager.Instance.latestHighScorePlayerData.PlayerName);
            playerNameHighscoreLbl.SetText("" + GameManager.Instance.latestHighScorePlayerData.Highscore);
        }
    }

    public void BackToMenu()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.BackToTitle();
        }
    }
}
