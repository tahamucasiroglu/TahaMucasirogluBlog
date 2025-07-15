using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Concurrent;

namespace TahaMucasirogluBlog.Client.P2PMessage.TahaMucasirogluMVC.Services
{
    public class SignalRClientService
    {
        private HubConnection? _hubConnection;
        private readonly ConcurrentDictionary<string, Action<string, string>> _messageHandlers = new();
        private readonly ConcurrentDictionary<string, TaskCompletionSource<bool>> _connectionRequests = new();
        private readonly ILogger<SignalRClientService> _logger;

        public SignalRClientService(ILogger<SignalRClientService> logger)
        {
            _logger = logger;
        }

        public async Task StartAsync(string hubUrl)
        {
            try
            {
                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(hubUrl)
                    .WithAutomaticReconnect()
                    .Build();

                // Mesaj geldiğinde
                _hubConnection.On<string, string, string>("ReceiveMessage", (fromId, toId, encryptedMessage) =>
                {
                    if (_messageHandlers.TryGetValue(toId, out var handler))
                    {
                        handler(fromId, encryptedMessage);
                    }
                });

                // Bağlantı isteği geldiğinde
                _hubConnection.On<string, string>("ConnectionRequest", (fromId, toId) =>
                {
                    if (_messageHandlers.TryGetValue(toId, out var handler))
                    {
                        handler("CONNECTION_REQUEST", fromId);
                    }
                });

                // Bağlantı kabul edildiğinde
                _hubConnection.On<string, string>("ConnectionAccepted", (accepterId, requesterId) =>
                {
                    // İstek atana bildir
                    if (_messageHandlers.TryGetValue(requesterId, out var requesterHandler))
                    {
                        requesterHandler("CONNECTION_ACCEPTED", accepterId);
                    }
                    // Kabul edene de bildir
                    if (_messageHandlers.TryGetValue(accepterId, out var accepterHandler))
                    {
                        accepterHandler("CONNECTION_ACCEPTED", requesterId);
                    }
                });

                // Bağlantı reddedildiğinde
                _hubConnection.On<string>("ConnectionRejected", (requesterId) =>
                {
                    if (_messageHandlers.TryGetValue(requesterId, out var handler))
                    {
                        handler("CONNECTION_REJECTED", "");
                    }
                });

                // Kullanıcı bağlantısı koptuğunda
                _hubConnection.On<string>("UserDisconnected", (connectionId) =>
                {
                    if (_messageHandlers.TryGetValue(connectionId, out var handler))
                    {
                        handler("USER_DISCONNECTED", "");
                    }
                });

                await _hubConnection.StartAsync();
                _logger.LogInformation("SignalR Client connected to {HubUrl}", hubUrl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to start SignalR client");
                throw;
            }
        }

        public async Task EnsureConnectedAsync()
        {
            if (_hubConnection == null)
            {
                // Local development için localhost, production için domain
                var baseUrl = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
                    ? "https://localhost:5001"
                    : "https://p2pmessage.tahamucasiroglu.com.tr";
                await StartAsync($"{baseUrl}/chatHub");
            }

            if (_hubConnection?.State != HubConnectionState.Connected)
            {
                if (_hubConnection != null)
                    await _hubConnection.StartAsync();
            }
        }

        public void RegisterMessageHandler(string connectionId, Action<string, string> handler)
        {
            _messageHandlers[connectionId] = handler;
        }

        public void UnregisterMessageHandler(string connectionId)
        {
            _messageHandlers.TryRemove(connectionId, out _);
        }

        public async Task SendMessageAsync(string fromId, string toId, string encryptedMessage)
        {
            try
            {
                await EnsureConnectedAsync();
                await _hubConnection!.InvokeAsync("SendMessage", fromId, toId, encryptedMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send message");
                throw;
            }
        }

        public async Task SendConnectionRequestAsync(string fromId, string toId)
        {
            try
            {
                await EnsureConnectedAsync();
                await _hubConnection!.InvokeAsync("RequestConnection", fromId, toId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send connection request");
                throw;
            }
        }

        public async Task NotifyConnectionAcceptedAsync(string accepterId, string requesterId)
        {
            try
            {
                await EnsureConnectedAsync();
                // Her iki kullanıcıya da bildir
                await _hubConnection!.InvokeAsync("ConnectionAccepted", accepterId, requesterId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to notify connection accepted");
                throw;
            }
        }

        public async Task NotifyConnectionRejectedAsync(string requesterId)
        {
            try
            {
                await EnsureConnectedAsync();
                await _hubConnection!.InvokeAsync("ConnectionRejected", requesterId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to notify connection rejected");
            }
        }

        public async Task NotifyDisconnectionAsync(string connectionId)
        {
            try
            {
                await EnsureConnectedAsync();
                await _hubConnection!.InvokeAsync("NotifyDisconnection", connectionId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to notify disconnection");
            }
        }

        public TaskCompletionSource<bool> WaitForConnectionRequest(string connectionId)
        {
            var tcs = new TaskCompletionSource<bool>();
            _connectionRequests[connectionId] = tcs;
            return tcs;
        }

        public void ClearConnectionRequest(string connectionId)
        {
            _connectionRequests.TryRemove(connectionId, out _);
        }
    }
}
