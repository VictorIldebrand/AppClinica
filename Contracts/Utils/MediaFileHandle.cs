using System;
using System.Collections.Generic;
using System.IO;

namespace Contracts.Utils
{
    public static class MediaFileHandle
    {
        private static List<string> AttachmentsRollbackList = new List<string>();
        private static string ProfileImagesPath = Environment.CurrentDirectory + @"/MediaFiles/ProfileImages/";
        private static string ProposalAttachmentsPath = Environment.CurrentDirectory + @"/MediaFiles/ProposalAttachments/";



        public static void RollbackProposalAttachments()
        {
            foreach (var file in AttachmentsRollbackList)
                File.Delete(ProposalAttachmentsPath + file);
        }
        public static string SaveProposalAttachment(string attachment)
        {
            var fileExtension = attachment.GetFileExtension();
            var fileName = Guid.NewGuid() + fileExtension;

            File.WriteAllBytes(ProposalAttachmentsPath + fileName, Convert.FromBase64String(attachment));

            AttachmentsRollbackList.Add(fileName);

            return fileName;
        }
    }
}
