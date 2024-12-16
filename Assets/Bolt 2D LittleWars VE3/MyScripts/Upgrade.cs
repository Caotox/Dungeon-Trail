using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string upgrade = "Upgrade";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Effects();
    }
    public Upgrade(string upgrade){
        this.upgrade=upgrade;
    }
    public void Effects(){
        if (upgrade == "Upgrade"){
            Debug.Log("Upgrade");
        }
    }
}
