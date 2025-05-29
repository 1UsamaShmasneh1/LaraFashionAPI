using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using File = Google.Apis.Drive.v3.Data.File;

namespace LaraFashionAPI.Google
{
    public class GoogleDriveManagament
    {
        public GoogleDriveManagament() 
        {
            _connection = new GoogleConnection();
            _driveService = _connection.GetDriveService();
        }

        private GoogleConnection _connection;
        private DriveService _driveService;

        public string UploadImage(string path)
        {
            var fileMetadata = new File()
            {
                Name = Path.GetFileName(path)
            };

            FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(path, FileMode.Open))
            {
                request = _driveService.Files.Create(fileMetadata, stream, "image/jpeg");
                request.Fields = "id";
                request.Upload();
            }
            var uploadFile = request.ResponseBody;
            return uploadFile.WebViewLink;
        }

        public string UploadImage(byte[] imageBytes, string fileName, string contentType = "image/jpeg")
        {
            var fileMetadata = new File()
            {
                Name = fileName
            };

            using (var stream = new MemoryStream(imageBytes)) 
            {
                var request = _driveService.Files.Create(fileMetadata, stream, contentType);
                request.Fields = "id, webViewLink, WebContentLink";
                request.Upload();
                var uploadFile = request.ResponseBody;

                var permission = new Permission
                {
                    Type = "anyone",
                    Role = "reader"
                };
                _driveService.Permissions.Create(permission, uploadFile.Id).Execute();

                return uploadFile.WebViewLink;
            }
        }
    }
}
