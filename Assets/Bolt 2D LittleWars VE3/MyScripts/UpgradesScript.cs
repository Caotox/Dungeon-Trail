using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Linq;

public class UpgradesScript : MonoBehaviour
{
    // Start is called before the first frame update
    //public  GameObject mainCharacter;
    //public  Script mainCharacterScript;
    //public Text UIText;
    public Upgrade upgradeTemp;
    public string descriptionTemp;
    public string nomUpgradeRandom;
    public int nombreRandom;
    public int probaTemp;
    public int idTemp;
    public int indiceTemp;
    /*
    public Dictionary<int, string> playerUpgrades = new Dictionary<int, string>()
    {
        { 1, "Amélioration de la vitesse" },
        { 2, "Amélioration de la hauteur du saut" },
        { 3, "Tu peux spam les flèches frérot" },
        { 4, "Tu peux spam les spells" },
        { 5, "Augmentation de l'attaque" },
        { 6, "Augmentation des PV max" }
    };
    public Dictionary<int, int> upgradeProba = new Dictionary<int , int>()
    {
        { 1, 20},
        { 2, 20},
        { 3, 5},
        { 4, 5},
        { 5, 10},
        { 6, 40}
    };
    */
    public class Upgrade {
        public string nom;
        public int id;
        public int proba;
        public string descriptif;
        public Upgrade(string nom, int id, int proba, string descriptif){
            this.nom = nom;
            this.id = id;
            this.proba = proba;
            this.descriptif = descriptif;
        }   
    }
    public List<Upgrade> upgrades= new List<Upgrade>{
        new Upgrade("Amélioration de la vitesse", 1, 20, "Augmente la vitesse du joueur"),
        new Upgrade("Amélioration de la hauteur du saut", 2, 20, "Augmente la hauteur du saut du joueur"),
        new Upgrade("Tu peux spam les flèches frérot", 3, 5, "Permet de spam les flèches"),
        new Upgrade("Tu peux spam les spells", 4, 5, "Permet de spam les spells"),
        new Upgrade("Augmentation de l'attaque", 5, 50, "Augmente l'attaque du joueur")};
    void Start()
    {
        //nombreRandom = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Upgrade ActiveUpgrade(List<Upgrade> upgrade){
        indiceTemp = SelectUpgrade(upgrades);
        for (int i=0; i<upgrades.Count; i++){
            if (indiceTemp == upgrade[i].id){
                upgradeTemp = upgrade[i];
                Debug.Log("Description Update sélectionnée :" + upgradeTemp.descriptif);
            }
        }
        return upgradeTemp;
        
    }
    void UpdateText(Upgrade upgrade /*, UItext text*/){
        //UIText.text = upgrade.description;
    }
    void EffetUpgrade(Upgrade upgrade){
        Debug.Log("Effet");
        switch (upgrade.id){
            case 1:
                Debug.Log("Vitesse");
                // effet
                break;
            case 2:
                Debug.Log("Hauteur");
                // effet
                break;
            case 3:
                Debug.Log("Spam flèches");
                // effet
                break;
            case 4:
                Debug.Log("Spam spells");
                // effet
                break;
            case 5:
                Debug.Log("Attaque");
                // effet
                break;
            case 6:
                Debug.Log("PV max");
                // effet
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            Destroy(gameObject);
            upgradeTemp = ActiveUpgrade(upgrades);
            EffetUpgrade(upgradeTemp);
            //EffetUpgrade();
        }
    }
    void AddUpgrade(List<Upgrade> upgrade, string nom, int id, int proba, string descriptif){
        upgrade.Add(new Upgrade(nom, id, proba, descriptif));
        /*Array.Resize(ref upgrades, upgrades.Length + 1);
        upgrades[upgrades.Length - 1] = new upgrade("Augmentation du Mana max", 6, 40, "Augmente les points de mana maximum du joueur");*/
    }
    int SelectUpgrade(List<Upgrade> upgrade){
        nombreRandom = Random.Range(0, 100);
        Debug.Log("nombre random" + nombreRandom);
        while (nombreRandom > 0){ // Faire en sorte que 1 itération = 1 - nombre random et pas après itération
            Debug.Log("nombre random après itération" + nombreRandom);
            for (int i=0; i< upgrade.Count; i++){
                Debug.Log("indice :" + i + "upgrade :" + upgrade[i].nom);
                //idTemp = upgrades[i].id;
                indiceTemp = i;
                nombreRandom -= upgrade[i].proba;
            }
        }
        Debug.Log("indice temp après fonction" + indiceTemp);
        return indiceTemp;
    }
}
