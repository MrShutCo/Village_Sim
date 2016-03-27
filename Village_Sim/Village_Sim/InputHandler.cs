using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Village_Sim {
    public class InputHandler {

        private KeyboardState _keyboardStateCurrent, _keyboardStatePrevious;
        private Dictionary<InputActions, Keys> _keyboardBindings;

        public delegate void InputEvent();

        // define events
        // ("dead" default subscribers to avoid having to null check before invokes)
        public event InputEvent onSpaceBar = delegate { };
        public event InputEvent onSpeedUp = delegate { };
        public event InputEvent onSlowDown = delegate { };


        public InputHandler() {
            _keyboardStatePrevious = Keyboard.GetState();
            // if config file exist then load it here, else...
            ResetBindings();
        }

        private void PollKeyboard() {
            _keyboardStateCurrent = Keyboard.GetState();

            foreach (KeyValuePair<InputActions, Keys> keyBinding in _keyboardBindings) {
                // fire events when key pressed
                if (_keyboardStateCurrent.IsKeyDown(keyBinding.Value) && _keyboardStatePrevious.IsKeyUp(keyBinding.Value)) {
                    switch (keyBinding.Key) {
                        /*case InputActions.Pause:
                            onSpaceBar();
                            break;*/
                    }
                }

                // fire events when key released
                else if (_keyboardStateCurrent.IsKeyUp(keyBinding.Value) && _keyboardStatePrevious.IsKeyDown(keyBinding.Value)) {
                    switch (keyBinding.Key) {
                        case InputActions.Pause:
                            onSpaceBar();
                            break;
                        case InputActions.SlowDown:
                            onSlowDown();
                            break;
                        case InputActions.SpeedUp:
                            onSpeedUp();
                            break;
                    }
                }
            }
            _keyboardStatePrevious = _keyboardStateCurrent;
        }


        // update method to call in gameloop
        public void Update() {
            PollKeyboard();
        }

        // set default bindings
        // (future: add more bindings obviously; hardcoded defaults or move them to a default config file?)
        public void ResetBindings() {
            _keyboardBindings = new Dictionary<InputActions, Keys>() {
                { InputActions.Pause, Keys.Space },
                { InputActions.SlowDown, Keys.OemMinus },
                { InputActions.SpeedUp, Keys.OemPlus }
            };
        }

        /*public void ChangeBinding(InputActions inputAction, Keys key) {
            if (_keyboardBindings.ContainsKey(inputAction)) {
                _keyboardBindings[inputAction] = key;
            }
        }*/

        // various enumerated actions
        // (future: maybe seperate input actions for each gamestate into seperate enums?)
        enum InputActions {
            Pause,
            SpeedUp,
            SlowDown
        }

    }
}
