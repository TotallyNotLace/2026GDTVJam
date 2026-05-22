using System.Collections.Generic;
using Player;
using Player.Ally;
using UnityEngine;

public class AllyManager : MonoBehaviour
{
    public static AllyManager Instance { get; private set; }

    [SerializeField] private List<AllyController> allies = new List<AllyController>();

    [SerializeField] private PlayerMovement playerMovement;

    public AllyController MainAlly { get { return allies.Count > 0 ? allies[0] : null; } }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddAlly(AllyController newAlly)
    {
        // check for duplicate
        foreach (AllyController ally in allies)
        {
            if (ally.allyData == newAlly.allyData)
            {
                Debug.Log($"{newAlly.allyData.name} is already in the roster, ignoring.");
                return;
            }
        }

        if (allies.Count >= 7)
        {
            // implement in the future
            return;
        }

        allies.Add(newAlly);
        bool isMain = allies.Count == 1;
        newAlly.Init(this, isMain);

        // disable follower if main
        AllyFollower follower = newAlly.GetComponent<AllyFollower>();
        if (follower != null)
            follower.enabled = !isMain;

        AssignFormationPositions();

        if (!isMain)
        {
            ModelAnimator modelAnimator = newAlly.GetComponentInChildren<ModelAnimator>();
            if (modelAnimator != null && playerMovement != null)
                playerMovement.SubscribeAnimator(modelAnimator);
        }

    }

    public void RemoveAlly(AllyController ally)
    {
        if (!allies.Contains(ally)) return;

        allies.Remove(ally);
        Destroy(ally.gameObject);

        if (allies.Count == 0)
        {
            Debug.Log("Game Over");
            return;
        }

        // promote next ally to main
        allies[0].SetIsMain(true);
        allies[0].Init(this, true);

        AllyFollower promoted = allies[0].GetComponent<AllyFollower>();
        if (promoted != null)
            promoted.enabled = false;

        AssignFormationPositions();

        // unsubscribe old main's animator
        ModelAnimator oldAnimator = ally.GetComponent<ModelAnimator>();
        if (oldAnimator != null && playerMovement != null)
            playerMovement.UnsubscribeAnimator(oldAnimator);

    }

    public List<AllyController> GetFollowers()
    {
        List<AllyController> followers = new List<AllyController>();
        for (int i = 1; i < allies.Count; i++)
        {
            followers.Add(allies[i]);
        }
        return followers;
    }

    private void AssignFormationPositions()
    {
        List<AllyController> followers = GetFollowers();
        List<Vector3> positions = AllyFormation.GetFormationPositions(transform.position, followers.Count);

        for (int i = 0; i < followers.Count; i++)
        {
            AllyFollower follower = followers[i].GetComponent<AllyFollower>();
            if (follower != null)
            {
                follower.SetTargetPosition(positions[i]);
            }
        }
    }

    private void Update()
    {
        AssignFormationPositions();
    }
}