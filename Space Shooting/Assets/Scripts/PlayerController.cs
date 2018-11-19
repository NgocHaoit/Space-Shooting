using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D r2;
    private float x, y;
    private Vector2 viewPortSize;
    // Use this for initialization
    private void Awake()
    {
        viewPortSize = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) - new Vector3(0.5f, .5f, 0f);
    }
    void Start () {
        r2 = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.position = new Vector3(Mathf.Clamp(r2.position.x, -viewPortSize.x, viewPortSize.x), Mathf.Clamp(r2.position.y, -viewPortSize.y, viewPortSize.y));

    }
    void FixedUpdate()
    {
        Movement(x, y);
    }
    void Movement(float x, float y)
    {
        r2.MovePosition(r2.position + new Vector2(x, y) * speed * Time.deltaTime);
  
    }
}
