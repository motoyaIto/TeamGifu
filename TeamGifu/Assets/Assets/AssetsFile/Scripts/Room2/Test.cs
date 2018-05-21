using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public GameObject obj;
    public Material mtl;

	// Use this for initialization
	void Start () {
        
	}
	
    public void Action()
    {
        Debug.Log("Change!!");
        obj.GetComponent<Renderer>().material = mtl;
    }
}
