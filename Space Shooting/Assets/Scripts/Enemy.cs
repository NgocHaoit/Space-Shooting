using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script defines 'Enemy's' health and behavior. 
/// </summary>
public class Enemy : MonoBehaviour {

    #region FIELD
    public int health;
    public GameObject enemyBullet;
    [SerializeField]
    private GameObject destroyExp;

    public string tag;

    [SerializeField]
    private float fireRate;
    private float timer;
    [SerializeField]
    private bool isGravity;
    private Transform player;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject[] items;
    #endregion

    void Start()
    {
        timer = Time.time;
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        if (playerGO)
        {
            player = playerGO.transform;
        }
        InvokeRepeating("Shoot", 0.5f, 1 / fireRate);
    }

   
    void Shoot()
    {
        if (player != null && gameObject != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            GameObject bulletPool = ObjectPooler.Instance.GetPooledObject(EnemyBullet.tag);
            bulletPool.transform.position = firePoint.position;
            bulletPool.transform.rotation = firePoint.rotation;
            bulletPool.SetActive(true);
            bulletPool.GetComponent<EnemyBullet>().Shoot(isGravity, direction);
            
        }
    }
   
    public void GetDamage(int damage) 
    {
        health -= damage;
        if(health <= 0)
        {
            //Instantie Destroy Effect
            Destruction();
        }
    }    
   
    void Destruction()                           
    {
        Instantiate(destroyExp, transform.position, Quaternion.identity);
        if (gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            Instantiate(destroyExp, transform.position, Quaternion.identity);
            GameManager.instance.WinGame();
            Destroy(gameObject);
        }
        else
        {
            LevelController.enemyCount--;
            int item0 = Random.Range(0, 3);
            int item1 = Random.Range(0, 1);
            int item2 = Random.Range(0, 1);
            int item3 = Random.Range(0, 30);
            int item4 = Random.Range(0, 30);



            for (int i = 0; i < item0; i++)
            {
                GameObject obj = (GameObject) ObjectPooler.Instance.GetPooledObject(items[0].tag);
                Debug.Log("BLUE");
                obj.transform.position = transform.position;
                obj.SetActive(true);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)) * 100);
            }
            for (int i = 0; i < item1; i++)
            {
                GameObject obj = (GameObject) ObjectPooler.Instance.GetPooledObject(items[01].tag);
                obj.transform.position = transform.position;
                obj.SetActive(true);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)) * 100);
            }
            for (int i = 0; i < item2; i++)
            {
                GameObject obj = (GameObject) ObjectPooler.Instance.GetPooledObject(items[02].tag);
                obj.transform.position = transform.position;
                obj.SetActive(true);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)) * 100);
            }
            if(item3 >= 28)
            {
                GameObject obj = (GameObject) ObjectPooler.Instance.GetPooledObject(items[03].tag);
                obj.transform.position = transform.position;
                obj.SetActive(true);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)) * 100);
            }
            if (item4 >= 28)
            {
                GameObject obj = (GameObject) ObjectPooler.Instance.GetPooledObject(items[04].tag);
                obj.transform.position = transform.position;
                obj.SetActive(true);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)) * 100);
            }

            Destroy(gameObject);
        }
        
    }
}
