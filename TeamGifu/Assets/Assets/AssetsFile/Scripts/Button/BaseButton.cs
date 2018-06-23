using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButton : MonoBehaviour {
    public BaseButton button;

    public void OnClick()
    {
        if (button == null)
        {
            throw new System.Exception("Button instance is null!!");
        }
    }
}
