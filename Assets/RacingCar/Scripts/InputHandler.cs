using UnityEngine;

namespace RacingCar
{
    public class InputHandler : MonoBehaviour
    {
        private Vector2 _playerInput;

        public Vector2 PlayerInput { get => _playerInput; }

        private void Update()
        {
            _playerInput = new Vector2(Input.GetAxisRaw("vertical"), Input.GetAxisRaw("horizontal"));
        }
    }
}
