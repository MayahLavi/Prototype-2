using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval); 
       gameManager = GameObject.FindObjectOfType<GameManager>();
       if (gameManager == null)
        {
            Debug.Log("GameManager not found in the scene. Make sure it has the correct tag.");
        }
        else{
            Debug.Log("found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX),0,spawnPosZ);
            int animalIndex = Random.Range(0,animalPrefabs.Length);
            GameObject newAnimal = Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
            DestroyOutOfBounds scriptComponent = newAnimal.GetComponent<DestroyOutOfBounds>();
            if (scriptComponent != null){
                scriptComponent.gameManager = gameManager;
                bool res = (scriptComponent.gameManager == null);
                Debug.Log(res);
            }
            
    }
}
