using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SAE_24T2.ReusableGameFramework.Events.PadEvents
{
    public static class PadEvents
    {
        public static UnityEvent<Collision2D> OnBouncePadPressed = new UnityEvent<Collision2D>();
    }
}
