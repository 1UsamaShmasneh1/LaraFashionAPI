using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using System.Text;

namespace LaraFashionAPI.Google
{
    public class GoogleConnection
    {
        private string[] SheetScopes = { SheetsService.Scope.Spreadsheets };
        private string[] DriveScopes = { DriveService.Scope.Drive };
        private string ApplicationName = "LaraFashion";
        private GoogleCredential? sheetCredential;
        private UserCredential? driveCredential;
        private SheetsService? sheetService;
        private DriveService? driveService;

        private void SetSheetCredential()
        {
            Console.WriteLine("File exists: " + File.Exists("secret.json"));
            using (var stream = new FileStream(@"secret.json", FileMode.Open, FileAccess.Read))
            {

                sheetCredential = GoogleCredential.FromStream(stream).CreateScoped(SheetScopes);

                 sheetCredential = GoogleCredential.FromStream(stream)
                    .CreateScoped(SheetScopes);
            }

            //var base64 = Environment.GetEnvironmentVariable("secret_base64");
            //var json = Encoding.UTF8.GetString(Convert.FromBase64String(base64));

            //using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            //{
            //     sheetCredential = GoogleCredential.FromStream(stream)
            //        .CreateScoped(SheetScopes);
            //}
        }

        private void SetDriveCredential()
        {
            using (var stream = new FileStream(@"secret.json", FileMode.Open, FileAccess.Read))
            {

                driveCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        DriveScopes,
                        ApplicationName,
                        CancellationToken.None,
                        new FileDataStore("token.json", true)
                    ).Result;
            }
        }

        private void SetSheetService()
        {
            sheetService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = sheetCredential,
                ApplicationName = ApplicationName,
            });
        }

        private void SetDriveService()
        {
            driveService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = driveCredential,
                ApplicationName = ApplicationName,
            });
        }

        public SheetsService GetSheetService()
        {
            SetSheetCredential();
            SetSheetService();
            return sheetService;
        }

        public DriveService GetDriveService()
        { 
            SetDriveCredential();
            SetDriveService();
            return driveService;
        }

    }   
}
