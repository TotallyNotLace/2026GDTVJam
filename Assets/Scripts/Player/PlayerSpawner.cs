using Player;
using Player.Ally;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private AllyController startingAllyPrefab;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private PlayerMovement playerMovement;

    void Start()
    {
        Debug.Log($"PlayerSpawner Start | playerMovement is null: {playerMovement == null}");
        AllyController startingAlly = Instantiate(startingAllyPrefab, spawnPoint.position, Quaternion.identity);
        AllyManager.Instance.AddAlly(startingAlly);

        // wire speed event to the spawned ally's animator
        ModelAnimator modelAnimator = startingAlly.GetComponentInChildren<ModelAnimator>();
        Debug.Log($"modelAnimator is null: {modelAnimator == null}");
        if (modelAnimator != null && playerMovement != null)
            playerMovement.SubscribeAnimator(modelAnimator);
    }
}