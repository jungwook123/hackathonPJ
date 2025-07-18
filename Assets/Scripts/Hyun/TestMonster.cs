using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class TestMonster : MonoBehaviour,IHitable
{
    public NavMeshAgent agent;
    public float speed = 5f;
    public float wanderRadius = 10f;
    public float wanderInterval = 3f;
    public float health = 5f;
    public float detectionRange = 10f;
    public float stopDistance = 3f;
    public LayerMask playerLayer;
    public LayerMask obstacleLayer;

    private GameObject target;
    private float wanderTimer;
    private Animator animator;

    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        agent.destination = transform.position;

        animator = GetComponent<Animator>();
        target = GameObject.Find("Player");
        wanderTimer = wanderInterval;
    }

    public void Hit()
    {
        health -= 1;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        switch (GameManager.Instance.gameState)
        {
            case GameState.Ongoing:
                Wander();
                break;

            case GameState.Onrunning:
                ChasePlayer();
                break;

            case GameState.OnBank:
                if (DetectPlayerInSight())
                    ApproachPlayerUntilRange();
                else
                    Wander(4f); // 플레이어를 못 봤으면 대기
                
                break;
        }

        UpdateAnimatorDirection();
    }

    void UpdateAnimatorDirection()
    {
        Vector3 velocity = agent.velocity;

        if (velocity.sqrMagnitude > 0.01f)
        {
            Vector2 moveDir = velocity.normalized;
            animator.SetFloat("MoveX", moveDir.x);
            animator.SetFloat("MoveY", moveDir.y);
        }
        else
        {
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveY", 0f);
        }
    }

    void Wander(float wanderRange = 10f)
    {
        wanderTimer += Time.deltaTime;

        if (wanderTimer >= wanderInterval || agent.remainingDistance <= 0.5f)
        {
            float x = Random.Range(-wanderRange, wanderRange);
            float y = Random.Range(-wanderRange, wanderRange);
            Vector3 randomDestination = new Vector3(x, y, 0f) + transform.position;

            agent.SetDestination(randomDestination);
            wanderTimer = 0f;
        }
    }

    void ChasePlayer()
    {
        if (target != null)
            agent.SetDestination(target.transform.position);
    }

    void ApproachPlayerUntilRange()
    {
        if (target == null) return;

        float distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > stopDistance)
        {
            agent.SetDestination(target.transform.position);
        }
        else
        {
            agent.ResetPath(); // 멈춤
        }
    }

    bool DetectPlayerInSight()
    {
        if (target == null) return false;

        Vector2 origin = transform.position;
        Vector2 direction = (target.transform.position - transform.position).normalized;

        RaycastHit2D hitPlayer = Physics2D.Raycast(origin, direction, detectionRange, playerLayer);

        if (hitPlayer.collider != null)
        {
            RaycastHit2D hitObstacle = Physics2D.Raycast(origin, direction, detectionRange, obstacleLayer);

            if (hitObstacle.collider == null || hitObstacle.distance > hitPlayer.distance)
            {
                return true;
            }
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent<IHitable>(out IHitable hitable))
        {
            hitable.Hit();
        }
    }
}
