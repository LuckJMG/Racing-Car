using UnityEngine;

namespace RacingCar
{
    public class InputHandler : MonoBehaviour
    {
        private Vector3 _playerInput;
        private float _break;

        public Vector3 PlayerInput { get => _playerInput; }

        private void Update()
        {
            _break = Input.GetKey(KeyCode.Space) ? 1f : 0f;
            _playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), _break);
        }
    }
}
