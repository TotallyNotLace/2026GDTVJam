using Player.Ally;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rotator rotator;
        [SerializeField] private UnityEvent<float> onSpeedChanged;

        private CharacterController _mainAllyController;
        private Vector3 currentMovement;

        void Update()
        {
            RefreshMainAlly();

            AllyController main = AllyManager.Instance.MainAlly;
            if (main == null) return;

            // move the player object directly
            transform.position += currentMovement.normalized * main.allyData.moveSpeed * Time.deltaTime;

            // snap main ally to player position
            main.transform.position = transform.position;
        }

        private void RefreshMainAlly()
        {
            AllyController main = AllyManager.Instance.MainAlly;
            if (main == null) return;

            CharacterController cc = main.allyCharacterController;
            if (cc != _mainAllyController)
                _mainAllyController = cc;
        }

        public void OnMovementInput(Vector2 joystick)
        {
            Vector3 move = new Vector3(joystick.x, 0f, joystick.y);
            currentMovement = move;

            AllyController main = AllyManager.Instance.MainAlly;
            if (main != null)
            {
                Rotator rotator = main.GetComponent<Rotator>();
                if (rotator != null)
                    rotator.SetMoveDirection(currentMovement);
            }

            float speedRatio = Mathf.Clamp01(currentMovement.magnitude);
            onSpeedChanged.Invoke(speedRatio);
        }

        public void SubscribeAnimator(ModelAnimator modelAnimator)
        {
            onSpeedChanged.AddListener(modelAnimator.OnMovementSpeedChange);
            Debug.Log($"Subscribed {modelAnimator.gameObject.name} to speed event");
        }

        public void UnsubscribeAnimator(ModelAnimator modelAnimator)
        {
            onSpeedChanged.RemoveListener(modelAnimator.OnMovementSpeedChange);
        }
    }
}