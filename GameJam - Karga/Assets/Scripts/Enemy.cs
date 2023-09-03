using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public enum Direction{  // 0 = left, 1 = right
        Left,
        Right
    }
    private Direction direction;
    float timer;
   
    bool isChasing;
    bool isPlayerInRange;
   
    [SerializeField] float maxFlipDuration;
    [SerializeField] float minFlipDuration;
    float flipDuration;

    [SerializeField] float speed;


    [SerializeField] EnemyAttack enemyAttack;

    public float detectionRange = 5.0f;      // The range at which the enemy can detect the player.
    public LayerMask playerLayer;            // The layer containing the player.

    private Transform player;

    void Start()
    {
        flipDuration = Random.Range(minFlipDuration, maxFlipDuration);   
        player = GameObject.FindGameObjectWithTag("player").transform;
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
      //  Vector3 scale = transform.localScale;
     //   scale.x *= -1;

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

    


   /* void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("player")){
            isPlayerInRange = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("player")){
            isPlayerInRange = false;
            StopChasing();
        }
    }*/


    void Chase(){
        isChasing = true;

        Vector2 chaseDirection = direction == Direction.Left ? Vector2.left : Vector2.right;

        transform.Translate(chaseDirection * Time.deltaTime * speed, Space.World);
    }

    void StopChasing(){
        isChasing = false;
    }
    
}