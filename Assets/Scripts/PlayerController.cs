using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float cuerda1;
    public float maxcuerda1=500;
    public float cuerda2;
    public float maxcuerda2=1000;
    public float speed;
    public float rotspeed; 
    private float cuerdaRate=0.5f;
    private Robot Robotp1;
    private Robot Robotp2;


    private bool cuenta=false;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        Robotp1 = player1.GetComponent<Robot>();
        Robotp2 = player2.GetComponent<Robot>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!cuenta){
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

        if(cuenta){
            if(Robotp1.isDown){
                if(Input.GetKeyDown(KeyCode.W)){
                    cuerda1+=10;
                    if(cuerda1 >= maxcuerda1){
                        cuenta=false;
                        Robotp1.isDown=false;
                    }
                }
            }
            if(Robotp2.isDown){
                if(Input.GetKeyDown(KeyCode.UpArrow)){
                    cuerda2+=10;
                    if(cuerda2 >= maxcuerda2){
                        cuenta=false;
                        Robotp2.isDown=false;
                    }
                }
            }
        }
    }

    void FixedUpdate(){

        if((cuerda1>0)&&(cuerda2>0)&&!cuenta){
            player1.transform.eulerAngles = new Vector3(0, player1.transform.eulerAngles.y, player1.transform.eulerAngles.z);
            player2.transform.eulerAngles = new Vector3(0, player2.transform.eulerAngles.y, player2.transform.eulerAngles.z);

            cuerda1 -= cuerdaRate;
            cuerda2 -= cuerdaRate;
        }
        if(cuerda1<=0)
        {
            player1.transform.eulerAngles = new Vector3(90, player1.transform.eulerAngles.y, player1.transform.eulerAngles.z);
            cuenta=true;
            Robotp1.isDown=true;
        }
        if(cuerda2<=0){
            player2.transform.eulerAngles = new Vector3(90, player2.transform.eulerAngles.y, player2.transform.eulerAngles.z);
            cuenta=true;
            Robotp2.isDown=true;
        }
    }
}
