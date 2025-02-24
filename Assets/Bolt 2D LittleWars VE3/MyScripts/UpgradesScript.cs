using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Unity.TextMeshPro;
using TMPro;
//using System.Linq;

// Text s'update dans le trigger après la fonction d'obtention d'upgrade --> le bouton onlick est la fonction crée pour faire l'effet de l'upgrade : longue fonction avec bcp de if

public class UpgradesScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isUpgrading = false;
    public CanvasGroup UpUI;
    public Button bouton1;
    public  GameObject mainCharacter;
    public GameObject bouton;
    public TextMeshProUGUI Upgrade1Text;
    public TextMeshProUGUI Upgrade2Text;
    public TextMeshProUGUI Upgrade3Text;
    public Upgrade upgradeTemp;
    public Upgrade upgrade1;
    public Upgrade upgrade2;
    public Upgrade upgrade3;
    public string textChose;
    public int idChose;
    public TextMeshProUGUI descriptionText1;
    public TextMeshProUGUI descriptionText2;
    public TextMeshProUGUI descriptionText3;
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
        new Upgrade("Amélioration de la vitesse", 0, 20, "Augmente la vitesse du joueur"),
        new Upgrade("Amélioration de la hauteur du saut", 1, 20, "Augmente la hauteur du saut du joueur"),
        new Upgrade("Tu peux spam les flèches frérot", 2, 5, "Permet de spam les flèches"),
        new Upgrade("Tu peux spam les spells", 3, 5, "Permet de spam les spells"),
        new Upgrade("Augmentation de l'attaque", 4, 50, "Augmente l'attaque du joueur")};
    public List<Upgrade> usedUpgrades = new List<Upgrade>{};
    void Start()
    {
        //nombreRandom = Random.Range(0, 100);
        UpUI.alpha = 0;
        upgrades= new List<Upgrade>{
        new Upgrade("Amélioration de la vitesse", 0, 20, "Augmente la vitesse du joueur"),
        new Upgrade("Amélioration de la hauteur du saut", 1, 20, "Augmente la hauteur du saut du joueur"),
        new Upgrade("Tu peux spam les flèches frérot", 2, 5, "Permet de spam les flèches"),
        new Upgrade("Tu peux spam les spells", 3, 5, "Permet de spam les spells"),
        new Upgrade("Augmentation de l'attaque", 4, 50, "Augmente l'attaque du joueur")};
        usedUpgrades = new List<Upgrade>{};

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void hideUpgrade(){
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            hideUpgrade();
            mainCharacter.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            isUpgrading = true;
            //Destroy(gameObject);
            //upgradeTemp = ActiveUpgrade(upgrades);
            ShowUpgradeMenu();
            upgrade1 = ActiveUpgrade(upgrades);
            AddUpgrade(usedUpgrades, upgrade1.nom, upgrade1.id, upgrade1.proba, upgrade1.descriptif);
            upgrade2 = ActiveUpgrade(upgrades);
            AddUpgrade(usedUpgrades, upgrade2.nom, upgrade2.id, upgrade2.proba, upgrade2.descriptif);
            upgrade3 = ActiveUpgrade(upgrades);
            Upgrade1Text.text = upgrade1.nom;
            Upgrade2Text.text = upgrade2.nom;
            Upgrade3Text.text = upgrade3.nom;
            descriptionText1.text = upgrade1.descriptif;
            descriptionText2.text = upgrade2.descriptif;
            descriptionText3.text = upgrade3.descriptif;
            if(upgradeTemp == null){
                Debug.Log("Erreur : Upgrade null");
            } else {
                Debug.Log("Update selectionnée");
                //UpdateText(upgradeTemp.descriptif);            
            }
            //EffetUpgrade();
        }
    }
    public void ShowUpgradeMenu()
    {
        UpUI.alpha = 1;
        UpUI.interactable = true;
        UpUI.blocksRaycasts = true;
    }

    public void HideUpgradeMenu()
    {
        UpUI.alpha = 0;
        UpUI.interactable = false;
        UpUI.blocksRaycasts = false;
    }
    Upgrade ActiveUpgrade(List<Upgrade> upgrade){
        indiceTemp = SelectUpgrade(upgrades);
        for (int i=0; i<upgrades.Count; i++){
            if (indiceTemp == upgrade[i].id){
                upgradeTemp = upgrade[i];
            }
        }
        return upgradeTemp;
        
    }
    int lookUpgradeByName(string name, List<Upgrade> upgrades)
    {
        for (int i=0; i<upgrades.Count; i++)
        {
            if (name == upgrades[i].nom)
            {
                return upgrades[i].id;
            }
        }
        return -1;
    }
    /*
    Upgrade GiveUpgrade1{
        // écrire fonction
    }
    Upgrade GiveUpgrade2{
        // écrire fonction
    }
    Upgrade GiveUpgrade3{
        // écrire fonction
    }
    */
    public void EffetUpgrade(){
        bouton = GameObject.FindGameObjectWithTag("Upgrades");
        textChose = bouton.GetComponentInChildren<TextMeshProUGUI>().text;
        idChose = lookUpgradeByName(textChose, upgrades);
        switch (idChose){
            case -1 :
                Debug.Log("Erreur : Upgrade non trouvée");
                break;
            case 0:
                Debug.Log("Vitesse");
                mainCharacter.GetComponent<MainCharacterScript>().speed += 12;
                HideUpgradeMenu();
                isUpgrading = false;
                // effet
                break;
            case 1:
                Debug.Log("Hauteur");
                mainCharacter.GetComponent<MainCharacterScript>().nombreDeSautsMax += 2;
                HideUpgradeMenu();
                isUpgrading = false;
                // effet
                break;
            case 2:
                Debug.Log("Spam flèches");
                mainCharacter.GetComponent<MainCharacterScript>().timerArrowMax -= 1;
                HideUpgradeMenu();
                isUpgrading = false;
                // effet
                break;
            case 3:
                Debug.Log("Spam spells");
                mainCharacter.GetComponent<MainCharacterScript>().timerStaffMax -= 1;
                HideUpgradeMenu();
                isUpgrading = false;
                // effet
                break;
            case 4:
                Debug.Log("Attaque");
                mainCharacter.GetComponent<MainCharacterScript>().attackDamage += 2;
                HideUpgradeMenu();
                isUpgrading = false;
                // effet
                break;
            case 5:
                Debug.Log("PV max");
                mainCharacter.GetComponent<MainCharacterScript>().maxHP += 100;
                HideUpgradeMenu();
                isUpgrading = false;
                // effet
                break;
        }
    }
    void AddUpgrade(List<Upgrade> upgrade, string nom, int id, int proba, string descriptif){
        upgrade.Add(new Upgrade(nom, id, proba, descriptif));
        /*Array.Resize(ref upgrades, upgrades.Length + 1);
        upgrades[upgrades.Length - 1] = new upgrade("Augmentation du Mana max", 6, 40, "Augmente les points de mana maximum du joueur");*/
    }
    int SelectUpgrade(List<Upgrade> upgrade){
        int i = 0;
        int iMax = upgrade.Count;
        nombreRandom = Random.Range(0, 100);
        Debug.Log("Nombre random :" + nombreRandom);
                while (i < iMax){
                    //Debug.Log("indice :" + i + "upgrade :" + upgrade[i].nom);
                    //idTemp = upgrades[i].id;
                    //indiceTemp = i;
                    nombreRandom -= upgrade[i].proba;
                    if(nombreRandom <= 0){
                        //Debug.Log("Indice sélectionné :" + (i));
                        return i;
                    }
                    i+=1;
                }
        return 0;
    }
}
