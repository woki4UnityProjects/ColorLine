using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Percent : MonoBehaviour
{
    [SerializeField] 
    private Slider slider;
    
    void Start()
    {
        int percent = (int) (slider.value / slider.maxValue * 100);
        gameObject.GetComponent<TextMeshProUGUI>().text = percent + "%";
    }

}
