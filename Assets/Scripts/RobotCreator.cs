using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;
using Unity.VisualScripting;

public class RobotCreator : MonoBehaviour
{
    // Start is called before the first frame update
    int hand = 0;
    [SerializeField] GameObject[] Hands = new GameObject[4];
    int head = 0;
    [SerializeField] GameObject[] Heads = new GameObject[4];
    int body = 0;
    [SerializeField] GameObject[] Bodys = new GameObject[4];
    int leg = 0;
    [SerializeField] GameObject[] Legs = new GameObject[4];

    string nombreArchivo = "SavedRobots";

    [SerializeField] TMP_InputField robotName;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) { ChangeHand(1); }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) { ChangeHand(-1); }
    }

    public void ChangeHand(int change)
    {
        Hands[hand].SetActive(false);
        hand += change;
        if (hand < 0) { hand = Hands.Length - 1; }
        if (hand >= Hands.Length) { hand = 0; }
        Hands[hand].SetActive(true);

    }
    public void ChangeHead(int change) 
    {
        Heads[head].SetActive(false);
        head += change;
        if (head < 0) { head = Heads.Length - 1; }
        if (head >= Heads.Length) { head = 0; }
        Heads[head].SetActive(true);

    }
    public void ChangeBody(int change)
    {
        Bodys[body].SetActive(false);
        body += change;
        if (body < 0) { body = Bodys.Length - 1; }
        if (body >= Bodys.Length) { body = 0; }
        Bodys[body].SetActive(true);

    }
    public void ChangeLeg(int change)
    {
        Legs[leg].SetActive(false);
        leg += change;
        if (leg < 0) { leg = Legs.Length - 1; }
        if (leg >= Legs.Length) { leg = 0; }
        Legs[leg].SetActive(true);
    }
    public void Safe()
    {
        using (StreamWriter sw = File.AppendText(nombreArchivo))
        {
            sw.WriteLine(robotName.text + "," + head + "," + hand + "," + body + "," + leg);
        }

    }
}

