using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoinotouController : MonoBehaviour {

    GameObject Ring1, Ring2, Ring3;

	// Use this for initialization
	void Start () {
        Ring1 = gameObject.transform.Find("Ring1").gameObject;
        Ring2 = gameObject.transform.Find("Ring2").gameObject;
        Ring3 = gameObject.transform.Find("Ring3").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
