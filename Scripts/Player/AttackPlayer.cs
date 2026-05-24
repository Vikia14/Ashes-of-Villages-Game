using System;
using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class AttackPlayer : MonoBehaviour
{
    
    [SerializeField] private int _damageAmout = 30;
    private PolygonCollider2D _polygonCollider2D;
    

    public event EventHandler OnSwordAttack;

    private void Awake()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }
    public void Attack()
    {
        OnSwordAttack?.Invoke(this, EventArgs.Empty);
    }
    
    public void AttackColliderTurnOff()
    {
        _polygonCollider2D.enabled = false;

    }
    public void AttackColliderTurnOn()
    {
        _polygonCollider2D.enabled = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out EnemyEnrity _enemyEnrity))
        {
            _enemyEnrity.TakeDamage(_damageAmout);
        }
    }
}
