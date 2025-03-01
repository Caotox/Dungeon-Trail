using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject mainCharacter;
    public string directionShoot;
    public Rigidbody2D fireBall;
    public float direction = 1;
    public float puissanceDash = 8f;
    //public bool isFar = false;
    public float compteurDestroy = 15f;

    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("Player");
        directionShoot = mainCharacter.GetComponent<MainCharacterScript>().direction;
        direction = Mathf.Sign(mainCharacter.transform.localScale.x);
        Shoot();
        DashArriere();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyWhenFar();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            //Debug.Log("Hit Ennemi");
            //Destroy(gameObject);
            enableGameObject();
        }
        if (collision.gameObject.tag == "DemonFireBall")
        {
            //Debug.Log("Hit Object");
            //Destroy(gameObject);
            enableGameObject();
        }
        if (collision.gameObject.layer == 7){
            //Debug.Log("Hit Wall");
            //Destroy(gameObject);
            enableGameObject();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Hit Ennemy");
            //Destroy(gameObject);
            enableGameObject();
        }
        if (collision.gameObject.tag == "DemonFireBall")
        {
            Debug.Log("Hit Object");
            //Destroy(gameObject);
            enableGameObject();
        }
        if (collision.gameObject.layer == 7){
            Debug.Log("Hit Wall");
            //Destroy(gameObject);
            enableGameObject();
        }
        if (collision.gameObject.layer == 3){
            Debug.Log("Hit Ground");
           //Destroy(gameObject);
           enableGameObject();
        }
    }
    void enableGameObject(){
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        if (compteurDestroy > 0){
            compteurDestroy-=Time.deltaTime;
        } else if (compteurDestroy < 0){
            Destroy(gameObject);
            //Debug.Log("destroyed");
        }
    }
    void Shoot(){
        fireBall.velocity = Vector2.zero;
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
            fireBall.velocity = new Vector2(8 * direction, 0);
        }
        else if (directionShoot == "bas"){
            fireBall.velocity = new Vector2(0, -8);
            // code bas
        }
        else if (directionShoot == "haut"){
            // code haut
            fireBall.velocity = new Vector2(0, 8);
        } else {
            fireBall.velocity = new Vector2(8 * direction, 0);
        }
        /*
        if (directionShoot == "diagoDroiteHaut"){
            fireBall.velocity = new Vector2(6 , 3);
            // code diago droite haut

        }
        if (directionShoot == "diagoDroiteBas"){
            fireBall.velocity = new Vector2(6 , -3);
            // code diago droite bas
        }
        if (directionShoot == "diagoHautGauche"){
            fireBall.velocity = new Vector2(-6 , 3);
            // code diago haut gauche
        }
        if (directionShoot == "diagoBasGauche"){
            fireBall.velocity = new Vector2(-6 , -3);
            // code diago bas gauche
        }
        //fireBall.velocity = new Vector2(8 * direction, 0);
        */
    }
    void DashArriere()
    {
        // code 
    }

    void DestroyWhenFar(){
        if (transform.position.x >= mainCharacter.transform.position.x + 20){
            Debug.Log("FireBall destroyed");
            //Destroy(gameObject);
            enableGameObject();
        }
    }
}
