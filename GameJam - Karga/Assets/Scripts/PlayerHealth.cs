using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;


    
    void Start()
    {
        health = maxHealth;
    }


    public void TakeDamage(int damage){
        health -= damage;
        if(health <= 0){
            Die();
        }
    }

    private void Die(){
        //GAME OVER
    }
}
