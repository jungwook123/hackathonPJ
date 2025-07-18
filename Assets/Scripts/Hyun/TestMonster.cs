using UnityEngine;
using UnityEngine.AI;

public class TestMonster : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    private void Start()
    {
        agent.destination = new Vector3(-6.5f,8,0);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    
}
