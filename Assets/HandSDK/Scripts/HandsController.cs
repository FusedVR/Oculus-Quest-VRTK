namespace FusedVR {
    public class HandsController : InputControl {

        public OVRHand leftHand;
        public OVRHand rightHand;

        public OVRHand.HandFinger triggerFinger = OVRHand.HandFinger.Index;
        public OVRHand.HandFinger gripFinger = OVRHand.HandFinger.Middle;
        public OVRHand.HandFinger aFinger = OVRHand.HandFinger.Ring;
        public OVRHand.HandFinger bFinger = OVRHand.HandFinger.Pinky;

        public override bool GetButton(Hand h, Button b) {
            OVRHand hand = (h == Hand.Left) ? leftHand : rightHand;
            OVRHand.HandFinger finger = FingerMap(b);
            return hand.GetFingerIsPinching(finger);
        }

        public override float GetAxis(Hand h, Button b) {
            OVRHand hand = (h == Hand.Left) ? leftHand : rightHand;
            OVRHand.HandFinger finger = FingerMap(b);
            return hand.GetFingerPinchStrength(finger);
        }

        public override void Show(bool show) {
            leftHand.gameObject.SetActive(show);
            rightHand.gameObject.SetActive(show);
        }

        private OVRHand.HandFinger FingerMap(Button b) {
            switch (b) {
                case Button.Trigger: return triggerFinger;
                case Button.Grip: return gripFinger;
                case Button.A: return aFinger;
                case Button.B: return bFinger;
                default: return OVRHand.HandFinger.Index;
            }
        }
    }
}

