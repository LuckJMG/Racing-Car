using System;
using UnityEngine;

namespace RacingCar
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 positionOffset = new Vector3(0, 4, -5);
        [SerializeField] private Vector3 rotationOffset = new Vector3(0, 2, 0);
        [Range(.01f, 1f)] [SerializeField] private float translationTime = .1f;
        [Range(1f, 20f)] [SerializeField] private float rotationSpeed = 10f;
        private Transform _transform;
        private Vector3 _currentTranslationVelocity;

        private void Awake()
        {
            _transform = transform;
        }

        private void FixedUpdate()
        {
            HandleTranslation();
            HandleRotation();
        }

        private void HandleTranslation()
        {
            var targetPosition = target.TransformPoint(positionOffset);
            _transform.position = Vector3.SmoothDamp(_transform.position, targetPosition, ref _currentTranslationVelocity, translationTime);
        }

        private void HandleRotation()
        {
            var direction = target.position - _transform.position + rotationOffset;
            var rotation = Quaternion.LookRotation(direction, rotationOffset);
            transform.rotation = Quaternion.Slerp(_transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }
}
