using UnityEngine;

public class LogController : MonoBehaviour
{

    public Vector3 startingPos;
    public float offScreenXPos;
    private GameManager gameManager;
    private PlayerController playerController;
    //The ending position of the log before it teleports back to its starting position
    public Vector3 targetPosition;
    public float step;
    //The direction that the vehicle is driving. 0 = top to bottom //1 = bottom to top
    public int direction;
    private Vector3 startingPosition;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        startingPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetGameOverStatus() && !gameManager.GetPausedStatus() && gameManager.GetStartedStatus())
        {
            startingPosition = transform.position; 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step * Time.deltaTime);

            if ((direction == 0) && (transform.position.x >= offScreenXPos))
            {
                transform.position = startingPos;
            }
            if ((direction == 1) && (transform.position.x <= offScreenXPos))
            {
                transform.position = startingPos;
            }
        }
    }

    public Vector3 GetMovement()
    {
       return transform.position - startingPosition; 
    }

}
