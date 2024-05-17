using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public Slider volumeSlider;

    public void Mute()
    {
        volumeSlider.value = 0;
    }
}
