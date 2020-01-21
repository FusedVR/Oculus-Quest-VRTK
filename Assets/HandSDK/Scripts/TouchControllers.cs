namespace FusedVR {
    /// <summary>
    /// This class respresents a mapping for the control scheme used for Touch Controllers
    /// </summary>
    public class TouchControllers : InputControl {

        #region InputControlMethods

        /// <summary>
        /// Get whether or not a button has been pressed from the control scheme
        /// </summary>
        /// <param name="h">Which hand is the button on</param>
        /// <param name="b">Which button is being pressed</param>
        /// <returns>A bool indicating whether the given button has been pressed</returns>
        public override bool GetButton(Hand h, Button b) {
            OVRInput.Controller hand = (h == Hand.Left) ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch; //map hands to OVR Input
            OVRInput.Button button = ButtonMap(b); //map abstract buttons to OVR Button
            return OVRInput.Get(button , hand); //get bool from OVRInput
        }

        /// <summary>
        /// Get a float value representing how much a button has been pressed from the control scheme
        /// </summary>
        /// <param name="h">Which hand is the axis on</param>
        /// <param name="b">Which button is being pressed</param>
        /// <returns>A float from 0-1 indicating how much the input has been pressed</returns>
        public override float GetAxis(Hand h, Button b) {
            OVRInput.Controller hand = (h == Hand.Left) ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch; //maps hands to OVRInput
            OVRInput.Axis1D axis = AxisMap(b); //maps abstract buttons to OVR Axis
            if (axis != OVRInput.Axis1D.None) return OVRInput.Get(axis, hand); //null check to make sure an axis exists
            else return GetButton(h, b) ? 1f : 0f; //if no axis exists, then just get a bool value and return 0 or 1
        }
        #endregion

        #region HelperFunctions
        /// <summary>
        /// Maps our abstract button enum to the OVRInput Button enum
        /// </summary>
        /// <param name="b">Which button is being mapped</param>
        /// <returns>Return the corresponding OVRInput.Button</returns>
        private OVRInput.Button ButtonMap(Button b) {
            switch (b) {
                case Button.Trigger: return OVRInput.Button.PrimaryIndexTrigger;
                case Button.Grip: return OVRInput.Button.PrimaryHandTrigger;
                case Button.A: return OVRInput.Button.One;
                case Button.B: return OVRInput.Button.Two;
                default: return OVRInput.Button.PrimaryIndexTrigger; //return a default even though all enums have been covered
            }
        }

        /// <summary>
        /// Maps our abstract button enum to the OVRInput Axis enum
        /// </summary>
        /// <param name="b">Which button is being mapped</param>
        /// <returns>Return the corresponding OVRInput.Axis</returns>
        private OVRInput.Axis1D AxisMap(Button b) {
            switch (b) {
                case Button.Trigger: return OVRInput.Axis1D.PrimaryIndexTrigger;
                case Button.Grip: return OVRInput.Axis1D.PrimaryHandTrigger;
                default: return OVRInput.Axis1D.None; //for buttons which out an axis return null
            }
        }
        #endregion
    }
}

