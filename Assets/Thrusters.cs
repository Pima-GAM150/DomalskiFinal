using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thrusters : MonoBehaviour
{
 	
 	public int lives;   
    public float verticalRot, horizontalRot, baseForce, thrust, rotRate, thrustRate;
    public Transform tracker;
    public Text	 v, h, t, l;

    void Update()
    {
        
    	v.text = "" +verticalRot;
    	h.text = "" + horizontalRot;
    	t.text = "" + (100 * thrust);
    	l.text = "" + lives;

    	if(Input.GetKey(KeyCode.LeftShift) && thrust < 1f){

    		thrust += thrustRate * Time.deltaTime;

    	} else if(Input.GetKey(KeyCode.LeftControl) && thrust > -1f){

    		thrust -= thrustRate * Time.deltaTime;

    	}

    	verticalRot += Input.GetAxis("Vertical") * rotRate * Time.deltaTime;
    	horizontalRot += Input.GetAxis("Horizontal") * rotRate * Time.deltaTime;

    	tracker.eulerAngles = new Vector3(verticalRot, horizontalRot, 0f);
    	Vector3 temp = tracker.TransformVector(0, 0, 1);

    	temp = temp * thrust * baseForce * Time.deltaTime;

    	GetComponent<Rigidbody>().AddForce(temp);

    }

    void OnCollisionEnter(Collision hit){

    	if(hit.tag.Equals("Obstacle")){

    		lives--;
    		if(lives < 0){

    			GameOver();

    		}

    	}

    }

    void GameOver(){}
}
