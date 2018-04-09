using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : Button {
    private string[] AitemName;
    private ray _ray;
    private void Start()
    {
        AitemName = new string[4];
        _ray = new ray();
        
    }
    private void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if(ray.objName[i]!=null)
            AitemName[i] = ray.objName[i];
        }
    }

    protected override void OnClick(string objectName)
    {
        // 渡されたオブジェクト名で処理を分岐
        //（オブジェクト名はどこかで一括管理した方がいいかも）
        if ("Aitem1".Equals(objectName))
        {
            // Button1がクリックされたとき
            this.Button1Click();
        }
        else if ("Aitem2".Equals(objectName))
        {
            // Button2がクリックされたとき
            this.Button2Click();
        }
        else if ("Aitem3".Equals(objectName))
        {
            // Button2がクリックされたとき
            this.Button3Click();
        }
        else if ("Aitem4".Equals(objectName))
        {
            // Button2がクリックされたとき
            this.Button4Click();
        }
        else
        {
            throw new System.Exception("Not implemented!!");
        }
    }

    private void Button1Click()
    {
        Debug.Log("Aitem1 Click");
    }

    private void Button2Click()
    {
        Debug.Log("Aitem2 Click");
    }
    private void Button3Click()
    {
        Debug.Log("Aitem3 Click");
    }
    private void Button4Click()
    {
        Debug.Log("Aitem4 Click");
    }
}
