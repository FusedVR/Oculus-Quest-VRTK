using UnityEngine;
using Zinnia.Action;

namespace FusedVR.VRTK {
    /// <summary>
    /// A child class of VRTK Float Action that maps OVR Input to VRTK Actions
    /// </summary>
    public class OVRAxis : FloatAction {

        [Tooltip("Which hand is this button on")]
        public InputControl.Hand hand;
        [Tooltip("Which button does this object represent")]
        public InputControl.Button button = InputControl.Button.Trigger; //default axis

        // Update is called once per frame
        void Update() {
            Receive(InputManager.Instance.GetAxis(hand, button)); //sends axis data to VRTK
        }
    }
}

