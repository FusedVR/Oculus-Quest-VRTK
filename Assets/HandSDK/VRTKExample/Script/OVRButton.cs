using UnityEngine;
using Zinnia.Action;

namespace FusedVR.VRTK {
    /// <summary>
    /// A child class of VRTK Boolean Action that maps OVR Input to VRTK Actions
    /// </summary>
    public class OVRButton : BooleanAction {
        
        [Tooltip("Which hand is this button on")]
        public InputControl.Hand hand;
        [Tooltip("Which button does this object represent")]
        public InputControl.Button button = InputControl.Button.A; //default button

        // Update is called once per frame
        void Update() {
            Receive(InputManager.Instance.GetButton(hand, button)); //send button data to VRTK
        }
    }
}