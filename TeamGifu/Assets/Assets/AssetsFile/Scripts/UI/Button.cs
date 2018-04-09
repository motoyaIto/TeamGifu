using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
    public Button button;
    

    public void OnClick()
    {

        //例外処理
        if (button == null)
        {
            throw new System.Exception("Button instance is null");
        }
        //自身のオブジェクト名を渡す
        button.OnClick(this.gameObject.name);
    }
    protected virtual void OnClick(string objectName)
    {
        Debug.Log("BaseButton");
    }
}
