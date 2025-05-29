using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;

namespace LaraFashionAPI.Google
{
    public class GoogleSheetManagement
    {
        public GoogleSheetManagement() 
        {
            _connection = new GoogleConnection();
            _sheetsService = _connection.GetSheetService();
        }

        private GoogleConnection _connection;
        private SheetsService _sheetsService;
        string spreadsheetId = "1-c9wc9XvXJa3cZlDt8YViw_p9XYr4HoAugj85oELooM";

        public void AddProductToSheet(string range, string value)
        {
            if (_sheetsService == null)
            {
            }

            var valueRange = new ValueRange();
            valueRange.Values = new[] { new[] { value } };

            var updateRequest = _sheetsService?.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
            if (updateRequest != null)
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            var updateResponse = updateRequest?.Execute();
        }

        public void UpdateSheet(string range, string value)
        {
            if (_sheetsService == null)
            {
            }

            var valueRange = new ValueRange();
            valueRange.Values = new[] { new[] { value } };

            var updateRequest = _sheetsService?.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
            if (updateRequest != null)
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            var updateResponse = updateRequest?.Execute();
        }
    }
}