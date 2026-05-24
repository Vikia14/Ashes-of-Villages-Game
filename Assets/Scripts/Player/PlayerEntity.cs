using UnityEngine;
using System;
[RequireComponent(typeof(PolygonCollider2D))]

public class PlayerEntity : MonoBehaviour
{
    

    //[SerializeField] private int _damageAmout = 30;
    //private PolygonCollider2D _polygonCollider2D;
    //[SerializeField] private EnemyEnrity _enemyEnrity;
    //private int _currentHealth;

    //private void Awake()
    //{
    //    _polygonCollider2D = GetComponent<PolygonCollider2D>();
    //}
    //public void AttackColliderTurnOff()
    //{
    //    _polygonCollider2D.enabled = false;

    //}
    //public void AttackColliderTurnOn()
    //{
    //    _polygonCollider2D.enabled = true;

    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision is not BoxCollider2D)
    //    {
    //        if (collision.transform.TryGetComponent(out EnemyEnrity _enemyEnrity))
    //        {
    //            _enemyEnrity.TakeDamage(_damageAmout);
    //        }
    //    }
    //}


    //public void TakeDamage(int damage)
    //{
    //    _currentHealth -= damage;
    //    //DetectDeath();

    //}


    //private void DetectDeath()
    //{
    //    if (_currentHealth <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
