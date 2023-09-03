using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] Image healthBar;

    public int health;
    public int maxHealth;
    
    void Start()
    {
        health = maxHealth;
    }


    public void TakeDamage(int damage){
        AudioManager.Instance.PlayGetHurt();
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
        LevelManager.Instance.LevelFailed();
    }
}
