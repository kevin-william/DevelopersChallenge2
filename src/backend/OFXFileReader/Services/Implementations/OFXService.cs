using DataAccess.Repositories.Interfaces;
using Entities;
using Entities.Enums;
using Entities.Helpers.Interfaces;
using OFXFileReader.Business.Interfaces;
using OFXFileReader.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFXFileReader.Services.Implementations
{
    public class OFXService : IOFXService
    {
        public IFileReader OFXFileReader { get; }
        public IOFXTransactionHelper OfxTransactionHelper { get; }
        public IOFXRepository TransactionsOFXRepository { get; }

        public OFXService(
            IFileReader ofxFileReader,
            IOFXTransactionHelper ofxTransactionHelper,
            IOFXRepository transactionsOFXRepository)
        {
            OFXFileReader = ofxFileReader ??
                throw new ArgumentNullException(nameof(ofxFileReader));
            OfxTransactionHelper = ofxTransactionHelper ??
                throw new ArgumentNullException(nameof(ofxTransactionHelper));
            TransactionsOFXRepository = transactionsOFXRepository ??
                throw new ArgumentNullException(nameof(transactionsOFXRepository));
        }

        public OFXEntity Get()
        {
            var result = TransactionsOFXRepository.Get();

            if(result == null)
            {
                return new OFXEntity();
            }

            return result;
        }

        public async Task SaveOFXTransactions(IEnumerable<Stream> fileListAsStream)
        {
            var ofxEntity = new OFXEntity();
            foreach (var stream in fileListAsStream)
            {
                var ofxEntityFronFile = (await ReadFile(stream));

                if (ofxEntity.OFXTransactions != null)
                {
                    ofxEntity.OFXTransactions = OfxTransactionHelper.Merge(ofxEntityFronFile.OFXTransactions, ofxEntity.OFXTransactions);
                }
                else
                {
                    ofxEntity.OFXTransactions = ofxEntityFronFile.OFXTransactions;
                }

                if(ofxEntity.Currency == OFXCurrenciesEnum.UNDEFINED && ofxEntityFronFile.Currency != OFXCurrenciesEnum.UNDEFINED)
                {
                    ofxEntity.Currency = ofxEntityFronFile.Currency;
                }                
            }           

            var ofxEntitySaved = Get();
            if (ofxEntitySaved != null && ofxEntitySaved.OFXTransactions != null)
            {
                ofxEntity.OFXTransactions = OfxTransactionHelper.Merge(ofxEntitySaved.OFXTransactions, ofxEntity.OFXTransactions).ToList();
            }            
            TransactionsOFXRepository.Save(ofxEntity);
        }

        private async Task<OFXEntity> ReadFile(Stream stream)
        {
            return await OFXFileReader.ReadFile(stream);
        }

    }
}
