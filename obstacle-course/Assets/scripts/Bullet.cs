using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private Vector3 dir;
    [SerializeField] LayerMask checkLayer;
    public int damage = 1;


    private void FixedUpdate()
    {
        CheckGroundAndEnemy();
        transform.Translate(dir * speed * Time.deltaTime);
        Destroy(gameObject, lifeTime);
    }

  

    private void CheckGroundAndEnemy()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.1f, checkLayer);
        if (collider.Length > 0)
        {
            Destroy(gameObject);
        }
    }
    
}
