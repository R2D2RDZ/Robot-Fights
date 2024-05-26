using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowd : MonoBehaviour
{
    private int contador=500;
    private int activador;
    private int up=0;

    void Start(){
        activador = Random.Range(0, 499);
    }
    void LateUpdate()
    {
        contador = contador%500;
        if(activador!=contador){
            contador++;
        }
        else{
            if(up<5){
                transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
                up++;
            }
            else if(up<10){
                transform.position = new Vector3(transform.position.x, transform.position.y-1, transform.position.z);
                up++;
            }
            else{
                up=0;
                activador = Random.Range(0, 499);
            }
        }

    }
}