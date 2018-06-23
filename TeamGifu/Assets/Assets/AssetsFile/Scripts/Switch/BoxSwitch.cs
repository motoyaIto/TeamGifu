using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSwitch : MonoBehaviour {
    //プレファブ生成するアイテム
    private GameObject PrefabItem;
    [SerializeField,Header("ItemListControllerのオブジェ")]
    private ItemListController _item;
    [SerializeField, Header("固定オブジェの座標")]
    private Vector3 ObjPos;
    [SerializeField,Header("Rayのオブジェクト")]
    private ray _ray;
    private const string TagName = "Sphere";
    [SerializeField]
    Vector3 OffsetPos;
    [SerializeField,Header("trueの場合は左")]
    private bool Derection=false;

    private bool OnSwitch = false;

    // Use this for initialization
    void Start() {


    }
     
    // Update is called once per frame
    void Update() {


        if (gameObject.name==""&& _ray.LockObjFlagState && TagName == _item.GetSelectImage())
        {
            Instantiate(PrefabItem, ObjPos, transform.rotation);

            _ray.LockObjFlagState = false;

        }





    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Item")
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
