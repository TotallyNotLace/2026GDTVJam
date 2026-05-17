using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private IAlly mainAlly;
        private CharacterController mainAllyController;

        private Vector3 currentMovement;

        void Start()
        {
            mainAllyController = mainAlly.allyCharacterController;
        }
        public void OnMovementInput(Vector2 joystick)
        {
            Debug.Log("Move move!");
            // Convert 2D input into 3D movement (X/Z plane)
            Vector3 move = new Vector3(joystick.x, 0f, joystick.y);

            // Normalize so diagonal movement isn't faster
            currentMovement = move.normalized;

            // Apply movement
            
        }

        void Update()
        {
            mainAllyController.Move(currentMovement * mainAlly.allyMoveSpeed * Time.deltaTime);
        }
    }
}