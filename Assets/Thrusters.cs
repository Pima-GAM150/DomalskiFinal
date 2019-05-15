using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Thrusters : MonoBehaviour
{
 	
 	public int lives;   
    public float verticalRot, horizontalRot, baseForce, thrust, rotRate, thrustRate;
    private bool invul;
    private float timer;
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

    	if(invul){

    		timer+= Time.deltaTime;

    		if(timer > 2f)
    			invul = false;

    	}

    }

    void OnCollisionEnter(Collision hit){

    	if(hit.gameObject.tag.Equals("Obstacle") && !invul){

    		lives--;
    		invul = true;
    		if(lives < 0){

    			GameOver();

    		}

    	}

    }

    void GameOver(){

    	SceneManager.LoadScene(0);

    }
}
