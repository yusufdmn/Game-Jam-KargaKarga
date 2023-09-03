using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public enum PlayerStatus
    {
        Left,
        Right,
        Up,
        Down,
        Idle
    }


  //  [SerializeField] InputManager inputManager;
   // [SerializeField] Player player;

    SpriteRenderer spriteRenderer;
    [SerializeField] InputManager inputManager;
    
    private Transform playerTransform;
    private Vector2 moveVector;
    private Vector2 leftVector = new Vector2(-1,0);
    private Vector2 rightVector = new Vector2(1,0);

    public PlayerStatus currentStatus; // 0 = left, 1 = right, 2 = Up , 3 = Down, 4 = Idle



    [SerializeField] private float speed;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if(inputManager.x > 0){
            ChangeDirectionToRight();
        }
        else if(inputManager.x < 0){
            ChangeDirectionToLeft();
        }
        else{
            StoptMoving();
        }

        MovePlayer();
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

    private void StoptMoving(){
        moveVector = Vector2.zero;
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

}
