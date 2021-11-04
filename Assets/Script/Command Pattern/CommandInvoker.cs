using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    static Queue<ICommand> commandBuffer;

    static List<ICommand> commandHistory;
    static int counter;

    private bool dirty_; //Lab 7

    private void Awake() 
    {
        commandBuffer = new Queue<ICommand>();
        commandHistory = new List<ICommand>();

        dirty_ = false; //Lab 7
    }

    public static void AddCopmmand(ICommand command)
    {
        while(commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }
        
        commandBuffer.Enqueue(command);
    }

    // Update is called once per frame
    void Update()
    {
        if (commandBuffer.Count > 0)
        {
            ICommand c = commandBuffer.Dequeue();
            c.Execute();
            
            //commandBuffer.Dequeue().Execute();

            commandHistory.Add(c);
            counter++;
            Debug.Log("Command history length: " + commandHistory.Count);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (counter > 0)
                {
                    counter--;
                    commandHistory[counter].Undo();
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (counter < commandHistory.Count)
                {
                    commandHistory[counter].Execute();
                    counter++;
                }
            }
        }
        // Lab 7 below
        if (dirty_)
        {
            List<string> lines = new List<string>();

            foreach (ICommand c in commandHistory)
            {
                lines.Add(c.ToString());
            }
            System.IO.File.WriteAllLines(Application.dataPath + "/logsOfEnginesAssign3.txt", lines);

            dirty_ = false;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            dirty_ = true;
        }
    }
}
