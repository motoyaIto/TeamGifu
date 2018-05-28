using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour {
    public GameObject obj;

    public void Clear()
    {
        obj.SetActive(false);
    }
}
