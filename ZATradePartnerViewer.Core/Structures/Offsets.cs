namespace ZATradePartnerViewer.Core.Structures;

public abstract class Offsets
{
    public const string LegendsZAID                                    = "0100F43008C44000";
    public const string LegendsZAGameVersion                           = "2.0.0";

    public static IReadOnlyList<long> PlayerMyStatusPointer   { get; } = [0x6105710, 0xA0, 0x40];

    public static IReadOnlyList<long> TradePartnerDataPointer { get; } = [0x40F73D8, 0x1D8, 0x30, 0xA0, 0x0];
    public static IReadOnlyList<long> TradePartnerNIDPointer  { get; } = [0x6108630, 0x108];

    public const uint TradePartnerNIDShift                             = 0x30;
    public const uint TradePartnerTIDShift                             = 0x74;
    public const uint TradePartnerOTShift                              = 0x7C;
    public const uint FallBackTradePartnerDataShift                    = 0x598;
}

