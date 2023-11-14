using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] private Vector2 initialvelocity;

    private Rigidbody2D ballRb;
    private bool isballmoving;
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isballmoving)
        {
            launch();
        }
    }

    private void launch()
    {
        transform.parent = null;
        ballRb.velocity = initialvelocity;
        isballmoving = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("block")) 
        {
          Destroy(collision.gameObject);
        }
    }
}
