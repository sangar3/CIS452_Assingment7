﻿/*
		 * (Santiago Garcia II)
		 * (PlaceCubeCommand.cs)
		 * (Assignment 7)
		 * (Has a binding for a action and a receiver )
	*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCubeCommand : ICommand //concreete class
{

    Vector3 position;
    Color color;
    Transform cube;

    public PlaceCubeCommand(Vector3 position, Color color, Transform cube)
    {
        this.position = position ;
        this.color = color;
        this.cube = cube;

    }

    public void Execute()
    {
        CubePlacer.PlaceCube(position, color, cube);
    }
    public void Undo()
    {
        CubePlacer.RemoveCube(position, color);
    }
}
