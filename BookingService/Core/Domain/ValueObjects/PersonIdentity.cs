using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects; 
public class PersonIdentity 
{
    public string Number { get; set; }
    public DocumentType documentType { get; set; }
    public DateTime expirationDate { get; set; }= DateTime.UtcNow;
}
