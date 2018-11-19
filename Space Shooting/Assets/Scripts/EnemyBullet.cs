using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public int damage;
    public float speed;
    public float gravitySpeed;
    private Rigidbody2D r2;
    public float timeDestroy;
    public static string tag = "EnemyBullet";
    private void Awake()
    {
        r2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
            if (transform.position.y > Camera.main.orthographicSize + 1 || transform.position.y < -Camera.main.orthographicSize - 1)
                gameObject.SetActive(false);
    }

    public void Shoot(bool isGravity, Vector3 direction)
    {
        if (isGravity)
        {
            r2.velocity = Vector3.down * gravitySpeed;
        }
        else
        {
            r2.velocity = direction * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if(player != null)
            {
                player.GetDamage(damage);
                player.GiamPower();
                gameObject.SetActive(false);
            }
        }
    }
}
