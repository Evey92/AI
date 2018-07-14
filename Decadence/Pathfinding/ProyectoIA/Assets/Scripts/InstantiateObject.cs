using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour {

    Ray ray;      // initializing the ray
    RaycastHit hit; // initializing the raycasthit
    public GameObject Cube;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            //if (Input.GetKey(KeyCode.Mouse0))
            //{
            //    GameObject obj = Instantiate(Cube, hit.normal + hit.transform.position, hit.transform.rotation);
            //    Debug.Log("Placed a Cube");
            //}

        }
    }
}
