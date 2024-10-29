using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;
    private float currHealth;
    [SerializeField] private LayerMask damageLayerMask;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Awake()
    {
        currHealth = startHealth;
        DrawHealth();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(damageLayerMask, collision.gameObject))
        {
            if(collision.gameObject.TryGetComponent(out Enemy enemy))
            {
                GetDamage(enemy.damage);
            }
        }
    }
    private void GetDamage(float damage)
    {
        if (currHealth > 0)
        {
            currHealth -= damage;
            DrawHealth();
        }
        if(currHealth <= 0)
        {

            SceneManager.LoadScene(0);
        }
           
    }
    private void DrawHealth()
    {
        healthText.text = $"HP: {currHealth}";
    }
}
