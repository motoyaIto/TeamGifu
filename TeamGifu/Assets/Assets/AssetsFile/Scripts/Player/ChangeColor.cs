using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
    public GameObject myCube;
    // Use this for initialization
    void Start () {
        myCube = GameObject.Find("obj");

    }

    // Update is called once per frame
    void Update () {
        if(ray.flag)
        {
            myCube.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            myCube.GetComponent<Renderer>().material.color = Color.white;

        }

    }
}
