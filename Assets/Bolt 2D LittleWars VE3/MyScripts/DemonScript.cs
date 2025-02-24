using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonScript : MonoBehaviour
{
    public GameObject demonCharacter;
    public float currenthP;
    public float xposition;
    public float yposition;
    public float maxHP = 100.0f;
    public GameObject enemy_fireball;
    public float timer = 2f;
    public GameObject mainCharacter;
    public string fireDirection;
    public float temp_scale;
    public Rigidbody2D demonRigid;
    public Transform mainCharTransform;
    public float timerStop = 3f;
    public float timerStop2 = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        currenthP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (UpgradesScript.isUpgrading == false){
        if (timer <= 0){
            if (fireDirection == "right")
                Instantiate(enemy_fireball, new Vector2(transform.position.x+1, transform .position.y), transform.rotation);
            else {
                Instantiate(enemy_fireball, new Vector2(transform.position.x-1, transform .position.y), transform.rotation);
                }
            timer = 4f;
        }
        else{
            timer -= Time.deltaTime;
        }
    }
        Death();
        FlipCharacter();
        GetPositions();
        Deplacement();
    }
    void FixedUpdate(){
        StopRegu();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MCSpell")
        {
            currenthP -= 30;
            //Debug.Log("Hit FireBall : " + currenthP);
        }
        if (collision.gameObject.tag == "MCFleche")
        {
            currenthP -= 20;
            //Debug.Log("Hit Fleche : " + currenthP);
        }
    }
    void FlipCharacter()
    {
        if (mainCharacter.transform.position.x < transform.position.x)
        {
            temp_scale = 1;
            fireDirection = "left";
        }
        else
        {
            temp_scale = -1;
            fireDirection = "right";
        }
        transform.localScale = new Vector3(temp_scale*Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    void GetPositions()
    {
        xposition = mainCharTransform.position.x;
        yposition = mainCharTransform.position.y;
    }
    void Deplacement()
    {
        if (UpgradesScript.isUpgrading == false){
        if (fireDirection == "right"){
            if (xposition - transform.position.x > 8){ // avancer
                demonRigid.velocity = Vector2.right * 3;
            } else if (xposition - transform.position.x < 5){ // reculer
                demonRigid.velocity = Vector2.left * 3;
            } else { // ne rien faire
                demonRigid.velocity = Vector2.zero;
            }


        } else if (fireDirection == "left"){
            if (transform.position.x - xposition > 8){ // avancer
                demonRigid.velocity = Vector2.left * 3;
            } else if (transform.position.x - xposition < 5){ // reculer
                demonRigid.velocity = Vector2.right * 3;
            } else { // ne rien faire
                demonRigid.velocity = Vector2.zero;
            }

        }
        }
    }
    void StopRegu(){
        if (timerStop <=0){
            demonRigid.velocity = Vector2.zero;
            if (timerStop2 <=0){
                timerStop = 3f;
                timerStop2 = 1.5f;
            } else {
                timerStop2 -= Time.deltaTime;
            } 
        } else {
            timerStop -= Time.deltaTime;
            Deplacement();
        }
    }
    void Death(){
        if (currenthP <= 0)
            {
                Destroy(gameObject);
                //Instantiate(this.gameObject, new Vector2(6, -1.823f), transform.rotation);
            }
    }
}
