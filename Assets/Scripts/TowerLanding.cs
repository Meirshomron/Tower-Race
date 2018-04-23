using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerLanding : MonoBehaviour {

    public Vector3 positionOffset;
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;
    private Renderer rend;
    public float LastTimePressed;
    public bool builtHereAlready;
    float timePanelOpen;

    public GameObject Panel;
    public GameObject PanelAnim;

    BuildManager buildManager;


    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        Panel.SetActive(false);
        LastTimePressed = 0;
        builtHereAlready = false;

        timePanelOpen = 5f;
    }
    private void Update()
    {

        if (builtHereAlready)
        {
            closePanelNow();
            gameObject.SetActive(false);
            LastTimePressed = 0;
        }
    }

    //mouse hovering over
    void OnMouseEnter()
    {

        if (buildManager.HasMoney())
            rend.material.color = hoverColor;
        else
            rend.material.color = notEnoughMoneyColor;
            
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        Debug.Log("pressed!");
        LastTimePressed = Time.time;
        Panel.GetComponent<RectTransform>().position = new Vector3(transform.position.x+20f, transform.position.y+100f, transform.position.z);

        Panel.SetActive(true);
    }


    public void closePanelNow()
    {
        Panel.SetActive(false);
    }

    /*  void OnMouseDown()
      {
          if (EventSystem.current.IsPointerOverGameObject())
              return;

          if (turrent != null)
          {
              buildManager.SelectNode(this);
              return;
          }
          if (!buildManager.CanBuild)
              return;

          BuildTurrent(buildManager.getTurrentToBuild());
      }
      */

    // Use this for initialization

}
