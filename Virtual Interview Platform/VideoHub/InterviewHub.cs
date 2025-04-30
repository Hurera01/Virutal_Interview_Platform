using Microsoft.AspNetCore.SignalR;
using Virtual_Interview_Platform.DTO.RTCDto;

namespace Virtual_Interview_Platform.VideoHub
{
    public sealed class InterviewHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine("--------");
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} has joined");
        }

        public async Task SendOffer(RtcOfferDto offer)
         {
            Console.WriteLine("--------");
            await Clients.Others.SendAsync("Receive Offer", offer);
        }

        public async Task SendAnswer(RtcAnswerDto answer)
        {
            await Clients.Others.SendAsync("Receive Answer", answer);
        }

        public async Task SendIceCandidate(IceCandidateDto candidate)
        {
            await Clients.Others.SendAsync("Receive IceCandidate", candidate);
        }
    }
}