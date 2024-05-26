using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ataque : MonoBehaviour
{
    private GameObject ring;
    private PlayerController controller;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider victima){
        ring = GameObject.Find("Ring");
        controller = ring.GetComponent<PlayerController>();

        if(victima.gameObject.name=="Robot1"){
            controller.cuerda1 = controller.cuerda1 - controller.ataque2;
        }
        
        else if(victima.gameObject.name=="Robot1"){
            controller.cuerda2 = controller.cuerda2 - controller.ataque1;
        }
    }
}
