using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemy : MonoBehaviour {


    public GameObject deathEffect;
    public float startHealth=100;
    private float health;
    [HideInInspector]
    public float speed;
    public int worth = 50;
    public float startSpeed = 10f;

    [Header("Unity Stuff")]
    public Image healthBar;

    private void Start()
    {
        health = startHealth;
        speed = startSpeed;
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct) ;
    }

    public void AddSpeed(float pct)
    {
        speed = startSpeed * (1f + pct);

    }

    public void TakeDamage(float amount)
    {
        health -= amount;
       // healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
       // GameObject effect = (GameObject)Instantiate(deathEffect,transform.position,Quaternion.identity);
       // Destroy(effect, 3f);
        Destroy(gameObject);
    }
}
