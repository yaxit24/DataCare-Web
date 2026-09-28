
using System;
using System.Threading.Tasks;
using System.ComponentModel;

// ============================================================
// STUB: DevNet.WhatsApp.V2 / TagitIce — compile-time stubs only
// ============================================================

namespace DevNet.WhatsApp.V2 {
    public class WhatsAppClient : IDisposable {
        public event EventHandler<WhatsAppStateEventArgs> StateChanged;
        public event EventHandler<QRCodeEventArgs> QRCodeAvailable;
        public event EventHandler<MessageSentEventArgs> MessageSent;
        public event EventHandler<ConnectionEstablishedEventArgs> ConnectionEstablished;
        public WhatsAppState State { get; }
        public Task InitializeAsync(string profilePath) => Task.CompletedTask;
        public Task<bool> SendMessageAsync(string phone, string message) => Task.FromResult(false);
        public Task<bool> SendImageAsync(string phone, string imagePath, string caption) => Task.FromResult(false);
        public Task LogoutAsync() => Task.CompletedTask;
        public void Dispose() { }
    }
    public enum WhatsAppState { Disconnected, QRCodePending, Authenticated }
    public class WhatsAppStateEventArgs : EventArgs { public WhatsAppState State { get; set; } }
    public class QRCodeEventArgs : EventArgs { public string QRCode { get; set; } }
    public class MessageSentEventArgs : EventArgs { public bool Success { get; set; } }
    public class ConnectionEstablishedEventArgs : EventArgs { }
}

namespace TagitSDK {
    public class TagitDevices { 
        public static TagitDevices Instance { get; } = new TagitDevices();
        public event EventHandler TagRead;
        public void Start() { }
        public void Stop() { }
    }
    public class TagReadEventArgs : EventArgs { public string TagId { get; set; } }
}
