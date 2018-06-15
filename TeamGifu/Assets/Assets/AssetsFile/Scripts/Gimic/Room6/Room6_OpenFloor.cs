using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Room6_OpenFloor : MonoBehaviour {
    [SerializeField]
    private GameObject RightFloor;
    [SerializeField]
    private Vector3 RightPos;

    [SerializeField]
    private GameObject LeftFloor;
    [SerializeField]
    private Vector3 LeftPos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RightFloor.transform.DOMove(RightPos, 2.0f);
            LeftFloor.transform.DOMove(LeftPos, 2.0f);

        }

		
	}
}
