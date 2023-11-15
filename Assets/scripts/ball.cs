using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] private Vector2 initialvelocity;
    [SerializeField] private float velocityMultiplayer;

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
          ballRb.velocity *= velocityMultiplayer;
            GameManager.Instance.blockDestroyed();
        }
        velocityfix();
    }
    private void velocityfix()
    {
        float velocitydelta = 0.5f;
        float minVelocity = 0.2f;

        if (Mathf.Abs(ballRb.velocity.x) < minVelocity)
        {
            velocitydelta = Random.value < 0.1f ? velocitydelta : -velocitydelta;
            ballRb.velocity += new Vector2(velocitydelta, 0f);
        }
        if (Mathf.Abs(ballRb.velocity.y) < minVelocity)
        {
            velocitydelta = Random.value < 0.3f ? velocitydelta : -velocitydelta;
            ballRb.velocity += new Vector2(velocitydelta, 0f);
        }
    }
}
