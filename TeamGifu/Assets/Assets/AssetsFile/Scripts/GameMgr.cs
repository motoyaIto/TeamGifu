using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // 
        SoundManager.LoadBgm("bgm", "BGM");
        SoundManager.LoadSe("gate", "GateOpen");
        SoundManager.LoadSe("unlock", "unlocking-1");
        SoundManager.LoadSe("button", "puni");
        SoundManager.LoadSe("getItem", "magic-cure1");
        SoundManager.LoadSe("pushItem", "warp1");
        SoundManager.LoadSe("selectItem", "cursor1");
        SoundManager.LoadSe("bag", "SystemSelect");
        SoundManager.LoadSe("start", "SystemSelect1");


        SoundManager.PlayBgm("bgm");

    }

    // Update is called once per frame
    void Update () {
		
	}
}
