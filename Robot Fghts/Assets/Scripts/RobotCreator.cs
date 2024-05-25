using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCreator : MonoBehaviour
{
    // Start is called before the first frame update
    int hand = 0;
    public GameObject[] Hands = new GameObject[4];

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

}

