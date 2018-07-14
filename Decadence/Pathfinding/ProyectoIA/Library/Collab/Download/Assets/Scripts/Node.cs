using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE
{
    NORMAL,
    STAR,
    END,
    OBSTACLE,
    
}

public class Node : MonoBehaviour {

    public int iID, x, y;
    public TYPE type;
    int iCost, iCostNow;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
