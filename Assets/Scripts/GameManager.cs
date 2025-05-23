using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Player _player;
    private Platforms _platforms;
    private bool _time = true;
    private bool _canDie = true;

    [SerializeField] private GameObject _present;
    [SerializeField] private GameObject _future;
    [SerializeField] private int _coins;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _platforms = GetComponent<Platforms>();
        _coins = 0;
    }

    public void Switch()
    {
        Rigidbody2D[] rigidbody2Ds = FindObjectsOfType<Rigidbody2D>();

        if (_time)
        {
            _future.SetActive(true);
            _present.SetActive(false);

            foreach (var rb in rigidbody2Ds)
                rb.gravityScale = 0f;

            if (_player != null)
                _player.player();

            _time = false;
        }
        else
        {
            _future.SetActive(false);
            _present.SetActive(true);

            foreach (var rb in rigidbody2Ds)
                rb.gravityScale = 1f;

            _time = true;
        }
    }

    public void GameOver()
    {
        if (_canDie)
        {
            StartCoroutine(Lose());
        }
    }

    public void GetCoin()
    {
        _coins++;
        if (_coins >= 3)
        {
            LoadNextScene();
            Debug.Log("Win!");
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
            Debug.Log("Você completou todos os níveis!");
        }
    }
}
