using UnityEngine;
using Zinnia.Tracking.Velocity;

namespace FusedVR.VRTK {
    public class GenericVelocityEstimator : VelocityTracker {
        private Vector3 pastPosition;
        private Vector3 pastRotation;

        private Vector3 deltaPosition = Vector3.zero;
        private Vector3 deltaRotation = Vector3.zero;

        private void Start() {
            pastPosition = transform.position;
            pastRotation = transform.rotation.eulerAngles; //not ideal but fine for now
        }

        private void Update() {
            deltaPosition = (transform.position - pastPosition) / Time.deltaTime;
            deltaRotation = (transform.rotation.eulerAngles - deltaRotation) / Time.deltaTime;

            pastPosition = transform.position;
            pastRotation = transform.rotation.eulerAngles;
        }

        protected override Vector3 DoGetAngularVelocity() {
            return Vector3.zero; //temp
        }

        protected override Vector3 DoGetVelocity() {
            return deltaPosition;
        }
    }

}