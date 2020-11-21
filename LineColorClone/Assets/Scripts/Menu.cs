using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] 
    private GameObject startMenu;
    [SerializeField] 
    private GameObject deathMenu;
    [SerializeField] 
    private GameObject finishMenu;
    [SerializeField] 
    private String nextSceneName;

    private Player player;
    private bool isStarted = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isStarted)
            {
                startMenu.SetActive(false);
                isStarted = true; 
            }
            else if (player.isDead)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (player.isFinished)
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }

        if (player.isDead)
        {
            deathMenu.SetActive(true);
        }

        if (player.isFinished)
        {
            finishMenu.SetActive(true);
        }
    }
}


