using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoinotouController : MonoBehaviour {

    [SerializeField]
    Camera PlayerCamera;//プレイヤーカメラ
    [SerializeField]
    Camera HanoiCamera;//ハノイの塔

    GameObject Ring1, Ring2, Ring3;

	// Use this for initialization
	void Start () {
        Ring1 = gameObject.transform.Find("Ring1").gameObject;
        Ring2 = gameObject.transform.Find("Ring2").gameObject;
        Ring3 = gameObject.transform.Find("Ring3").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReturnButton()
    {
        //プレイヤー用のカメラに切り替え
        PlayerCamera.enabled = true;
        HanoiCamera.enabled = false;
    }
}
