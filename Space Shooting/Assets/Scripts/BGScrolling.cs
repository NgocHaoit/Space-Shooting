using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrolling : MonoBehaviour {

    public float Speed;
    public GameObject[] BG;
    private Vector2 viewPortSize;
    private float size = 33.8f;
    private void Start()
    {
        viewPortSize = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }
    private void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);

        if(BG[0].transform.position.y < -viewPortSize.y - size - 1)
        {
            BG[0].transform.position = new Vector3(0,BG[1].transform.position.y + size - 1,0);
        }
        if (BG[1].transform.position.y < -viewPortSize.y - size - 1)
        {
            BG[1].transform.position = new Vector3(0, BG[0].transform.position.y + size - 1, 0);
        }
    }

}
