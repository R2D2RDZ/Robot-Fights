using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float speed;
    public float rotspeed; 
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        //player1 
        if(Input.GetKey(KeyCode.W)){
            player1.transform.position += player1.transform.forward*speed*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A)){
            float rotationAmount = rotspeed * Time.deltaTime;
            player1.transform.Rotate(Vector3.down, rotationAmount);
        }
        if(Input.GetKey(KeyCode.D)){
            float rotationAmount = rotspeed * Time.deltaTime;
            player1.transform.Rotate(Vector3.up, rotationAmount);
        }
        if(Input.GetKey(KeyCode.S)){
            player1.transform.position -= player1.transform.forward*speed*Time.deltaTime;
        }

        //player2
        if(Input.GetKey(KeyCode.UpArrow)){
            player2.transform.position += player2.transform.forward*speed*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            float rotationAmount = rotspeed * Time.deltaTime;
            player2.transform.Rotate(Vector3.down, rotationAmount);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            float rotationAmount = rotspeed * Time.deltaTime;
            player2.transform.Rotate(Vector3.up, rotationAmount);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            player2.transform.position -= player2.transform.forward*speed*Time.deltaTime;
        }
    }
}
