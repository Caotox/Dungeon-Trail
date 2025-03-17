using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagement : MonoBehaviour
{
    public GameObject demon;
    public List<GameObject> waves;
    public int currentWave = 0;
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    
    // Start is called before the first frame update
    void Start()
    {
        GetGameObjects();
        waves  = new List<GameObject>{demon};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetGameObjects(){
        demon = GameObject.FindGameObjectWithTag("Demon");
        spawnPoint1 = GameObject.Find("SpawnPoint1");
        spawnPoint2 = GameObject.Find("SpawnPoint2");
        spawnPoint3 = GameObject.Find("SpawnPoint3");
    }
}
