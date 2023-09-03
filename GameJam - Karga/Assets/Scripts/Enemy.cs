using UnityEngine;

public class Enemy : MonoBehaviour
{

    public enum Direction{  // 0 = left, 1 = right
        Left,
        Right
    }

    private Direction direction;
    private bool isChasing;
    private bool isPlayerInRange;
    private float flipDuration;
    private float timer;

    [SerializeField] float maxFlipDuration;
    [SerializeField] float minFlipDuration;
    [SerializeField] float speed;
    [SerializeField] EnemyAttack enemyAttack;

    public float detectionRange = 5.0f;
    public LayerMask playerLayer;


    void Start()
    {
        flipDuration = Random.Range(minFlipDuration, maxFlipDuration);   
    }


    void Update()
    {
        CheckIfPlayerIsInRange();

        if(!enemyAttack.isPlayerInAttackRange && isPlayerInRange){
            Chase();
        }
        
        if(isChasing){
            return;
        }

        timer += Time.deltaTime;

        if(timer > flipDuration){
            flipDuration = Random.Range(minFlipDuration, maxFlipDuration);  
            Flip();
            timer = 0;
        }
    }

    public void Die(){
        Destroy(gameObject);
    }


    void Flip(){
        if(direction == Direction.Left){
            direction = Direction.Right;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.zero);
        }
        else{
            direction = Direction.Left;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.zero);
        }
    }
    
    private void CheckIfPlayerIsInRange()
    {
        Vector2 raycastDirection = direction == Direction.Left ? Vector2.left : Vector2.right;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, raycastDirection, detectionRange, playerLayer);

        if (hit.collider != null && hit.collider.CompareTag("player"))
        {
            isPlayerInRange = true;
        }
        else
        {
            isPlayerInRange = false;
            StopChasing();
        }
    }


    void Chase(){
        isChasing = true;

        Vector2 chaseDirection = direction == Direction.Left ? Vector2.left : Vector2.right;

        transform.Translate(chaseDirection * Time.deltaTime * speed, Space.World);
    }

    void StopChasing(){
        isChasing = false;
    }
    
}