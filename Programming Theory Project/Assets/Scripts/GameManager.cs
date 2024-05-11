using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public bool GameOver = false;

    public static GameManager Instance { get; private set;}
     private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame(){
        SceneManager.LoadScene(1);
    }

    public void ContinueGame(){
        // To DO Get current player data from saved session

        // Load main game scene
        SceneManager.LoadScene(1);
    }

    public void BackToTitle(){
        SceneManager.LoadScene(0);  
    }
}
