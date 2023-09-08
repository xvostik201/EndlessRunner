using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [Header("Settings")]

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); 
        Destroy(gameObject, gameManager.TimeToDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.forward * gameManager.Speed() * Time.deltaTime;
    }
}
