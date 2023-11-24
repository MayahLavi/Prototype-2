using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float time = 1.0f;
    public float timer = Time.time;
    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>=time){
            if (Input.GetKeyDown(KeyCode.Space)){
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timer = 0;
        }
        }
        // On spacebar press, send dog
        
    }
}
