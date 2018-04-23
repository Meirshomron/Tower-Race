using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Button startRaceButton;

    public Camera startCam;
    public Camera miniCam;
    public Camera playerCam;

    public Canvas endCanvas;
    public Text endGameText;

    public Text Coins;
    public GameObject TowersSelect; 

    public bool youWon;
    public GameObject Player;
    
    public GameObject Enemy;

    public static bool playSound = true;


    //sounds
    AudioSource sm;
    public AudioSource EngineStart;


    //easy
    Vector3 EasyStartPos = new Vector3(2000,0,-477);

    //medium
    Vector3 MediumStartPos = new Vector3(2000, 0, 670);


    //hard
    Vector3 HardStartPos = new Vector3(2000, 0, 2040);

    public bool started;

    void Awake () {
        instance = this;
        startCam.enabled = true;
        miniCam.enabled = false;
        playerCam.enabled = false;
    }

    private void Start()
    {
        endCanvas.enabled = false;
        started = false;
        startRaceButton.gameObject.SetActive(true);
        sm = GetComponent<AudioSource>();
        EngineStart.Play();


        sm.Play();

    }

    void Update () {

        Coins.text = "Coins:\n    "+ PlayerStats.Money;

        if (!playSound)
        {
            sm.mute = true;
        }
        else
        {
            sm.mute = false;
        }

        if (PlayerStats.health <=0 || enemyMovement.finished)
        {
            if(Player !=null)
                Player.SetActive(false);
            if(Enemy !=null)
                Enemy.SetActive(false);

            endGameText.text = "You Lose!";
            endCanvas.enabled = true;

            //player lost
            //open  End game canvas
        }

        else if (EndMap.PlayerWon)
        {
            if (Player != null)
                Player.SetActive(false);
            if (Enemy != null)
                Enemy.SetActive(false);
            endGameText.text = "You Win!";
            endCanvas.enabled = true;

            //player Won!
            //open  End game canvas
        }
    }

    public void StartGame()
    {
        TowersSelect.SetActive(false);
        sm.Stop();
        EngineStart.Play();
        if (!playSound)
            EngineStart.mute = true;

            playerCam.enabled = true;
        miniCam.enabled = true;

        startCam.enabled = false;
        StartCoroutine(startTheRace());
        startRaceButton.gameObject.SetActive(false);
    }

    IEnumerator startTheRace()
    {
        yield return new WaitForSeconds(0);
        started = true;

    }

    public void EasyGame()
    {
        Debug.Log("Easy");
        Player.transform.position = EasyStartPos;
        Player.GetComponent<PlayerStats>().startMoney = 300;
        PlayerStats.Money = 300;
        Player.GetComponent<PlayerStats>().SetHealth(2500);

    }


    public void MediumGame()
    {
        Debug.Log("Medium");
        Player.transform.position = MediumStartPos;
        Player.GetComponent<PlayerStats>().startMoney = 250;
        PlayerStats.Money = 250;
        Player.GetComponent<PlayerStats>().SetHealth(2000);

    }

    public void HardGame()
    {
        Debug.Log("Hard");
        Player.transform.position = HardStartPos;
        Player.GetComponent<PlayerStats>().startMoney = 200;
        PlayerStats.Money = 200;
        Player.GetComponent<PlayerStats>().SetHealth(2000);

    }


    public void SoundOn()
    {
        playSound = true;
    }


    public void SoundOff()
    {
        playSound = false;
    }

    public void restartGame()
    {
        SceneManager.LoadScene("TheGame");
    }

}
