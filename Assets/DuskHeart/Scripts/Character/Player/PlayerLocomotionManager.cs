using DuskHeart.Data.Prefabs.Character;
using UnityEngine;

namespace DuskHeart.Scripts.Character.Player
{
    public class PlayerLocomotionManager : CharacterLocomotionManager
    {
        [SerializeField] private float walkingSpeed = 2;
        [SerializeField] private float runningSpeed = 5;

        private PlayerManager _playerManager;

        public float VerticalMovement { get; private set; }
        public float HorizontalMovement { get; private set; }
        public float MoveAmount { get; private set; }

        private Vector3 _movementDirection;

        protected override void Awake()
        {
            base.Awake();

            _playerManager = GetComponent<PlayerManager>();
        }

        public void HandleAllMovement()
        {
            HandleGroundedMovement();
        }

        private void GetGroundedInputs()
        {
            VerticalMovement = PlayerInputManager.Instance.VerticalInput;
            HorizontalMovement = PlayerInputManager.Instance.HorizontalInput;
        }

        private void HandleGroundedMovement()
        {
            GetGroundedInputs();

            _movementDirection = PlayerCameraManager.Instance.transform.forward * VerticalMovement +
                                 PlayerCameraManager.Instance.transform.right * HorizontalMovement;
            _movementDirection.Normalize();
            _movementDirection.y = 0;

            var movement = PlayerInputManager.Instance.MoveAmount switch
            {
                > 0.5f => Time.deltaTime * runningSpeed * _movementDirection,
                <= 0.5f => Time.deltaTime * walkingSpeed * _movementDirection,
                _ => Vector3.zero
            };

            _playerManager.CharacterController.Move(movement);
        }
    }
}