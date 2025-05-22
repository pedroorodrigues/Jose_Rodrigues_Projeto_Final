using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AimGun: MonoBehaviour
{ 
    [SerializeField] private int _fireRate;
    [SerializeField] private float _timePassed;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _player;
    private int _fireDuration;

    private void Start()
    {
        _fireDuration = _fireRate;
    }
    private void Awake()
    {
        //_player = Player.instance.transform;
    }
    private void Update()
    {
        //if (_player != null)
        //{
            //transform.LookAt(_player.position);
            //Fire();
        //}
    }

    //void Fire()
    //{
    //    if (_timePassed < _fireRate)
    //    {

    //        _timePassed += Time.deltaTime;
    //    }
    //    else
    //    {
    //        Vector2 direction = _player.position - transform.position;
    //        Bullet dir = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
    //        dir.SetDirection(direction);
    //        _timePassed = 0;

    //    }
    //}
}