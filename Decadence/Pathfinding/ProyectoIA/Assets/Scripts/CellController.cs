using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    public bool isStart, isEnd, isObstacle;
    Manager managerScript;
    Pathfinding pathScript;
    int clickedNode;
    Node currNodescript;
    public GameObject manager;
    public GameObject pathObject;
    public Renderer[] renderer;
    //bool isBFS, isDFS, isDIJS, isBESTF, ASTAR;
    // Use this for initialization
    void Start()
    {
        renderer = GetComponentsInChildren<Renderer>();
        managerScript = manager.GetComponent<Manager>();
        pathScript = pathObject.GetComponent<Pathfinding>();

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {

            foreach (Renderer rend in renderer)
            {
                if (rend.gameObject.tag == "Node")
                {
                    currNodescript = rend.gameObject.GetComponent<Node>();

                    if (!managerScript.isStartSelected && !currNodescript.isEnd && !currNodescript.isObstacle)
                    {
                        rend.material.SetColor("_Color", Color.red);
                        rend.enabled = !rend.enabled;
                        clickedNode = currNodescript.iID;
                        managerScript.isStartSelected = true;
                        //isStart = true;
                        currNodescript.isStart = true;
                        if(clickedNode >0)
                        pathScript.nodes[clickedNode-1].type = TYPE.STAR;
                        else
                            pathScript.nodes[0].type = TYPE.STAR;
                        //pathScript.startNode = currNodescript;
                        if (managerScript.isBFS)
                            pathScript.openList.Enqueue(currNodescript);
                        else if (managerScript.isDFS)
                            pathScript.openLstStack.Push(currNodescript);

                    }

                    else if (currNodescript.isStart)
                    {
                        rend.enabled = !rend.enabled;
                        managerScript.isStartSelected = false;
                        //isStart = false;
                        currNodescript.isStart = false;
                        if (clickedNode > 0)
                            pathScript.nodes[clickedNode-1].type = TYPE.NORMAL;
                        else
                            pathScript.nodes[0].type = TYPE.NORMAL;
                        //pathScript.startNode = null;
                        if (managerScript.isBFS)
                            pathScript.openList.Dequeue();
                        else if (managerScript.isDFS)
                            pathScript.openLstStack.Pop();
                    }
                }

            }
            
        }
        if (Input.GetMouseButtonDown(1))
        {

            foreach (Renderer rend in renderer)
            {
                if (rend.gameObject.tag == "Node")
                {
                    currNodescript = rend.gameObject.GetComponent<Node>();
                    if (!managerScript.isEndSelected && !currNodescript.isStart && !currNodescript.isObstacle)
                    {
                        clickedNode = currNodescript.iID;
                        rend.material.SetColor("_Color", Color.blue);
                        rend.enabled = !rend.enabled;
                        managerScript.isEndSelected = true;
                        currNodescript.isEnd = true;
                        if (clickedNode > 0)
                            pathScript.nodes[clickedNode-1].type = TYPE.END;
                        else
                            pathScript.nodes[0].type = TYPE.END;

                    }
                    else if (currNodescript.isEnd)
                    {
                        rend.enabled = !rend.enabled;
                        managerScript.isEndSelected = !managerScript.isEndSelected;
                        currNodescript.isEnd = false;
                        if (clickedNode > 0)
                            pathScript.nodes[clickedNode-1].type = TYPE.NORMAL;
                        else
                            pathScript.nodes[0].type = TYPE.NORMAL;

                    }
                }
            }
            
        }
        if (Input.GetMouseButtonDown(2))
        {

            foreach (Renderer rend in renderer)
            {
                

                if (rend.gameObject.tag == "Node")
                {
                    currNodescript = rend.gameObject.GetComponent<Node>();
                    clickedNode = currNodescript.iID;
                    Debug.Log(clickedNode);
                    
                }
                if (rend.gameObject.tag == "Obstacle" && !currNodescript.isStart && !currNodescript.isEnd)
                {
                    rend.enabled = !rend.enabled;
                    currNodescript.isObstacle = !currNodescript.isObstacle;

                    if (currNodescript.isObstacle)
                    {
                        if (clickedNode > 0)
                            pathScript.nodes[clickedNode - 1].type = TYPE.OBSTACLE;
                        else
                            pathScript.nodes[0].type = TYPE.OBSTACLE;
                    }
                    else if (!isObstacle)
                    { 
                        if (clickedNode > 0)
                            pathScript.nodes[clickedNode - 1].type = TYPE.NORMAL;
                        else
                            pathScript.nodes[0].type = TYPE.NORMAL;
                    }
                }


            }

        }
    }


    void Update()
    {

    }
}
