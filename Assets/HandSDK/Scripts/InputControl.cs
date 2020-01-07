using UnityEngine;

namespace FusedVR {
    public abstract class InputControl : MonoBehaviour {
        public enum Button {
            Trigger, Grip , A , B
        }

        public enum Hand {
            Left, Right
        }

        public abstract void Show(bool show);

        public abstract float GetAxis(Hand h, Button b);
        public abstract bool GetButton(Hand h, Button b);
        //public abstract bool GetButtonDown(Hand h);
        //public abstract bool GetButtonUp(Hand h);

    }
}

