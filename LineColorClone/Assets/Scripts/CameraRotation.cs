using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] 
    private float rotationSpeed;
    
    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (player.isFinished)
        {
            transform.Rotate(0,rotationSpeed * Time.deltaTime,0);
        }
    }
}
