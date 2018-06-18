using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_GimicOn : MonoBehaviour {
    private bool LockFlag;

    private AudioSource As;

    public AudioClip se;
    private bool one;

    public bool LockFlagParm
    {
        set
        {
            LockFlag = value;
        }
    }
    private void Awake()
    {
        GetComponent<Collider>().enabled = false;
        As = GetComponent<AudioSource>();
        one = false;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(LockFlag)
        {
            GetComponent<Collider>().enabled = true;
            if (!one)
            {
                As.PlayOneShot(se);
                one = true;
            }
        }

    }
}
