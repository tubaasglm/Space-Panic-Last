using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouLose : MonoBehaviour
{

    public PickUp O2;
    private AudioSource audioo2;
    GameObject mainUI;
    public RawImage RI;
    public TriggerOutside triggeroutside;
    public LaunchGame gamemanager;

    private void OnTriggerEnter(Collider other)
    {
        if (O2.o2 == false)
        {
            GameObject fpsController = GameObject.Find("FPSController");
            (fpsController.GetComponent("FirstPersonController") as MonoBehaviour).enabled = false;

            audioo2 = this.GetComponent<AudioSource>();
            audioo2.Play();

            mainUI = Instantiate(Resources.Load<GameObject>("UIGameOver")) as GameObject;
            mainUI.SetActive(true);
            RI.texture = Resources.Load<Texture>("GameOver");

            Destroy(gamemanager.GetComponent<AudioSource>());
            Destroy(triggeroutside.GetComponent<AudioSource>());
        }
    }


}
