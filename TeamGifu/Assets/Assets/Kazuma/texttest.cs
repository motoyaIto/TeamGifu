using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class texttest : MonoBehaviour {
    public TextMeshProUGUI text;
    public WeightGimmick weight;
	// Use this for initialization
	void Start () {
        text = GetComponent<TextMeshProUGUI>();

     
	}
	
	// Update is called once per frame
	void Update () {
        text.SetText(weight.SumState.ToString()+"g");

    }
}
