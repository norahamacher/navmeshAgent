using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class guyAI : MonoBehaviour
{
    NavMeshAgent agent;
 
    private bool hasDestination;
    //each agent has a favorite color, to which they will try to navigate
    public Color favoriteColor;
    private Transform idlePosition;
    private GameObject[] targets;
    private GameObject currentDestination;

    public guyAI()
    {
        
    }
    void Start()
    {
        idlePosition = GameObject.Find("Idle").transform;
        agent = GetComponent<NavMeshAgent>();
        targets = new GameObject[4];
        targets[0] = GameObject.Find("wall4_door");
        targets[1] = GameObject.Find("house_door");
        targets[2] = GameObject.Find("door3");
        targets[3] = GameObject.Find("target1");
        hasDestination = false;
        //GetComponent<Renderer>().material.shader = Shader.Find("_Color");
        // GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    void Update()
    {
        //move to mouse position
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }

        bool availabletarget = targetExists(); 
        
        if(!hasDestination) {
            if (availabletarget)
            {
                int ind = getIndexOfTarget();
                agent.destination = targets[ind].transform.position;
                currentDestination = targets[ind];
                hasDestination = true;
            } else
            {
                agent.destination = idlePosition.position;
                currentDestination = null;
            }
        } else {  //has a  destination already, check if that is still the correct color
            if(! (currentDestination.GetComponent<Renderer>().material.GetColor("_Color") == this.favoriteColor)){
                agent.destination = idlePosition.position;
                currentDestination = null;
                hasDestination = false;
            }
        }
    }

    private bool targetExists()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].GetComponent<Renderer>().material.GetColor("_Color") == this.favoriteColor)
            {
                return true;
            }
        }
        return false;
    }

    private int getIndexOfTarget()
    {
        List<int> indexList = new List<int>();
        for(int i = 0; i < targets.Length; i++)
        {
           if (targets[i].GetComponent<Renderer>().material.GetColor("_Color") == this.favoriteColor)
            {
                indexList.Add(i);
            }
        }
        //return a random index of the list
        int[] arr = indexList.ToArray();
        return arr[Random.Range(0, arr.Length)];
    }
}
