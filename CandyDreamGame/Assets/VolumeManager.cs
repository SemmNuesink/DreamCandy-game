using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlide;

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlide.value;
    }
    
}
