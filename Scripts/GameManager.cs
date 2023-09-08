using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("  Spawn System   ")]
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeToSpawn, timeToDestroy;
    [SerializeField] private float speed;
    private float spawnTimer;

    [Header(" Menu System")]
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject reloadButton;


    [Header("Score System")]
    [SerializeField] private TextMeshProUGUI score;
    private float scoreTimer;

    void Start()
    {
        Time.timeScale = 0f;
        spawnTimer = timeToSpawn;
    }

    
    void Update()
    {
        scoreTimer += Time.deltaTime;
        score.text = $"{Mathf.Round(scoreTimer)}";

        if(speed < 6f)
            speed += 0.05f;
        
        SpawnObject();
    }

    private void SpawnObject()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= timeToSpawn)
        {
            Instantiate(spawnObject, spawnPoint.position, Quaternion.identity);



            spawnTimer = 0;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        reloadButton.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        playButton.SetActive(false);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    public float Speed()
    {
        return speed;
    }
    
    public float TimeToDestroy()
    {
        return timeToDestroy;
    }
}
