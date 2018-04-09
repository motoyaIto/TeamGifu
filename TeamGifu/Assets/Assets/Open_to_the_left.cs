using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Open_to_the_left : MonoBehaviour {

    private bool doorSwitch = false;
    private float size_X = 0.0f;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (doorSwitch == true)
        {
          
            transform.DOLocalMove(new Vector3(-(this.transform.position.x + this.transform.localScale.x * 1), 0, 0), 0.5f);
        }
    }

    public void SetDoorSwitch(bool state)
    {
        doorSwitch = state;
    }
}
