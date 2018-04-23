using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(enemy))]
public class enemyMovement : MonoBehaviour {

    public static bool finished;

    private Transform target;
    private int wavePointIndex = 0;

    private enemy enemy;
    GameManager gm;
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = GameManager.instance;
        enemy = GetComponent<enemy>();
        target = waypoints.points[0];
        finished = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (gm.started)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * enemy.speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                GetNextWaypoint();
            }
            enemy.speed = enemy.startSpeed;
        }
    }

    void GetNextWaypoint()
    {
        if (wavePointIndex >= waypoints.points.Length - 1)
        {
            wavePointIndex--;
            target = waypoints.points[wavePointIndex];
            EndPath();

        }
        wavePointIndex++;
        target = waypoints.points[wavePointIndex];
    }
    void EndPath()
    {
        finished = true;
        Destroy(gameObject);
        return;
    }

}
