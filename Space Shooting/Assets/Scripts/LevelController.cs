using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public EnemyWave[] waves;
    public GameObject power, doubleBullet;
    Vector2 viewPortSize;
    public float timeSpawnPower, timeSpawnDouble;
    public static int enemyCount;
    [SerializeField]
    private GameObject bossWave;
    // Use this for initialization
    private void Awake()
    {
        viewPortSize = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        enemyCount = 0;
        for (int i = 0; i < waves.Length; i++)
        {
            enemyCount += waves[i].wave.GetComponent<Wave>().count;
        }
        Debug.Log(enemyCount);
    }
    void Start () {
        StartCoroutine(WaveController());
        StartCoroutine(CreatePower());
        StartCoroutine(CreateDoubleBullet());
    }
    private void Update()
    {
        if(enemyCount == 0)
        {
            StartCoroutine(CreateBoss());
            enemyCount = -1;
        }
    }

    IEnumerator CreateWave(EnemyWave wave)
    {
        yield return new WaitForSeconds(wave.timeStart);
        Instantiate(wave.wave);
    }
    IEnumerator WaveController()
    {
        for(int i = 0; i < waves.Length; i++)
        {
            StartCoroutine(CreateWave(waves[i]));
        }
        yield return null;
    }
    IEnumerator CreatePower()
    {

        yield return new WaitForSeconds(Random.Range(timeSpawnPower - 1, timeSpawnPower + 1));
        Instantiate(power, new Vector3(Random.Range(-viewPortSize.x + 1.5f, viewPortSize.x - 1.5f), viewPortSize.y, 0), Quaternion.identity);
        StartCoroutine(CreatePower());
    }
    IEnumerator CreateDoubleBullet()
    {

        yield return new WaitForSeconds(Random.Range(timeSpawnDouble - 1, timeSpawnDouble + 1));
        Instantiate(doubleBullet, new Vector3(Random.Range(-viewPortSize.x + 1.5f, viewPortSize.x - 1.5f), viewPortSize.y, 0), Quaternion.identity);
        StartCoroutine(CreateDoubleBullet());
    }
    IEnumerator CreateBoss()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(bossWave); 
    }
}
[System.Serializable]
public class EnemyWave
{
    public GameObject wave;
    public float timeStart;
}
