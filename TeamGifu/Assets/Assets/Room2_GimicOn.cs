using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_GimicOn : MonoBehaviour {
    private bool LockFlag;
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

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(LockFlag)
        {
            GetComponent<Collider>().enabled = true;
        }

    }
}
