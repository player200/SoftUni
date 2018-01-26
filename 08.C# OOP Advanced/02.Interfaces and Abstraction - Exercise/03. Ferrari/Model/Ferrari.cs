public class Ferrari:ICar
{
    public Ferrari(string driversName)
    {
        this.Model = "488-Spider";
        this.DriversName = driversName;
    }
    public string Model { get;}
    public string DriversName { get; }

    public string Brakes()
    {
        return "Brakes!";
    }
    public string GasPedal()
    {
        return "Zadu6avam sA!";
    }
    public override string ToString()
    {
        return $"{this.Model}/{this.Brakes()}/{this.GasPedal()}/{this.DriversName}"; 
    }
}