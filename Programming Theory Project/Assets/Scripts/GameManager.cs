using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public bool GameOver = false;

    public PlayerData playerData;

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
        playerData = new PlayerData();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(0);
    }

    public void CreateNewPlayer()
    {
        SceneManager.LoadScene(2);
    }
    public void StartNewGame(string playerName)
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.playerData.PlayerName = playerName;
            GameManager.Instance.playerData.Highscore = "0";
        }
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        // To DO Get current player data from saved session

        // Load main game scene
        SceneManager.LoadScene(1);
    }
    public void BackToTitle()
    {
        SceneManager.LoadScene(0);
    }

    private void savePlayerData()
    {

    }
}
