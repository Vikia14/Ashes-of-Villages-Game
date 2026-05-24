using System;
using UnityEngine;


public class DestructivePlants : MonoBehaviour
{
    public EventHandler OnDestructiveTakeDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AttackPlayer>())
        {
            OnDestructiveTakeDamage?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);

            //NavMeshSurfasManager.Instance.RebakeNavMeshSurface();
        }
    }
}
