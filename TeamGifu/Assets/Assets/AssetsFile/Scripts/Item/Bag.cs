using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour {
   
    static Canvas bag;

	// Use this for initialization
	void Start () {
        bag = GetComponent<Canvas>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void SetActive(string name, bool b)
    {
        foreach(Transform child in bag.transform)
        {
            if(child.name == name)
            {
                child.gameObject.SetActive(b);

                return;
            }
        }
    }
}
