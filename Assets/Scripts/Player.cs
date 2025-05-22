using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IDamageable
{
    public static Player instance;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private bool forceUnground;
    private Rigidbody2D _rigidBody;
    private bool _canDie;
    private bool _isDead;

    public UnityEvent OnDiedEvent;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce = 2;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float rightRayDistance;
    [SerializeField] private float leftRayDistance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        _rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _isDead = false;
        _canDie = true;
    }

    void Update()
    {
        Debug.DrawRay(transform.position + Vector3.left * leftRayDistance, Vector2.down * groundCheckDistance, Color.red);
        Debug.DrawRay(transform.position + Vector3.right * rightRayDistance, Vector2.down * groundCheckDistance, Color.red);

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Walk", Mathf.Abs(horizontalInput));
        animator.SetBool("isGrounded", isGrounded);

        if (horizontalInput > 0)
            spriteRenderer.flipX = false;
        else if (horizontalInput < 0)
            spriteRenderer.flipX = true;

        Jump();
        GroundCheck();

        _rigidBody.velocity = new Vector2(horizontalInput * movementSpeed, _rigidBody.velocity.y);
    }

    public void Die()
    {
        if (_isDead) return;
        _isDead = true;
        OnDiedEvent?.Invoke();
    }

    private void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.left * leftRayDistance, Vector2.down, groundCheckDistance, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + Vector3.right * rightRayDistance, Vector2.down, groundCheckDistance, groundLayer);

        isGrounded = (hit.collider != null || hit2.collider != null) && !forceUnground;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetTrigger("Jump");
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            UiManager.instance.JumpCooldownTimer();
            forceUnground = true;

            _canDie = false;
            GameManager.instance.CantDie();

            Invoke(nameof(EnableGroundAgain), 2f);
            Invoke(nameof(AllowDieAgain), 0.5f);
            

            GameManager.instance.Switch();
        }
    }

    private void EnableGroundAgain()
    {
        forceUnground = false;
    }

    private void AllowDieAgain()
    {
        GameManager.instance.CanDie();
        _canDie = true;
    }

    public void player()
    {
        _rigidBody.gravityScale = 0.3f;
    }
}
