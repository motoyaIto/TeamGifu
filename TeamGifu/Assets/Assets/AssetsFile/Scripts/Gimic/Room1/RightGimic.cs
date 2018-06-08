using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGimic : MonoBehaviour {

    //プレファブ生成するアイテム
    private GameObject PrefabItem;
    [SerializeField, Header("ItemListControllerのオブジェ")]
    private ItemListController _item;
    [SerializeField, Header("固定オブジェの座標")]
    private Vector3 ObjPos;
    [SerializeField, Header("Rayのオブジェクト")]
    private ray _ray;
    private const string TagName = "Sphere";
    [SerializeField]
    Vector3 OffsetPos;
    [SerializeField, Header("trueの場合は左")]
    private bool Derection = false;
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


        if (gameObject.name== _ray.RayHitNameState && _ray.LockObjFlagState && TagName == _item.GetSelectImage())
        {
             GameObject obj= Instantiate(PrefabItem, ObjPos, transform.rotation);
            obj.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);

            obj.transform.parent = GameObject.Find("swich_2").transform;
            _ray.LockObjFlagState = false;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Item")
        {
            OnSwitch = true;
            GetComponent<Collider>().enabled = false;
        }
    }
    public bool GetOnSwitch()
    {
        return OnSwitch;
    }
}
