using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour {

    float maxHp = 100f;
    float maxSpeed;

    // set here the time interval to take dmg from towers
    float dmgTimeInterval;
    float carHp;
    bool destroyed;

    // parts to throw when dmg is taken
    public GameObject backBumper;
    public GameObject frontBumper;
    public GameObject hood;
    public GameObject roof;
    //public GameObject frontWindow;
    //public GameObject backWindow;
  

    // parts rigidBody
    private Rigidbody backBumperRB;
    private Rigidbody frontBumperRB;
    private Rigidbody hoodRB;
    private Rigidbody roofRB;
    //private Rigidbody frontWindowRB;
    //private Rigidbody backWindowRB;

    // bools for FixedUpdate
    private bool frontBumperOut = false;
    private bool backBumperOut = false;
    private bool hoodOut = false;
    private bool roofOut = false;
    private bool frontWindowOut = false;
    private bool backWindowOut = false;



    public float destroyTime;  // The time to wait for a part to be destroyed from the Scene
    public float popForce;
    private Vector3 rotationVector;


    // switch this to Awake?
    void Start () {
        carHp = maxHp;
        destroyed = false;

        backBumperRB = backBumper.GetComponent<Rigidbody>();
        frontBumperRB = frontBumper.GetComponent<Rigidbody>();
        hoodRB = hood.GetComponent<Rigidbody>();
        roofRB = roof.GetComponent<Rigidbody>();
        //frontWindowRB = frontWindow.GetComponent<Rigidbody>();
        //backWindowRB = backWindow.GetComponent<Rigidbody>();
        



    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A key Pressed, rear bumper off bitch");
            detachFromCar(backBumper);
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D key Pressed, front bumper off bitch");
            detachFromCar(frontBumper);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S key Pressed, hood off bitch");
            detachFromCar(hood);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W key pressed, roof off bitch");
            detachFromCar(roof);
        }
       /* else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed, front window off bitch");
            detachFromCar(frontWindow);
        }*/
    }
	

    void setTimeInterval(float newTime){
        dmgTimeInterval = newTime;
    }


    void setMaxSpeed(float newSpd){
        maxSpeed = newSpd;
    }



    // takes dmg from shooting towers
    // or via crashes to walls
    void takeDmg(float amt){
        carHp = carHp - amt;

        if (carHp <= 0){
            Debug.Log("Car HP <= 0");
            destroyed = true;
        }
    }

    
    // detach the part GameObject from the car
    // GameObject, and destroy it from the scene
    void detachFromCar(GameObject part){
        part.transform.parent = null;
        
        if (part == backBumper)
        {
            Debug.Log("Rear bumper detaching");

            Vector3 popDirection = new Vector3(-10, 2, 0);  // need to make the direction according to the back of the car rear
            backBumperRB.AddForce(popDirection * popForce);
            backBumperRB.useGravity = true;
       //     rotationVector = new Vector3(-100, 0, 0);
            backBumperOut = true;
            
        }

        if (part == frontBumper)
        {
            Debug.Log("front bumper detaching");

            Vector3 popDirection = new Vector3(10, 2, 0);  // need to make the direction according to the back of the car rear
            frontBumperRB.AddForce(popDirection * popForce);
            frontBumperRB.useGravity = true;
       //     rotationVector = new Vector3(100, 0, 0);
            frontBumperOut = true;
        }

        if (part == hood)
        {
            Debug.Log("hood detaching");

            Vector3 popDirection = new Vector3(0, 10, 0);  // need to make the direction according to the back of the car rear
            hoodRB.AddForce(popDirection * popForce);
            hoodRB.useGravity = true;
            //     rotationVector = new Vector3(100, 0, 0);
            hoodOut = true;
        }

        if (part == roof)
        {
            Debug.Log("roof detaching");

            Vector3 popDirection = new Vector3(0, 10, 0);  // need to make the direction according to the back of the car rear
            roofRB.AddForce(popDirection * popForce);
            roofRB.useGravity = true;
            //     rotationVector = new Vector3(100, 0, 0);
            roofOut = true;
        }
/*
        if (part == frontWindow)
        {
            Debug.Log("front window detaching");

            Vector3 popDirection = new Vector3(10, 2, 0);  // need to make the direction according to the back of the car rear
            frontWindowRB.AddForce(popDirection * popForce);
            frontWindowRB.useGravity = true;
            //     rotationVector = new Vector3(100, 0, 0);
            frontWindowOut= true;
        }*/

        Destroy(part, destroyTime);
        
    }
    /*
    void FixedUpdate(){
        // check which part needs to rotate
        if (backBumperOut && backBumper != null){
            Debug.Log("FixedUpdate is in the house");
            Quaternion deltaRotation = Quaternion.Euler(rotationVector * Time.deltaTime);
            backBumperRB.MoveRotation(backBumperRB.rotation * deltaRotation);
            
        }
        
    }*/
}
