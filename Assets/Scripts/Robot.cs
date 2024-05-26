using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
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
    }
}
