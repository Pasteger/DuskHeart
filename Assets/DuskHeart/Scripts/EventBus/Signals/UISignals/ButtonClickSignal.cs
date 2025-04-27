namespace DuskHeart.Scripts.EventBus.Signals.UISignals
{
    public class ButtonClickSignal : ISignal
    {
        public readonly string ButtonName;

        public ButtonClickSignal(string buttonName) => ButtonName = buttonName;
    }
}