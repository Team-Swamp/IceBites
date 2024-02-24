using Player.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Input_Parser
{
    public class InputParser : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private InputActionAsset _inputActionAsset;
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _inputActionAsset = _playerInput.actions;
            _playerMovement = GetComponent<PlayerMovement>();

            AddListeners();
        }
        
        private void OnDisable()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            _inputActionAsset["MoveTowards"].performed += MoveTowards;
        }

        private void RemoveListeners()
        {
            _inputActionAsset["MoveTowards"].performed -= MoveTowards;
        }

        private void MoveTowards(InputAction.CallbackContext context) => _playerMovement.StartMovingEvent();
    }
}
