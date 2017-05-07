using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled_clone.Input
{
    public static class MouseUtils
    {
        public enum MouseButtons
        {
            Left,Right,Middle
        }
        static MouseState currentState = Mouse.GetState();
        static MouseState previousState = Mouse.GetState();

        public static Point GetCurrentPosition()
        {
            return currentState.Position;
        }
        public static Point GetPreviousPosition()
        {
            return previousState.Position;
        }


        public static void Update()
        {
            previousState = currentState;
            currentState = Mouse.GetState();
        }

        public static bool WentDown(MouseButtons button)
        {
            if (GetState(button, true) == ButtonState.Released && GetState(button, false) == ButtonState.Pressed)
                return true;
            return false;
        }

        public static bool WentUp(MouseButtons button)
        {
            if (GetState(button, true) == ButtonState.Pressed && GetState(button, false) == ButtonState.Released)
                return true;
            return false;
        }

        private static ButtonState GetState(MouseButtons button, bool previous)
        {
            var state = currentState;
            if (previous)
                state = previousState;
            switch (button)
            {
                case MouseButtons.Left:
                    return state.LeftButton;
                case MouseButtons.Right:
                    return state.RightButton;
                case MouseButtons.Middle:
                    return state.MiddleButton;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
