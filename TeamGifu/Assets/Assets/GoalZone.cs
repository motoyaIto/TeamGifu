using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalZone : MonoBehaviour {

    private bool Goal = false;

    [SerializeField]
    private GameObject Fireworks1;
    private Fireworks_Controller fc1;

    [SerializeField]
    private GameObject Fireworks2;
    private Fireworks_Controller fc2;

    private float count = 0.0f;
    // Use this for initialization
    void Start()
    {
        fc1 = Fireworks1.GetComponent<Fireworks_Controller>();
        fc2 = Fireworks2.GetComponent<Fireworks_Controller>();
    }
	// Update is called once per frame
	void Update () {
        if(Goal == true)
        {
            count++;

            if(count / 60.0f >= 3.0f)
            {
                SceneManager.LoadScene("Title");
            }
        }
       
	}

    private void OnTriggerEnter(Collider other)
    {
        Goal = true;

        fc1.SetFire(true);
        fc2.SetFire(true);
    }

    public bool GoalFlag()
    {
        return Goal;
    }
}
