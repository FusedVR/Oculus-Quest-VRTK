using Zinnia.Action;

namespace FusedVR.VRTK {
    public class OVRAxis : FloatAction {

        public InputControl.Hand hand;
        public InputControl.Button button = InputControl.Button.Trigger; //default to fill in

        // Update is called once per frame
        void Update() {
            Receive(InputManager.Instance.GetAxis(hand, button));
        }
    }
}

