namespace DuskHeart.Scripts.EventBus
{
    public class PrioritizedCallback
    {
        public readonly object Callback;
        public readonly int Priority;

        public PrioritizedCallback(object callback, int priority)
        {
            Callback = callback;
            Priority = priority;
        }
    }
}