using UnityEngine;
using UnityEngine.AI;

public class BasicNavAgent : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    public void SetTarget(Transform playerTarget)
    {
        target = playerTarget;
    }

    private void Update()
    {
        if (target != null)
            agent.SetDestination(target.position);
    }

    public void OnDeathClearTarget()
    {
        target = transform;
    }
}
