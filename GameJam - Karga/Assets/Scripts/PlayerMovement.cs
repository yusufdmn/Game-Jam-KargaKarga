using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public enum PlayerStatus
    {
        Left,
        Right,
        Up,
        Down,
        Idle,
        Attack
    }

    private bool isNearLadderUp;
    private bool isNearLadderBottom;
    private Vector2 moveVector;
    private Vector2 leftVector = new Vector2(-1,0);
    private Vector2 rightVector = new Vector2(1,0);
    private Vector2 targetFloorPos;


    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] InputManager inputManager;

    [SerializeField] ScreenTransition screenTransition;
    

    public PlayerStatus currentStatus; // 0 = left, 1 = right, 2 = Up , 3 = Down, 4 = Idle, 5 = Attack


    void Update()
    {
        if(inputManager.x > 0){
            ChangeDirectionToRight();
        }
        else if(inputManager.x < 0){
            ChangeDirectionToLeft();
        }
        else{
            StopMoving();
        }


        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))  && isNearLadderBottom && currentStatus != PlayerStatus.Up && currentStatus != PlayerStatus.Down){
            currentStatus = PlayerStatus.Up;
            StartCoroutine(ClimbLadder());
            ClimbLadder();
        }
        else if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) ) && isNearLadderUp&& currentStatus != PlayerStatus.Up && currentStatus != PlayerStatus.Down){
            currentStatus = PlayerStatus.Down;
            StartCoroutine(ClimbLadder());
        }
        
        MovePlayer();
    }


    private IEnumerator ClimbLadder(){
        screenTransition.StartTransitionCoroutine();
        yield return new WaitForSeconds(0.85f);

        transform.position = targetFloorPos;
        currentStatus = PlayerStatus.Idle;  
    }

    private void MovePlayer(){

        transform.Translate(moveVector * speed * Time.deltaTime, Space.World);
    }

    private void ChangeDirectionToRight(){
        moveVector = rightVector;
        currentStatus = PlayerStatus.Right;
        
        RotatePlayerToDirection();
    }

    private void ChangeDirectionToLeft(){
        moveVector = leftVector;
        currentStatus = PlayerStatus.Left;
        RotatePlayerToDirection();
    }

    private void StopMoving(){
        moveVector = Vector2.zero;
        currentStatus = PlayerStatus.Idle;
    }

    private void RotatePlayerToDirection(){
        switch(currentStatus){
            case PlayerStatus.Left:
                transform.rotation = Quaternion.Euler(0,180,0);
                break;
            case PlayerStatus.Right:
                transform.rotation = Quaternion.Euler(0,0,0);
                break;
        }
    }

    private void AttackEnemy(){
        // Play the animation

    }


    private void OnTriggerEnter2D(Collider2D other) {     

        if(other.CompareTag("ladderBottom")){
            targetFloorPos = other.transform.parent.GetChild(1).position;
            isNearLadderBottom = true;
        }
        else if(other.CompareTag("ladderUp")){
            targetFloorPos = other.transform.parent.GetChild(0).position;
            isNearLadderUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if(other.CompareTag("ladderBottom")){
            isNearLadderBottom = false;
        }
        else if(other.CompareTag("ladderUp")){
            isNearLadderUp = false;
        }
    }


}