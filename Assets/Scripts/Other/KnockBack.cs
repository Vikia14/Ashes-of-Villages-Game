using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KnockBack : MonoBehaviour
{
    [SerializeField] private float knockBackForce = 2f;
    [SerializeField] private float knockBackMovingTimeMax = 0.3f;

    private float _knockBackMovingTimer;

    private Rigidbody2D _rb;

    public bool IsGettingKnockBack { get; private set; }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _knockBackMovingTimer -= Time.deltaTime;
        if (_knockBackMovingTimer < 0)
        {
            StopKnockBackMovement();
        }
    }
    public void GetKnockBack(Transform damageSourse)
    {
        IsGettingKnockBack = true;
        _knockBackMovingTimer = knockBackMovingTimeMax;
        Vector2 difference = (transform.position - damageSourse.position).normalized * knockBackForce / _rb.mass;
        _rb.AddForce(difference, ForceMode2D.Impulse);
    }

    public void StopKnockBackMovement()
    {
        _rb.linearVelocity = Vector2.zero;
        IsGettingKnockBack = false;
    }
}
