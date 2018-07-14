using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Manager : MonoBehaviour {

    public bool isStartSelected = false, isEndSelected = false;
    Pathfinding pathScript;
    public GameObject pathObject;
    public Toggle BFSToggle, DFSToggle, DIJToggle, BESTToggle, ASToggle;
    public bool isBFS, isDFS, isDIJS, isBESTF, ASTAR;
    // Use this for initialization
    void Start () {
        pathScript = pathObject.GetComponent<Pathfinding>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartAlgo()
    {
        if(isBFS)
        {
            pathScript.algoritm = ALGORITM.BFS;
        }
        else if(isDFS)
        {
            pathScript.algoritm = ALGORITM.DFS;

        }
        else if (isDIJS)
        {
            pathScript.algoritm = ALGORITM.DIJKSTRA;

        }
        else if(isBESTF)
        {
            pathScript.algoritm = ALGORITM.BESTF;

        }
        else if(ASTAR)
        {
            pathScript.algoritm = ALGORITM.ASTAR;

        }
    }

    public void setBFS()
    {
        isBFS = true;
        DFSToggle.enabled = !DFSToggle.enabled;
        DIJToggle.enabled = !DIJToggle.enabled;
        BESTToggle.enabled = !BESTToggle.enabled;
        ASToggle.enabled = !ASToggle.enabled;
        

    }
    public void setDFS()
    {
        isDFS = true;
        BFSToggle.enabled = !BFSToggle.enabled;
        DIJToggle.enabled = !DIJToggle.enabled;
        BESTToggle.enabled = !BESTToggle.enabled;
        ASToggle.enabled = !ASToggle.enabled;

    }
    public void setDIJS()
    {
        isDIJS = true;
        DFSToggle.enabled = !DFSToggle.enabled;
        BFSToggle.enabled = !BFSToggle.enabled;
        BESTToggle.enabled = !BESTToggle.enabled;
        ASToggle.enabled = !ASToggle.enabled;

    }
    public void setBest()
    {
        isBESTF = true;
        DFSToggle.enabled = !DFSToggle.enabled;
        DIJToggle.enabled = !DIJToggle.enabled;
        BFSToggle.enabled = !BFSToggle.enabled;
        ASToggle.enabled = !ASToggle.enabled;

    }
    public void setAS()
    {
        ASTAR = true;
        DFSToggle.enabled = !DFSToggle.enabled;
        DIJToggle.enabled = !DIJToggle.enabled;
        BESTToggle.enabled = !BESTToggle.enabled;
        BFSToggle.enabled = !BFSToggle.enabled;

    }
}
