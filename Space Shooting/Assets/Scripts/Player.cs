using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int maxHealth;
    public int health;
    public int power = 0;
    public bool isDoubleBullet;
    public float dbTime;
    public float coin;
    [SerializeField]
    private GameObject destroyEffect;
    [SerializeField]
    private Text coinValue;
    private void Awake()
    {
        coin = 0;
        health = maxHealth;
        if(PlayerManager.Instance != null)
        {
            power = PlayerManager.Instance.GetBulletLV();
        }
    }

    public void GetDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destruction();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Power")
        {
            if (power < 17)
            {
                power++;
            }

            collision.gameObject.SetActive(false);
        }
        if(collision.tag == "DoubleBullet")
        {
            StartCoroutine(DoubleBullet());
            collision.gameObject.SetActive(false);
        }
        if(collision.tag == "Blue")
        {
            coin += 5;
            coinValue.text = coin + "";
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "Red")
        {
            coin += 10;
            coinValue.text = coin + "";
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "Pupple")
        {
            coin += 15;
            coinValue.text = coin + "";
            collision.gameObject.SetActive(false);
        }
    }
    public void GiamPower()
    {
        if(power >= 1)
        {
            power--;
        }
    }
    IEnumerator DoubleBullet()
    {
        isDoubleBullet = true;
        yield return new WaitForSeconds(dbTime);
        isDoubleBullet = false;
    }
    void Destruction()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        GameManager.instance.LoseGame();
        Destroy(gameObject);
    }
}
