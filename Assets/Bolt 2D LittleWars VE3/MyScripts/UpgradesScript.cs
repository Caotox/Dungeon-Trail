using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesScript : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<int, string> playerUpgrades = new Dictionary<int, string>()
    {
        { 1, "Amélioration de la vitesse" },
        { 2, "Amélioration de la hauteur du saut" },
        { 3, "Tu peux spam les flèches frérot" },
        { 4, "Tu peux spam les spells" },
        { 5, "Augmentation de l'attaque" },
        { 6, "Augmentation des PV max" }
    };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EffetUpgrade(){
        Debug.Log("Upgrade");
    }
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            Destroy(gameObject);
            EffetUpgrade();
        }
    }
}
