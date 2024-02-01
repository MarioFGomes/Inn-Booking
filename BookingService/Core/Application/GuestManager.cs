using Application.Guest.DTO;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Application.Guest.Responses;
using Domain.DomainExceptions;
using Domain.Ports;


namespace Application;
public class GuestManager : IGuestManager 
{
    private readonly IGuestRepository _guestRepository;
    public GuestManager(IGuestRepository guestRepository)
    {
        _guestRepository= guestRepository;
    }
    public async Task<ResponseGest> CreateGuest(RequestGest request) 
    {
        try 
        {
            var guest = GuestDTO.MapToEntity(request.Data);

            await guest.Salve(_guestRepository);

            request.Data.Id = guest.Id;

            return new ResponseGest 
            {
                Data = request.Data,
                Success = true
            };

        } catch (InvalidPersonDocumentException e) 
        {
            return new ResponseGest 
            {

                Success = false,
                ErrorCode = ErrorCodes.InvalidDocument,
                Message = "There was an error with document "
            };
        } 
        catch (MissingRequeridInformationException e) 
        {
            return new ResponseGest 
            {

                Success = false,
                ErrorCode = ErrorCodes.MissingInformation,
                Message = "you missing requerid information"
            };
        } 
        catch (Exception ex) 
        {
            return new ResponseGest 
            {
               
                Success = false,
                ErrorCode=ErrorCodes.COULD_NOT_STORE_DATA,
                Message="There was an error when saving Data"
            };

        }
    }
}
