using UnityEngine;
using Utilities;

namespace DuskHeart.Scripts.Character.Player
{
    public class PlayerInputManager : MonoSingleton<PlayerInputManager>
    {
        public float VerticalInput { get; private set; }
        public float HorizontalInput { get; private set; }
        public float MoveAmount { get; private set; }

        private PlayerControl _playerControl;
        private Vector2 _movementInput;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            if (_playerControl == null)
            {
                _playerControl = new PlayerControl();
                _playerControl.PlayerMovement.Movement.performed +=
                    movement => _movementInput = movement.ReadValue<Vector2>();
            }

            _playerControl.Enable();
        }

        private void OnDisable() => _playerControl.Disable();
        private void OnDestroy() => _playerControl.Dispose();

        private void Update()
        {
            HandleMovementInput();
        }

        private void HandleMovementInput()
        {
            VerticalInput = _movementInput.y;
            HorizontalInput = _movementInput.x;
            
            MoveAmount = Mathf.Clamp01(Mathf.Abs(VerticalInput) + Mathf.Abs(HorizontalInput));
            MoveAmount = MoveAmount switch
            {
                <= 0.5f and > 0 => 0.5f,
                > 0.5f and < 1 => 1,
                _ => MoveAmount
            };
        }
    }
}