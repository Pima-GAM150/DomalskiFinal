using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingCamera : MonoBehaviour
{
    public float turnSpeed = 4.0f;
  
    private Vector3 offset;
  
    void Start () {
        offset = new Vector3(0, 2, -6/*transform.parent.position.x, transform.parent.position.y, transform.parent.position.z*/);
    }
  
    void Update(){
        offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        offset = Quaternion.AngleAxis (Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;
        transform.position = transform.parent.position + offset; 
        transform.LookAt(transform.parent.position);
    }
}
