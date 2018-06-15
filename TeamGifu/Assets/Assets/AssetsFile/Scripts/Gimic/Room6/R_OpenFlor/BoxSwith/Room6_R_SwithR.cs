using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room6_R_SwithR : MonoBehaviour {

    //プレファブ生成するアイテム
    private GameObject PrefabItem;
    [SerializeField, Header("ItemListControllerのオブジェ")]
    private ItemListController _item;
    [SerializeField, Header("固定オブジェの座標")]
    private Vector3 ObjPos;
    [SerializeField, Header("Rayのオブジェクト")]
    private ray _ray;
    private GameObject CreateObj;
    //クリアー判定の名前
    private const string CleaerName = "Sphere(Clone)";
    bool clearFlag;
    public bool clearFlagState
    {
        get
        {
            return clearFlag;
        }
    }
    private bool OnSwitch = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //生成するオブジェクトを取得
        PrefabItem = (GameObject)Resources.Load("Prefabs/" + _item.GetSelectImage());


        //ゲームオブジェクトの名前とRayに当たっているオブジェクト名が一緒か＆＆固定オブジェクトに当たっているか＆＆出すオブジェクトと選択しているアイテムの名前が一緒か
        if (gameObject.name == _ray.RayHitNameState && _ray.LockObjFlagState)
        {
            if(CreateObj==null)
            {
                CreateObj = Instantiate(PrefabItem, transform.TransformPoint(ObjPos), transform.rotation);
                CreateObj.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                CreateObj.transform.parent = GameObject.Find("RightSwith").transform;

                _ray.LockObjFlagState = false;
                Debug.Log("生成");
            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == CleaerName)
        {
            clearFlag = true;
        }

    }

    public bool GetOnSwitch()
    {
        return OnSwitch;
    }
}
