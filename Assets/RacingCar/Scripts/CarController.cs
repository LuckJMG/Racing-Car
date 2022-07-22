using UnityEngine;

namespace RacingCar
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 100f;
        [SerializeField] private float acceleration = 10f;
        [SerializeField] private AnimationCurve accelerationCurve;
        [SerializeField] private float breakForce = 3000f;
        [SerializeField] private float maxSteeringAngle = 30f;
        [SerializeField] private float steeringSpeed = 10f;
        [SerializeField] private WheelCollider[] wheelColliders = new WheelCollider[4];
        private float _currentSpeed;
        private float _currentSteeringAngle;
        private InputHandler _inputHandler;
        private Vector3 _playerInput;

        private void Start()
        {
            _inputHandler = GetComponent<InputHandler>();
        }

        private void FixedUpdate()
        {
            if (_inputHandler == null) return;
            _playerInput = _inputHandler.PlayerInput;

            HandleMotor();
            HandleSteering();
        }

        private void HandleMotor()
        {
            var targetSpeed = _playerInput.y * maxSpeed * 100;
            _currentSpeed = Mathf.Lerp(_currentSpeed, targetSpeed, accelerationCurve.Evaluate(Time.deltaTime * acceleration));
            wheelColliders[0].motorTorque = _currentSpeed;
            wheelColliders[1].motorTorque = _currentSpeed;
            ApplyBreaking();
        }

        private void ApplyBreaking()
        {
            var currentBreakForce = _playerInput.z == 1f ? breakForce : 0f;
            foreach (var wheel in wheelColliders)
            {
                wheel.brakeTorque = currentBreakForce;
            }
        }

        private void HandleSteering()
        {
            var targetSteeringAngle = maxSteeringAngle * _playerInput.x;
            _currentSteeringAngle = Mathf.LerpAngle(_currentSteeringAngle, targetSteeringAngle, Time.deltaTime * steeringSpeed);
            wheelColliders[0].steerAngle = _currentSteeringAngle;
            wheelColliders[1].steerAngle = _currentSteeringAngle;
        }
    }
}
