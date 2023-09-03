using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] int damage;
    public bool isPlayerInAttackRange;

    [SerializeField] float attackDuration;
    float timer;

    void Start()
    {
        
    }


    void Update()
    {
        if(isPlayerInAttackRange){
            timer += Time.deltaTime;
            if(timer > attackDuration){
                Attack();
                timer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("player")){
            isPlayerInAttackRange = true; 
        }
    }


    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("player")){
            isPlayerInAttackRange = false;
        }
    }

    public void Attack(){
        if(isPlayerInAttackRange){
            PlayerHealth player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerHealth>();
            player.TakeDamage(damage);
        }
    }


}
