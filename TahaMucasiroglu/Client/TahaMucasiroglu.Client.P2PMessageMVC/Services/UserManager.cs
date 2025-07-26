using System.Collections.Concurrent;

namespace TahaMucasirogluBlog.Client.P2PMessage.TahaMucasirogluMVC.Services
{
    public class UserManager
    {
        private readonly ConcurrentDictionary<string, UserInfo> _users = new();
        private readonly ConcurrentDictionary<string, string> _sessionToConnection = new();

        public class UserInfo
        {
            public string ConnectionId { get; set; } = string.Empty;
            public string SessionId { get; set; } = string.Empty;
            public string PublicKey { get; set; } = string.Empty;
            public string PrivateKey { get; set; } = string.Empty;
            public string? PartnerConnectionId { get; set; }
            public Queue<(string from, string message)> PendingMessages { get; } = new();
            public string? PendingConnectionRequest { get; set; }
        }

        public string CreateUser(string sessionId, string publicKey, string privateKey)
        {
            var connectionId = Guid.NewGuid().ToString("N").Substring(0, 16);
            var user = new UserInfo
            {
                ConnectionId = connectionId,
                SessionId = sessionId,
                PublicKey = publicKey,
                PrivateKey = privateKey
            };

            _users[connectionId] = user;
            _sessionToConnection[sessionId] = connectionId;

            return connectionId;
        }

        public UserInfo? GetUserBySession(string sessionId)
        {
            if (_sessionToConnection.TryGetValue(sessionId, out var connectionId))
            {
                return GetUser(connectionId);
            }
            return null;
        }

        public UserInfo? GetUser(string connectionId)
        {
            _users.TryGetValue(connectionId, out var user);
            return user;
        }

        public void SetPartner(string connectionId1, string connectionId2)
        {
            if (_users.TryGetValue(connectionId1, out var user1))
                user1.PartnerConnectionId = connectionId2;

            if (_users.TryGetValue(connectionId2, out var user2))
                user2.PartnerConnectionId = connectionId1;
        }

        public void RemoveUser(string sessionId)
        {
            if (_sessionToConnection.TryRemove(sessionId, out var connectionId))
            {
                if (_users.TryRemove(connectionId, out var user) && user.PartnerConnectionId != null)
                {
                    if (_users.TryGetValue(user.PartnerConnectionId, out var partner))
                    {
                        partner.PartnerConnectionId = null;
                    }
                }
            }
        }

        public void AddPendingMessage(string toConnectionId, string fromConnectionId, string message)
        {
            if (_users.TryGetValue(toConnectionId, out var user))
            {
                user.PendingMessages.Enqueue((fromConnectionId, message));
            }
        }

        public void AddPendingConnectionRequest(string toConnectionId, string fromConnectionId)
        {
            if (_users.TryGetValue(toConnectionId, out var user))
            {
                user.PendingConnectionRequest = fromConnectionId;
            }
        }

        public void ClearPendingConnectionRequest(string connectionId)
        {
            if (_users.TryGetValue(connectionId, out var user))
            {
                user.PendingConnectionRequest = null;
            }
        }
    }
}
