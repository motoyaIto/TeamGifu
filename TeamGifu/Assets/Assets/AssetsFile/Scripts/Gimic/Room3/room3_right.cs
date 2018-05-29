using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room3_right : MonoBehaviour {

    private bool LockFlag = false;
    public bool LockFlagState
    {
        set
        {
            LockFlag = value;
        }
    }
    // Use this for initialization
    void Start()
    {
        GetComponent<Collider>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (LockFlag)
        {
            GetComponent<Collider>().enabled = true;
        }
        else
        {
            GetComponent<Collider>().enabled = false;
        }
    }
}
