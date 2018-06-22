using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_SE : MonoBehaviour {

    private AudioSource As; // 音を鳴らす
    [HideInInspector]
    public AudioClip Se;


    private void Start()
    {
        As = gameObject.AddComponent<AudioSource>();
        As.volume = 0.15f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            As.PlayOneShot(Se);
        }
    }
}
