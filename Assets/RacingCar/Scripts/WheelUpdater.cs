using UnityEngine;

namespace RacingCar
{
    public class WheelUpdater : MonoBehaviour
    {
        [SerializeField] private WheelCollider[] wheelColliders = new WheelCollider[4];
        [SerializeField] private Transform[] wheelTransforms = new Transform[4];

        void FixedUpdate()
        {
            UpdateWheels();
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
