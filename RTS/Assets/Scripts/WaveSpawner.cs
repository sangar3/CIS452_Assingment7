using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform SpawnPoint;

    public float timebetweenwaves = 5.5f;
    public float countdown = 2f;
    private int waveIndex = 0;

    public Text waveCountdownText;


    public float spawntimer =0.5f;

    void Update()
    {
        if(countdown <=0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timebetweenwaves;

        }


        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }


    IEnumerator SpawnWave() //helps pause spawning
    {
        waveIndex++; //waves get bigger after every round 
        Debug.Log("Wave incoming!");
        
        for (int i = 0; i < waveIndex; i++)
        {
            Debug.Log("Spawn Enemy");
            SpawnEnemy();
            yield return new WaitForSeconds(spawntimer);
        }
        
       



    }


    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);

    }
}
