using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using System.Data;

public class RobotCreator : MonoBehaviour
{
    [SerializeField] Robot robot;

    int[] parts = new int[] { 0, 0, 0, 0 };


    int hand = 0;
    [SerializeField] GameObject[] Hands = new GameObject[3];
    int head = 0;
    [SerializeField] GameObject[] Heads = new GameObject[3];
    int body = 0;
    [SerializeField] GameObject[] Bodys = new GameObject[3];
    int leg = 0;
    [SerializeField] GameObject[] Legs = new GameObject[2];

    string nombreArchivo = "SavedRobots";

    [SerializeField] TMP_InputField robotName;

    [SerializeField] Slider[] stats;

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
        robot.DisableParts(parts);
        parts[1] += change;
        if (parts[1] < 0) { parts[1] = Hands.Length - 1; }
        if (parts[1] >= Hands.Length) { parts[1] = 0; }
        robot.EnableParts(parts);
        UpdateStats();

    }
    public void ChangeHead(int change) 
    {
        robot.DisableParts(parts);
        parts[0] += change;
        if (parts[0] < 0) { parts[0] = Heads.Length - 1; }
        if (parts[0] >= Heads.Length) { parts[0] = 0; }
        robot.EnableParts(parts);
        UpdateStats();

    }
    public void ChangeBody(int change)
    {
        robot.DisableParts(parts);
        parts[2] += change;
        if (parts[2] < 0) { parts[2] = Bodys.Length - 1; }
        if (parts[2] >= Bodys.Length) { parts[2] = 0; }
        robot.EnableParts(parts);
        UpdateStats();

    }
    public void ChangeLeg(int change)
    {
        robot.DisableParts(parts);
        parts[3] += change;
        if (parts[3] < 0) { parts[3] = Legs.Length - 1; }
        if (parts[3] >= Legs.Length) { parts[3] = 0; }
        robot.EnableParts(parts);
        UpdateStats();
    }
    public void Safe()
    {
        string txt = "";

        using (StreamReader sr = new StreamReader(nombreArchivo))
        {
            string linea;

            while ((linea = sr.ReadLine()) != "")
            {
                Debug.Log(linea);
                txt += linea + Environment.NewLine;
            }
        }

        txt += robotName.text + "," + parts[0] + "," + parts[1] + "," + parts[2] + "," + parts[3] + Environment.NewLine + Environment.NewLine;

        using (StreamWriter sw = new StreamWriter(nombreArchivo))
        {
            sw.Write(txt + Environment.NewLine);
        }
        
    }
    void UpdateStats()
    {
        float[] temp = robot.GetStats();
        for (int i = 0; i < temp.Length; i++)
        {
            stats[i].value = temp[i];
        }
    }
}

