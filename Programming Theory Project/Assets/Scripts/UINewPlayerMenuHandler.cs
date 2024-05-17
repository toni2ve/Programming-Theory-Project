using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UINewPlayerMenuHandler : MonoBehaviour
{
    public TMP_InputField playerNameInputTxt;
    public void StartGame()
    {
        if (GameManager.Instance != null)
        {
            if (playerNameInputTxt != null && playerNameInputTxt.text != "")
                GameManager.Instance.StartNewGame(playerNameInputTxt.text);
        }
    }

    public void BackToTitle()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.BackToTitle();
        }
    }
}
