using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FadaText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<TextMeshProUGUI>().alpha = 0.0f;


    }
	
	// Update is called once per frame
	void Update () {



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hit")
        {
            Debug.Log("hit");
            fadeFunction();

        }
    }
    public void fadeFunction()
    {
        this.GetComponent<TextMeshProUGUI>().enabled = true;

        this.GetComponent<TextMeshProUGUI>()
    .DOFade(1.0f,3.0f)
    .Play();
    }
}
