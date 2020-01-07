namespace FusedVR {
    public class TouchControllers : InputControl {

        public OVRControllerHelper leftHand;
        public OVRControllerHelper rightHand;

        public override bool GetButton(Hand h, Button b) {
            OVRInput.Controller hand = (h == Hand.Left) ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
            OVRInput.Button button = ButtonMap(b);
            return OVRInput.Get(button , hand);
        }

        public override float GetAxis(Hand h, Button b) {
            OVRInput.Controller hand = (h == Hand.Left) ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
            OVRInput.Axis1D axis = AxisMap(b);
            if (axis != OVRInput.Axis1D.None) return OVRInput.Get(axis, hand);
            else return GetButton(h, b) ? 1f : 0f; //convert bool to float
        }

        public override void Show(bool show) {
            leftHand.gameObject.SetActive(show);
            rightHand.gameObject.SetActive(show);
        }

        private OVRInput.Button ButtonMap(Button b) {
            switch (b) {
                case Button.Trigger: return OVRInput.Button.PrimaryIndexTrigger;
                case Button.Grip: return OVRInput.Button.PrimaryHandTrigger;
                case Button.A: return OVRInput.Button.One;
                case Button.B: return OVRInput.Button.Two;
                default: return OVRInput.Button.PrimaryIndexTrigger;
            }
        }

        private OVRInput.Axis1D AxisMap(Button b) {
            switch (b) {
                case Button.Trigger: return OVRInput.Axis1D.PrimaryIndexTrigger;
                case Button.Grip: return OVRInput.Axis1D.PrimaryHandTrigger;
                default: return OVRInput.Axis1D.None;
            }
        }
    }
}

