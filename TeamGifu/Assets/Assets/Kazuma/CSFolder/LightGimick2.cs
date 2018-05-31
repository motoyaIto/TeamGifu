using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGimick2 : MonoBehaviour {

    //プレファブ生成するアイテム
    private GameObject PrefabItem;
    [SerializeField, Header("ItemListControllerのオブジェ")]
    private ItemListController _item;
    [SerializeField, Header("固定オブジェの座標")]
    private Vector3 ObjPos;
    [SerializeField, Header("Rayのオブジェクト")]
    private ray _ray;

    private const string CreateName = "Battery_small_06 (1)";//固定オブジェクトに出す名前
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
        if (gameObject.name == _ray.RayHitNameState && _ray.LockObjFlagState && CreateName == _item.GetSelectImage())
        {
            GameObject obj = Instantiate(PrefabItem, new Vector3(ObjPos.x, ObjPos.y, ObjPos.z), transform.rotation);
            //obj.transform.parent = GameObject.Find("swich_1").transform;

            _ray.LockObjFlagState = false;


        }
        else if (gameObject.name == _ray.RayHitNameState && _ray.LockObjFlagState)
        {

            //生成するオブジェクトを取得
            GameObject DummyPrefabItem = (GameObject)Resources.Load("Prefabs/" + _item.GetSelectImage());
            GameObject obj = Instantiate(DummyPrefabItem, new Vector3(ObjPos.x, ObjPos.y, ObjPos.z), transform.rotation);

        }

    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("HitCapsel");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HitCapsel");
        if (collision.gameObject.tag == "Item")
        {
            //OnSwitch = true;
            GetComponent<Collider>().enabled = false;
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("HitCapsel");
    //    if (other.gameObject.tag == "LockHit")
    //    {
    //        //OnSwitch = true;
    //        GetComponent<Collider>().enabled = false;
    //    }
    //}
    public bool GetOnSwitch()
    {
        return OnSwitch;
    }
    
}
