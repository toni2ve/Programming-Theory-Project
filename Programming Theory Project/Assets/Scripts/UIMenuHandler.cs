using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenuHandler : MonoBehaviour
{
    public void CreateNewPlayer()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.CreateNewPlayer();
        }
    }

    public void ContinueGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ContinueGame();
        }
    }

    public void Exit()
    {
    #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
    #else
            Application.Quit(); // original code to quit Unity player
    #endif
    }
}
