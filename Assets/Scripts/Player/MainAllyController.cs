using System.Collections.Generic;
using UnityEngine;

public class MainAllyController : MonoBehaviour
{
    [SerializeField] private GameObject mainAlly;
    [SerializeField] private List<GameObject> currentAllies;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = mainAlly.transform.position;
    }
}
