namespace ReservationPatternDI.Desktop.StartupHelpers
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}