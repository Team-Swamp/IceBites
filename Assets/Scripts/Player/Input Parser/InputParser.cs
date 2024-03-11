using Player.Movement;
using UI.Menus;
using UnityEngine;
using UnityEngine.InputSystem;
using FrameWork;

namespace Player.Input_Parser
{
    public sealed class InputParser : MonoBehaviour
    {
        private const string CANVAS = "Canvas";
        private const string INTERACTABLE_TAG = "Interactable";
        
        [SerializeField, Range(10, 100)] private float interactableRayDistance;
        
        private Camera _mainCamera;
        private PlayerInput _playerInput;
        private InputActionAsset _inputActionAsset;
        private PlayerMovement _playerMovement;
        private SwitchMenus _switchMenus;
        private InteractableObject _lastInteractable;


        private void Awake()
        {
            GetReferences();
            Init();
        }

        private void OnEnable() => AddListeners();

        private void OnDisable() => RemoveListeners();
        
        private void GetReferences()
        {
            _playerInput = GetComponent<PlayerInput>();
            _playerMovement = GetComponent<PlayerMovement>();
            GameObject canvas = GameObject.Find(CANVAS);
            _switchMenus = canvas.GetComponent<SwitchMenus>();
        }

        private void Init()
        {
            _inputActionAsset = _playerInput.actions;
            _mainCamera = Camera.main;
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
            Ray ray = _mainCamera.ScreenPointToRay(GetMousePosition());
            Physics.Raycast(ray.origin, ray.direction * interactableRayDistance, out RaycastHit hit);

            if (hit.collider
                && hit.collider.CompareTag(INTERACTABLE_TAG))
            {
                if (_lastInteractable == null
                    || _lastInteractable.transform != hit.collider.transform)
                    _lastInteractable = hit.collider.GetComponent<InteractableObject>();
                
                _lastInteractable.onInteract.Invoke();
            }
        }

        private Vector3 GetMousePosition() => (Vector3) _inputActionAsset["MousePosition"].ReadValue<Vector2>();
    }
}