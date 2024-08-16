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
    }
}
