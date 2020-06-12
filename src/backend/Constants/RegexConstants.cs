namespace Constants
{
    public class RegexConstants
    {

        public const string TransactionRegex = @"(<STMTTRN>)([\s]+)?(<TRNTYPE>)([\s]+)?(\w+)([\s]+)?(<DTPOSTED>)([\d]+)(\[[\s\S][\d]{2}:[\w]{3}\])(([\s]+)?)(<TRNAMT>)(-)?([\d.]+)(([\s]+)?)(<MEMO>)([.\-\/\w\d\s]+)(<\/STMTTRN>)";
        public const string TransactionCurrencyRegex = @"(?<=<CURDEF>)([A-Z]{3})";
        public const string TransactionTypeRegex = @"(?<=<TRNTYPE>)([A-Z]{5}[A-Z]?)";
        public const string TransactionDateTime = @"(?<=<DTPOSTED>)([\d]{14})";
        public const string TransactionFuso = @"(\-|\+)([\d]{2}:[\w]{3})";
        public const string TransactionValue = @"(?<=<TRNAMT>(-)?)([\d]+)([.][\d]{2})";
        public const string TransactionDescription = @"(?<=<MEMO>)([\w-\s\/.])+";
        public const string JsonFilePattern = @"^([\s\S]+)(.json)";
    }
}
