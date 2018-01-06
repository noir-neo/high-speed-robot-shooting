namespace Players
{
    public class InputValue<T>
    {
        public PlayerId PlayerId;
        public T Value;

        public InputValue(PlayerId playerId, T value)
        {
            PlayerId = playerId;
            Value = value;
        }
    }
}
