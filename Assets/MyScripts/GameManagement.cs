using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public GameObject mainCharacter;
    public GameObject demon;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(mainCharacter, new Vector3(-7.043f, -2.07f), mainCharacter.transform.rotation);
        //Instantiate(demon, new Vector3(4.956f, -1.823f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        GetGameObjects();
    }
    void GetGameObjects(){
        //mainCharacter = GameObject.FindGameObjectWithTag("Player");
        //demon = GameObject.FindGameObjectWithTag("Demon");
    }
}
