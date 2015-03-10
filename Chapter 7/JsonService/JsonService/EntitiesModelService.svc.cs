#pragma warning disable 1591

using System.ServiceModel;
using JsonService.JsonDto;
using JsonService;
using System;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;

namespace JsonService
{
    /// <summary>
    /// EntitiesModelService service class handler.
    /// </summary>
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public partial class EntitiesModelService : IEntitiesModelService
    {
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public IEnumerable<Contact> GetContacts()
        {
            List<Contact> contacts = new List<Contact>();
            contacts.Add(new Contact()
            {
                ID = 1,
                UserName = "keith",
                Password = "moose",
                DisplayName = "Keith Welch",
                FirstName = "Keith",
                LastName = "Welch",
                Picture="KeithWelch.jpg"
            });
            contacts.Add(new Contact()
            {
                ID = 2,
                UserName = "jd",
                Password = "jd",
                DisplayName = "Jane Doe",
                FirstName = "Jane",
                LastName = "Doe"
            });
            return contacts;
        }

        public void SaveContacts(IEnumerable<Contact> Contacts)
        {
        }

        public byte[] DownloadBytes(string Folder, string FileName)
        {
            try
            {
                // get some info about the input file
                string folder = GetSiteDirectory() + Folder;
                string filePath = Path.Combine(folder, FileName);
                FileInfo fileInfo = new FileInfo(filePath);

                // check if exists
                if (!fileInfo.Exists)
                {
                    return null;
                }

                // open stream
                FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
                stream.Close();
                return bytes;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public void UploadBytes(string FileName, string Folder, IEnumerable<byte> Bytes)
        {
            FileStream targetStream = null;

            string folder = GetSiteDirectory() + Folder;
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            string filePath = Path.Combine(folder, FileName);

            using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                targetStream.Write(Bytes.ToArray(), 0, Bytes.Count());
                targetStream.Close();
            }
        }

        private string GetSiteDirectory()
        {
            return System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
        }

    }
}
#pragma warning restore 1591
