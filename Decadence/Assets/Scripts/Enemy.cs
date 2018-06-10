using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : SteeringBehaviours {

    GameObject player;
    //float speed = 3, escapeSpeed = 6;
    //float minRadius = 5;
    float playerSpeed;
    Player playerScript;
    //Vector3 initialSpeed;
    bool isFlocking =true;
    Vector3 flocking;


    // Use this for initialization
    void Start () {
        initialSpeed = Vector3.zero;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        gameControlScript = GameControl.GetComponent<MovementController>();
        gameControlScript.Agents.Add(gameObject);
        //playerScript.enemies.Add(gameObject);
        playerSpeed = playerScript.speed;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isFlocking)
            transform.position += Pursuit(transform.position, player.transform.position, speed, minRadius, initialSpeed);
        else
        {
            flocking = Flocking(gameControlScript.Agents);
            flocking.Normalize();
            transform.position += flocking;
        }
    }
}
