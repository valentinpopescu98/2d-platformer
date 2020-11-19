using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Animator animator;
    private Transform PennyTransform;
    private Vector2 target;

    IEnumerator HurtFalseAfterWait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        animator.SetBool("hurt", false);
    }

    void Start()
    {
        PennyTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = PennyTransform.GetComponent<Animator>();
        target = new Vector2(PennyTransform.position.x, PennyTransform.position.y + 0.5f);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            animator.SetBool("hurt", true);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.rigidbody.IsTouchingLayers(9))
        {
            Destroy(gameObject);
        }
    }
}
