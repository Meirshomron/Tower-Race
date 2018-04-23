using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    GameManager gm;

    Vector3 velocity;
    public float startSpeed = 20f;
    float moveSpeed;
    Vector3 dir;
    Vector3 previousPosition;

    public float RotateSpeed = 0.0005f;
    private Quaternion qTo;
    public float lookSpeed = .0002f;
    private Vector3 curLoc;
    private Vector3 prevLoc;

    public bool colliding;

    public AudioSource audioSource;
    public bool isMoving = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        colliding = false;
        moveSpeed = startSpeed;
        qTo = transform.rotation;
        audioSource.Play();
        gm = GameManager.instance;

    }

    void FixedUpdate()
    {

            if (!GameManager.playSound)
                audioSource.mute = true;
            else
                audioSource.mute = false;

            prevLoc = transform.position;

            if (dir != Vector3.zero && isMoving == false)
            {
                audioSource.Play();
            }
            else if (isMoving == false)
            {
                audioSource.Stop();
            }
            if (dir != Vector3.zero)
            {
                isMoving = true;
            }
            if (dir == Vector3.zero)
            {
                isMoving = false;
            }

            //transform.rotation = Quaternion.Lerp(transform.rotation, qTo, Time.deltaTime * RotateSpeed);
            InputListen();
            if (dir != Vector3.zero)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - prevLoc), Time.fixedDeltaTime * lookSpeed);

            moveSpeed = startSpeed;
        

    }

    private void InputListen()
    {
        prevLoc = curLoc;
        curLoc = transform.position;

        dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));

        if(dir!=Vector3.zero && !colliding)
            transform.Translate(dir * Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        colliding = true;

    }
    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }

    public void Slow(float pct)
    {
        moveSpeed = startSpeed * (1f - pct);
    }

    public void AddSpeed(float pct)
    {
        moveSpeed = startSpeed * (1f + pct);

    }

}
