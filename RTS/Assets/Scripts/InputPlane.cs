﻿/*
		 * (Santiago Garcia II)
		 * (InputPlane.cs)
		 * (Assignment 7)
		 * (preforms the work needed to carry out request by checking to see if player touches node )
	*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlane : MonoBehaviour  
{
  

    Camera maincam;
    RaycastHit hitinfo;
    public Transform cubPrefab;
    


    void Awake()
    {
        maincam = Camera.main;
    }
    void Update()
    {
        Placeturret();


    }
   
    void Placeturret()
    {
        if (Input.GetMouseButtonDown(0))
        {


            Ray ray = maincam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitinfo, Mathf.Infinity))
            {
                Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
                ICommand command = new PlaceCubeCommand(hitinfo.point, c, cubPrefab); //command is being created 
                CommandInvoker.AddCommand(command);
            }

        }
    }

}
