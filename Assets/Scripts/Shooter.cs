using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireRate;
    private float _timePassed;

    private void Start()
    { 
    }
    private void Update()
    {
        if (_timePassed < _fireRate)
        {

            _timePassed += Time.deltaTime;
        }
        else
        {
            GameObject newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            _timePassed = 0;
        }
    }
}
