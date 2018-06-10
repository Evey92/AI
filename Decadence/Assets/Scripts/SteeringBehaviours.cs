using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviours : MonoBehaviour {
    
    public GameObject Boid;
    public GameObject Objective;
    public bool flee = false, seek = false;
    public float speed = 3, escapeSpeed = 6;
    public float minRadius = 5;
    public float escapeRadius = 50;
    public Vector3 objectiveSpeed;
    public Vector3 currentSpeed;
    public Vector3 Pos, Obj;
    public Vector3 initialSpeed;
    public int neighbors = 0;
    public GameObject GameControl;
    public MovementController gameControlScript;

    // Use this for initialization
    void Start () {
        
        //if (this.tag == "Player")
        //{
        //    flee = true;
        //}      
    }

    // Update is called once per frame
    void Update () {

        //Pos = transform.position;
        //Obj = Objective.transform.position;

        //if (flee)
        //{
        //    transform.position += Evade(Pos, Obj, speed, escapeRadius);
        //}
        //else
        //    transform.position += Pursuit(Pos, Obj, speed, minRadius);



    }

    public Vector3 Seek(Vector3 Pos, Vector3 Obj, float M)
    {
        Vector3 force = Obj - Pos;
        Vector3 moveVec = new Vector3();

        //if (force.magnitude > r)
        //{
            moveVec = force.normalized * M * Time.deltaTime;
        //}
        //else
        //{
        //    moveVec = force * 0.0f;
        //}
        return moveVec;
    }

    public Vector3 Flee(Vector3 Pos, Vector3 Obj, float M)
    {
        Vector3 force = Pos - Obj;
        Vector3 moveVec = new Vector3();

        //if (force.magnitude < r)
        //{
            moveVec = force.normalized * M * Time.deltaTime;
        //}
        //else
        //{
        //    moveVec = force * 0.0f;
        //}
        return moveVec;
    }

    public Vector3 Arrive(Vector3 Pos, Vector3 Obj, float M, float r)
    {
        Vector3 force = Pos - Obj;
        Vector3 moveVec = new Vector3();
        r = force.magnitude;
        float desaceleration = r/5;
        float speed = M * desaceleration;

        moveVec = Seek(Pos, Obj, M).normalized * speed;
    
        return moveVec;
    }

    public Vector3 Pursuit(Vector3 Pos, Vector3 Obj, float M, float r, Vector3 objectiveSpeed)
    {
        int prediction = 30;
        Vector3 moveVec = new Vector3();
        //objectiveSpeed = Objective.GetComponent<MovementController>().objectiveSpeed;
        Vector3 objPredictPosition = Obj + (objectiveSpeed * prediction);
        Vector3 force = objPredictPosition - Pos;

        if (force.magnitude > r)
        {
            moveVec = force.normalized * M * Time.deltaTime;
        }
        else
            moveVec *= 0;

        return moveVec;
    }

    public Vector3 Evade(Vector3 Pos, Vector3 Obj, float M, float r, Vector3 objectiveSpeed)
    {
        int prediction = 30;
        Vector3 moveVec = new Vector3();
        //Vector3 objectiveSpeed = Objective.GetComponent<MovementController>().objectiveSpeed;
        Vector3 objPredictPosition = Obj + (objectiveSpeed * prediction);
        Vector3 force = Pos - objPredictPosition;

        if (force.magnitude < r)
        {
            moveVec = force.normalized * M * Time.deltaTime;
        }
        else
            moveVec *= 0;

        //moveVec = Seek(Pos, Obj, M, r) * speed;

        return moveVec;
    }

    public Vector3 Wander(Vector3 Pos, Vector3 Obj, float M, float r, Vector3 objectiveSpeed)
    {
        //int prediction = 30;
        Vector3 moveVec = new Vector3();

        return moveVec;
    }

    public Vector3 Patrol(Vector3 Pos, Vector3 Obj, float M, float r, Vector3 objectiveSpeed)
    {
        int prediction = 30;
        Vector3 moveVec = new Vector3();
        

        return moveVec;
    }

    public Vector3 ObstacleAvoidance(Vector3 Pos, Vector3 Obj, float M, float r, Vector3 objectiveSpeed)
    {
        int prediction = 30;
        Vector3 moveVec = new Vector3();
        

        return moveVec;
    }

    public Vector3 Flocking(List<GameObject>Agents)
    {
        Vector3 alignmentVec = Align(gameObject, Agents);
        Vector3 coheVec = Cohesion(gameObject, Agents);
        Vector3 separateVec = Sepration(gameObject, Agents);
        Vector3 finalVec;

        finalVec.x = alignmentVec.x + coheVec.x + separateVec.x;
        finalVec.z = alignmentVec.z + coheVec.z + separateVec.z;
        finalVec.y = 0;

        return finalVec;
    }

    public Vector3 Align(GameObject Pos, List<GameObject> Agents)
    {
        Vector3 alignVec= new Vector3();
       

        foreach (GameObject a in gameControlScript.Agents)
        {
            Rigidbody rb = a.GetComponent<Rigidbody>();
            if (a != Pos)
            {
                if (Pos.transform.position.magnitude < 300)
                {
                    alignVec.x += rb.velocity.x;
                    alignVec.z += rb.velocity.z;
                    alignVec.y = 0;
                    neighbors++;
                }

            }
        }
        if(neighbors == 0)
        {
            return alignVec;
        }

        alignVec.x /= neighbors;
        alignVec.z /= neighbors;
        alignVec.y = 0;
        alignVec.Normalize();
        return alignVec;
    }

    public Vector3 Cohesion(GameObject Pos, List<GameObject> Agents)
    {
        Vector3 cohesionVec = new Vector3();
        foreach (GameObject a in gameControlScript.Agents)
        {
            if (a != Pos)
            {
                if (Pos.transform.position.magnitude < 300)
                {
                    cohesionVec += a.transform.position;
                }
            }
        }

        cohesionVec.x /= neighbors;
        cohesionVec.z /= neighbors;
        cohesionVec.y = 0;
        cohesionVec -= Pos.transform.position;
        cohesionVec.Normalize();
        return cohesionVec;
    }

    Vector3 Sepration(GameObject Pos, List<GameObject> Agents)
    {
        Vector3 separationVec = new Vector3();
        foreach (GameObject a in gameControlScript.Agents)
        {
            if (a != Pos)
            {
                if (Pos.transform.position.magnitude < 300)
                {
                    separationVec += a.transform.position - Pos.transform.position;
                }
            }
        }

        separationVec.x /= neighbors;
        separationVec.z /= neighbors;
        separationVec.y = 0;
        separationVec.x *= -1;
        separationVec.z *= -1;
        separationVec.Normalize();
        return separationVec;
    }


}
