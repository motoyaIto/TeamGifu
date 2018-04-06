using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityStandardAssets.Characters.FirstPerson;
public class A_doubt : MonoBehaviour {


    // Update is called once per frame
    void Update () {
        //Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
        Ray ray = new Ray(transform.position, new Vector3(1, 0, 0));

        //Rayが当たったオブジェクトの情報を入れる箱
        RaycastHit hit;

        //Rayの飛ばせる距離


        //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　　　　　　↓Rayの     
        if (Physics.Raycast(ray, out hit))
        {
            //Rayが当たったオブジェクトのtagがPlayerだったら
            if (hit.collider.tag == "cube")
                Debug.Log("Rayがcubeに当たった");
        }
        //
    }
}

