using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "New Weapon", fileName = "Weapon")]
public class Weapon : ScriptableObject {
    public GameObject bulletPrefab;
    public string tag;
    public void Shoot(Transform firePoint)
    {
        GameObject bulletPool = ObjectPooler.Instance.GetPooledObject(tag);
        bulletPool.transform.position = firePoint.position;
        bulletPool.transform.rotation = firePoint.rotation;
        bulletPool.SetActive(true);
    }
}
