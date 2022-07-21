using UnityEngine;

namespace RacingCar
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private float motorForce;
        [SerializeField] private float breakForce;
        [SerializeField] private float maxSteeringAngle;
        [SerializeField] private WheelCollider[] wheelColliders = new WheelCollider[4];
        [SerializeField] private Transform[] wheelTransforms = new Transform[4];
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
            UpdateWheels();
        }

        private void HandleMotor()
        {
            var currentMotorForce = _playerInput.y * motorForce;
            wheelColliders[0].motorTorque = currentMotorForce;
            wheelColliders[1].motorTorque = currentMotorForce;
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
            var currentSteeringAngle = maxSteeringAngle * _playerInput.x;
            wheelColliders[0].steerAngle = currentSteeringAngle;
            wheelColliders[1].steerAngle = currentSteeringAngle;
        }

        private void UpdateWheels()
        {
            for (var i = 0; i < wheelTransforms.Length; i++)
            {
                Vector3 position;
                Quaternion rotation;
                wheelColliders[i].GetWorldPose(out position, out rotation);

                wheelTransforms[i].position = position;
                wheelTransforms[i].rotation = rotation;
            }
        }
    }
}
