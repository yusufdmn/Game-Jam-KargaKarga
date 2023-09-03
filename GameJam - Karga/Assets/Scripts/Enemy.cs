using UnityEngine;

public class Enemy : MonoBehaviour
{

    public enum Direction{  // 0 = left, 1 = right
        Left,
        Right
    }

    public int health;
    public int maxHealth = 100;

    private Direction direction;
    private bool isChasing;
    private bool isPlayerInRange;
    private float flipDuration;
    private float timer;
    private Animator enemyAnimator;
    
    [SerializeField] float maxFlipDuration;
    [SerializeField] float minFlipDuration;
    [SerializeField] float speed;
    [SerializeField] EnemyAttack enemyAttack;

    public float detectionRange = 5.0f;
    public LayerMask playerLayer;


    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        health = maxHealth;
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

    public void Takedamage(int damage){
        health -= damage;
        if(health <= 0){
            Die();
        }
    }

    public void Die(){
        AudioManager.Instance.PlayMonsterDie();
        Destroy(gameObject);
    }


    void Flip(){
        if(direction == Direction.Left){
            direction = Direction.Right;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.zero);
        }
        else{
            direction = Direction.Left;
            transform.rotation = Quaternion.Euler(0, 180, 0);
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
        enemyAnimator.SetBool("attack", true);
        isChasing = true;

        Vector2 chaseDirection = direction == Direction.Left ? Vector2.left : Vector2.right;

        transform.Translate(chaseDirection * Time.deltaTime * speed, Space.World);
    }

    void StopChasing(){
        enemyAnimator.SetBool("attack", false);
        isChasing = false;
    }
    
}