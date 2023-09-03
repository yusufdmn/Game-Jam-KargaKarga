using UnityEngine;

public class EnemyAttack : MonoBehaviour
{ 
    private float timer;
   
    [SerializeField] float attackDuration;
    [SerializeField] int damage;


    public bool isPlayerInAttackRange;


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
