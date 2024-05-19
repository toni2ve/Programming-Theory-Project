using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOverMenuHandler : MonoBehaviour
{
    public void BackToMenu()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.BackToTitle();
        }
    }
}