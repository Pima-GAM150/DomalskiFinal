using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingCamera : MonoBehaviour
{
    public float turnSpeed = 4.0f;
  
    private Vector3 offset;
  
    void Start () {
        offset = new Vector3(transform.parent.position.x, transform.parent.position.y + 8.0f, transform.parent.position.z + 7.0f);
    }
  
    void Update(){
        offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        offset = Quaternion.AngleAxis (Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;
        transform.position = transform.parent.position + offset; 
        transform.LookAt(transform.parent.position);
    }
}
