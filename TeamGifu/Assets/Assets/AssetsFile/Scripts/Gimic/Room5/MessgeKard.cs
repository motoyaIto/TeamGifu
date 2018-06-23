using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessgeKard : MonoBehaviour {
    [SerializeField]
   private FadaText fadeText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Hit")
        {
            fadeText.fadeFunction();
        }
        
    }
}
