using Catan.Players;

namespace Catan.Utilities {
    public static class GameOptionDictionaries {
        public static readonly Dictionary<string, GameOptions> BasicGameOptions = new() {
            {"1", GameOptions.BUILD },
            {"2", GameOptions.TRADE },
            {"3", GameOptions.BUY_CARD },
            {"4", GameOptions.END_ROUND },
        };

        public static readonly Dictionary<string, GameOptions> BuildGameOptions = new() {
            {"1", GameOptions.BUILD_STREET},
            {"2", GameOptions.BUILD_SETTLEMEN },
            {"3", GameOptions.BUILD_CITY},
        };

        public static readonly Dictionary<string, GameOptions> TradeGameOptions = new() {
            {"1", GameOptions.TRADE_PLAYER },
            {"2", GameOptions.TRADE_BANK},
        };

        public static readonly Dictionary<string, Colors> ColorOptions = new() {
            {"1", Colors.WHITE },
            {"2", Colors.RED},
            {"3", Colors.BLUE },
            {"4", Colors.YELLOW },
        };
    }
}
