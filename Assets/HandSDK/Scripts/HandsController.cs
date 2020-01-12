using UnityEngine;
namespace FusedVR {
    /// <summary>
    /// This class respresents a mapping for the control scheme used for Hand Tracking
    /// </summary>
    public class HandsController : InputControl {

        #region Properties
        [Tooltip("Customizable mapping of Finger to Trigger Input Button")]
        public OVRHand.HandFinger triggerFinger = OVRHand.HandFinger.Index;
        [Tooltip("Customizable mapping of Finger to Grip Input Button")]
        public OVRHand.HandFinger gripFinger = OVRHand.HandFinger.Middle;
        [Tooltip("Customizable mapping of Finger to A Input Button")]
        public OVRHand.HandFinger aFinger = OVRHand.HandFinger.Ring;
        [Tooltip("Customizable mapping of Finger to B Input Button")]
        public OVRHand.HandFinger bFinger = OVRHand.HandFinger.Pinky;
        #endregion

        #region InputControlMethods
        /// <summary>
        /// Get whether the correct finger has been pinched based on the abstract input button
        /// </summary>
        /// <param name="h">Which hand is the button on</param>
        /// <param name="b">Which button is being pressed</param>
        /// <returns>A bool indicating whether the given button has been pressed</returns>
        public override bool GetButton(Hand h, Button b) {
            GameObject handObj = (h == Hand.Left) ? leftHand : rightHand;
            OVRHand hand = handObj.GetComponent<OVRHand>();

            if (hand) {
                OVRHand.HandFinger finger = FingerMap(b);
                return hand.GetFingerIsPinching(finger);
            }

            Debug.LogError("MISSED BUTTON");
            return false; //null check for hand
        }

        /// <summary>
        /// Get a float value the finger pinch strength based on the abstract input button
        /// </summary>
        /// <param name="h">Which hand is the axis on</param>
        /// <param name="b">Which button is being pressed</param>
        /// <returns>A float from 0-1 indicating how much the input has been pressed</returns>
        public override float GetAxis(Hand h, Button b) {
            GameObject handObj = (h == Hand.Left) ? leftHand : rightHand;
            OVRHand hand = handObj.GetComponent<OVRHand>();

            if (hand) {
                OVRHand.HandFinger finger = FingerMap(b);
                return hand.GetFingerPinchStrength(finger);
            }

            Debug.LogError("MISSED AXIS");
            return 0f;
        }

        /// <summary>
        /// A Mapping from the abstract button input to each finger
        /// </summary>
        /// <param name="b">Which button should be mapped</param>
        /// <returns>An OVRHand.HandFinger corresponding to the button</returns>
        private OVRHand.HandFinger FingerMap(Button b) {
            switch (b) {
                case Button.Trigger: return triggerFinger;
                case Button.Grip: return gripFinger;
                case Button.A: return aFinger;
                case Button.B: return bFinger;
                default: return OVRHand.HandFinger.Index; //default to Index Finger even though all buttons have been mapped
            }
        }
        #endregion
    }
}

