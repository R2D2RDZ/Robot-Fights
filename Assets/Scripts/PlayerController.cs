using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float cuerda1;
    public float maxcuerda1;
    public float cuerda2;
    public float maxcuerda2;
    public float speed1;
    public float speed2;
    public float rotspeed1; 
    public float rotspeed2; 
    public float ataque1;
    public float ataque2;
    private float cuerdaRate=0.5f;
    private Robot Robotp1;
    private Robot Robotp2;
    private int count1 = 10;
    private int count2 = 10;
    int countdown;
    [SerializeField] TMP_Text p1countdown;
    [SerializeField] TMP_Text p2countdown;
    [SerializeField] bool hasStarted= false;
    private Healthbar healthbar1;
    private Healthbar healthbar2;
    private GameObject barra1;
    private GameObject barra2;



    private bool cuenta=false;
    private bool end=false;
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

        barra1 = GameObject.Find("Robot1/Canvas/Barra");
        healthbar1=barra1.GetComponent<Healthbar>();

        barra2 = GameObject.Find("Robot2/Canvas/Barra");
        healthbar2=barra2.GetComponent<Healthbar>();

        end=false;
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

        if(cuenta&&!end){
            if(Robotp1.isDown && Robotp2.isDown){
                if(Input.GetKeyDown(KeyCode.W)){
                    cuerda1+=15;
                    GameObject.Find("Robot1/ClockKey").transform.Rotate(Vector3.left, ((rotspeed1*10) * Time.deltaTime));
                    if(cuerda1 >= maxcuerda1){
                        cuenta=false;
                        Robotp1.isDown=false;
                        CancelInvoke();
                        p1countdown.text = "";
                    }
                }
                if(Robotp2.isDown){
                    if(Input.GetKeyDown(KeyCode.UpArrow)){
                        cuerda2+=15;
                        GameObject.Find("Robot2/ClockKey").transform.Rotate(Vector3.left, ((rotspeed2*10) * Time.deltaTime));
                        if(cuerda2 >= maxcuerda2){
                            cuenta=false;
                            Robotp2.isDown=false;
                            CancelInvoke();
                            p2countdown.text = "";
                        }
                    }
                }
            }
            else{
                if(Robotp1.isDown){
                    if(Input.GetKeyDown(KeyCode.W)){
                        cuerda1+=15;
                        GameObject.Find("Robot1/ClockKey").transform.Rotate(Vector3.left, ((rotspeed1*10) * Time.deltaTime));
                        if(cuerda1 >= maxcuerda1){
                            cuenta=false;
                            Robotp1.isDown=false;
                            CancelInvoke();
                            count1 -= 2;
                            p1countdown.text = "";
                        }
                    }
                }
                if(Robotp2.isDown){
                    if(Input.GetKeyDown(KeyCode.UpArrow)){
                        cuerda2+=15;
                        GameObject.Find("Robot2/ClockKey").transform.Rotate(Vector3.left, ((rotspeed2*10) * Time.deltaTime));
                        if(cuerda2 >= maxcuerda2){
                            cuenta=false;
                            Robotp2.isDown=false;
                            CancelInvoke();
                            count2 -= 2;
                            p2countdown.text = "";
                        }
                    }
                }
            }
        }

        healthbar1.UpdateHealth(cuerda1/maxcuerda1);
        healthbar2.UpdateHealth(cuerda2/maxcuerda2);
    }

    void FixedUpdate(){

        if((cuerda1>0)&&(cuerda2>0)&&!cuenta){
            player1.transform.eulerAngles = new Vector3(0, player1.transform.eulerAngles.y, player1.transform.eulerAngles.z);
            player2.transform.eulerAngles = new Vector3(0, player2.transform.eulerAngles.y, player2.transform.eulerAngles.z);

            cuerda1 -= cuerdaRate;
            GameObject.Find("Robot1/ClockKey").transform.Rotate(Vector3.right, ((rotspeed1*5) * Time.deltaTime));
            cuerda2 -= cuerdaRate;
            GameObject.Find("Robot2/ClockKey").transform.Rotate(Vector3.right, ((rotspeed2*5) * Time.deltaTime));
            Robotp1.isDown= false;
            Robotp2.isDown= false;
        }
        if(cuerda1<=0)
        {
            player1.transform.eulerAngles = new Vector3(90, player1.transform.eulerAngles.y, player1.transform.eulerAngles.z);
            
            Robotp1.isDown=true;
            if (hasStarted && !cuenta)
            {
                countdown = count1;
                InvokeRepeating("CountDown", 0, 1);
            }
            cuenta=true;
        }
        if(cuerda2<=0){
            player2.transform.eulerAngles = new Vector3(90, player2.transform.eulerAngles.y, player2.transform.eulerAngles.z);
            
            Robotp2.isDown=true;
            if (hasStarted && !cuenta)
            {
                countdown = count2;
                InvokeRepeating("CountDown", 0, 1);
            }
            cuenta=true;
            
        }
        if(!Robotp1.isDown && !Robotp2.isDown) { 
            hasStarted = true; 
            }
    }
    void CountDown()
    {

        if (Robotp1.isDown)
        {
            p1countdown.text = countdown.ToString();
        }
        else
        {
            p2countdown.text = countdown.ToString();
        }
        if (countdown == 0)
        {
            if (Robotp1.isDown)
            {
                p1countdown.text = "You lose";
                p2countdown.text = "You win";
                end = true;
            }
            else
            {
                p1countdown.text = "You win";
                p2countdown.text = "You lose";
                end = true;
            }
            CancelInvoke();
            Invoke("endfight", 3f);
        }
        countdown--;
    }
    void endfight()
    {
        ManagerScenes.ChangeLobby();
    }
}
