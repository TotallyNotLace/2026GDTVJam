using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private IAlly mainAlly;
        private CharacterController mainAllyController;
        
        [SerializeField] private UnityEvent<float> onSpeedChanged;
        private Vector3 currentMovement;

        void Start()
        {
            mainAllyController = mainAlly.allyCharacterController;
        }
        public void OnMovementInput(Vector2 joystick)
        {
            Vector3 move = new Vector3(joystick.x, 0f, joystick.y);
            currentMovement = move;
            float speedRatio = Mathf.Clamp01(currentMovement.magnitude);
            onSpeedChanged.Invoke(speedRatio);
        }

        void Update()
        {
            mainAllyController.Move(currentMovement.normalized * mainAlly.allyMoveSpeed * Time.deltaTime);
        }
    }
}