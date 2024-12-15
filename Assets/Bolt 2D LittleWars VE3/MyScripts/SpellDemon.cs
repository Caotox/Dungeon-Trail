using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCast : MonoBehaviour
{
    public Rigidbody2D fireBall;
    public GameObject demon;
    public DemonScript demonScript;
    public string fireDirection;
    // Start is called before the first frame update
    void Start()
    {
        demon = GameObject.FindGameObjectWithTag("Demon");
        demonScript = GameObject.FindGameObjectWithTag("Demon").GetComponent<DemonScript>();
        if (demon != null){
        fireDirection = demon.GetComponent<DemonScript>().fireDirection;
        if (fireDirection == "right"){
            fireBall.velocity = new Vector2(8, 0);
            transform.localScale = new Vector3(-1*Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        else {
        fireBall.velocity = new Vector2(-8, 0);
        }
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if (transform.position.x <= demon.transform.position.x - 40 && demon != null)
        {
            //Debug.Log("FireBall destroyed");
            Destroy(gameObject);
        }
    }
    void FixedUpdate(){
        Debug.Log(demonScript.currenthP);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MCFleche")
        {
            //Debug.Log("Hit Fleche");
        } else if (collision.gameObject.tag == "MCSpell"){
            Destroy(gameObject);
            //Debug.Log("FireBall destroyed onCollision");
        }
        else if (collision.gameObject.tag == "Player"){
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "Demon"){
            //Destroy(gameObject);
        }

    }
}
