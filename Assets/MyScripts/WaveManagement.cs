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
    public class WaveDiff1{
    }
    public class WaveDiff2{
    }
    public class WaveDiff3{
    }
    public class WaveDiff4{
    }
    public class WaveDiff5{
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GetGameObjects();
        waves  = new List<GameObject>{demon};
        SpawnEnnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnnemies(){
        Instantiate(demon, spawnPoint1.transform.position, Quaternion.identity);
        Instantiate(demon, spawnPoint2.transform.position, Quaternion.identity);
        Instantiate(demon, spawnPoint3.transform.position, Quaternion.identity);
    }
    void GetGameObjects(){
        //demon = GameObject.FindGameObjectWithTag("Demon");
        spawnPoint1 = GameObject.Find("SpawnPoint1");
        spawnPoint2 = GameObject.Find("SpawnPoint2");
        spawnPoint3 = GameObject.Find("SpawnPoint3");
    }
}
