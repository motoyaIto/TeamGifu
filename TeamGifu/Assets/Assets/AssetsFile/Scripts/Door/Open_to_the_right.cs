using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Open_to_the_right : MonoBehaviour {

    private bool doorSwitch = false;
    private float size_X = 0.0f;


	// Use this for initialization
	void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
		
        if(doorSwitch == true)
        {

            if (this.transform.position.z <= 5.0f)
            {
                Vector3 move = new Vector3(0f, 0f, 0.1f);

                this.transform.position += move;
            }

        }
	}

    public void SetDoorSwitch(bool state)
    {
        doorSwitch = state;
    }
}
