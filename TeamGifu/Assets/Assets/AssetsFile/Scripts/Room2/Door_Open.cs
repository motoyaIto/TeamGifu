using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour {
    #region
    [HideInInspector]
    public bool open_Flag;  // ドアを開けるためのフラグ

    [SerializeField]
    private Material mtl;   // 変更するマテリアル
    [SerializeField]
    private GameObject obj;   // 変更するObject

    private bool Lock_State;    // 今のロック状態

    #endregion

    private void Awake()
    {
        //mtl = GetComponent<Renderer>().material;
        open_Flag = false;
        Lock_State = true;
    }

    public void IsTrue()
    {
        if (Lock_State)
        {
            UnLock();
        }
        
    }

    // 鍵の解錠
    private void UnLock()
    {
        ReplaceMaterial(mtl);
        open_Flag = true;
    }

    // マテリアルの変更
    private void ReplaceMaterial(Material mat)
    {
        obj.GetComponent<Renderer>().material = mat;
    }
}
