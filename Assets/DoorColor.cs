using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColor : MonoBehaviour {
	  bool toggle;
	  Renderer rend;
      private float nextActionTime = 0.0f;
      public float period = 10.0f;
	// Use this for initialization
	void Start () {
		  //Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();
        toggle = true;
  
	}
	
	// Update is called once per frame
	void Update () {
		      
       // while(true){
     
        	if(toggle){
        		//Set the main Color of the Material to green
        	rend.material.shader = Shader.Find("_Color");
        	rend.material.SetColor("_Color", Color.yellow);

        //Find the Specular shader and change its Color to red
        	rend.material.shader = Shader.Find("Specular");
        	rend.material.SetColor("_SpecColor", Color.yellow);
        	} else {
        		    rend.material.shader = Shader.Find("_Color");
        			rend.material.SetColor("_Color", Color.magenta);

        //Find the Specular shader and change its Color to red
        			rend.material.shader = Shader.Find("Specular");
        			rend.material.SetColor("_SpecColor", Color.magenta);
        	}
        	
            if (Time.time > nextActionTime ) {
                 nextActionTime = Time.time + period;
            // execute block of code here

            if (Random.Range(0, 2) == 0)
            {
                toggle = !toggle;
            }
                //set period to a random value between 4 and 15 seconds 
              
            
            }
        	
     //   }
	}
}
