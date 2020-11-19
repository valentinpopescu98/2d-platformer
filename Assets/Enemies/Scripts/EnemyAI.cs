using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] LayerMask groundLayerMask;
    public Transform enemyGFX;
    public GameObject enemy;
    public GameObject projectile;
    public Animator animator;
    public CapsuleCollider2D capsCollider;
    public float speedX = 7f;
    public float jumpVelocity = 50f;
    public float nextWaypointDistance = 3f;
    public float startTimeBetweenShots;

    Path path;
    Seeker seeker;
    Rigidbody2D rb;
    Transform PennyTransform;
    GameObject projectileRef;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    float timeBetweenShots = 2;

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    bool IsGrounded()
    {
        float extraHeightTest = 1f;
        RaycastHit2D hit = Physics2D.BoxCast(capsCollider.bounds.center, capsCollider.bounds.size, 0f, Vector2.down, extraHeightTest, groundLayerMask);
        Color rayColor;

        if (hit.collider != null)
        {
            //rayColor = Color.green;
            animator.SetBool("grounded", true);
        }
        else
        {
            //rayColor = Color.red;
            animator.SetBool("grounded", false);
        }

        //Debug.Log(hit.collider);
        return hit.collider != null;
    }

    void TryJump()
    {
        if(!IsGrounded())
        {
            return;
        }
        else
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, PennyTransform.position, OnPathComplete);
    }

    IEnumerator DestroyProjectile(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(projectileRef);
    }

    void Start()
    {
        PennyTransform = GameObject.Find("PennyPixel").GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.25f);
    }

    void FixedUpdate()
    {
        animator.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));

        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        float forceX = direction.x * speedX;
        Vector2 force = new Vector2(forceX, 0);
        rb.AddForce(force);

        if(PennyTransform.position.y>transform.position.y)
        {
            Invoke("TryJump", 0.2f);
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance< nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.001f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (force.x <= 0.001f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void Update()
    {
        if(timeBetweenShots>0)
        {
            timeBetweenShots -= Time.deltaTime;
        }
        else
        {
            projectileRef = Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
            StartCoroutine(DestroyProjectile(3f));
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Destroy(enemy);
        }
    }
}
