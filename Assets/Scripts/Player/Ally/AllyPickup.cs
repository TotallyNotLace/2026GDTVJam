using Player.Ally;
using UnityEngine;

public class AllyPickup : MonoBehaviour
{
    [SerializeField] private AllyController allyPrefab;
    [SerializeField] private ModelAnimator modelAnimator;

    void Awake()
    {
        modelAnimator.PickupMode(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // check for duplicate before spawning
        foreach (AllyController ally in AllyManager.Instance.GetFollowers())
        {
            if (ally.allyData == allyPrefab.allyData)
            {
                Debug.Log($"{allyPrefab.allyData.name} already in roster, ignoring pickup.");
                Destroy(gameObject);
                return;
            }
        }

        if (AllyManager.Instance.MainAlly != null &&
            AllyManager.Instance.MainAlly.allyData == allyPrefab.allyData)
        {
            Debug.Log($"{allyPrefab.allyData.allyName} already in roster as main, ignoring pickup.");
            Destroy(gameObject);
            return;
        }

        AllyController newAlly = Instantiate(allyPrefab, transform.position, Quaternion.identity);
        AllyManager.Instance.AddAlly(newAlly);

        modelAnimator.PickupMode(false);
        Destroy(gameObject);
    }
}