using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    //The forward, backward, and horizontal movement of the player. Will most likely combine forward and backward variables into one. 
    public Vector3 forwardAddition;
    public Vector3 backwardAddition;
    public Vector3 horizontalAddition;

    public Vector3 startingPosition;

    //Special variables to make sure the player actually goes far enough to land on the road at the beginning 
    public Vector3 specialAddition;
    public Vector3 secondPosition;

    private GameManager gameManager;
    private LogController currentLogController;

    public bool isOnLog = false;
    private GameObject currentLog;

    //Used to detect the Trees layer masks and the detection radius size. 
    public LayerMask obstacleLayer;
    public float checkRadius = 0.1f;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        transform.position = startingPosition;
        isOnLog = false;
    }

    void Update()
    {
        if (!gameManager.GetGameOverStatus() && !gameManager.GetPausedStatus() && gameManager.GetStartedStatus())
        {
            //Implement new movement in level 4. 
            if (gameManager.GetLevel() >= 4)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    TryMove(-horizontalAddition);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    TryMove(horizontalAddition);
                }
            }

            if (isOnLog)
            {
                transform.position += currentLogController.GetMovement();

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Vector3 moveStep;
                    if (transform.position == startingPosition)
                    {
                        moveStep = specialAddition;
                    }
                    else
                    {
                        moveStep = forwardAddition;
                    }
                    TryMove(moveStep);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Vector3 moveStep;
                    if (transform.position == secondPosition)
                    {
                        moveStep = -specialAddition;
                    }
                    else
                    {
                        moveStep = backwardAddition;
                    }
                    TryMove(moveStep);
                }

                // Handling game over based on log position
                    // 0.5 will be made into variable. 
                if ((currentLogController.direction == 1) && (transform.position.x <= currentLogController.offScreenXPos + 0.5))
                {
                    gameManager.SetGameOverStatus(true);
                }
                else if ((currentLogController.direction == 0) && (transform.position.x >= currentLogController.offScreenXPos - 0.5))
                {
                    gameManager.SetGameOverStatus(true);
                }
            }
            else
            {
                //Regular forward and backward movement 
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
                {
                    Vector3 moveStep;

                    if (transform.position == startingPosition)
                    {
                        moveStep = specialAddition;
                    }
                    else
                    {
                        moveStep = forwardAddition;
                    }
                    TryMove(moveStep);
                }

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Vector3 moveStep;
                    if (transform.position == secondPosition)
                    {
                        moveStep = -specialAddition;
                    }
                    else
                    {
                        moveStep = backwardAddition;
                    }
                    TryMove(moveStep);
                }

            }
        }
    }


    //If moving the player won't result in a collision, then allow it. Else, don't.
    void TryMove(Vector3 displacement)
    {
        Vector3 targetPosition = transform.position + displacement;

        Collider2D hitObstacle = Physics2D.OverlapCircle(targetPosition, checkRadius, obstacleLayer);

        if (hitObstacle == null)
        {
            transform.position = targetPosition;
        }
        else
        {
            Debug.Log("Blocked by tree");
        }
    }

    public void ResetPosition()
    {
        transform.position = startingPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Log"))
        {
            isOnLog = true;
            currentLog = other.gameObject;
            currentLogController = other.GetComponent<LogController>();
            transform.position = other.transform.position + new Vector3(0, 1.92f, 0);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Log"))
        {
            isOnLog = false;
            currentLog = null;
            currentLogController = null;
        }
    }
}
