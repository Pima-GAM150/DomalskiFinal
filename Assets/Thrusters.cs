using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thrusters : MonoBehaviour
{
    
    public float verticalRot, horizontalRot, baseForce, thrust, rotRate, thrustRate;
    public Text	 v, h, t;

    void Update()
    {
        
    	v.text = "" +verticalRot;
    	h.text = "" + horizontalRot;
    	t.text = "" + (100 * thrust);

    	if(Input.GetKey(KeyCode.LeftShift) && thrust < 1f){

    		thrust += thrustRate * Time.deltaTime;

    	} else if(Input.GetKey(KeyCode.LeftAlt) && thrust > -1f){

    		thrust -= thrustRate * Time.deltaTime;

    	}

    	verticalRot += Input.GetAxis("Vertical") * rotRate * Time.deltaTime;
    	horizontalRot += Input.GetAxis("Horizontal") * rotRate * Time.deltaTime;

    }
}
