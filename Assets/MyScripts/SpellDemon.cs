using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCast : MonoBehaviour
{
    public Rigidbody2D fireBall;
    public GameObject demon;
    public DemonScript demonScript;
    public string fireDirection;
    //public bool isFar = false;
    public float compteurDestroy = 15f;

    // Start is called before the first frame update
    void Start()
    {
        demon = GameObject.FindGameObjectWithTag("Demon");
        demonScript = GameObject.FindGameObjectWithTag("Demon").GetComponent<DemonScript>();
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyWhenFar();
        getPos();
    }
    void FixedUpdate(){
        //Debug.Log(demonScript.currenthP);
    }
    void getPos(){
        fireDirection = demon.GetComponent<DemonScript>().fireDirection;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MCFleche")
        {
            //Debug.Log("Hit Fleche");
        } 
        if (collision.gameObject.tag == "MCSpell"){
            //Destroy(gameObject);
            enableGameObject();
            //Debug.Log("FireBall destroyed onCollision");
        }
        if (collision.gameObject.tag == "Player"){
            //Destroy(gameObject);
            enableGameObject();
        } 
        if (collision.gameObject.tag == "Demon"){
            //Destroy(gameObject);
            //enableGameObject();
        }
        if (collision.gameObject.layer == 3){
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
        if (fireDirection == "right"){
            fireBall.velocity = new Vector2(8, 0);
            transform.localScale = new Vector3(-1*Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        else {
        fireBall.velocity = new Vector2(-8, 0);
        }
    }
    void DestroyWhenFar(){
        if (transform.position.x <= demon.transform.position.x - 40 && demon != null)
        {
            //Debug.Log("FireBall destroyed");
            //Destroy(gameObject);
            enableGameObject();
        }
    }
}
