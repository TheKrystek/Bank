namespace Bank.Odsetki
{
    public interface IOdsetki
    {
        IModelOdsetek dajModelOdsetek();
        void ustawModelOdsetek(IModelOdsetek model);
    }
}
