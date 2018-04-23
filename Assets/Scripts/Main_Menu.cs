using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour {

    public Canvas menu;
    public Canvas OptionsMenu;
    public Canvas CreditsMenu;

    public void Awake()
    {
        menu.enabled = true;
        OptionsMenu.enabled = false;
        CreditsMenu.enabled = false;

    }

    //button func to start the game
    public void Play()
    {
        menu.enabled = false;
    }

    //button for Options canvas
    public void Options()
    {
        OptionsMenu.enabled = true;
        menu.enabled = false;
    }

    //go from options canvas to menu canvas
    public void Menu()
    {
        menu.enabled = true;
        OptionsMenu.enabled = false;
        CreditsMenu.enabled = false;

    }

    public void Credits()
    {
        CreditsMenu.enabled = true;
        menu.enabled = false;

    }

    public void Exit()
    {
        Application.Quit();
    }
}
