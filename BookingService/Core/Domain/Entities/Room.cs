using Domain.ValueObjects;


namespace Domain.Entities; 
public class Room 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Level { get; set; }
    public bool InMaintenance { get; set; }
    public Price price { get; set; }
    public bool HasGuest 
    {
        get 
        {
            // Verificar se existem Bookins abertos para esta Room
            return true;
        }
    }

    public bool IsAvailable 
    {
        get {

            if(this.InMaintenance || this.HasGuest) 
            {
                return false;
            }
            return true;
        }
    }

}
