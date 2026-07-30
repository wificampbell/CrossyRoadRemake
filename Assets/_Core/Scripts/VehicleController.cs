using UnityEngine;

public class VehicleController : MonoBehaviour
{

    public Vector3 startingPos;
    public float offScreenXPos;
    private GameManager gameManager;
    //The ending position of the car before it teleports back to its starting position
    public Vector3 targetPosition;
    public float step;
    //The direction that the vehicle is driving. 0 = top to bottom //1 = bottom to top
    public int direction; 



    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //As long as the game has been started, isn't paused, and isn't over, then move the vehicle and teleport it back to its starting position 
        // once it goes beyond its target position
        if (!gameManager.GetGameOverStatus() && !gameManager.GetPausedStatus() && gameManager.GetStartedStatus())
        {
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

    //Game over if player touches car
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.SetGameOverStatus(true);
            Debug.Log("Game over!");
        }
    }
}
