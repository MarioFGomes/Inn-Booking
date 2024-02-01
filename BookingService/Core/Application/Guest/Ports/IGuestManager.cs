using Application.Guest.Requests;
using Application.Guest.Responses;


namespace Application.Guest.Ports;
public interface IGuestManager
{
    Task<ResponseGest> CreateGuest(RequestGest request);
}
