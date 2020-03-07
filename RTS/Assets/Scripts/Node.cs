using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color HoverColor;

   
   
    private Renderer rend;
    private Color startcolor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
    }

   
   
    void OnMouseEnter()
    {
        rend.material.color = HoverColor;
        
    }

    void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
