namespace Recursio
{
    public interface IRecurced
    {
        ulong CallsAmount { get; }

        void ResetCounter();
    }
}
