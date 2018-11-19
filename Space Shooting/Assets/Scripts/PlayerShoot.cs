using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    [SerializeField]
    private Transform pointShooter;
    private float timer;
    public Guns gun;
    private Player player;
    public float fireRate;
    private WeaponManager weapons;
	// Use this for initialization
	void Start () {
        weapons = GetComponent<WeaponManager>();
        timer = Time.time;
        player = GetComponent<Player>();
        InvokeRepeating("Shooting", 0.5f, 1 / fireRate);
	}
	
	
    void Shooting()
    {
        if (!player.isDoubleBullet)
        {
            weapons.GetWeapon(player.power).Shoot(gun.centerPoint);
            gun.centerEffect.Play();
        }
        else
        {
            weapons.GetWeapon(player.power).Shoot(gun.leftPoint);
            weapons.GetWeapon(player.power).Shoot(gun.rightPoint);
            gun.centerEffect.Pause();
            gun.leftEffect.Play();
            gun.rightEffect.Play();
        }
    }
}
[System.Serializable]
public class Guns
{
    public Transform centerPoint, leftPoint, rightPoint;
    public ParticleSystem centerEffect, leftEffect, rightEffect;

}
