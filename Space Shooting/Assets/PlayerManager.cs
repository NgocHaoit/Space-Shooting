using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager Instance;

    private const string BulletLV = "Bullet Lv";
    private const string MapLV = "Map Lv";
    private const string Coin = "Coin";

    private void Awake()
    {
        Singleton();
        IsGameStartedForTheFirstTime();
       
    }

    void Singleton()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void IsGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
        {
            SetDefaults();
        }
    }

    public void SetMapLV(int lv)
    {
        PlayerPrefs.SetInt(MapLV, lv);
    }
    public void SetBulletLV(int lv)
    {
        PlayerPrefs.SetInt(BulletLV, lv);
    }
    public void SetCoin(int lv)
    {
        PlayerPrefs.SetInt(Coin, lv);
    }

    public int GetCoin()
    {
        return PlayerPrefs.GetInt(Coin);
    }
    public int GetMapLV()
    {
        return PlayerPrefs.GetInt(MapLV);
    }
    public int GetBulletLV()
    {
        return PlayerPrefs.GetInt(BulletLV);
    }
    public void UpdateBulletLV()
    {
        SetBulletLV(PlayerPrefs.GetInt(BulletLV) + 1);
    }
    public void UpdateMapLV()
    {
        SetMapLV(PlayerPrefs.GetInt(MapLV) + 1);
    }
    public void SetDefaults()
    {
        PlayerPrefs.SetInt(MapLV, 0);
        PlayerPrefs.SetInt(BulletLV, 0);
        PlayerPrefs.SetInt(Coin, 0);
        PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
    }
}
