using System;
using UnityEngine;

namespace RacingCar
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float translateSpeed;
        [SerializeField] private float rotationSpeed;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            HandleTranslation();
            HandleRotation();
        }

        private void HandleTranslation()
        {
            var targetPosition = target.TransformPoint(offset);
            _transform.position = Vector3.Lerp(_transform.position, targetPosition, Time.deltaTime * translateSpeed);
        }

        private void HandleRotation()
        {
            var direction = target.position - _transform.position;
            var rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }
}
