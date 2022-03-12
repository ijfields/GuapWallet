using NBitcoin;
using NBitcoin.Crypto;

using NBitcoin.DataEncoders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
namespace GuapWallet.Models
{
    public static class RSA
    {

        public static Wallet KeyGenerate()
        {
            Key privateKey = new Key();
            BitcoinAddress v = privateKey.GetBitcoinSecret(Network.Main).GetAddress();
            BitcoinAddress address = BitcoinAddress.Create(v.ToString(), Network.Main);
           // PrivateKeys = creation.Keys.Where(k => k.PrivateKey != null).Select(k => k.PrivateKey).ToArray();
            return new Wallet { PublicKey = v.ToString(), PrivateKey = privateKey.GetBitcoinSecret(Network.Main).ToString() };
        }
        public static string Sign(string privKey, string msgToSign)
        {
            BitcoinSecret secret = Network.Main.CreateBitcoinSecret(privKey);
            var signature = secret.PrivateKey.Sign(msgToSign);
            //var bol = pkh.VerifyMessage(msgToSign, signature);
            BitcoinPubKeyAddress v = secret.PubKey.vVerifyMessage(msgToSign, signature);
            return signature;
            
        }
        public static bool Verify(string pbKey, string originalMessage, string signedMessagesg)
        {
            var address = BitcoinAddress.Create(pbKey, Network.Main);
            var pkh = (address as ipubkeyhashusable);
            var bol = pkh.verifyMessage(originalMessage, signedMessage);
            return bol;

            }
    }
}
