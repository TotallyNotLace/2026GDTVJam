using UnityEngine;
using ScriptableObjects;

public class AllyController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] public AllyObject allyData;

    [Header("Object References")]
    public CharacterController allyCharacterController;

    public bool IsMain { get; private set; }

    private AllyManager _manager;

    public void Init(AllyManager manager, bool isMain)
    {
        _manager = manager;
        IsMain = isMain;
        allyCharacterController = GetComponent<CharacterController>();
    }

    public void SetIsMain(bool isMain)
    {
        IsMain = isMain;
    }

    public void Die()
    {
        _manager.RemoveAlly(this);
    }
}