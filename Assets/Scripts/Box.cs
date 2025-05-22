using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        if (GameManager.instance.Time == true)
        {
            _rigidBody.gravityScale = 300f;

        }
    }
}
