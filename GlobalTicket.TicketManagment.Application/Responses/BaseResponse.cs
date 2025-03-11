namespace GlobalTicket.TicketManagment.Application.Responses;

public class BaseResponse
{
	public BaseResponse()
	{
	}

	public BaseResponse(string message)
	{
		Message = message;
	}

	public BaseResponse(string message, bool success)
	{
		Message = message;
		Success = success;
	}

	public bool Success { get; set; } = true;
	public string Message { get; private set; } = string.Empty;
	public List<string>? ValidationErrors { get; set; }
}
