using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int health;

    [SerializeField] TMP_Text textHealth;
    [SerializeField] float jumpForce;

    bool isShowing;
    float[] leftAndRight = new float[2] { -1f, 1f };
    void Start()
    {
        UpdateHealthUI();
        isShowing = true;
        rb.gravityScale = 0f;
        float direction = leftAndRight[Random.Range(0, 1)];
        float screenOffset = Game.Instance.screenWidht * 1.3f;
        transform.position = new Vector2(screenOffset * direction,transform.position.y);

        rb.velocity = new Vector2(-direction,0f);
        Invoke("FallDown", Random.Range(screenOffset - 2f,screenOffset -1f));
    }

    void FallDown()
    {
        isShowing = false;
        rb.gravityScale = 1f;
        rb.AddTorque(Random.Range(-20f, 20f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cannon"))
        {
            Debug.Log("Game Over");
        }
        if(collision.CompareTag("missile"))
        {
            TakeDamage(1);
            Misslie.Instance.DestroyMisslie(collision.gameObject);
        }
        if(!isShowing && collision.CompareTag("wall"))
        {
            float posx = transform.position.x;
            if(posx > 0)
            {
                rb.AddForce(Vector2.left * 150f);
            }
            else if(posx < 0)
            {
                rb.AddForce(Vector2.right * 150f);
            }
            rb.AddTorque(posx * 4f);

        }
        if (collision.CompareTag("ground"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.AddTorque(-rb.angularVelocity * 4f);

        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        if(health > 1)
        {
            health -= damage;
        }
        else
        {
            Die();
        }
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        textHealth.text = health.ToString();
    }


    
  


}
