using Chapter.Command;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Command
{
    public class Invoker : MonoBehaviour
    {
        Stack<Command> stack;
        float timeToRecordMousePos = 0.1f;

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
}
