using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    private enemy targetEnemy;
    private PlayerStats targetPlayerLife;
    private PlayerController targetPlayerSpeed;

    // 4 types of laser shooters.
    //1 - red does most damage
    //2 - blue make it very slow 
    //3 - green damage and slow weak but with range
    //4 - tan switch directions left/right
    public int Type = 0;

    AudioSource audioSource;

    [Header("General")]
    public float range = 15f;

    [Header("Use laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;
    public int damageOverTime = 100;
    public float slowAmount = .5f;

    [Header("Unity setup fields")]

    public string enemyTag = "Enemy";
    public bool AttackPlayer = false;

    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform firePoint;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("UpdateTarget",0f,0.5f);
        switch (Type)
        {
            case (1):
                slowAmount = .1f;
                break;

            case (2):
                slowAmount = .8f;
                break;

            case (3):
                damageOverTime = 50;
                slowAmount = .3f;
                range = 75f;
                break;

            case (4):
                range = 70;
                slowAmount = .1f;
                damageOverTime = 0;
                break;
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (shortestDistance > distanceToEnemy)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy!=null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            audioSource.Play();
            if (!AttackPlayer)  //tower is trying to attack the enemy
                targetEnemy = nearestEnemy.GetComponent<enemy>();

            else //tower is trying to attack the player
            {
                targetPlayerLife = nearestEnemy.GetComponent<PlayerStats>();
                targetPlayerSpeed = nearestEnemy.GetComponent<PlayerController>();
            }
        }
        else
        {
            audioSource.Stop();
            target = null;
        }
    }
	
	void Update () {
        if (!GameManager.playSound)
            audioSource.mute = true;
        else
            audioSource.mute = false;

        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
    }

    void Laser()
    {
        if (!AttackPlayer)
        {
            targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
            targetEnemy.Slow(slowAmount);
            if(Type == 4)
                targetEnemy.AddSpeed(2);
        }
        else
        {
            targetPlayerLife.TakeDamage(damageOverTime * Time.deltaTime);
            targetPlayerSpeed.Slow(slowAmount);
            if (Type == 4)
                targetPlayerSpeed.AddSpeed(2);
        }

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.position = target.position +12*dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
