using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LivesUI : MonoBehaviour
{
    public Text livestext;

    void Update()
    {
        livestext.text = CommandInvoker.lives.ToString();
    }
}
