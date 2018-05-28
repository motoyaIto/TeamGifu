using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour {
    [SerializeField]
    private Vector3 ItemoffsetPos = Vector3.zero;
    [SerializeField]
    private ItemListController item;
    GameObject PrefabItem;
    [SerializeField]
    GameObject child;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (item.CreateAitemState)
        {
            //既に生成されていれば
            if (PrefabItem != null)
            {
                Destroy(child);//破棄
            }
            //生成するオブジェクトを取得
            PrefabItem = (GameObject)Resources.Load("Prefabs/" + item.GetSelectImage());
            //アイテムの生成
            child = Instantiate(PrefabItem, transform.position+ItemoffsetPos, transform.rotation) as GameObject;
            //スケールの縮小
            child.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            item.CreateAitemState = false;
            //コンポーネントを破棄
            Destroy(child.GetComponent<Rigidbody>());
            //手のオブジェクトの子にする
            child.transform.parent = GameObject.Find("Hand").transform;

        }


    }
}
