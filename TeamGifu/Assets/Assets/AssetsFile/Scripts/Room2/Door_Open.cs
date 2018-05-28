using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour {
    #region  
    [SerializeField]  
    private bool open_Flag;  // ドアを開けるためのフラグ

    private Material mtl;   // 変更するマテリアル
    private GameObject obj;   // 変更するObject
    [HideInInspector]
    public bool Lock_State;    // 今のロック状態

    #endregion

    private void Awake()
    {
        //mtl = GetComponent<Renderer>().material;
        open_Flag = false;
        Lock_State = false;
    }

    public void Check()
    {
        if (open_Flag & !Lock_State)
        {
            UnLock();
        }
        else
        {
            Debug.Log("合ってないよ");
        }
        
    }

    // 鍵の解錠
    private void UnLock()
    {
        ReplaceMaterial(mtl);
        Lock_State = true;
    }

    // マテリアルの変更
    private void ReplaceMaterial(Material mat)
    {
        obj.GetComponent<Renderer>().material = mat;
    }
}
