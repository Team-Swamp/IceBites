using Player.Movement;
using UnityEngine;
using UnityEngine.InputSystem;
using FrameWork;

namespace Player.Input_Parser
{
    public class InputParser : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private InputActionAsset _inputActionAsset;
        private PlayerMovement _playerMovement;

        private Camera _mainCamera;
        private const string INTERACTABLE_TAG = "Interactable";

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _inputActionAsset = _playerInput.actions;
            _playerMovement = GetComponent<PlayerMovement>();
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
            Ray ray = _mainCamera.ScreenPointToRay(SetMousePos());
            Physics.Raycast(ray.origin, ray.direction *10, out RaycastHit hit);
            
            if (hit.collider
                && hit.collider.CompareTag(INTERACTABLE_TAG))
                hit.collider.transform.GetComponent<InteractableObject>().onInteract.Invoke();
        }

        private Vector3 SetMousePos()
        {
            Vector2 mousePos = _inputActionAsset["MousePosition"].ReadValue<Vector2>();
            return mousePos;
        }
    }
}
