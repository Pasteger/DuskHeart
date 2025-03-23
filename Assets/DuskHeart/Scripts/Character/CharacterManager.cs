using UnityEngine;

namespace DuskHeart.Scripts.Character
{
    public class CharacterManager : MonoBehaviour
    {
        public CharacterController CharacterController {get; private set;}
        
        protected virtual void Awake()
        {
            DontDestroyOnLoad(this);
            
            CharacterController = GetComponent<CharacterController>();
        }

        protected virtual void Update(){}
    }
}
