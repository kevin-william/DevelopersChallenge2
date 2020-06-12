using Constants;
using Entities;
using Entities.Enums;
using OFXFileReader.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OFXFileReader.Business.Implementations
{
    public class FileReader : IFileReader
    {

        public async Task<OFXEntity> ReadFile(Stream stream)
        {
            var stringBuilder = new StringBuilder();
            using (var reader = new StreamReader(stream))
            {
                while (reader.Peek() >= 0)
                    stringBuilder.AppendLine(await reader.ReadLineAsync());
            }
            return GetOFXEntityInstance(stringBuilder.ToString());
        }

        public OFXEntity GetOFXEntityInstance(string ofxString)
        {
            var ofxEntity = new OFXEntity();
            ofxEntity.Currency = GetOFXCurrency(ofxString);
            ofxEntity.OFXTransactions = GetTransactions(ofxString);
            return ofxEntity;
        }

        private OFXCurrenciesEnum GetOFXCurrency(string ofxString)
        {
            var match = Regex.Match(ofxString, RegexConstants.TransactionCurrencyRegex);

            switch (match.Value)
            {
                case "BRL":
                    return OFXCurrenciesEnum.BRL;
                case "EUR":
                    return OFXCurrenciesEnum.EUR;
                case "USD":
                    return OFXCurrenciesEnum.USD;
                case "CAD":
                    return OFXCurrenciesEnum.CAD;
                case "CNY":
                    return OFXCurrenciesEnum.CNY;
                case "ARS":
                    return OFXCurrenciesEnum.ARS;
                case "RUB":
                    return OFXCurrenciesEnum.RUB;
                case "GBP":
                    return OFXCurrenciesEnum.GBP;
                default:
                    return OFXCurrenciesEnum.UNDEFINED;
            }
        }

        private IEnumerable<OFXTransaction> GetTransactions(string ofxString)
        {
            var transactionList = new List<OFXTransaction>();
            var matches = Regex.Matches(ofxString, RegexConstants.TransactionRegex);

            foreach (Match match in matches)
            {
                transactionList.Add(GetOFXTransactionInstance(match));
            }
            return transactionList;
        }

        private OFXTransaction GetOFXTransactionInstance(Match transactionMatch)
        {
            var transaction = transactionMatch.Value;
            var ofxTransaction = new OFXTransaction
            {
                DateTime = GetTransactionDateTime(transaction),
                Description = GetTransactionDescription(transaction),
                Type = GetTransactionType(transaction),
                Value = GetTransactionValue(transaction)
            };
            return ofxTransaction;
        }


        private OFXTransactionTypeEnum GetTransactionType(string transaction)
        {
            var match = Regex.Match(transaction, RegexConstants.TransactionTypeRegex);

            switch (match.Value)
            {
                case "DEBIT":
                    return OFXTransactionTypeEnum.DEBIT;
                case "CREDIT":
                    return OFXTransactionTypeEnum.CREDIT;
                default:
                    return OFXTransactionTypeEnum.UNDEFINED;
            }
        }

        private DateTime GetTransactionDateTime(string transaction)
        {
            var OFXDTPOSTED = Regex.Match(transaction, RegexConstants.TransactionDateTime).Value;
            var date = new DateTime(
                int.Parse(OFXDTPOSTED.Substring(0, 4)),
                int.Parse(OFXDTPOSTED.Substring(4, 2)),
                int.Parse(OFXDTPOSTED.Substring(6, 2)),
                int.Parse(OFXDTPOSTED.Substring(8, 2)),
                int.Parse(OFXDTPOSTED.Substring(10, 2)),
                int.Parse(OFXDTPOSTED.Substring(12, 2))
                );
            return date;
        }

        private double GetTransactionValue(string transaction)
        {
            var OFXTRNAMT = Regex.Match(transaction, RegexConstants.TransactionValue).Value;
            return double.Parse(OFXTRNAMT, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
        }

        private string GetTransactionDescription(string transaction)
        {
            return Regex.Match(transaction, RegexConstants.TransactionDescription).Value;
        }

    }
}
