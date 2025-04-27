using System;
using System.Collections.Generic;
using System.Linq;
using DuskHeart.Scripts.EventBus.Signals;
using UnityEngine;

namespace DuskHeart.Scripts.EventBus
{
    public static class EventBus
    {
        private static readonly Dictionary<string, List<PrioritizedCallback>> SignalsCallbacks = new();

        public static void Invoke<T>(T signal) where T : ISignal
        {
            var key = typeof(T).Name;
            if (!SignalsCallbacks.TryGetValue(key, out var signalCallbacks)) return;

            foreach (var callback in signalCallbacks.Select(callbackObject => callbackObject.Callback as Action<T>))
            {
                callback?.Invoke(signal);
            }
        }

        public static void Subscribe<T>(Action<T> callback, int priority = 0) where T : ISignal
        {
            var key = typeof(T).Name;
            if (SignalsCallbacks.TryGetValue(key, out var signalsCallback))
            {
                signalsCallback.Add(new PrioritizedCallback(callback, priority));
            }
            else
            {
                SignalsCallbacks.Add(key, new List<PrioritizedCallback> { new(callback, priority) });
            }

            SignalsCallbacks[key] = SignalsCallbacks[key].OrderBy(prioritizedCallback => prioritizedCallback.Priority)
                .ToList();
        }

        public static void Unsubscribe<T>(Action<T> callback) where T : ISignal
        {
            var key = typeof(T).Name;
            if (SignalsCallbacks.TryGetValue(key, out var prioritizedCallbackList))
            {
                var signalCallback = prioritizedCallbackList.FirstOrDefault(
                    prioritizedCallback => (Action<T>) prioritizedCallback.Callback == callback);

                if (signalCallback != null)
                {
                    SignalsCallbacks[key].Remove(signalCallback);
                }
                
                if (SignalsCallbacks[key].Count == 0)
                {
                     SignalsCallbacks.Remove(key);
                }
            }
            else
            {
                Debug.LogErrorFormat("Trying unsubscribe for not existing signal");
            }
        }
    }
}