using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {


    public static BuildManager instance;

    public int costOfTower1 = 50;
    public int costOfTower2 = 75;
    public int costOfTower3 = 50;
    public int costOfTower4 = 30;

    public GameObject prefabT1;
    public GameObject prefabT2;
    public GameObject prefabT3;
    public GameObject prefabT4;

    public TowerLanding[] TowerPositions;

    public AudioSource audioSource;


    void Awake()
    {
        instance = this;
    }

    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	void Update () {
        if (!GameManager.playSound)
            audioSource.mute = true;
        else
            audioSource.mute = false;
    }

    public void BuildTower1()
    {
        Debug.Log("Trying to build T1");
        if(PlayerStats.Money >= costOfTower1)
        {
            PlayerStats.Money -= costOfTower1;

            audioSource.Play();
            //build the tower on the positon pressed
            int index = getLocationPressed();

            Instantiate(prefabT1, TowerPositions[index].transform.position, Quaternion.identity);
            TowerPositions[index].builtHereAlready = true;
        }
    }

    public void BuildTower2()
    {
        Debug.Log("Trying to build T2");
        if (PlayerStats.Money >= costOfTower2)
        {
            PlayerStats.Money -= costOfTower2;
            Debug.Log("Money afterT2: " + PlayerStats.Money);
            audioSource.Play();
            //build the tower on the positon pressed
            int index = getLocationPressed();

            Instantiate(prefabT2, TowerPositions[index].transform.position, Quaternion.identity);
            TowerPositions[index].builtHereAlready = true;
        }
    }

    public void BuildTower3()
    {
        Debug.Log("Trying to build T3");
        if (PlayerStats.Money >= costOfTower3)
        {
            PlayerStats.Money -= costOfTower3;
            audioSource.Play();
            //build the tower on the positon pressed
            int index = getLocationPressed();

            Instantiate(prefabT3, TowerPositions[index].transform.position, Quaternion.identity);
            TowerPositions[index].builtHereAlready = true;
        }
    }

    public void BuildTower4()
    {
        Debug.Log("Trying to build T4");
        if (PlayerStats.Money >= costOfTower4)
        {
            PlayerStats.Money -= costOfTower4;
            audioSource.Play();
            //build the tower on the positon pressed
            int index = getLocationPressed();

            Instantiate(prefabT4, TowerPositions[index].transform.position, Quaternion.identity);
            TowerPositions[index].builtHereAlready = true;
        }
    }



    public void exitMenu()
    {
        Debug.Log("Trying to exit");

        int index = getLocationPressed();

        TowerPositions[index].closePanelNow();

    }


    int getLocationPressed()
    {
        int index = -1;
        float maxTime = 0;
        for (int i = 0; i < TowerPositions.Length; i++)
        {
            if (TowerPositions[i].LastTimePressed > maxTime)
            {
                maxTime = TowerPositions[i].LastTimePressed;
                index = i;
            }
        }
        return index;
    }

    public bool HasMoney() {
        Debug.Log("in HASMONEY");
        return PlayerStats.Money >= costOfTower1;
    }
}
