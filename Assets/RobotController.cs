using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    // Start is called before the first frame update
    
        public float speed=5;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
    }

    void OnCollisionEnter(Collision collision)
    {
        transform.Rotate(0f,transform.localRotation.eulerAngles.x*-1,0f, Space.Self);
        Debug.Log("COL");
    }
}
