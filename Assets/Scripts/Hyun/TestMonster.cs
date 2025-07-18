using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class TestMonster : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed = 5f;
    public float wanderRadius = 10f;
    public float wanderInterval = 3f;

    private GameObject target;
    private float wanderTimer;
    private Animator animator;
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player");
        wanderTimer = wanderInterval;
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
            // 멈췄을 때 값 유지할지 초기화할지는 선택사항
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveY", 0f);
        }
    }

    void Wander()
    {
        wanderTimer += Time.deltaTime;

        if (wanderTimer >= wanderInterval || agent.remainingDistance <= 0.5f)
        {
            float x = Random.Range(-10f, 10f);
            float y = Random.Range(-10f, 10f);
            Vector3 randomDestination = new Vector3(x, y, 0f)+ transform.position; // Z는 0으로 고정 (2D 환경 가정)

            agent.SetDestination(randomDestination);
            wanderTimer = 0f;
        }
    }


    

    void ChasePlayer()
    {
        if (target != null)
            agent.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent<IHitable>(out IHitable hitable))
        {
            hitable.Hit();
        }
    }
}