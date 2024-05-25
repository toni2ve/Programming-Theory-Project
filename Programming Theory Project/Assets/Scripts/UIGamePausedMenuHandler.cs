using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIGamePausedMenuHandler : MonoBehaviour
{
    public GameObject pausePanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameManager.Instance != null && !GameManager.Instance.GameOver)
            {
                GameManager.Instance.TogglePause(pausePanel);
            }
        }
    }
    public void Continue()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.TogglePause(pausePanel);
        }
    }

    public void Quit()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.TogglePause(pausePanel);
            GameManager.Instance.BackToTitle();
        }
    }
}
