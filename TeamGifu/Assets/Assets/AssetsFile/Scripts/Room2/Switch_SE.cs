using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_SE : MonoBehaviour {

    public AudioSource As;
    public AudioClip se;

	// Use this for initialization
	void Start () {
        As = GetComponent<AudioSource>();
	}
	
    public void PlaySE()
    {
        As.PlayOneShot(se);
    }
}
