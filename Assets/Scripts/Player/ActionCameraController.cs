using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class ActionCameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool active;

    [Header("Object References")]
    [SerializeField] private CinemachineCamera actionCamera;
    [SerializeField] private GameObject activeAlly;

}
