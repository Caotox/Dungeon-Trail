using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject mainCharacter;
    public Rigidbody2D fireBall;
    public float horizontalMove = 1;
    public float direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("Player");
        float direction = Mathf.Sign(mainCharacter.transform.localScale.x);
        if (direction == 1)
        {
            transform.localScale = new Vector3(1*transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-1*transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        fireBall.velocity = new Vector2(8 * direction, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= mainCharacter.transform.position.x + 20){
            Debug.Log("FireBall destroyed");
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Hit Ennemi");
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "DemonFireBall")
        {
            Debug.Log("Hit Object");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Hit Ennemy");
            Destroy(gameObject);
        }
    }
}
