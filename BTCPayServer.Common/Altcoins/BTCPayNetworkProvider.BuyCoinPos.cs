using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBitcoin;
using NBXplorer;

namespace BTCPayServer
{
    public partial class BTCPayNetworkProvider
    {
        public void InitBuyCoinPos()
        {
            var nbxplorerNetwork = NBXplorerNetworkProvider.GetFromCryptoCode("BCP");
            Add(new BTCPayNetwork()
            {
                CryptoCode = nbxplorerNetwork.CryptoCode,
                DisplayName = "BuyCoinPos",
                BlockExplorerLink = NetworkType == NetworkType.Mainnet ? "http://185.2.101.142:3031/tx/{0}" : "http://185.2.101.142:3031/tx/{0}",
                NBXplorerNetwork = nbxplorerNetwork,
                UriScheme = "buycoinpos",
                DefaultRateRules = new[] 
                {
                                "BCP_X = BCP_BTC * BTC_X",
                                "BCP_BTC = bittrex(BCP_BTC)"
                },
                CryptoImagePath = "imlegacy/feathercoin.png",
                DefaultSettings = BTCPayDefaultSettings.GetDefaultSettings(NetworkType),
                CoinType = NetworkType == NetworkType.Mainnet ? new KeyPath("44'") : new KeyPath("1'")
            });
        }
    }
}
