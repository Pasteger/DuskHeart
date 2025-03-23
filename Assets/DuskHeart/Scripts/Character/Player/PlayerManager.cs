namespace DuskHeart.Scripts.Character.Player
{
    public class PlayerManager : CharacterManager
    {
        private PlayerLocomotionManager _playerLocomotionManager;
        
        protected override void Awake()
        {
            base.Awake();
            
            _playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        }

        protected override void Update()
        {
            _playerLocomotionManager.HandleAllMovement();
        }
    }
}
