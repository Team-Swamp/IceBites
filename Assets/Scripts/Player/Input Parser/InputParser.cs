using Player.Movement;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Input_Parser
{
    public sealed class InputParser : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private InputActionAsset _inputActionAsset;
        private PlayerMovement _playerMovement;
        private SwitchMenus _switchMenus;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _inputActionAsset = _playerInput.actions;
            _playerMovement = GetComponent<PlayerMovement>();
            GameObject canvas = GameObject.Find("Canvas");
            _switchMenus = canvas.GetComponent<SwitchMenus>();

            AddListeners();
        }
        
        private void OnDisable()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            _inputActionAsset["MoveTowards"].performed += MoveTowards;
            _inputActionAsset["PauseGame"].performed += PauseGame;
        }

        private void RemoveListeners()
        {
            _inputActionAsset["MoveTowards"].performed -= MoveTowards;
            _inputActionAsset["PauseGame"].performed -= PauseGame;
        }

        private void MoveTowards(InputAction.CallbackContext context) => _playerMovement.StartMovingEvent();

        private void PauseGame(InputAction.CallbackContext context) => _switchMenus.PausingEvent();
    }
}
