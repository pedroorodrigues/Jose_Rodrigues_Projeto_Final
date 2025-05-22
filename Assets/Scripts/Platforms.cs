using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    [SerializeField] private int _platformSpeed;
    private Rigidbody2D _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
       
    }
    public void Go()
    {
        _rigidBody.gravityScale = 0;
        _rigidBody.AddForce(Vector2.up * _platformSpeed, ForceMode2D.Impulse);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Go();
        }

    }
}
