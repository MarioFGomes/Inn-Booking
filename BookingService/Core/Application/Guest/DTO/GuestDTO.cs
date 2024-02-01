

using Domain.Enums;
using Domain.ValueObjects;

namespace Application.Guest.DTO; 
public class GuestDTO 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Document_Number { get; set; }
    public int documentType { get; set; }
    public DateTime expirationDate { get; set; }

    public static Domain.Entities.Guest MapToEntity(GuestDTO guestDTO) 
    {
        return new Domain.Entities.Guest 
        {
            Id = guestDTO.Id,
            Name = guestDTO.Name,
            Surname = guestDTO.Surname,
            Email = guestDTO.Email,
            Document = new PersonIdentity 
            {
                Number = guestDTO.Document_Number,
                documentType = (DocumentType)guestDTO.documentType,
                expirationDate = guestDTO.expirationDate
            }
        };
    }

}
