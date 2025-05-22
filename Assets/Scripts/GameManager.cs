using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Platforms _platforms;
    private Player _player;
    private bool _time;
    private Animator _animator;
    private bool _canDie;
    [SerializeField] Bullet _bullet;
    [SerializeField] private GameObject _present;
    [SerializeField] private GameObject _future;
    [SerializeField] private Image _loseS;
    [SerializeField] private Box _box;
    [SerializeField] private int _coins;

    public bool Time { get => _time; set => _time = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _player = Player.instance;
        _platforms = GetComponent<Platforms>();
        _bullet = GetComponent<Bullet>();
        _box = GetComponent<Box>();
        _coins = 0;
    }


    public void Switch()
    {
        if (_time == true)
        {
            _future.SetActive(true);
            _present.SetActive(false);
            Rigidbody2D[] rigidbody2Ds = FindObjectsOfType<Rigidbody2D>();
            for (int i = 0; i < rigidbody2Ds.Length; i++)
            {
                rigidbody2Ds[i].gravityScale = 0f;
                Player.instance.player();
                
            }
            _time = false;
        }
        else 
        {
            _future.SetActive(false);
            _present.SetActive(true);
            Rigidbody2D[] rigidbody2Ds = FindObjectsOfType<Rigidbody2D>();
            for (int i = 0; i < rigidbody2Ds.Length; i++)
            {
                rigidbody2Ds[i].gravityScale = 1;
               
                
            }
            _time = true;
        }
    }

    public void GameOver()
    {
        if (_canDie == true)
        { 
        StartCoroutine(Lose());
        }
      
    }
    public void GetCoin()
    {
        _coins++;
        if (_coins == 3)
        {
            LoadNextScene();
            print("win");
        }
    }
    public void CanDie()
    {
        _canDie = true;
    }
    public void CantDie()
    {
        _canDie = false;
    }

    private IEnumerator Lose()
    {
        UiManager.instance.spiral();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
        UiManager.instance.spiral();
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1; 

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            print("Você completou todos os níveis!");
           
        }
    }


}


