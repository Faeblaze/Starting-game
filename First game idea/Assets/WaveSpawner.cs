﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class WaveSpawner : MonoBehaviour {

    public Transform EnemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;
    private int waveIndex = 0;

    public Text waveCountdownText;

    // creating a countdown and then at 0 spawns waves
    //then reseting it after 0 is done and timebetweenwaves acts as new enemy timer
    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        // Floor rounds the number NO DECIMALS, 
        //Although rand stops JUMPING from 0-5 with the delay anyways.
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }
    // spawning groups of enemies
   // void 
   // CO ROUTINE- pause peace of code to wait before continuing.
   IEnumerator SpawnWave ()
        // TAB TAB auto fill for generic... KINDA COOL
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void SpawnEnemy ()
    {
        Instantiate(EnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
