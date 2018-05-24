using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeightData : ScriptableObject {

    [SerializeField]
	private int weight5, weight10, weight15, weight20;

    public int GetWeight5()
    {
        return weight5;
    }

    public int GetWeight10()
    {
        return weight10;
    }

    public int GetWeight15()
    {
        return weight15;
    }

    public int GetWeight20()
    {
        return weight20;
    }
}
