/*
		 * (Santiago Garcia II)
		 * (ICommand.cs)
		 * (Assignment 7)
		 * (main command interface to perform all major actions in game )
	*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand  
{

    void Execute();
    void Undo();
}
