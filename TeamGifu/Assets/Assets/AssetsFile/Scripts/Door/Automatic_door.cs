using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic_door : MonoBehaviour {

    [SerializeField]
    private GameObject LeftDoor;
    [SerializeField]
    private GameObject RightDoor;

    private Open_to_the_left LeftScript;
    private Open_to_the_right RightScript;

	// Use this for initialization
	void Start () {
        LeftScript = LeftDoor.GetComponent<Open_to_the_left>();
        RightScript = RightDoor.GetComponent<Open_to_the_right>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            LeftScript.SetDoorSwitch(true);
            RightScript.SetDoorSwitch(true);
        }
    }
}
