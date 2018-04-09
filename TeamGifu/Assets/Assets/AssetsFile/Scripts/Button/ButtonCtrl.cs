using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCtrl : BaseButton{
    private string[] AitemName;
    private void Start()
    {
        AitemName = new string[5];
    }
    private void Update()
    {
        for(int i=0;i<4;i++)
        {
            if(ray.objName[i]!=null)
            {
                AitemName[i] = ray.objName[i];
            }
        }

    }
    protected override void OnClick(string objectName)
    {
        // 渡されたオブジェクト名で処理を分岐
        //（オブジェクト名はどこかで一括管理した方がいいかも）
        if ("Button1".Equals(objectName))
        {
            // Button1がクリックされたとき
            this.Button1Click();
        }
        else if ("Button2".Equals(objectName))
        {
            // Button2がクリックされたとき
            this.Button2Click();
        }
        else if ("Button3".Equals(objectName))
        {
            // Button2がクリックされたとき
            this.Button3Click();
        }
        else if ("Button4".Equals(objectName))
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
        Debug.Log("Button1 Click");
    }

    private void Button2Click()
    {
        Debug.Log("Button2 Click");
    }
    private void Button3Click()
    {
        Debug.Log("Button3 Click");
    }
    private void Button4Click()
    {
        Debug.Log("Button4 Click");
    }
}
