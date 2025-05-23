using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            Collect();
        }
    }

    public void Collect()
    {
        StartCoroutine(GetCoin());
    }

    private IEnumerator GetCoin()
    {
        _animator.SetTrigger("Get");
        GameManager.Instance.GetCoin();
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
}
