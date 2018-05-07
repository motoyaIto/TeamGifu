using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Open_to_the_left : MonoBehaviour {

    private bool doorSwitch = false;
    private bool CloseSwith = false;
    public bool CloseSwithState
    {
        set
        {
            CloseSwith = value;
        }
    }
    private float size_X = 0.0f;

    [SerializeField]
    private float Movepos_Z = -5.0f;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
       
        if (doorSwitch == true)
        {
            transform.DOLocalMove(new Vector3(5.0f, 0, -0.55f), 2.0f);
            CloseSwith = true;
        }
        if (doorSwitch == false&&CloseSwith==true)
        {
            transform.DOLocalMove(new Vector3(3.0564f, 0, -0.55f), 2.0f);
        }

    }

    public void SetDoorSwitch(bool state)
    {
        doorSwitch = state;
    }
}
