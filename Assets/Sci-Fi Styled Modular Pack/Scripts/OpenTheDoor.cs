using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoor : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;

    private void OnTriggerEnter(Collider other)
    {
        myAnimationController.SetBool("character_nearby", true);
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerExit(Collider other)
    {
        myAnimationController.SetBool("character_nearby", false);
        GetComponent<AudioSource>().Play();
    }
}
