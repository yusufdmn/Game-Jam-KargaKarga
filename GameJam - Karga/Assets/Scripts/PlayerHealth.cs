using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    [SerializeField] Image healthBar;

    
    void Start()
    {
        health = maxHealth;
    }


    public void TakeDamage(int damage){
        health -= damage;
        UpdateHealthBar();
        if(health <= 0){
            Die();
        }
    }

    void UpdateHealthBar(){
        healthBar.fillAmount = (float)health / (float)maxHealth;
    }

    private void Die(){
        SceneManager.LoadScene(0);
    }
}
