using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] 
    private PathCreator pathCreator;
    [SerializeField] 
    private float maxSpeed;
    [SerializeField] 
    private float acceleration;
    [HideInInspector] 
    public float distanceTravelled;
    [SerializeField] 
    private Transform mesh;
    private float speed;
    
    [Header("Other")]
    [SerializeField] 
    private GameObject deathParticle;
    [HideInInspector] 
    public bool isFinished = false;
    [HideInInspector] 
    public bool isDead;
    

    private void Update()
    {
        if (Input.GetMouseButton(0) && !isFinished)
        {
            if (speed < maxSpeed)
            {
                speed += Time.deltaTime * acceleration;
            }
        }
        else
        {
            if (speed > 0)
            {
                speed -= Time.deltaTime * acceleration;
            }
            else
            {
                speed = 0;
            }
        }
        
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        mesh.transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        Destroy(mesh.gameObject);
        Destroy(this);
        Instantiate(deathParticle, mesh.transform.position, Quaternion.Euler(-90,0,0));
    }
    
}
