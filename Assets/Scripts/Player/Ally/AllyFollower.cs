using UnityEngine;

public class AllyFollower : MonoBehaviour
{
    [SerializeField] private Transform model;
    [SerializeField] private float lerpSpeed = 5f;
    [SerializeField] private float arrivalThreshold = 0.1f;

    private Vector3 _targetPosition;

    public void SetTargetPosition(Vector3 position)
    {
        _targetPosition = position;
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        float distance = Vector3.Distance(transform.position, _targetPosition);
        if (distance < arrivalThreshold) return;

        transform.position = Vector3.Lerp(
            transform.position,
            _targetPosition,
            lerpSpeed * Time.deltaTime
        );

        // rotate to face movement direction
        Vector3 direction = (_targetPosition - transform.position);
        direction.y = 0f;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            model.rotation = Quaternion.Slerp(
                model.rotation,
                targetRotation,
                lerpSpeed * Time.deltaTime
            );
        }
    }
}