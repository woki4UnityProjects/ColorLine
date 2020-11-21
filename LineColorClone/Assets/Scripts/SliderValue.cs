using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    [SerializeField] 
    private PathCreator pathCreator;
    [SerializeField] 
    private Player player;
    
    private Slider slider;

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.maxValue = pathCreator.path.length - 4;
    }

    private void Update()
    {
        slider.value = player.distanceTravelled;
    }
}
