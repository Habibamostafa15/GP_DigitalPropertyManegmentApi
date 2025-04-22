namespace GP_DigitalPropertyManegmentApi.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", folderName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = $"{Guid.NewGuid()}{file.FileName}";
            var filePath = Path.Combine(folderPath, fileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;
        }
        public static IEnumerable<string> UploadFiles(IEnumerable<IFormFile> files, string folderName)
        {
            var uploadedFileNames = new List<string>();
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", folderName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = $"{Guid.NewGuid()}{file.FileName}";
                    var filePath = Path.Combine(folderPath, fileName);

                    using var stream = new FileStream(filePath, FileMode.Create);
                    file.CopyTo(stream);

                    uploadedFileNames.Add(fileName);
                }
            }

            return uploadedFileNames;
        }

        public static void DeleteFile(string fileName, string folderName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", folderName, fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
        public static void DeleteFiles(IEnumerable<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                var uri = new Uri(fileName);
                string relativePath = uri.AbsolutePath;

                relativePath = Uri.UnescapeDataString(relativePath);

                var wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var fullPath = Path.Combine(wwwRootPath, relativePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));

                if (File.Exists(fullPath))
                    File.Delete(fullPath);
            }
        }

    }
}
