using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMap : MonoBehaviour {


    public static bool PlayerWon;
	// Use this for initialization
	void Start () {
        PlayerWon = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        PlayerWon = true;

        Debug.Log("Reached end");
    }

  
}
