using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Virtual_Interview_Platform.DTO.RTCDto;

namespace Virtual_Interview_Platform.VideoHub
{
    public sealed class InterviewHub : Hub
    {
        public async Task JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            //await Clients.Group(roomId).SendAsync("ReceiveMessage", $"{Context.ConnectionId} joined room {roomId}");
        }

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine("--------");
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} has joined");
        }

        public async Task SendOffer(string roomId,RtcOfferDto offer)
         {
            Console.WriteLine("--------");
            await Clients.OthersInGroup(roomId).SendAsync("Receive Offer", offer);
        }

        public async Task SendAnswer(string roomId, RtcAnswerDto answer)
        {
            await Clients.OthersInGroup(roomId).SendAsync("Receive Answer", answer);
        }

        public async Task SendIceCandidate(string roomId, IceCandidateDto candidate)
        {
            await Clients.OthersInGroup(roomId).SendAsync("Receive IceCandidate", candidate);
        }
    }
}