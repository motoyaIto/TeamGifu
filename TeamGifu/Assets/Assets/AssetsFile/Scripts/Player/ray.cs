using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour {
    #region variable
    public static bool flag;
    

    private GameObject HitObj;//ヒットしたオブジェクト
    [SerializeField]
    private Camera camera;
    Ray _ray;

    [SerializeField]
   private string[] objName; 
    #endregion

    #region Event
    // Use this for initialization
    void Start()
    {
        objName = new string[5];
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _ray = camera.ScreenPointToRay(Input.mousePosition);
        }
        //Rayが当たったオブジェクトの情報を入れる箱
        RaycastHit hit;

        //Rayの飛ばせる距離
        int distance = 10;

        //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　　　　　　↓Rayの     
        if (Physics.Raycast(_ray, out hit))
        {
            
            //Rayが当たったオブジェクトのtagがPlayerだったら
            if (hit.collider.tag == "cube")
            {
                Debug.Log(hit.collider.name);
                for (int i = 0; i < 4; i ++)
                {
                    if(objName[i]==null)
                    {
                        if (objName[i] != hit.collider.name)
                        {
                            objName[i] = hit.collider.name;
                            break;
                        }
                    }
                }
            }
        }
    }


    #endregion

}
