using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;

public static class CharacterSelector
{
    [SerializeField] static GameObject robotBase;

    static character[] personajes = new character[8];

    static string nombreArchivo = "SavedRobots";

    public static int LoadCharacters()
    {
        int i = 0;
        using (StreamReader sr = new StreamReader(nombreArchivo))
        {
            string linea;
            
            while ((linea = sr.ReadLine()) != "")
            { 
                Debug.Log(linea);
                personajes[i] = new character(linea);
                i++;
            }
        }
        return i;
    }
    public static character selectCharacter(int i)
    {
        return personajes[i];
    }
}

public class character
{
    string name;
    int head;
    int hand;
    int body;
    int leg;

    public character(string name, int head, int hand, int body, int leg)
    {
        this.name = name;
        this.head = head;
        this.hand = hand;
        this.body = body;
        this.leg = leg;
    }

    public character(string line)
    {
        string[] temp = line.Split(',');
        name = temp[0];
        head = int.Parse(temp[1]);
        hand = int.Parse(temp[2]);
        body = int.Parse(temp[3]);
        leg = int.Parse(temp[4]);
    }

    public int[] ToIntArray()
    {
        int[] array = new int[4];
        array[0] = head;
        array[1] = hand;
        array[2] = body;
        array[3] = leg;
        return array;
    }
}
