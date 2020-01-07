using UnityEngine;

namespace FusedVR {
    public class InputManager : MonoBehaviour {
        #region Properties
        public InputControl hands;
        public InputControl controllers;

        private OVRPlugin.Controller currControl = OVRPlugin.Controller.None;

        public static InputManager Instance;
        #endregion

        #region UnityEvents
        private void Awake() {
            if (Instance == null) Instance = this;
        }

        private void OnDestroy() {
            if (Instance == this) Instance = null;
        }

        // Start is called before the first frame update
        void Start() {
            currControl = OVRPlugin.GetActiveController(); //set active
        }

        // Update is called once per frame
        void Update() {
            OVRPlugin.Controller control = OVRPlugin.GetActiveController();
            if (currControl != control) {
                Swap(control);
                currControl = control;
            }
        }
        #endregion

        #region InputMethods
        private void Swap(OVRPlugin.Controller controller) {
            bool swap = (controller == OVRPlugin.Controller.Hands); //if hands then true otherwise false
            hands.Show(swap);
            controllers.Show(!swap);
        }

        public float GetAxis ( InputControl.Hand hand , InputControl.Button button) {
            InputControl control = (currControl == OVRPlugin.Controller.Hands) ? hands : controllers;
            return control.GetAxis(hand, button);
        }

        public bool GetButton(InputControl.Hand hand, InputControl.Button button) {
            InputControl control = (currControl == OVRPlugin.Controller.Hands) ? hands : controllers;
            return control.GetButton(hand , button);
        }
        #endregion
    }
}
