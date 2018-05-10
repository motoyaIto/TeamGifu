using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSwitch : MonoBehaviour {

    private bool OnSwitch = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Item")
        {
            OnSwitch = true;
            GetComponent<Collider>().enabled = false;
        }
    }



    public bool GetOnSwitch()
    {
        return OnSwitch;
    }
}
