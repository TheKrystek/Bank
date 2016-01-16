namespace Bank
{
    /// <summary>
    /// Przykładowy interfejs modelu odsetek 
    /// </summary>
    public interface IModelOdsetek
    {
        Pieniadze Oblicz(ProduktBankowy produkt);
        Pieniadze Oblicz(Pieniadze produkt);
    }
}
