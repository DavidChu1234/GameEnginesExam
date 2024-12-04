using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    Stack<Command> stack;
    float timeToRecordMousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeToRecordMousePos = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToRecordMousePos -= Time.deltaTime;
        if (timeToRecordMousePos < 0.0000001f)
        {
            //record current mouse pos and put it into the stack
            timeToRecordMousePos = 0.1f;
        }
    }

    private void Rewind()
    {
        //read thru stack and update new mouse pos.
    }
}
