using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigWakeUp : MonoBehaviour {
    Rigidbody rig;

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        
        if (rig.IsSleeping())
        {
            rig.WakeUp();
        }

    }
}
