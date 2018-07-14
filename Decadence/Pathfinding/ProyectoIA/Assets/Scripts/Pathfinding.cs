using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ALGORITM
{
    DEFAULT,
    ASTAR,
    BFS,
    DFS,
    DIJKSTRA,
    BESTF
}

public class Pathfinding : MonoBehaviour {
    //public int[,]  NodeGrid;
    public List<GameObject> GridContainer = new List<GameObject>();
    public ALGORITM algoritm = ALGORITM.DEFAULT;
    public Node[] nodes;
    public Node startNode, currentNode;
    int nodeId;
    bool start = false;
    public Queue<Node> openList = new Queue<Node>();
    public Stack<Node> openLstStack = new Stack<Node>();
    bool isBFS, isDFS, isDIJS, isBESTF, ASTAR;

    // Use this for initialization
    void Start()
    {

        nodes = GetComponentsInChildren<Node>();
        //NodeGrid = new int[10, 10];
        int currNode = 1;

        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                //Debug.Log(currNode - 1);
                nodes[currNode-1].coords = new Vector2(x + 1, y + 1);

                currNode++;
            }
        }
        
       
        foreach (Node node in nodes)
        {
            node.iID = nodeId;
            nodeId++;
        }

    }

	// Update is called once per frame
	void Update () {
        foreach (Node node in nodes)
        {
            if(node.isStart)
            {
                startNode = node;
            }
            
        }
        if (openList.Count < 0)
            Debug.Log("Aun no tengo start!");
        //if(start)
         runAlgo();
        //if(nodes[11])

    }


    
    public void runAlgo()
    {
        switch (algoritm)
        {
            case ALGORITM.DEFAULT:
                break;
            case ALGORITM.ASTAR:
                AStar_PF();
                break;
            case ALGORITM.BFS:
                isBFS = true;
                BFS_PF();
                //algoritm = ALGORITM.DEFAULT;
                break;
            case ALGORITM.DFS:
                isDFS = true;
                DFS_PF();
                break;
            case ALGORITM.DIJKSTRA:
                Dijkstra_PF();
                break;
            case ALGORITM.BESTF:
                BestFS_PF();
                break;
        }
    }

    void AStar_PF()
    {
        Debug.Log("Pues se activo A*");
        algoritm = ALGORITM.DEFAULT;
    }
    void BFS_PF()
    {
        Debug.Log("Buscando Path con BFS");
        if (openList.Count > 0)
        {
            currentNode = openList.Dequeue();
            currentNode.visited = true;
            //Debug.Log("Estoy checando el nodo: " + currentNode.iID);
            //currentNode.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);

            if (currentNode.isEnd)
            {
                Debug.Log("Encontre el final! es: (" + currentNode.coords + ", " + currentNode.coords.y + ")");
                algoritm = ALGORITM.DEFAULT;
                return;

            }

            float x, y;

            //ESTE
            x = currentNode.coords.x + 1;
            y = currentNode.coords.y;
            if (currentNode.coords.x < 9)
            {
                VisitNode(GetNode(x, y));
            }

            //SUD-ESTE
            x = currentNode.coords.x + 1;
            y = currentNode.coords.y + 1;
            if (currentNode.coords.x < 9 && currentNode.coords.y < 9)
            {
                VisitNode(GetNode(x, y));
            }

            //SUR
            x = currentNode.coords.x;
            y = currentNode.coords.y + 1;
            if (currentNode.coords.y < 9)
            {
                VisitNode(GetNode(x, y));
            }

            //SUD-OESTE
            x = currentNode.coords.x - 1;
            y = currentNode.coords.y + 1;
            if (currentNode.coords.y < 9 && currentNode.coords.x > 0)
            {
                VisitNode(GetNode(x, y));
            }

            //OESTE
            x = currentNode.coords.x - 1;
            y = currentNode.coords.y;
            if (currentNode.coords.x > 0)
            {
                VisitNode(GetNode(x, y));
            }

            //NOR-OESTE
            x = currentNode.coords.x - 1;
            y = currentNode.coords.y - 1;
            if (currentNode.coords.x > 0 && currentNode.coords.y > 0)
            {
                VisitNode(GetNode(x, y));
            }

            //NORTE
            x = currentNode.coords.x;
            y = currentNode.coords.y - 1;
            if (currentNode.coords.y > 0)
            {
                VisitNode(GetNode(x, y));
            }

            //NOR-ESTE
            x = currentNode.coords.x + 1;
            y = currentNode.coords.y - 1;
            if (currentNode.coords.y > 0 && currentNode.coords.x < 9)
            {
                VisitNode(GetNode(x, y));
            }

            if (!currentNode.isStart)
                currentNode.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);

        }
        else
        {
            Debug.Log("Esta vacía.");
            algoritm = ALGORITM.DEFAULT;
        }
    }
    void DFS_PF()
    {

        {
            Debug.Log("Buscando Path con DFS");
            if (openLstStack.Count > 0)
            {
                currentNode = openLstStack.Pop();
                currentNode.visited = true;
                //Debug.Log("Estoy checando el nodo: " + currentNode.iID);
                //currentNode.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);

                if (currentNode.isEnd)
                {
                    Debug.Log("Encontre el final! es: (" + currentNode.coords + ", " + currentNode.coords.y + ")");
                    algoritm = ALGORITM.DEFAULT;
                    return;

                }

                float x, y;

                //ESTE
                x = currentNode.coords.x + 1;
                y = currentNode.coords.y;
                if (currentNode.coords.x < 9)
                {
                    VisitNode(GetNode(x, y));
                }

                //SUD-ESTE
                x = currentNode.coords.x + 1;
                y = currentNode.coords.y + 1;
                if (currentNode.coords.x < 10 && currentNode.coords.y < 10)
                {
                    VisitNode(GetNode(x, y));
                }

                //SUR
                x = currentNode.coords.x;
                y = currentNode.coords.y + 1;
                if (currentNode.coords.y < 9)
                {
                    VisitNode(GetNode(x, y));
                }

                //SUD-OESTE
                x = currentNode.coords.x - 1;
                y = currentNode.coords.y + 1;
                if (currentNode.coords.y < 10 && currentNode.coords.x > 0)
                {
                    VisitNode(GetNode(x, y));
                }

                //OESTE
                x = currentNode.coords.x - 1;
                y = currentNode.coords.y;
                if (currentNode.coords.x > 0)
                {
                    VisitNode(GetNode(x, y));
                }

                //NOR-OESTE
                x = currentNode.coords.x - 1;
                y = currentNode.coords.y - 1;
                if (currentNode.coords.x > 0 && currentNode.coords.y > 0)
                {
                    VisitNode(GetNode(x, y));
                }

                //NORTE
                x = currentNode.coords.x;
                y = currentNode.coords.y - 1;
                if (currentNode.coords.y > 0)
                {
                    VisitNode(GetNode(x, y));
                }

                //NOR-ESTE
                x = currentNode.coords.x + 1;
                y = currentNode.coords.y - 1;
                if (currentNode.coords.y > 0 && currentNode.coords.x < 10)
                {
                    VisitNode(GetNode(x, y));
                }

                if (!currentNode.isStart)
                    currentNode.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);

            }
            else
            {
                Debug.Log("Esta vacía.");
                algoritm = ALGORITM.DEFAULT;
            }
        }
    }
    void Dijkstra_PF()
    {
        Debug.Log("Pues se activo DIJS");
    }
    void BestFS_PF()
    {
        Debug.Log("Pues se activo BESTFS");
    }

    void VisitNode(Node visitedNode)
    {
        if (visitedNode.isObstacle || visitedNode.visited)
        {
            //Debug.Log("O era obstaculo, o estaba visitado");
            return;
        }
        else if (visitedNode.isEnd)
        {
            if (isBFS)
            {
                openList.Enqueue(visitedNode);
            }
            else if (isDFS)
            {
                openLstStack.Push(visitedNode);
            }
            Debug.Log("Encontre el final! es: (" + currentNode.coords + ", " + currentNode.coords.y + ")");
            visitedNode.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            visitedNode.parent = currentNode;
            DrawPath(visitedNode);
            algoritm = ALGORITM.DEFAULT;
            return;
        }
        if (isBFS)
        {
            openList.Enqueue(visitedNode);
        }
        else if(isDFS)
        {
            openLstStack.Push(visitedNode);
        }

        visitedNode.GetComponent<Renderer>().enabled = true;
        visitedNode.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
        visitedNode.parent = currentNode;
    }

    Node GetNode( float x, float y)
    {
        Node foundNode = currentNode;
        foreach (Node node in nodes)
        {
            if (node.coords.x == x && node.coords.y == y)
            {
                foundNode = node;
                //Debug.Log("Si encontr el nodo!: " + foundNode.iID);
            }
        }
        return foundNode;
    }

    void DrawPath(Node node)
    {
        while(node.parent != null)
        {
            node = node.parent;
            node.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

        }
    }

}
