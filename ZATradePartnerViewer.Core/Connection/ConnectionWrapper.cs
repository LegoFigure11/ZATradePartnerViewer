using System.Diagnostics;
using System.Net.Sockets;
using ZATradePartnerViewer.Core.Structures;
using PKHeX.Core;
using SysBot.Base;
using static System.Buffers.Binary.BinaryPrimitives;
using static SysBot.Base.SwitchButton;
using static SysBot.Base.SwitchCommand;

namespace ZATradePartnerViewer.Core.Connection;

public class ConnectionWrapperAsync(SwitchConnectionConfig Config, Action<string> StatusUpdate) : Offsets
{
    public readonly ISwitchConnectionAsync Connection = Config.Protocol switch
    {
        SwitchProtocol.USB => new SwitchUSBAsync(Config.Port),
        _ => SwitchSocketAsync.CreateInstance(Config),
    };

    public bool Connected => IsConnected;
    private bool IsConnected { get; set; }
    private readonly bool CRLF = Config.Protocol is SwitchProtocol.WiFi;

    private readonly SAV9SV sav = new();

    private ulong PlayerMyStatusOffset;
    private ulong TradePartnerNIDOffset;
    private ulong TradePartnerTIDOffset;
    private ulong TradePartnerOTOffset;

    public async Task<(bool, string)> Connect(CancellationToken token)
    {
        if (Connected) return (true, "");

        try
        {
            StatusUpdate("Connecting...");
            Connection.Connect();
            IsConnected = true;

            StatusUpdate("Detecting Game Version");
            string title = await Connection.GetTitleID(token).ConfigureAwait(false);

            var myStatusPointer = title switch
            {
                LegendsZAID => PlayerMyStatusPointer,
                _           => throw new Exception("Cannot detect Legends: Z-A running on your switch!")
            };

            string v = await Connection.GetGameInfo("version", token).ConfigureAwait(false);
            if (!v.SequenceEqual(LegendsZAGameVersion))
                throw new Exception($"Game version is not supported. Expected version {LegendsZAGameVersion}, and current game version is {v}.");

            StatusUpdate("Caching Pointers...");
            PlayerMyStatusOffset = await Connection.PointerAll(myStatusPointer,  token).ConfigureAwait(false);


            StatusUpdate("Reading SAV...");
            var tid = await Connection.ReadBytesAbsoluteAsync(PlayerMyStatusOffset, 2, token).ConfigureAwait(false);
            var sid = await Connection.ReadBytesAbsoluteAsync(PlayerMyStatusOffset + 2, 2, token).ConfigureAwait(false);

            sav.MyStatus.TID16 = ReadUInt16LittleEndian(tid);
            sav.MyStatus.SID16 = ReadUInt16LittleEndian(sid);

            StatusUpdate("Connected!");
            return (true, "");
        }
        catch (SocketException e)
        {
            IsConnected = false;
            return (false, e.Message);
        }
    }

    public async Task<(bool, string)> DisconnectAsync(CancellationToken token)
    {
        if (!Connected) return (true, "");

        try
        {
            StatusUpdate("Disconnecting controller");
            await Connection.SendAsync(DetachController(CRLF), token).ConfigureAwait(false);

            StatusUpdate("Disconnecting...");
            Connection.Disconnect();
            IsConnected = false;
            StatusUpdate("Disconnected!");
            return (true, "");
        }
        catch (SocketException e)
        {
            IsConnected = false;
            return (false, e.Message);
        }
    }

    public async Task ResolveTradePointers(CancellationToken token)
    {
        var baseOffset = await Connection.PointerAll(TradePartnerDataPointer, token).ConfigureAwait(false);
        TradePartnerNIDOffset = baseOffset + TradePartnerNIDShift;
        TradePartnerTIDOffset = baseOffset + TradePartnerTIDShift;
        TradePartnerOTOffset = baseOffset + TradePartnerOTShift;
    }

    public (string TID, string SID) GetIDs()
    {
        var myStatus = sav.MyStatus;
        return ($"{myStatus.TID16:D05}", $"{myStatus.SID16:D05}");
    }
    public async Task<string> ReadNID(CancellationToken token)
    {
        var b = await Connection.ReadBytesAbsoluteAsync(TradePartnerNIDOffset, 8, token).ConfigureAwait(false);
        return Convert.ToHexString(b);
    }

    // https://github.com/kwsch/SysBot.NET/blob/master/SysBot.Pokemon/LZA/BotTrade/PokeTradeBotLZA.cs
    public async Task<(ulong, uint, uint, string)> ReadTradePartnerData(CancellationToken token)
    {
        // Grab a chunk of bytes starting from the NID. Most likely this will also include the OT and TID.
        // Check if data is loaded at the last byte of this chunk. If it's not loaded, we'll have to try and find OT and TID at the fallback location.
        var chunk = await Connection.ReadBytesAbsoluteAsync(TradePartnerNIDOffset, 0x69, token).ConfigureAwait(false);

        // NID should be the first 8 bytes, converted to a ulong.
        var id = chunk.AsSpan(0, 8).ToArray();
        var nid = BitConverter.ToUInt64(id);
        if (nid == 0) // They probably left too quickly, so try the backup pointer.
            nid = await GetTradePartnerNID(token).ConfigureAwait(false);

        // Now check if the last byte is populated.
        if (chunk[0x68] != 0)
        {
            // Data is loaded here, so we can read TID and OT from here.
            var tid = chunk.AsSpan(0x44, 4).ToArray();
            var name = chunk.AsSpan(0x4C, 26).ToArray();

            var TIDSID = BitConverter.ToUInt32(tid, 0);
            var DisplayTID = TIDSID % 1_000_000;
            var DisplaySID = TIDSID / 1_000_000;
            var TrainerName = StringConverter8.GetString(name);
            return (nid, DisplayTID, DisplaySID, TrainerName);
        }
        // Data is not loaded at the expected place, so we have to read TID and OT from the fallback location.
        {
            chunk = await Connection.ReadBytesAbsoluteAsync(TradePartnerTIDOffset + FallBackTradePartnerDataShift, 34, token).ConfigureAwait(false);
            var tid = chunk.AsSpan(0, 4).ToArray();
            var name = chunk.AsSpan(0x8, 26).ToArray();

            var TIDSID = BitConverter.ToUInt32(tid, 0);
            var DisplayTID = TIDSID % 1_000_000;
            var DisplaySID = TIDSID / 1_000_000;
            var TrainerName = StringConverter8.GetString(name);
            return (nid, DisplayTID, DisplaySID, TrainerName);
        }
    }

    public async Task<ulong> GetTradePartnerNID(CancellationToken token)
    {
        var data = await Connection.PointerPeek(8, TradePartnerNIDPointer, token).ConfigureAwait(false);
        return BitConverter.ToUInt64(data, 0);
    }
}
