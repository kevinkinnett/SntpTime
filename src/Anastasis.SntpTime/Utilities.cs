namespace Anastasis.SntpTime
{
    public static class Utilities
    {
        public static Mode GetModeFromByteArray(byte[] bytes)
        {
            // Isolate bits 0 - 3
            var val = (bytes[0] & 0x7);
            switch (val)
            {
                case 0: goto default;
                case 6: goto default;
                case 7: goto default;
                default:
                    return Mode.Unknown;
                case 1:
                    return Mode.SymmetricActive;
                case 2:
                    return Mode.SymmetricPassive;
                case 3:
                    return Mode.Client;
                case 4:
                    return Mode.Server;
                case 5:
                    return Mode.Broadcast;
            }
        }
    }
}