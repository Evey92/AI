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

    public bool isStart, isEnd, isObstacle;
    public int iID;
    public Vector2 coords;
    public Node parent;
    public bool visited = false;

    public TYPE type;
    int iCost, iCostNow;
    
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
