using Zinnia.Action;

namespace FusedVR.VRTK {
    public class OVRButton : BooleanAction {

        public InputControl.Hand hand;
        public InputControl.Button button = InputControl.Button.A; //default to fill in 

        // Update is called once per frame
        void Update() {
            Receive(InputManager.Instance.GetButton(hand, button));
        }
    }
}