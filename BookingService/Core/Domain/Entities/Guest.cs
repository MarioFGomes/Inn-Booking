using Domain.DomainExceptions;
using Domain.Ports;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities; 
public class Guest 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public PersonIdentity Document { get; set; }

    private void Validate() 
    {
        if(Document==null || Document.Number.Length<8 || Document.documentType == 0) 
        {
            throw new InvalidPersonDocumentException();
        }

        if(Name==null || Surname==null || Email == null) 
        {
            throw new MissingRequeridInformationException();
        }
    }

    public async Task Salve(IGuestRepository guestRepository) 
    {
        this.Validate();

        if(this.Id==0) 
        {
            this.Id = await guestRepository.Create(this);
        } else {
            await guestRepository.Update(this);
        }
    }
   
}
