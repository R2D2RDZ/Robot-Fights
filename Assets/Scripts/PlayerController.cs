using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private float cuerda1;
    private float maxcuerda1;
    private float cuerda2;
    private float maxcuerda2;
    public float speed1;
    public float speed2;
    public float rotspeed1; 
    public float rotspeed2; 
    public float ataque1;
    public float ataque2;
    private float cuerdaRate=0.5f;
    private Robot Robotp1;
    private Robot Robotp2;


    private bool cuenta=false;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Robot1");
        player2 = GameObject.Find("Robot2");

        Robotp1 = player1.GetComponent<Robot>();
        Robotp2 = player2.GetComponent<Robot>();

        player1.transform.position = new Vector3(-6.5f, 9f, -1.5f);
        player2.transform.position = new Vector3(10.9f, 9f, 10.9f);

        player1.transform.localScale = Vector3.one;
        player2.transform.localScale = Vector3.one;

        player1.transform.eulerAngles = new Vector3(0, 55, 0);
        player2.transform.eulerAngles = new Vector3(0, 235, 0);

        float[] temp = Robotp1.GetStats();
        speed1 = temp[0];
        rotspeed1= temp[1];
        ataque1= temp[2];
        maxcuerda1= temp[3];

        temp = Robotp2.GetStats();
        speed2 = temp[0];
        rotspeed2= temp[1];
        ataque2= temp[2];
        maxcuerda2= temp[3];
    }

    // Update is called once per frame
    void Update()
    {
        if(!cuenta){
            if(Input.GetKey(KeyCode.W)){
                player1.transform.position += player1.transform.forward*speed1*Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.A)){
                float rotationAmount = rotspeed1 * Time.deltaTime;
                player1.transform.Rotate(Vector3.down, rotationAmount);
            }
            if(Input.GetKey(KeyCode.D)){
                float rotationAmount = rotspeed1 * Time.deltaTime;
                player1.transform.Rotate(Vector3.up, rotationAmount);
            }
            if(Input.GetKey(KeyCode.S)){
                player1.transform.position -= player1.transform.forward*speed1*Time.deltaTime;
            }

            //player2
            if(Input.GetKey(KeyCode.UpArrow)){
                player2.transform.position += player2.transform.forward*speed2*Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.LeftArrow)){
                float rotationAmount = rotspeed2 * Time.deltaTime;
                player2.transform.Rotate(Vector3.down, rotationAmount);
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                float rotationAmount = rotspeed2 * Time.deltaTime;
                player2.transform.Rotate(Vector3.up, rotationAmount);
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                player2.transform.position -= player2.transform.forward*speed2*Time.deltaTime;
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
