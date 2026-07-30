using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneManager : MonoBehaviour
{
    private GameManager gameManager;
    private UIManager uiManager;


    void Start()
    {
        SceneManager.LoadScene("Level 1 Environment", LoadSceneMode.Additive); 
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }


    void Update()
    {
   
    }

    public void LoadNextLevel()
    {
        string currentScene = $"Level {gameManager.GetLevel()} Environment";
        gameManager.SetLevel(gameManager.GetLevel() + 1);

        string nextScene = $"Level {gameManager.GetLevel()} Environment";

        //Deletes the previous scene and "replaces" it with the next level scene. 
        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive); 

        gameManager.SetPausedStatus(false);
        uiManager.ClearScreen();
        Debug.Log(nextScene + "     " + gameManager.GetLevel());
    }

    public void RetryLevel()
    {
        string currentScene = $"Level {gameManager.GetLevel()} Environment";
        SceneManager.UnloadSceneAsync(currentScene);

        SceneManager.LoadSceneAsync(currentScene, LoadSceneMode.Additive); 

        gameManager.SetPausedStatus(false);
        gameManager.SetGameOverStatus(false);
        uiManager.ClearScreen();
    }
}
