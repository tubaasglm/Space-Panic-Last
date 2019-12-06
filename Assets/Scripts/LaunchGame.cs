using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LaunchGame : MonoBehaviour
{
    public GameObject textDisplay;
    public ShipWin ship;

    public int SecondsLeft = 30;
    public bool takingAway = false;

    private AudioSource sonAmbience;
    private AudioClip clip;
    private bool beep = false;
    private AudioSource BeepSound;

    GameObject mainUI;
    public RawImage RI;

    public TriggerOutside triggeroutside;


    private void Awake()
    {
        sonAmbience = GetComponent<AudioSource>();
        sonAmbience.Play();
        Cursor.visible = true;
        

    }
    //HideMainUI
    public void HideUI()
    {

        BeepSound = gameObject.AddComponent<AudioSource>();
        BeepSound.clip = Resources.Load<AudioClip>("beep");
        BeepSound.loop = false;
        BeepSound.Play();

        mainUI = GameObject.Find("MainUI");
        mainUI.SetActive(false);
        GameObject fpsController = GameObject.Find("FPSController");
        (fpsController.GetComponent("FirstPersonController") as MonoBehaviour).enabled = true;

        takingAway = true;
        textDisplay.GetComponent<Text>().text = "00:" + SecondsLeft;

        sonAmbience.clip = Resources.Load<AudioClip>("Alarmm2");
        sonAmbience.Play();
        
        //alarm moins fort
    }
    void Update()
    {

      
        if (takingAway == true && SecondsLeft >= 0)
        {
            StartCoroutine(TimeTake());
        }

        if (ship.won == true)
        {
            mainUI = Instantiate(Resources.Load<GameObject>("UIYouWin")) as GameObject;
            Destroy(triggeroutside.gameObject);
            Destroy(this);
            mainUI.SetActive(true);

            GameObject fpsController = GameObject.Find("FPSController");
            (fpsController.GetComponent("FirstPersonController") as MonoBehaviour).enabled = false;

        }

        else if (ship.won == false)
        {
            //
        }
    }

    //Coroutine
    IEnumerator TimeTake()
    {
        takingAway = false;
        yield return new WaitForSeconds(1);
        SecondsLeft -= 1;

        if (SecondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + SecondsLeft;

            if (SecondsLeft == 0)
            {

                if (ship.won == true)
                {
                    mainUI = Instantiate(Resources.Load<GameObject>("UIYouWin")) as GameObject;
                    mainUI.SetActive(true);
                    GameObject fpsController = GameObject.Find("FPSController");
                    (fpsController.GetComponent("FirstPersonController") as MonoBehaviour).enabled = false;
                    Destroy(triggeroutside.gameObject);
                    Destroy(this);

                }

                else if (ship.won == false)
                {
                    mainUI = Instantiate(Resources.Load<GameObject>("UIGameOver")) as GameObject;
                    mainUI.SetActive(true);
                    GameObject fpsController = GameObject.Find("FPSController");
                    (fpsController.GetComponent("FirstPersonController") as MonoBehaviour).enabled = false;
                    Destroy(triggeroutside.gameObject);
                    Destroy(this);
                }
            }
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:" + SecondsLeft;
        }
        takingAway = true;
    }

}