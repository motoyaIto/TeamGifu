using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_SE : MonoBehaviour {
    private AudioSource As; // 音を鳴らす
    [Header("効果音")]
    public AudioClip Se;

    private void Start()
    {
        As = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            As.PlayOneShot(Se);
        }
    }

}
