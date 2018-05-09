using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private Material mat;

	// Use this for initialization
	void Start () {
        this.mat = GetComponent<Renderer>().material;
		
	}
	
	// Update is called once per frame
	void Update () {
        float y = Mathf.PingPong(Time.time, 10.0f);
        GetComponent<Renderer>().sharedMaterial.SetFloat("_Height", y);

        
		
	}
}
