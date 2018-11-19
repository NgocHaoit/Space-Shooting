using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiManager : MonoBehaviour {
    public GameObject settingPanel, upgradePanel, MapPanel;
    public GameObject player, bullet;
    public Text coinValue;
    public Image bulletImage;
    public Text coinCost;
    public GameObject bulletSprite;

    private void Awake()
    {
        
        if(PlayerManager.Instance)
            coinValue.text = PlayerManager.Instance.GetCoin() + "";
    }

    public void ShowSettings()
    {
        player.SetActive(false);
        bullet.SetActive(false);
        upgradePanel.SetActive(false);
        MapPanel.SetActive(false);
       
        settingPanel.SetActive(true);
    }
    public void ShowMap()
    {
        player.SetActive(false);
        bullet.SetActive(false);
        upgradePanel.SetActive(false);
        MapPanel.SetActive(true);
        
        settingPanel.SetActive(false);
    }
    public void ShowUpgrade()
    {
        player.SetActive(false);
        bullet.SetActive(false);
        upgradePanel.SetActive(true);
        MapPanel.SetActive(false);        
        settingPanel.SetActive(false);

        coinCost.text = 100 + PlayerManager.Instance.GetBulletLV() * 100 +"";
        bulletImage.sprite = BulletManager.instance.bullets[PlayerManager.Instance.GetBulletLV()].sprite;
    }
    public void Close()
    {
        player.SetActive(true);
        bullet.SetActive(true);
        upgradePanel.SetActive(false);
        MapPanel.SetActive(false);
        settingPanel.SetActive(false);
    }
    public void Upgrade()
    {
        int coinV = int.Parse(coinValue.text);
        int coinC = int.Parse(coinCost.text);
        if (coinV >= coinC)
        {
            PlayerManager.Instance.UpdateBulletLV();
            coinCost.text = 100 + PlayerManager.Instance.GetBulletLV() * 149 + "";
            bulletImage.sprite = BulletManager.instance.bullets[PlayerManager.Instance.GetBulletLV()].sprite;
            coinV = coinV - coinC;
            PlayerManager.Instance.SetCoin(coinV);
            coinValue.text = coinV + "";
            bulletSprite.GetComponent<SpriteRenderer>().sprite = BulletManager.instance.bullets[PlayerManager.Instance.GetBulletLV()].sprite;
        }
        else
            return;
    }
}
