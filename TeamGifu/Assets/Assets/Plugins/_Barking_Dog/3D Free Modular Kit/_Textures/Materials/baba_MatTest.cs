using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baba_MatTest : MonoBehaviour {
    
    public Material blueMat;
    public Renderer renderer;
    
	void Update () {
		if ( Input.GetKeyDown( KeyCode.Z ))
        {
            renderer.material = blueMat;
        }
	}
}
