using UnityEngine;

namespace FusedVR {
    /// <summary>
    /// Abstract Class used to have a consistent input control scheme between hand tracking and controller input
    /// </summary>
    public abstract class InputControl : MonoBehaviour {
        /// <summary>
        /// Abstract representations of buttons. Can be overridden for more types of buttons
        /// </summary>
        public enum Button {
            Trigger, Grip , A , B
        }

        /// <summary>
        /// Representation of which hands are buttons are located
        /// </summary>
        public enum Hand {
            Left, Right
        }

        /// <summary>
        /// Whether or not to show the visuals for this controller
        /// </summary>
        /// <param name="show">True = show. False = to hide.</param>
        public abstract void Show(bool show);

        /// <summary>
        /// Get a float value representing how much a button has been pressed from the control scheme
        /// </summary>
        /// <param name="h">Which hand is the button on</param>
        /// <param name="b">Which button is being pressed</param>
        /// <returns>A float from 0-1 indicating how much the input has been pressed</returns>
        public abstract float GetAxis(Hand h, Button b);

        /// <summary>
        /// Get whether or not a button has been pressed from the control scheme
        /// </summary>
        /// <param name="h">Which hand is the axis on</param>
        /// <param name="b">Which button is being pressed</param>
        /// <returns>A bool indicating whether the given button has been pressed</returns>
        public abstract bool GetButton(Hand h, Button b);
    }
}

