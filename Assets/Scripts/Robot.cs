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

    private void FixedUpdate()
    {
        //Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "MainMenu") Destroy(gameObject);
        DontDestroyOnLoad(this.gameObject);
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
