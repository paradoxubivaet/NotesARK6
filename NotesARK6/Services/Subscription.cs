﻿using System;

namespace NotesARK6.Services
{
    public class Subscription
    {
        public object Subscriber { get; }
        public Action<Object> Action { get; }

        public Subscription(object subscriber, Action<object> action)
        {
            Subscriber = subscriber;
            Action = action;
        }
    }
}
