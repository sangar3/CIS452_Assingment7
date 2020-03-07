/*
		 * (Santiago Garcia II)
		 * (CubePlacer.cs)
		 * (Assignment 7)
		 * (creates the turret creation commands and setting the recevier )
	*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour //client class 
{
    

    static List<Transform> cubes;
    
    public static void PlaceCube(Vector3 position, Color color, Transform cube)
    {
        Transform newCube = GameObject.Instantiate(cube, position, Quaternion.identity);
        newCube.GetComponentInChildren<MeshRenderer>().material.color = color;
        if( cubes == null)
        {
            cubes = new List<Transform>();

        }
        cubes.Add(newCube); //keeping track of cube
        
    }

    public static void RemoveCube(Vector3 position, Color color)
    {
        for(int i = 0; i < cubes.Count; i++)
        {
            if(cubes[i].position == position && cubes[i].GetComponentInChildren<MeshRenderer>().material.color == color)
            {
                GameObject.Destroy(cubes[i].gameObject); //removing cube
                cubes.RemoveAt(i);
            }
        }
    }
}

