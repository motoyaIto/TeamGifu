using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour {

    private HanoinotouController _parentScript;

    [SerializeField]
    private int namber;

    // Use this for initialization
    void Start () {
        //親オブジェクトを取得
        _parentScript = transform.root.gameObject.GetComponent<HanoinotouController>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            _parentScript.ClickController(namber);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        _parentScript.ClickController(namber);
    }
}
