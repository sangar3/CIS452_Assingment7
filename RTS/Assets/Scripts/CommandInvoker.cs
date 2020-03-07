/*
		 * (Santiago Garcia II)
		 * (CommandInvoker.cs)
		 * (Assignment 7)
		 * (This holds commands to carries out requests)
	*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandInvoker : MonoBehaviour
{
    static Stack<ICommand> commandbuffer;
    static List<ICommand> commandHistory;
    static int counter;
    public Text banktext;
    public static int playerbank = 100;
    public int turretcost = 10;
    public static int lives;
    public int startlives = 1;


    
    public AudioClip turretbuildsfx;
   
    private void Awake()
    {
        commandbuffer = new Stack<ICommand>();
        commandHistory = new List<ICommand>();

    }

    public static void AddCommand(ICommand command)
    {
        while (commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }
        commandbuffer.Push(command);

    }

    public void Start()
    {
        banktext.text = playerbank.ToString();
        lives = startlives;

    }

    void Update()
    {
        if (playerbank < turretcost)
        {
            
            Debug.Log("Need more money");
            return;
        }
        if (commandbuffer.Count > 0  ) //keeps track when cubs are placed
        {
            AudioManager.Instance.PlaySFX(turretbuildsfx, 3.0f);
            ICommand c = commandbuffer.Pop();
            c.Execute();
            //commandbuffer.Pop().Execute();

            commandHistory.Add(c);
            counter++;
            
            playerbank -= turretcost;
            Debug.Log("Command History Length: " + commandHistory.Count);
            Debug.Log("Playerbank is: " + playerbank);
            banktext.text = playerbank.ToString();

        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Z)) //undo key
            {
                Debug.Log("z was pressed");
                if (counter > 0)
                {
                    AudioManager.Instance.PlaySFX(turretbuildsfx, 3.0f);
                    counter--;
                    commandHistory[counter].Undo();
                    playerbank += turretcost;
                    Debug.Log("Playerbank is: " + playerbank);
                    banktext.text = playerbank.ToString();

                }
            }
            else if(Input.GetKeyDown(KeyCode.X)) //redo key
            {
                Debug.Log("x was pressed");
                if( counter < commandHistory.Count)
                {
                    AudioManager.Instance.PlaySFX(turretbuildsfx, 3.0f);
                    commandHistory[counter].Execute();
                    counter++;
                    playerbank -= turretcost;
                    Debug.Log("Playerbank is: " + playerbank);
                    banktext.text = playerbank.ToString();
                }
            }
        }
    }





}
