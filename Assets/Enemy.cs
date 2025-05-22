using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(bullets());
    }
    void Update()
    {
        
    }
    private IEnumerator bullets()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(bullets());
        yield return new WaitForSeconds(1);
        bullet.SetActive(false);


    }
}
