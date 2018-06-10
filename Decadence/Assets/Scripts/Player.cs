using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SteeringBehaviours {

    int state = 0;


    // Use this for initialization
    void Start () {
        initialSpeed = Vector3.zero;
        //gameControlScript = GameControl.GetComponent<MovementController>();
        gameControlScript = GameControl.GetComponent<MovementController>();

        gameControlScript.Agents.Add(gameObject);
    }

    // Update is called once per frame
    void Update () {

        switch (state)
        {
            case 0:
                Escaping();
                break;
            case 1:
                Pursuing();
                break;
            case 2:
                avoidingObstacles();
                break;
            case 3:
                Escaping();
                avoidingObstacles();
                break;
        }
        
    }

    void Escaping()
    {
        foreach (GameObject o in gameControlScript.Agents)
        {
            if (o != gameObject)
            currentSpeed = Evade(transform.position, o.transform.position, speed, escapeRadius, initialSpeed);
            transform.position = transform.position + currentSpeed;
        }
    }
    void Pursuing()
    {

    }
    void avoidingObstacles()
    {

    }
    

}
