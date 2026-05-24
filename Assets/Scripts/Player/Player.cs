using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
[SelectionBase]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event EventHandler OnPlayerDeath;
    public event EventHandler OnFlashBlink;

    [SerializeField] private float movingSpeed = 10f;
    [SerializeField] public int maxHealf = 100;
    [SerializeField] private float damageRecoveryTime = 0.5f;
    [SerializeField] private float blockRecoveryTime = 0.5f;
    [Header("Dash Setting")]
    [SerializeField] private int dashSpeed = 4;
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private float dashCoolDownTime = 3f;


    private Rigidbody2D _rb;
    private KnockBack _knockBack;

    private PolygonCollider2D _polygonCollider2D;
    private float _minMovingSpeed = 0.1f;
    private bool _isRunning = false;

    public int _currentHealf;
    public bool _canTakeDamage;
    private bool _isAlive = true;
    private Camera _mainCamera;
    private float _initialMovingSpeed;
    private bool _isDashing;


    public float BlockTime = 3f;

    private void Start()
    {
        _isAlive = true;
        _canTakeDamage = true;
        _currentHealf = maxHealf;
        SceneManager.sceneLoaded += OnSceneLoaded;
        Gameinput.Instance.OnPlayerDash += Gameinput_OnPlayerDash;
        Gameinput.Instance.OnPlayerBlock += Gameinput_OnPlayerBlock;
    }
    private void Awake()

    {

        Instance = this;

        _mainCamera = Camera.main;

        _rb = GetComponent<Rigidbody2D>();
        _knockBack = GetComponent<KnockBack>();

        _initialMovingSpeed = movingSpeed;
    }
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void FixedUpdate()
    {
        if (_knockBack.IsGettingKnockBack)
            return;
        HandleMovement();
    }

    public bool IsRunning()
    {
        return _isRunning;
    }
    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = _mainCamera.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
    public bool IsAlive()
    {
        return _isAlive;
    }
    public void TakeDamage(Transform damageSourse, int damage)
    {
        if (_canTakeDamage && _isAlive)
        {
            _canTakeDamage = false;
            _currentHealf = Mathf.Max(0, _currentHealf -= damage);
            _knockBack.GetKnockBack(damageSourse);
            StartCoroutine(DamageRecoveryRoutine());

            OnFlashBlink?.Invoke(this, EventArgs.Empty);
        }
        DetectDeath();
    }
    private void Gameinput_OnPlayerDash(object sender, EventArgs e)
    {
        Dash();
    }
    private void Gameinput_OnPlayerBlock(object sender, EventArgs e)
    {
        Debug.Log("block");
        Block();
    }
    private void Block()
    {
        _canTakeDamage = false;
        StartCoroutine(BlockRecoveryRoutine());
    }
    private void Dash()
    {
        if (_isDashing != true)
        {
            StartCoroutine(DashRoutine());
        }

    }
    private IEnumerator DashRoutine()
    {
        _isDashing = true;
        movingSpeed *= dashSpeed;
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashTime);
        trailRenderer.emitting = false;

        movingSpeed = _initialMovingSpeed;

        yield return new WaitForSeconds(dashCoolDownTime);
        _isDashing = false;
    }
    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        _canTakeDamage = true;
    }
    private IEnumerator BlockRecoveryRoutine()
    {
        yield return new WaitForSeconds(blockRecoveryTime);
        _canTakeDamage = true;
    }

    private void HandleMovement()
    {
        Vector2 inputVector = Gameinput.Instance.GetMovementVector();

        inputVector = inputVector.normalized;
        _rb.MovePosition(_rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > _minMovingSpeed || Mathf.Abs(inputVector.y) > _minMovingSpeed)
        {
            _isRunning = true;
        }
        else
        {
            _isRunning = false;
        }
    }
    private void DetectDeath()
    {
        if (_currentHealf == 0 && _isAlive)
        {
            _isAlive = false;
            _canTakeDamage = false;
            _knockBack.StopKnockBackMovement();
            Gameinput.Instance.DiseableMovement();

            OnPlayerDeath?.Invoke(this, EventArgs.Empty);
            Invoke(nameof(LoadScene), 1f);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Найти стартовую позицию в новой сцене (если есть)
        GameObject startPoint = GameObject.FindWithTag("Player");
        if (startPoint != null)
        {
            transform.position = startPoint.transform.position;
        }

        // Обновить камеру (если камера меняется)
        Camera mainCamera = Camera.main;
        if (mainCamera != null && mainCamera.GetComponent<CameraFollow>() != null)
        {
            mainCamera.GetComponent<CameraFollow>().SetTarget(transform);
        }
    }
}

