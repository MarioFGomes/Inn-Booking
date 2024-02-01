using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application; 
public abstract class Response 
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public ErrorCodes ErrorCode { get; set; }
}

public enum ErrorCodes 
{
    NOT_FOUND=404,
    COULD_NOT_STORE_DATA=500,
    InvalidDocument=400,
    MissingInformation=400
}
