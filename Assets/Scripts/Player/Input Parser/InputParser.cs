using System;
using OpenCover.Framework.Model;
using Player.Movement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

namespace Player.Input_Parser
{
    public class InputParser : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private InputActionAsset _inputActionAsset;
        private PlayerMovement _playerMovement;
        private InteractableObject _interactableObject;

        private Camera _mainCamera;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _inputActionAsset = _playerInput.actions;
            _playerMovement = GetComponent<PlayerMovement>();
            _interactableObject = GetComponent<InteractableObject>();
            _mainCamera = Camera.main;
            
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            _inputActionAsset["MoveTowards"].performed += MoveTowards;
            _inputActionAsset["Interact"].performed += Interact;
        }

        private void RemoveListeners()
        {
            _inputActionAsset["MoveTowards"].performed -= MoveTowards;
            _inputActionAsset["Interact"].performed -= Interact;
        }

        private void MoveTowards(InputAction.CallbackContext context) => _playerMovement.StartMoving();

        private void Interact(InputAction.CallbackContext context)
        { 
            Debug.Log("Set point");
            Ray ray = _mainCamera.ScreenPointToRay(SetMousePos());
            Debug.DrawRay(ray.origin, ray.direction *10, Color.green);
        }

        private Vector3 SetMousePos()
        {
            Vector2 mousePos = _inputActionAsset["MousePosition"].ReadValue<Vector2>();
            return mousePos;
        }
    }
}
