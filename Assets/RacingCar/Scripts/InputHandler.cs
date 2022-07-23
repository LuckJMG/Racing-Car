using UnityEngine;

namespace RacingCar
{
    public class InputHandler : MonoBehaviour
    {
        private Vector3 _playerInput;
        private float _break;
        private bool _beep;

        public Vector3 PlayerInput { get => _playerInput; }
        public bool Beep { get => _beep;}

        private void Update()
        {
            _break = Input.GetKey(KeyCode.Space) ? 1f : 0f;
            _beep = Input.GetKey(KeyCode.C);
            _playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), _break);
        }
    }
}
