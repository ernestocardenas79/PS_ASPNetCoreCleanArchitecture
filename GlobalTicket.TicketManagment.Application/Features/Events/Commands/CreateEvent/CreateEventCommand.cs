﻿using MediatR;

namespace GlobalTicket.TicketManagment.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommand: IRequest<Guid>
{
	public string Name { get; set; }
	public int Price { get; set; }
	public string Artist { get; set; }
	public DateTime Date { get; set; }
	public string Description{ get; set; }
	public string ImageUrl { get; set; }
	public Guid CategoryId { get; set; }
	public override string ToString()
	{
		return $"Event Name: {Name}; Price: {Price}; By: {Artist}; on: {Date.ToShortDateString()}; Description: {Description}";
	}
}
