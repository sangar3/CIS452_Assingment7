using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    static Stack<ICommand> commandbuffer;

    private void Awake()
    {
        commandbuffer = new Stack<ICommand>();

    }

    public static void AddCommand(ICommand command)
    {
        commandbuffer.Push(command);

    }
    void Update()
    {
        if(commandbuffer.Count >0)
        {
            ICommand c = commandbuffer.Pop();
            c.Execute();
            //commandbuffer.Pop().Execute();
        }
    }
}
