using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour {
    public static bool flag;
	// Use this for initialization
	void Start () {
        flag = false;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(transform.position, new Vector3(0, 0, 1));

        //Rayが当たったオブジェクトの情報を入れる箱
        RaycastHit hit;

        //Rayの飛ばせる距離
        int distance = 10;

        //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　　　　　　↓Rayの     
        if (Physics.Raycast(ray, out hit))
        {
            //Rayが当たったオブジェクトのtagがPlayerだったら
            if (hit.collider.tag == "cube")
            {
                Debug.Log("Rayがcubeに当たった");
                flag = true;
            }
   

        }
        else
        {
            flag = false;
        }
    }
}
