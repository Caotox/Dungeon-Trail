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
    public GameObject button1;
    public GameObject button2;
    public GameObject button3; 
    public Sprite greenUpgrade;
    public Sprite blueUpgrade;
    public Sprite violetUpgrade;
    public Sprite legUpgrade;
    public Sprite arrowUpgrade;
    public Sprite staffUpgrade;
    public Sprite swordUpgrade;
    public SpriteRenderer spriteRenderer;
    public bool isDoublon = false;
    // spriteRenderer.sprite = newSprite;
    public static bool isUpgrading = false;
    public CanvasGroup UpUI;
    public GameObject mainCharacter;
    public GameObject bouton;
    public TextMeshProUGUI Upgrade1Text;
    public TextMeshProUGUI Upgrade2Text;
    public TextMeshProUGUI Upgrade3Text;
    public Upgrade upgradeTemp;
    public Upgrade upgrade1;
    public Upgrade upgrade2;
    public Upgrade upgrade3;
    public string rareteTemp;
    public string textChose;
    public int idChose;
    public TextMeshProUGUI descriptionText1;
    public TextMeshProUGUI descriptionText2;
    public TextMeshProUGUI descriptionText3;
    public string descriptionTemp;
    public string nomUpgradeRandom;
    public int nombreRandom;
    public int nombreRandom2;
    public int probaTemp;
    public int idTemp;
    public int indiceTemp;
    public List<Upgrade> upgradeToChose;

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
    public class Rarety {
        public string nom;
        public int proba;
        public Rarety(string nom, int proba){
            this.nom = nom;
            this.proba = proba;
        }
    }
    public List<int> listeId = new List<int>{};
    public List<Upgrade> upgradeGreen= new List<Upgrade>{
        new Upgrade("Amélioration de la vitesse", 0, 20, "Augmente la vitesse du joueur"),
        new Upgrade("Amélioration de la hauteur du saut", 1, 20, "Augmente la hauteur du saut du joueur"),
        new Upgrade("Tu peux spam les flèches frérot", 2, 5, "Permet de spam les flèches"),
        new Upgrade("Tu peux spam les spells", 3, 5, "Permet de spam les spells"),
        new Upgrade("Augmentation de l'attaque", 4, 50, "Augmente l'attaque du joueur")};
    public List<Upgrade> upgradeBlue= new List<Upgrade>{
        new Upgrade("Amélioration de la vitesse", 0, 20, "Augmente la vitesse du joueur"),
        new Upgrade("Amélioration de la hauteur du saut", 1, 20, "Augmente la hauteur du saut du joueur"),
        new Upgrade("Tu peux spam les flèches frérot", 2, 5, "Permet de spam les flèches"),
        new Upgrade("Tu peux spam les spells", 3, 5, "Permet de spam les spells"),
        new Upgrade("Augmentation de l'attaque", 4, 50, "Augmente l'attaque du joueur")};
    public List<Upgrade> upgradeViolet= new List<Upgrade>{
        new Upgrade("Amélioration de la vitesse", 0, 20, "Augmente la vitesse du joueur"),
        new Upgrade("Amélioration de la hauteur du saut", 1, 20, "Augmente la hauteur du saut du joueur"),
        new Upgrade("Tu peux spam les flèches frérot", 2, 5, "Permet de spam les flèches"),
        new Upgrade("Tu peux spam les spells", 3, 5, "Permet de spam les spells"),
        new Upgrade("Augmentation de l'attaque", 4, 50, "Augmente l'attaque du joueur")};
    public List<Upgrade> upgradeLeg= new List<Upgrade>{
        new Upgrade("Amélioration de la vitesse", 0, 20, "Augmente la vitesse du joueur"),
        new Upgrade("Amélioration de la hauteur du saut", 1, 20, "Augmente la hauteur du saut du joueur"),
        new Upgrade("Tu peux spam les flèches frérot", 2, 5, "Permet de spam les flèches"),
        new Upgrade("Tu peux spam les spells", 3, 5, "Permet de spam les spells"),
        new Upgrade("Augmentation de l'attaque", 4, 50, "Augmente l'attaque du joueur")};
    public List<Upgrade> upgradeSword= new List<Upgrade>{
        new Upgrade("Amélioration de la vitesse", 0, 20, "Augmente la vitesse du joueur"),
        new Upgrade("Amélioration de la hauteur du saut", 1, 20, "Augmente la hauteur du saut du joueur"),
        new Upgrade("Tu peux spam les flèches frérot", 2, 5, "Permet de spam les flèches"),
        new Upgrade("Tu peux spam les spells", 3, 5, "Permet de spam les spells"),
        new Upgrade("Augmentation de l'attaque", 4, 50, "Augmente l'attaque du joueur")};
    public List<Upgrade> upgradeArrow= new List<Upgrade>{
        new Upgrade("Amélioration de la vitesse", 0, 20, "Augmente la vitesse du joueur"),
        new Upgrade("Amélioration de la hauteur du saut", 1, 20, "Augmente la hauteur du saut du joueur"),
        new Upgrade("Tu peux spam les flèches frérot", 2, 5, "Permet de spam les flèches"),
        new Upgrade("Tu peux spam les spells", 3, 5, "Permet de spam les spells"),
        new Upgrade("Augmentation de l'attaque", 4, 50, "Augmente l'attaque du joueur")};
    public List<Upgrade> upgradeStaff= new List<Upgrade>{
        new Upgrade("Amélioration de la vitesse", 0, 20, "Augmente la vitesse du joueur"),
        new Upgrade("Amélioration de la hauteur du saut", 1, 20, "Augmente la hauteur du saut du joueur"),
        new Upgrade("Tu peux spam les flèches frérot", 2, 5, "Permet de spam les flèches"),
        new Upgrade("Tu peux spam les spells", 3, 5, "Permet de spam les spells"),
        new Upgrade("Augmentation de l'attaque", 4, 50, "Augmente l'attaque du joueur")};
    public List<Rarety> listeProbaUpgrades = new List<Rarety>{
        new Rarety("Vert", 65),
        new Rarety("Bleu", 25),
        new Rarety("Violet", 5),
        new Rarety("Légendaire", 2),
        new Rarety("Sword", 1),
        new Rarety("Arc", 1),
        new Rarety("Spell", 1)};

    void Start()
    {
        InstantitateObjects();
        //UpUI.alpha = 0;
        InstantiateUpgrade();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void InstantiateUpgrade(){
        rareteTemp = SelectRandomRarete();
        ActiveRareteUpgrade(rareteTemp);
    }
    void InstantitateObjects(){
        UpUI=GameObject.Find("Upgrades Canva").GetComponent<CanvasGroup>();
        button1 = UpUI.transform.Find("Upgrade1Gen/Upgrade1")?.gameObject;
        button2 = UpUI.transform.Find("Upgrade2Gen/Upgrade2")?.gameObject;
        button3 = UpUI.transform.Find("Upgrade3Gen/Upgrade3")?.gameObject;
        Upgrade1Text = UpUI.transform.Find("Upgrade1Gen/Upgrade1/TextUpgrade1")?.GetComponent<TextMeshProUGUI>();
        Upgrade2Text = UpUI.transform.Find("Upgrade2Gen/Upgrade2/TextUpgrade2")?.GetComponent<TextMeshProUGUI>();
        Upgrade3Text = UpUI.transform.Find("Upgrade3Gen/Upgrade3/TextUpgrade3")?.GetComponent<TextMeshProUGUI>();
        descriptionText1 = UpUI.transform.Find("Upgrade1Gen/Description1")?.GetComponent<TextMeshProUGUI>();
        descriptionText2 = UpUI.transform.Find("Upgrade2Gen/Description2")?.GetComponent<TextMeshProUGUI>();
        descriptionText3 = UpUI.transform.Find("Upgrade3Gen/Description3")?.GetComponent<TextMeshProUGUI>();
        mainCharacter = GameObject.FindGameObjectWithTag("Player");

    }
    void hideUpgrade(){
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            //hideUpgrade();
            mainCharacter.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            isUpgrading = true;
            //Destroy(gameObject);
            //upgradeTemp = ActiveUpgrade(upgrades);
            ShowUpgradeMenu();
            upgrade1 = ActiveUpgrade(upgradeGreen);
            upgrade2 = ActiveUpgrade(upgradeGreen);
            upgrade3 = ActiveUpgrade(upgradeGreen);
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
    Upgrade ActiveUpgrade(List<Upgrade> upgradeToChose){
        indiceTemp = SelectUpgrade(upgradeToChose);
        for (int i=0; i<upgradeToChose.Count; i++){
            if (indiceTemp == upgradeToChose[i].id){
                upgradeTemp = upgradeToChose[i];
            }
        }
        return upgradeTemp;   
    }
    int lookUpgradeByName(string name, List<Upgrade> upgradeToChose)
    {
        Debug.Log(upgradeGreen.Count);
        upgradeToChose = upgradeGreen;
        Debug.Log(upgradeToChose.Count);
        for (int i=0; i<upgradeToChose.Count; i++)
        {
            if (name == upgradeToChose[i].nom)
            {
                return upgradeToChose[i].id;
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
    public void Button1(){
        EffetUpgrade(button1);
    }
    public void Button2(){
        EffetUpgrade(button2);
    }
    public void Button3(){
        EffetUpgrade(button3);
    }
    public void EffetUpgrade(GameObject bouton){
        //bouton = GameObject.FindGameObjectWithTag("Upgrades");
        textChose = bouton.GetComponentInChildren<TextMeshProUGUI>().text;
        idChose = lookUpgradeByName(textChose, upgradeGreen);
        Debug.Log(idChose);
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
                mainCharacter.GetComponent<MainCharacterScript>().attackDamage += 200;
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
    string SelectRandomRarete(){
        nombreRandom = Random.Range(0, 100);
        //Debug.Log("Nombre random :" + nombreRandom);
        for (int i=0; i<listeProbaUpgrades.Count; i++){
            nombreRandom -= listeProbaUpgrades[i].proba;
            if(nombreRandom <= 0){
                rareteTemp= listeProbaUpgrades[i].nom;
                Debug.Log("Rareté : " + rareteTemp);
                return rareteTemp;
            }
        }
        return "null";
    }
        void ActiveRareteUpgrade(string rareteTemp){
             switch (rareteTemp){
            case "null" :
                Debug.Log("Erreur : Rarete non trouvée");
                break;
            case "Vert":
                spriteRenderer.sprite = greenUpgrade;
                upgradeToChose = upgradeGreen;
                break;
            case "Bleu":
                spriteRenderer.sprite = blueUpgrade;
                upgradeToChose = upgradeBlue;
                break;
            case "Violet":
                spriteRenderer.sprite = violetUpgrade;
                upgradeToChose = upgradeViolet;
                break;
            case "Légendaire":
                spriteRenderer.sprite = legUpgrade;
                upgradeToChose = upgradeLeg;
                break;
            case "Arc":
                spriteRenderer.sprite = arrowUpgrade;
                upgradeToChose = upgradeArrow;
                break;
            case "Spell":
                spriteRenderer.sprite = staffUpgrade;
                upgradeToChose = upgradeStaff;
                break;
            case "Sword":
                spriteRenderer.sprite = swordUpgrade;
                upgradeToChose = upgradeSword;
                break;
        }
    }
       
    int SelectUpgrade(List<Upgrade> upgradeToChose){
        int i = 0;
        int iMax = upgradeToChose.Count;
        nombreRandom = Random.Range(0, 100);
        //Debug.Log("Nombre random :" + nombreRandom);
                while (i < iMax){
                    //Debug.Log("indice :" + i + "upgrade :" + upgrade[i].nom);
                    //idTemp = upgrades[i].id;
                    //indiceTemp = i;
                    nombreRandom -= upgradeToChose[i].proba;
                    if(nombreRandom <= 0){
                        //Debug.Log("Indice sélectionné :" + (i));
                            for (int j=0; j<listeId.Count; j++){
                                if (listeId[j] == i){
                                    isDoublon = true;
                                }
                            }
                            if (isDoublon == false){
                            listeId.Add(i);
                            //isDoublon = false;
                            return i;
                            } else {
                                isDoublon = false;
                                nombreRandom = Random.Range(0, 100);
                                i = 0;
                            }
                    }
                    i+=1;
                }
        return 0;
    }
}