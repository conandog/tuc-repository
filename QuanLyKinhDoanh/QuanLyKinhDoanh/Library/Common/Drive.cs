using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Upload;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;

namespace QuanLyKinhDoanh.Library.Common
{
    public class Drive
    {
        /// <summary>
        /// Authenticating to Google using a Service account
        /// Documentation: https://developers.google.com/accounts/docs/OAuth2#serviceaccount
        /// </summary>
        /// <param name="serviceAccountEmail">From Google Developer console https://console.developers.google.com</param>
        /// <param name="keyFilePath">Location of the Service account key file downloaded from Google Developer console https://console.developers.google.com</param>
        /// <returns></returns>
        public static DriveService AuthenticateServiceAccount(string serviceAccountEmail, string keyFilePath)
        {
            UserCredential credential;
            string[] scopes = new string[] { DriveService.Scope.Drive,  // view and manage your files and documents
                                             DriveService.Scope.DriveAppdata,  // view and manage its own configuration data
                                             DriveService.Scope.DriveAppsReadonly,   // view your drive apps
                                             DriveService.Scope.DriveFile,   // view and manage files created by this app
                                             DriveService.Scope.DriveMetadataReadonly,   // view metadata for files
                                             DriveService.Scope.DriveReadonly,   // view files and documents on your drive
                                             DriveService.Scope.DriveScripts };  // modify your app scripts     

            using (var stream =
                new System.IO.FileStream("d:\\client_id.json", System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                string credPath = @"d:\drive-dotnet-quickstart.json";

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Tuc test",
            });

            return service;
        }

        public static File CreateDirectory(DriveService _service, string _title, string _description, string _parent)
        {
            if (_service == null)
            {
                _service = new DriveService(new BaseClientService.Initializer()
                {
                    ApiKey = "[API key]",  // from https://console.developers.google.com (Public API access)
                    ApplicationName = "Drive API Sample",
                });
            }

            File NewDirectory = null;

            // Create metaData for a new Directory
            File body = new File();
            body.Title = _title;
            body.Description = _description;
            body.MimeType = "application/vnd.google-apps.folder";
            body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };

            try
            {
                FilesResource.InsertRequest request = _service.Files.Insert(body);
                NewDirectory = request.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            return NewDirectory;
        }

        // tries to figure out the mime type of the file.
        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }

        public static File UploadFile(DriveService _service, string _uploadFile, string _parent)
        {

            if (System.IO.File.Exists(_uploadFile))
            {
                File body = new File();
                body.Title = System.IO.Path.GetFileName(_uploadFile);
                body.Description = "File uploaded by Tuc.Nguyen";
                body.MimeType = GetMimeType(_uploadFile);
                body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };

                // File's content.
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.InsertMediaUpload request = _service.Files.Insert(body, stream, GetMimeType(_uploadFile));
                    request.Upload();
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    return null;
                }
            }
            else {
                Console.WriteLine("File does not exist: " + _uploadFile);
                return null;
            }

        }
    }
}
