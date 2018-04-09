using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour {

    private bool Goal = false;

    [SerializeField]
    private GameObject Fireworks1;
    private Fireworks_Controller fc1;

    [SerializeField]
    private GameObject Fireworks2;
    private Fireworks_Controller fc2;

    [SerializeField]
    private GameObject Fireworks3;
    private Fireworks_Controller fc3;

    // Use this for initialization
    void Start()
    {
        fc1 = Fireworks1.GetComponent<Fireworks_Controller>();
        fc2 = Fireworks2.GetComponent<Fireworks_Controller>();
        fc3 = Fireworks3.GetComponent<Fireworks_Controller>();
    }
	// Update is called once per frame
	void Update () {
       
	}

    private void OnTriggerEnter(Collider other)
    {
        Goal = true;

        fc1.SetFire(true);
        fc2.SetFire(true);
        fc3.SetFire(true);
    }

    public bool GoalFlag()
    {
        return Goal;
    }
}
