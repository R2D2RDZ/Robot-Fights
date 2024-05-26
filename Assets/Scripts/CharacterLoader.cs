using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLoader : MonoBehaviour
{
    [SerializeField] Robot p1robotbase;
    [SerializeField] Robot p2robotbase;

    int curretp1 = 0;
    int curretp2 = 0;

    character robotp1 = new character("Test", 0, 0, 0, 0);
    character robotp2 = new character("Test", 0, 0, 0, 0);

    int numPersonajes; 

    [SerializeField] Slider[] statsp1 = new Slider[4];
    [SerializeField] Slider[] statsp2 = new Slider[4];

    // Start is called before the first frame update
    void Start()
    {
        numPersonajes = CharacterSelector.LoadCharacters();
        Debug.Log(numPersonajes);

        int[] temp = robotp1.ToIntArray();
        for (int i = 0; i < temp.Length; i++)
        {
            statsp1[i].value = temp[i];
        }

        temp = robotp1.ToIntArray();
        for (int i = 0; i < temp.Length; i++)
        {
            statsp2[i].value = temp[i];
        }
    }

    public void ChangeP1(int change)
    {
        //Visual part
        p1robotbase.DisableParts(robotp1.ToIntArray());
        curretp1 += change;
        if (curretp1 < 0) { curretp1 = numPersonajes - 1; }
        else if (curretp1 >= numPersonajes) { curretp1 = 0; }
        robotp1 = CharacterSelector.selectCharacter(curretp1);
        p1robotbase.EnableParts(robotp1.ToIntArray());

        //Stats part
        float[] temp = p1robotbase.GetStats();
        for (int i =0 ; i < temp.Length; i++)
        {
            statsp1[i].value = temp[i];
        }

        //Debug.Log(temp[0] + "," + temp[1] + "," + temp[2] + "," + temp[3]);

    }
    public void ChangeP2(int change)
    {
        p2robotbase.DisableParts(robotp2.ToIntArray());
        curretp2 += change;
        if (curretp2 < 0) { curretp2 = numPersonajes - 1; }
        else if (curretp2 >= numPersonajes) { curretp2 = 0; }
        robotp2 = CharacterSelector.selectCharacter(curretp2);
        p2robotbase.EnableParts(robotp2.ToIntArray());

        float[] temp = p2robotbase.GetStats();
        for (int i = 0; i < temp.Length; i++)
        {
            statsp2[i].value = temp[i];
        }
    }
}
