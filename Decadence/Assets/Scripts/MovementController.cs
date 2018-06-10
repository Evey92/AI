using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    float speed = 10, rotSpeed = 3;
    public Vector3 objectiveSpeed;
    public List<GameObject> Agents;
	// Use this for initialization
	void Start () {
        objectiveSpeed = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
         objectiveSpeed = transform.position - transform.position;
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * rotSpeed;
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, -z);
    }
}
