using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameOver = false; 
    private int currentLevel = 1; 
    private int previousLevel;
    private bool gameStarted = false; 
    private bool gamePaused = false; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetGameOverStatus()
    {
        return gameOver; 
    }

    public void SetGameOverStatus(bool newValue)
    {
        gameOver = newValue; 
    }

    public int GetLevel()
    {
        return currentLevel;
    }

    public void SetLevel(int newLevel)
    {
        currentLevel = newLevel;
        previousLevel = currentLevel - 1; 
    }

    public bool GetStartedStatus()
    {
        return gameStarted;
    }

    public void SetStartedStatus(bool newGameStatus)
    {
        gameStarted = newGameStatus;
    }
    public bool GetPausedStatus()
    {
        return gamePaused;
    }

    public void SetPausedStatus(bool newPauseStatus)
    {
        gamePaused = newPauseStatus;
    }

    public void PauseGame()
    {
        gamePaused = !gamePaused;
    }


}
