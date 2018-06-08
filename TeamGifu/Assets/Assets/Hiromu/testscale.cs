using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.1f);
        //Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
