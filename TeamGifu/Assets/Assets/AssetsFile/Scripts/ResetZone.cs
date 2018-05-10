using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Vector3 ResetPos = new Vector3(-91.75f, 14f, -74f);
        other.transform.position = ResetPos;
    }
}
