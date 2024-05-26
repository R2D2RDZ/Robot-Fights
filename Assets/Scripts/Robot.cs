using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Robot : MonoBehaviour
{
    int hand = 0;
    public bool isDown=false;
    [SerializeField] GameObject[] Hands = new GameObject[4];
    int head = 0;
    [SerializeField] GameObject[] Heads = new GameObject[4];
    int body = 0;
    [SerializeField] GameObject[] Bodys = new GameObject[4];
    int leg = 0;
    [SerializeField] GameObject[] Legs = new GameObject[4];

    [SerializeField] Stats[] HandsStats= new Stats[4];
    [SerializeField] Stats[] HeadsStats= new Stats[4];
    [SerializeField] Stats[] BodysStats= new Stats[4];
    [SerializeField] Stats[] LegsStats= new Stats[4];

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Lobby" && GameObject.FindGameObjectsWithTag("Player").Length > 2)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "MainMenu") Destroy(gameObject);
        DontDestroyOnLoad(this.gameObject);
        if (SceneManager.GetActiveScene().name == "Lobby" && name=="Robot1")
        {
            transform.position = new Vector3(-56.6534615f, -11.8757868f, 51.3726425f);
            transform.eulerAngles = new Vector3(0, 150, 0);
            transform.localScale = new Vector3(20.6012573f, 20.6012573f, 20.6012573f);
        }

        if (SceneManager.GetActiveScene().name == "Lobby" && name == "Robot2")
        {
            transform.position = new Vector3(56.6534615f, -11.8757868f, 51.3726425f);
            transform.eulerAngles = new Vector3(0, 210, 0);
            transform.localScale = new Vector3(20.6012573f, 20.6012573f, 20.6012573f);
        }
    }
    public void DisableParts(int[] i)
    {
        Heads[i[0]].SetActive(false);
        Hands[i[1]].SetActive(false);
        Bodys[i[2]].SetActive(false);
        Legs[i[3]].SetActive(false);
    }
    public void EnableParts(int[] i)
    {
        Heads[i[0]].SetActive(true);
        Hands[i[1]].SetActive(true);
        Bodys[i[2]].SetActive(true);
        Legs[i[3]].SetActive(true);
        head = i[0];
        hand = i[1];
        body = i[2];
        leg = i[3];
    }

    public float[] GetStats()
    {
        float[] array = new float[4];
        Stats[] temp = new Stats[] { HeadsStats[head], HandsStats[hand], BodysStats[body], LegsStats[leg] };
        foreach (Stats part in temp)
        {
            array[0] += part.velocidad;
            array[1] += part.rotacion;
            array[2] += part.ataque;
            array[3] += part.maxCuerda;
        }
        return array;
    }
}
