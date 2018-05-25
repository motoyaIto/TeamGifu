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
        Lock_State = false;
    }

    public void IsTrue()
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
