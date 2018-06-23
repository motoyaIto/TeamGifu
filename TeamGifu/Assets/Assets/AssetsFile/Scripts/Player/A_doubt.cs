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


    }
}

