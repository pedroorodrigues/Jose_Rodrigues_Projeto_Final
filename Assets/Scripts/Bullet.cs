using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private Rigidbody2D _force;
    //[SerializeField] private int _velocity;
    [SerializeField] private int _bulletSpeed;
    [SerializeField] private float _bulletLife;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        Go();
        if (GameManager.instance.Time == false)
        {
            _rigidBody.gravityScale = 0;
        }
    }
 
    public void Go()
    {
        _rigidBody.AddForce(Vector2.left * _bulletSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, _bulletLife);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player playerDetected = collision.GetComponent<Player>();
        if (playerDetected != null)
        {
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
