using System;
using Player.Movement;
using UI;
using UI.Menus;
using UnityEngine;
using UnityEngine.InputSystem;
using FrameWork;

namespace Player.Input_Parser
{
    public sealed class InputParser : MonoBehaviour
    {
        [SerializeField, Range(0, 20)] private float interactableRayDistance;
        
        private PlayerInput _playerInput;
        private InputActionAsset _inputActionAsset;
        private PlayerMovement _playerMovement;
        private SwitchMenus _switchMenus;
        private const string CANVAS = "Canvas";

        private Camera _mainCamera;
        private InteractableObject _lastObject;
        private const string INTERACTABLE_TAG = "Interactable";

        private void Awake()
        {
            GetReferences();
            Init();
            
            AddListeners();
        }

        private void GetReferences()
        {
            _playerInput = GetComponent<PlayerInput>();
            _playerMovement = GetComponent<PlayerMovement>();
            _switchMenus = canvas.GetComponent<SwitchMenus>();
        }

        private void Init()
        {
            _inputActionAsset = _playerInput.actions;
            GameObject canvas = GameObject.Find(CANVAS);
            _mainCamera = Camera.main;
        }
        
        private void OnDisable()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            _inputActionAsset["MoveTowards"].performed += MoveTowards;
            _inputActionAsset["PauseGame"].performed += PauseGame;
            _inputActionAsset["Interact"].performed += Interact;
        }

        private void RemoveListeners()
        {
            _inputActionAsset["MoveTowards"].performed -= MoveTowards;
            _inputActionAsset["PauseGame"].performed -= PauseGame;
            _inputActionAsset["Interact"].performed -= Interact;
        }

        private void MoveTowards(InputAction.CallbackContext context) => _playerMovement.StartMovingEvent();

        private void PauseGame(InputAction.CallbackContext context) => _switchMenus.PausingEvent();

        private void Interact(InputAction.CallbackContext context)
        {
            Ray ray = _mainCamera.ScreenPointToRay(SetMousePos());
            Physics.Raycast(ray.origin, ray.direction * interactableRayDistance, out RaycastHit hit);

            if (hit.collider
                && hit.collider.CompareTag(INTERACTABLE_TAG))
            {
                if (_lastObject == null
                    || _lastObject.transform != hit.collider.transform)
                    _lastObject = hit.collider.GetComponent<InteractableObject>();
                
                _lastObject.onInteract.Invoke();
            }
        }

        private Vector3 SetMousePos()
        {
            Vector2 mousePos = _inputActionAsset["MousePosition"].ReadValue<Vector2>();
            return mousePos;
        }
    }
}