using UnityEngine;

namespace FusedVR {
    /// <summary>
    ///  Singleton Class that manages context switching between Controllers and Hand Tracking.
    ///  To be used, to access the current input choosen by the user. 
    /// </summary>
    public class InputManager : MonoBehaviour {
        #region Properties

        [Tooltip("Hand Tracking Input Control Scheme")]
        public InputControl hands;
        [Tooltip("Physical Controller Input Control Scheme")]
        public InputControl controllers;

        private OVRPlugin.Controller currControl = OVRPlugin.Controller.None; //variable to keep tracking of current input mechanism

        public static InputManager Instance; //singleton variable
        #endregion

        #region UnityEvents
        private void Awake() {
            if (Instance == null) Instance = this; //store singleton
        }

        private void OnDestroy() {
            if (Instance == this) Instance = null; //delete singelton
        }

        // Start is called before the first frame update
        void Start() {
            currControl = OVRPlugin.GetActiveController(); //set active
        }

        // Update is called once per frame
        void Update() {
            OVRPlugin.Controller control = OVRPlugin.GetActiveController(); //get current controller scheme
            if (currControl != control) { //if current controller is different from previous
                Swap(control); //swap shown controllers
                currControl = control; //save current controller scheme
            }
        }
        #endregion

        #region InputMethods
        /// <summary>
        /// Swaps the visibility of controllers depending on which controller a user has selected
        /// </summary>
        /// <param name="controller">Which controller is the active controller at the present</param>
        private void Swap(OVRPlugin.Controller controller) {
            bool swap = (controller == OVRPlugin.Controller.Hands); //if hands then true otherwise false
            hands.Show(swap);
            controllers.Show(!swap);
        }

        /// <summary>
        /// Get a float value representing how much a button has been pressed from the active control scheme
        /// </summary>
        /// <param name="hand">Which hand is the axis on</param>
        /// <param name="button">Which button is being pressed</param>
        /// <returns>A float from 0-1 indicating how much the input has been pressed</returns>
        public float GetAxis(InputControl.Hand hand , InputControl.Button button) {
            InputControl control = (currControl == OVRPlugin.Controller.Hands) ? hands : controllers;
            return control.GetAxis(hand, button);
        }

        /// <summary>
        /// Get whether or not a button has been pressed from the active control scheme
        /// </summary>
        /// <param name="hand">Which hand is the button on</param>
        /// <param name="button">Which button is being pressed</param>
        /// <returns>A bool indicating whether the given button has been pressed</returns>
        public bool GetButton(InputControl.Hand hand, InputControl.Button button) {
            InputControl control = (currControl == OVRPlugin.Controller.Hands) ? hands : controllers;
            return control.GetButton(hand , button);
        }
        #endregion
    }
}
