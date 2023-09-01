using System;
using UnityEngine;
using UnityEngine.UI;

// This script is used to constantly update and display the value of joints when we move the slider
public class SliderBehaviour : MonoBehaviour {
    public Text[] myText;
    public Slider[] mySlider;
    //public InputField[] inputSlider;

    void Update() 
    {
        for (int i = 0; i < myText.Length; i++)
        {
            myText[i].text = "Joint " + (i + 1) + ": " + Math.Round(mySlider[i].value, 2);
            //if (Input.GetKeyUp(KeyCode.Return)) { mySlider[i].value = float.Parse(inputSlider[i].text); }
        }
    }
}
