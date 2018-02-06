namespace LinearRegression
{
    class Constants
    {
        public const string GET_FROM_CURRENCY = "Please input FROM currency: "; // for console
        public const string GET_TO_CURRENCY = "Please input TO currency: "; // for console
        public const string SUCCESS_MESSAGE = "The predicted currency exchange from {0} to {1} for {2} is {3:N4}"; // return the result with 4 decimal places
        public const string ERROR_MESSAGE = "Cannot calculate the prediction";
        public const string ERROR_MESSAGE_CANNOT_GET_EXCHANGE_RATE_FROM = "Cannot get the exchange rate for {0}. Please try again or change the FROM currency";
        public const string ERROR_MESSAGE_CANNOT_GET_EXCHANGE_RATE_TO = "Cannot get the exchange rate for {0}. Please change another exist TO currency";
        public const string ERROR_MESSAGE_CANNOT_GET_ENOUGH_INFORMATION = "Cannot get enough information";
        public const string ERROR_MESSAGE_INPUT_ARGUMENTS = "Need two input parameters for the FROM currency and the TO currency";
        public const string API_REQUEST = "{0}/{1}?base={2}";
        public const string API_ADDRESS = "https://api.fixer.io/"; // should put the rest api into the config file
        public const string API_DEFAULT_DATA_TYPE = "application/json";
        public const string API_DATE_FORMAT = "yyyy-MM-dd";
        public const int MONTH_COUNT = 12;
    }
}
