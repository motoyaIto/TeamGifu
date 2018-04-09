using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks_Controller : MonoBehaviour {

    private bool Fire = false;

    private ParticleSystem ps;

    private bool theck = false;

	// Use this for initialization
	void Start () {
        ps = this.GetComponent<ParticleSystem>();
        ps.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		if(Fire == true && theck == false)
        {

            theck = true;
              
            ps.Play();
        }
	}

    public void SetFire(bool fire)
    {
        Fire = fire;
    }
}
