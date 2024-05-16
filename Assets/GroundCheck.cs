using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject houseObj;
    public bool touchingGrass;
    public bool touchingRoad;
    // Start is called before the first frame update
    void Start()
    {
        touchingGrass = false;
        touchingRoad = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, -transform.up, out hit);

        //Check if player is touching grass
        if(hit.collider.tag == "Terrain")
        {
            touchingGrass = true;
        }
        if(hit.collider.tag != "Terrain")
        {
            touchingGrass = false;
        }

        //Check if player is touching road
        if(hit.collider.tag == "Road")
        {
            touchingRoad = true;
        }
        if(hit.collider.tag != "Road")
        {
            touchingRoad = false;
        }
    }
}
