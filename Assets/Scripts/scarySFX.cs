using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scarySFX : MonoBehaviour
{
    private AudioSource sfx;

    private void Awake()
    {
        sfx = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "FPSController")
        {
            Debug.Log("player");
            sfx.Play();
            Destroy(this);
        }
    }
}
