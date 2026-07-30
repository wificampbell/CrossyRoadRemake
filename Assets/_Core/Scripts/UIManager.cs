using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI levelName; 
    public TextMeshProUGUI levelCompletedText; 
    public GameObject levelTextCanvas; 
    public GameObject levelCompletedCanvas; 
    public GameObject retryCanvas; 
    public Vector2 startingPos; 
    public Vector2 endingPos; 
    public float glideRate; 
    private GameManager gameManager;



    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        levelName.rectTransform.anchoredPosition = startingPos; 
        levelTextCanvas.SetActive(true);
        levelCompletedCanvas.SetActive(false);
        retryCanvas.SetActive(false);
        UpdateLevelName();
    }


    //Testing out an animation with level 1 text. 
    void Update()
    {
        if (levelName.rectTransform.anchoredPosition.y < endingPos.x)
        {
            levelName.rectTransform.anchoredPosition += new Vector2(0,5);
        }
        else
        {
            levelTextCanvas.SetActive(false);
            gameManager.SetStartedStatus(true);
        }

        if (gameManager.GetGameOverStatus())
        {
            retryCanvas.SetActive(true);
        }

    }

    public void UpdateLevelName()
    {
        levelName.text = "Level " + gameManager.GetLevel();
    }

    public void LevelCompleted()
    {
        levelCompletedCanvas.SetActive(true);
        levelCompletedText.text = "Level " + gameManager.GetLevel() + " Completed!";
    }

    public void ClearScreen()
    {
        levelTextCanvas.SetActive(false);
        levelCompletedCanvas.SetActive(false);
        retryCanvas.SetActive(false);
    }

}
