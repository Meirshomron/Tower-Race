using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public static float health;

    public float startHealth = 2000;
    public static int Money;

    public int startMoney = 250;

    public Image healthBar;


    private void Start()
    {
        health = startHealth;
        Money = startMoney;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    public void SetHealth(int _health)
    {
        health = _health;
        startHealth = _health;
    }

    void Die()
    {
        // GameObject effect = (GameObject)Instantiate(deathEffect,transform.position,Quaternion.identity);
        // Destroy(effect, 3f);
        Destroy(gameObject);
    }

}