using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Controller : MonoBehaviour {
    // ~~ 使うギミックたち ~~ //
    public Light[] lights;
    public GameObject[] switch_box;

    // 連続成功回数
    private int count;

    public static string name;
    public string name_state { get { return name; } set{ name = value; } }

    private void Start()
    {
        name = "";
        State_Reset();
    }

    /// <summary>
    /// 全ての状態をリセットする
    /// </summary>
    public void State_Reset()
    {
        for(int i = 0; i < 9; i++)
        {
            // 1つ目のライト以外を消す & スイッチの出現・消滅
            if (i != 0)
            {
                switch_box[i].SetActive(false);
                lights[i].intensity = 0.0f;
            }
            else
            {
                switch_box[i].SetActive(true);
                lights[i].intensity = 2.5f;
                lights[i].color = new Vector4(1, 1, 1, 1);
            }
        }
        count = 0;
    }

    /// <summary>
    /// 出現時：TRUE, 非表示：FALSE
    /// </summary>
    /// <returns>反転して返す</returns>
    public bool NowActive(bool e)
    {
        if (e)
        {
            e = false;
        }
        else
        {
            e = true;
        }
        return e;
    }

    public int GetCount()
    {        
        return count;
    }

    public void CountUp()
    {
        count++;
    }

    public Vector4 GetColor()
    {        
        Vector4 color = Vector4.one;
        switch (name)
        {
            case "RedBox":
                Debug.Log("入った");
                color = new Vector4(1, 0, 0, 1);
                break;
            case "GreenBox":
                color = new Vector4(0, 1, 0, 1);
                break;
            case "BlueBox":
                color = new Vector4(0, 0, 1, 1);
                break;
        }
        return color;
    }
}
