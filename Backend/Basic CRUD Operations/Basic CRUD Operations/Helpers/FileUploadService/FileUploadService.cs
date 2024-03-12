namespace Basic_CRUD_Operations.Helpers.FileUploadService
{
    public static class FileUploadService
    {
        public static async Task<string> UploadImageAsync(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    throw new ArgumentException("No file uploaded.");

                // Ensure the file is an image if needed
                if (!IsImage(file))
                    throw new ArgumentException("Uploaded file is not an image.");

                // Define a unique file name
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                // Define the path to save the uploaded file
                var folderPath = Path.Combine("wwwroot", "Uploads");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var filePath = Path.Combine(folderPath, fileName);
                // Save the file to the server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return filePath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static bool IsImage(IFormFile file)
        {
            // Check if the file is an image based on its content type
            return file.ContentType.StartsWith("image/");
        }
    }
}
