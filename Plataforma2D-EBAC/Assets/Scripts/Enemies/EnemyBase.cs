using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private int inflictedDamage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthBase health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(inflictedDamage);
        }
    }
}
