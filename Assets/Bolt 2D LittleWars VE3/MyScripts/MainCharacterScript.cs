using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 
public class MainCharacterScript : MonoBehaviour
{
    //public GameObject staff;
    //public GameObject bow;
    //public GameObject sword;
    //public KeyCode attackKey;
    public bool canGrip = true;
    public float timerDeath = 3;
    public float timerGrip = 0;
    public bool isDead = false;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public LayerMask enemyProjectiles;
    public Animator animator;
    public GameObject arrow;
    public GameObject fireBall;
    public Rigidbody2D mainCharacter;
    public float speed = 7.0f;
    public float attackDamage = 20.0f;
    public float jumpForce = 10.0f;
    public float offSet;
    public float horizontalMove;    
    public float currenthP;
    public float maxHP = 100.0f;
    public float timerArrow = 0;
    public float timerStaff = 0;
    public float timerEpee = 0;
    public float timerArrowMax = 1.5f;
    public float timerStaffMax = 1.5f;
    public float timerEpeeMax = 1.5f;
    public int nombreDeSauts = 0;
    public int nombreDeSautsMax = 2;
    public bool canArrow = true;
    public bool canStaff = true;
    public bool canEpee = true;
    public bool isPlateformeLeft = false;
    public bool isPlateformeRight = false;
    public float attackRange = 1.3f;
    
    // Start is called before the first frame update
    void Start()
    {
        //demonScript = GameObject.FindGameObjectWithTag("Upgrades").GetComponent<UpgradesScript>();
        gameObject.SetActive(true);
        currenthP = maxHP;
        offSet = 2;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        CharacterMovement();
        CharacterAction();
        FlipCharacter();
        Timers();
        Death();
        GripWall();
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == 3){
            nombreDeSauts = 0;
        }
        if (collision.gameObject.layer == 7){
            nombreDeSauts = 0;
            foreach (ContactPoint2D contact in collision.contacts){
                Vector2 point = contact.normal;
                if (point.x > 0){
                    isPlateformeLeft = true;
                } else {
                    isPlateformeRight = true;
                }
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "DemonFireBall"){
            currenthP -= 30;
            Debug.Log("HP: " + currenthP);
        }
        if (collision.gameObject.layer == 6){
            currenthP -= 20;
            Debug.Log("HP: " + currenthP);
        }
    }
    private void OnCollisionExit2D(Collision2D collision){
        //if (collision.gameObject.layer == 7){
            isPlateformeLeft = false;
            isPlateformeRight = false;
        //}
    }
    void CharacterMovement(){
        if (UpgradesScript.isUpgrading == false){
        Vector2 moveDirection = Vector2.zero;
        if (isPlateformeLeft == false){
            if (Input.GetKey(KeyCode.A)){
            moveDirection = moveDirection + Vector2.left * speed;
        } 
        }
        if (isPlateformeRight == false){
            if (Input.GetKey(KeyCode.D)){
            moveDirection = moveDirection + Vector2.right * speed;
        }
        }
        mainCharacter.velocity = new Vector2(moveDirection.x, mainCharacter.velocity.y);
        if (Input.GetKeyDown(KeyCode.W) && (nombreDeSauts < nombreDeSautsMax)){
            canGrip = false;
            mainCharacter.velocity = new Vector2(mainCharacter.velocity.x, jumpForce);
            nombreDeSauts = nombreDeSauts + 1;
            canGrip = true;
        }
        }
    }
    void FlipCharacter(){
        Vector3 scale = mainCharacter.transform.localScale;
        if (horizontalMove > 0 && !isPlateformeLeft){
            scale.x = Mathf.Abs(scale.x);
            offSet = 2;
        }
        if (horizontalMove < 0 && !isPlateformeRight){
            scale.x = -Mathf.Abs(scale.x);
            offSet = -2;
            
        }
        mainCharacter.transform.localScale = new Vector3(scale.x, scale.y, scale.z);

    }
    void CharacterAction(){
        if (UpgradesScript.isUpgrading == false){
        if (Input.GetKeyDown(KeyCode.U)){
            if (canStaff){
            animator.SetTrigger("isStaffing");
            //staff.SetActive(true);
            //bow.SetActive(false);
            //sword.SetActive(false);
            Instantiate(fireBall, new Vector2(transform.position.x+offSet, transform.position.y+1), transform.rotation);
            timerStaff = timerStaffMax;
            canStaff = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Y)){
            if (canArrow){
            animator.SetTrigger("isBowing");
            //bow.SetActive(true);
            //staff.SetActive(false);
            //sword.SetActive(false);
                Instantiate(arrow, new Vector2(transform.position.x+offSet, transform.position.y), transform.rotation);
                timerArrow = timerArrowMax;
                canArrow = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.I)){
            if (canEpee){
            canEpee = false;
            timerEpee = timerEpeeMax;
            animator.SetTrigger("isAttacking");
            //sword.SetActive(true);
            //staff.SetActive(false);
            //bow.SetActive(false);
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            Collider2D[] hitProjectiles = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyProjectiles);
            Debug.Log(hitEnemies);
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("Hit " + enemy.name);
                enemy.GetComponent<DemonScript>().currenthP -= attackDamage;
                Debug.Log("HP: " + enemy.GetComponent<DemonScript>().currenthP);
            }
            foreach (Collider2D projectile in hitProjectiles)
            {
                Debug.Log("Hit " + projectile.name);
                FireCast fireball = projectile.GetComponent<FireCast>();
                if (fireball != null)
                    {
                        if (fireball.fireBall.transform.localScale.x>0)
                        {
                            if (transform.localScale.x > 0)
                            {
                            fireball.fireBall.velocity = new Vector2(-fireball.fireBall.velocity.x+4, fireball.fireBall.velocity.y);
                            fireball.fireBall.transform.localScale = new Vector3(-fireball.fireBall.transform.localScale.x, fireball.fireBall.transform.localScale.y, fireball.fireBall.transform.localScale.z);
                            } else 
                            {
                            fireball.fireBall.velocity = new Vector2(fireball.fireBall.velocity.x -4, fireball.fireBall.velocity.y);
                            fireball.fireBall.transform.localScale = new Vector3(fireball.fireBall.transform.localScale.x, fireball.fireBall.transform.localScale.y, fireball.fireBall.transform.localScale.z);
                            }
                        } else 
                        {
                            if (transform.localScale.x < 0)
                            {
                            fireball.fireBall.velocity = new Vector2(-fireball.fireBall.velocity.x-4, fireball.fireBall.velocity.y);
                            fireball.fireBall.transform.localScale = new Vector3(-fireball.fireBall.transform.localScale.x, fireball.fireBall.transform.localScale.y, fireball.fireBall.transform.localScale.z);
                            } else 
                            {
                            fireball.fireBall.velocity = new Vector2(fireball.fireBall.velocity.x +4, fireball.fireBall.velocity.y);
                            fireball.fireBall.transform.localScale = new Vector3(fireball.fireBall.transform.localScale.x, fireball.fireBall.transform.localScale.y, fireball.fireBall.transform.localScale.z);
                            }
                        }
                        //fireball.fireBall.velocity = new Vector2(-fireball.fireBall.velocity.x, fireball.fireBall.velocity.y);
                        //fireball.fireBall.transform.localScale = new Vector3(-fireball.fireBall.transform.localScale.x, fireball.fireBall.transform.localScale.y, fireball.fireBall.transform.localScale.z);
                    }
            }
        }
    }
        }
}
    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    void Timers(){
        if (timerArrow <= 0){
            canArrow = true;
        }
        else{
            timerArrow -= Time.deltaTime;
        }
        if (timerStaff <= 0){
            canStaff = true;
        }
        else{
            timerStaff -= Time.deltaTime;
        }
        if (timerEpee <= 0){
            canEpee = true;
        }
        else{
            timerEpee -= Time.deltaTime;
        }
    }
    void Death(){
        // Ajouter la logique d'animation de mort : désactiver le SpriteRenderer = false, jouer l'animation
        if (currenthP <= 0){
            //gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = false;
            //GetComponent<BoxCollider2D>().enabled = false;
            //GetComponent<Rigidbody2D>().enabled = false;
            isDead = true;
        }
        if (isDead){
            mainCharacter.velocity = new Vector2(0, 0); 
            mainCharacter.gravityScale = 0;
            Debug.Log("You are dead" + timerDeath);
            if (timerDeath <= 0){
                    SceneManager.LoadScene("Menu");
                }
                else{
                    timerDeath -= Time.deltaTime;
                }
            }
    }
    void GripWall()
{
    if (canGrip)
    {
    if (Input.GetKey(KeyCode.G))
    {
    if (isPlateformeLeft || isPlateformeRight)
    {
        mainCharacter.velocity = Vector2.zero;
        mainCharacter.gravityScale = 0;
        //nombreDeSauts = 0;
    }
    }
    else
    {
        mainCharacter.gravityScale = 3;
    }
    }
    }
}


