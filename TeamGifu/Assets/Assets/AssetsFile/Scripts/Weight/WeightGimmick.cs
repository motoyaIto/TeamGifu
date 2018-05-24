using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightGimmick : MonoBehaviour {

    [SerializeField]
    private WeightData data;
	// Use this for initialization
	void Start () {
        //int count = 0;
        //foreach (Transform child in transform)
        //{
        //    //child is your child transform

        //    Debug.Log("Child[" + count + "]:" + child.name);
        //    count++;
            
        //}
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
    }
}
