using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int damage;
    public float speed;
    public float force;
    [SerializeField]
    private GameObject hitEffect;
    // Use this for initialization
    private void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
        if (gameObject.activeInHierarchy)
            if (transform.position.y > Camera.main.orthographicSize + 2)
                gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.GetDamage(damage);
                gameObject.SetActive(false);
            }
        }
    }
}
