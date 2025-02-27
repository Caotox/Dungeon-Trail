using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public GameObject mainCharacter;
    public string directionShoot;
    public Rigidbody2D arrow;
    public float direction;
    public float compteurBoostVitesse = 2f;
    public bool hasShot = false;
    public bool hasBuff = false;
    public bool isTouched = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("Player");
        directionShoot = mainCharacter.GetComponent<MainCharacterScript>().direction;
        Debug.Log(directionShoot);
        float direction = Mathf.Sign(mainCharacter.transform.localScale.x);
        if (direction == 1)
        {
            transform.localScale = new Vector3(1*transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-1*transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        if (directionShoot == "gauche" || directionShoot == "droite")
        {
            arrow.velocity = new Vector2(15 * direction, 0);
            //BoostVitesse();
            hasBuff = false;
            hasShot = true;
        }
        /*
        if (directionShoot == "bas"){
            arrow.velocity = new Vector2(0, -10);
            // code bas
        }
        if (directionShoot == "haut"){
            // code haut
            arrow.velocity = new Vector2(0, 10);
        }
        */
        else if (directionShoot == "diagoDroiteHaut"){
            arrow.velocity = new Vector2(10 , 5);
            //BoostVitesse();
            hasShot = true;
            hasBuff = false;
        }
        else if (directionShoot == "diagoDroiteBas"){
            arrow.velocity = new Vector2(10 , -5);
            //BoostVitesse();
            hasShot = true;
            hasBuff = false;
        }
        else if (directionShoot == "diagoHautGauche"){
            arrow.velocity = new Vector2(-10 , 5);
            //BoostVitesse();
            hasShot = true;
            hasBuff = false;
        }
        else if (directionShoot == "diagoBasGauche"){
            arrow.velocity = new Vector2(-10 , -5);
            //BoostVitesse();
            hasShot = true;
            hasBuff = false;
        } else {
            Debug.Log(direction);
            arrow.velocity = new Vector2(15 * direction, 0);
            //BoostVitesse();
            hasShot = true;
            hasBuff = false;
        }
        //arrow.velocity = new Vector2(15 * direction, 0);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mainCharacter.GetComponent<MainCharacterScript>().speed);
        if (transform.position.x >= mainCharacter.transform.position.x + 20){
            Debug.Log("Arrow destroyed");
            Destroy(gameObject);
        }
        //BoostVitesse();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTouched = true;
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Hit Ennemi");
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 7){
            Debug.Log("Hit Wall");
            Destroy(gameObject);
        }
    }
    void BoostVitesse(){
        if (isTouched = true && hasBuff == true){
            mainCharacter.GetComponent<MainCharacterScript>().speed -= 10;
            hasBuff = false;
        }
        if (hasShot == true && hasBuff == false){
            mainCharacter.GetComponent<MainCharacterScript>().speed += 10;
            hasBuff = true;
        }
        if (compteurBoostVitesse>0 && hasShot == true){
            compteurBoostVitesse-=Time.deltaTime;
            Debug.Log(compteurBoostVitesse);
        } else if (compteurBoostVitesse < 0 && hasShot == true){
            mainCharacter.GetComponent<MainCharacterScript>().speed -= 10;
            hasShot = false;
        }
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTouched = true;
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Hit Ennemy");
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "DemonFireBall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 7){
            Debug.Log("Hit Wall");
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 3){
            Debug.Log("Hit Ground");
            Destroy(gameObject);
        }
    }
    void UpdateVelocity(){
        //switch (direction)
    }
}
