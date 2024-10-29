using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private Vector3 dir;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask enemyLayer;



    private void FixedUpdate()
    {
        CheckGround();
        CheckEnemy();
        transform.Translate(dir * speed * Time.deltaTime);
        Destroy(gameObject, lifeTime);
    }

  

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.1f, groundLayer);
        if (collider.Length > 0)
        {
            Destroy(gameObject);
        }
    }
    private void CheckEnemy()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.1f, enemyLayer);
        if (collider.Length > 0)
        {
            Destroy(gameObject);
        }
    }
}
