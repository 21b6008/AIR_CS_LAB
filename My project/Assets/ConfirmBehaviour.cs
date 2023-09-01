using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This function is used to get the value of each joint to be sent for moving joints
public class ConfirmBehaviour : MonoBehaviour
{
    public Slider[] mySlider;
    public static String jointVals;
    void Update()
    {
        jointVals = Math.Round(mySlider[0].value, 2) + " " + Math.Round(mySlider[1].value, 2) + " " + Math.Round(mySlider[2].value, 2) + " " + Math.Round(mySlider[3].value, 2) + " " + Math.Round(mySlider[4].value, 2) + " " + Math.Round(mySlider[5].value, 2);
    }
}
