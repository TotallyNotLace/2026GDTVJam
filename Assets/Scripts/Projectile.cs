using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Vector3 rotationAngle;

    [SerializeField] private Vector3 forward;
    [SerializeField] private float flySpeed;

    [SerializeField] private float lifeTime;

    [SerializeField] private GameObject model;
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }
    void Update()
    {
        model.transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * flySpeed * Time.deltaTime);
    }
}
