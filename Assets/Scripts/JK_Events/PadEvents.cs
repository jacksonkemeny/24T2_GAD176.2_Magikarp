using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SAE_24T2.ReusableGameFramework.Events.PadEvents
{
    public static class PadEvents
    {
        // All this will do is create an event for when the Bounce Pad is Pressed
        public static UnityEvent<Collision2D> OnBouncePadPressed = new UnityEvent<Collision2D>();

        // What these are the events for the teleport pad start being pressed as well as the end
        public static UnityEvent<Collision2D> OnTeleportPadStartPressed = new UnityEvent<Collision2D>();
        public static UnityEvent<Collision2D> OnTeleportPadEndPressed = new UnityEvent<Collision2D>();
    }
}
