using UnityEngine;
/*This class handles the end-of-level goals that indicate that the player has finished the end of the level.*/


public class EndGoalController : MonoBehaviour
{

    private GameManager gameManager;
    private UIManager uiManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }


    void Update()
    {

    }

    //When the player reaches the end, pause the game and show the level completed UI
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.SetPausedStatus(true);
            uiManager.LevelCompleted();
        }
    }

}
