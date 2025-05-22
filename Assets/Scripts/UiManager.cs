using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    //private float _jumpCooldownTimer = 100f;
    //private bool _isJumpInCooldown = false;
    [SerializeField] private Image _jumpCooldown;
    [SerializeField] private Image _loseS;
    [SerializeField] private Image _loseS1;
    [SerializeField] private int _playerLife;
    [SerializeField] private GameObject _loseScreen;
    private bool _isLoop;
    private bool _isLoop1 = false;

    private void Start()
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
    private void Awake()
    {
        if (_loseS1 != null)
        {
            _loseS1.fillAmount = 1f;
        }

        if (_loseS != null)
        {
            _loseS.fillAmount = 0f;
        }

        _isLoop1 = true;
    }
    private void Update()
    {
        if (_isLoop == true && _loseS != null)
        {
            _loseS.fillAmount += Time.deltaTime;
        }
        if (_isLoop1 == true && _loseS1 != null)
        {
            _loseS1.fillAmount -= Time.deltaTime;
        }

        if (_jumpCooldown != null)
        {
            _jumpCooldown.fillAmount += Time.deltaTime;
        }
        else
        {
            Debug.LogError("Referencia de _jumpCooldown não está atribuída no Inspector!");
        }
    }
    public void JumpCooldownTimer()
    {
        _jumpCooldown.fillAmount = 5f;
    }
    public void spiral()
    {
        _isLoop = true;
    }

}
