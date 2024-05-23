using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public bool GameOver = false;

    public PlayerData currentPlayerData;
    public PlayerData latestHighScorePlayerData;

    GameObject scoreObject = null;

    public TMP_Text ClipAmmo;
    public TMP_Text ExtraAmmo;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        currentPlayerData = new PlayerData();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        latestHighScorePlayerData = new PlayerData();
        loadHighscore();
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void UpdatePlayerHighscore()
    {
        if (scoreObject == null)
        {
            scoreObject = GameObject.Find("ScoreValue");
        }

        TMP_Text highscoreText = scoreObject.GetComponent<TMP_Text>();
        highscoreText.SetText("" + currentPlayerData.Highscore);
    }
    public void CreateNewPlayer()
    {
        SceneManager.LoadScene(2);
    }
    public void StartNewGame(string playerName)
    {
        if (GameManager.Instance != null)
        {
            GameOver = false;
            GameManager.Instance.currentPlayerData.PlayerName = playerName;
            GameManager.Instance.currentPlayerData.Highscore = 0;
        }
        SceneManager.LoadScene(1);
    }
    public void ViewHighscore()
    {
        SceneManager.LoadScene(3);
    }
    public void BackToTitle()
    {
        SceneManager.LoadScene(0);
    }
    public void SaveHighscore()
    {
        if (currentPlayerData.Highscore > latestHighScorePlayerData.Highscore)
        {
            PlayerData data = new PlayerData();
            data.PlayerName = currentPlayerData != null ? currentPlayerData.PlayerName : "None";
            data.Highscore = currentPlayerData.Highscore;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
        }
    }

    private void loadHighscore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            if (data != null)
            {
                latestHighScorePlayerData.PlayerName = data.PlayerName;
                latestHighScorePlayerData.Highscore = data.Highscore;
            }
        }
        else
        {
            latestHighScorePlayerData.PlayerName = "None";
            latestHighScorePlayerData.Highscore = 0;
        }
    }

    public void UpdateClipAmmoDisplay(int ammo)
    {
        if (ClipAmmo != null)
            ClipAmmo.text = "" + ammo;
    }

    public void UpdateExtraAmmoDisplay(int ammo)
    {
        if (ExtraAmmo != null)
            ExtraAmmo.text = "" + ammo;
    }
}
