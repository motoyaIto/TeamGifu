using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {

    [SerializeField]
    private Image bag;
    [SerializeField]
    private Image cursor;
    [SerializeField]
    private Image returnButton;

    bool HanoinoTouFlag = false;

    // Use this for initialization
    void Start () {
        returnButton.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void HanoinoTou()
    {
        returnButton.enabled = true;

        bag.enabled = false;
        cursor.enabled = false;

        HanoinoTouFlag = true;
    }

    public void ReturnButton()
    {
        returnButton.enabled = false;

        bag.enabled = true;
        cursor.enabled = true;

        HanoinoTouFlag = false;
    }

    public bool GetHanoinoTouFlag()
    {
        return HanoinoTouFlag;
    }
}
