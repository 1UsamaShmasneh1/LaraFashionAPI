using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using LaraFashionAPI.Data;

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
        string[] rangs = ["A", "B", "C", "D", "E" , "F", "G", "H", "I", "J", "K", "L"];

        public void AddProductToSheet(Product product)
        {
            int lastId = 0;
            int productCount = 0;

            GetIds(ref productCount, ref lastId);

            product.Id = lastId + 1;
            int row = productCount + 2;

            for (var i = 0; i < 12; i++)
            {
                switch (i) 
                {
                    case 0:
                        SendUpdate(product.Id, $"Products!{rangs[i]}{row}");
                        break;
                    case 1:
                        SendUpdate(product.SerialNumber, $"Products!{rangs[i]}{row}");
                        break;
                    case 2:
                        SendUpdate(product.ProductName, $"Products!{rangs[i]}{row}");
                        break;
                    case 3:
                        SendUpdate(product.Category, $"Products!{rangs[i]}{row}");
                        break;
                    case 4:
                        SendUpdate(product.Price, $"Products!{rangs[i]}{row}");
                        break;
                    case 5:
                        SendUpdate(product.Descount, $"Products!{rangs[i]}{row}");
                        break;
                    case 6:
                        SendUpdate(product.Size.S3x4, $"Products!{rangs[i]}{row}");
                        break;
                    case 7:
                        SendUpdate(product.Size.S4x5, $"Products!{rangs[i]}{row}");
                        break;
                    case 8:
                        SendUpdate(product.Size.S5x6, $"Products!{rangs[i]}{row}");
                        break;
                    case 9:
                        SendUpdate(product.Size.S7x8, $"Products!{rangs[i]}{row}");
                        break;
                    case 10:
                        SendUpdate(product.Size.S9x10, $"Products!{rangs[i]}{row}");
                        break;
                    case 11:
                        SendUpdate(Convert.ToBase64String(product.ImageBytes), $"Products!{rangs[i]}{row}");
                        break;
                }
            }
        }

        private List<int> GetIds(ref int count, ref int last)
        {
            var request = _sheetsService.Spreadsheets.Values.Get(spreadsheetId, "Products!A2:A");
            var response = request.Execute();
            IList<IList<object>> vlaues = response.Values;
            if (vlaues != null && vlaues.Count > 0)
            {
                List<int> ids = vlaues.Select(row => Int32.Parse((string)row[0])).ToList();
                count = ids.Count;
                last = ids.Last();
                return ids;
            }
            return null;
        }

        private void SendUpdate(string value = "", string range = "")
        {
            var valueRange = new ValueRange();
            valueRange.Values = new List<IList<object>> { new List<object> { value } };
            var updateRequest = _sheetsService?.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
            if (updateRequest != null)
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            var updateResponse = updateRequest?.Execute();
        }

        private void SendUpdate(int value, string range = "")
        {
            var valueRange = new ValueRange();
            valueRange.Values = new List<IList<object>> { new List<object> { value } };
            var updateRequest = _sheetsService?.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
            if (updateRequest != null)
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            var updateResponse = updateRequest?.Execute();
        }

        private void SendUpdate(double value, string range = "")
        {
            var valueRange = new ValueRange();
            valueRange.Values = new List<IList<object>> { new List<object> { value } };
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
            valueRange.Values = new List<IList<object>> { new List<object> { value } };

            var updateRequest = _sheetsService?.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
            if (updateRequest != null)
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            var updateResponse = updateRequest?.Execute();
        }
    }
}