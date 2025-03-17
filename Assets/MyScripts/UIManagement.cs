using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagement : MonoBehaviour
{
    public TextMeshProUGUI flechesText;
    public TextMeshProUGUI spellsText;
    public int flechesCount = 0;
    public float manaCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        //flechesText = GameObject.Find("FightUI").GameObject.transform.Find("Canvas/FlechesCount").GetComponent<TextMeshProUGUI>();
        //spellsText = GameObject.Find("FightUI").GameObject.transform.Find("Canvas/SpellsCount").GetComponent<TextMeshProUGUI>();
        flechesText = GameObject.Find("FlechesCount").GetComponent<TextMeshProUGUI>();
        spellsText = GameObject.Find("ManaCount").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        getInformations();   
        updateText(); 
    }
    void getInformations(){
        flechesCount = GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacterScript>().nombreFleches;
        manaCount = GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacterScript>().manaCount;
    }
    void updateText(){
        flechesText.text = flechesCount.ToString();
        spellsText.text = manaCount.ToString();
    }
}
