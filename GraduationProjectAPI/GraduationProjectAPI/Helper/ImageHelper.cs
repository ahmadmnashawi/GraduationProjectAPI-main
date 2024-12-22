namespace GraduationProjectAPI.Helper
{
    public static class ImageHelper
    {
        public static byte[] GetImagePathAsync(IFormFile formFile)
        {
            byte[] array = { };
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    array = memoryStream.ToArray();
                }

            }

            return array;
        }
        public static IFormFile GetFilePathAsync(byte[] byteArray)
        {
            var stream = new MemoryStream(byteArray);
            IFormFile file = new FormFile(stream, 0, byteArray.Length, "name", "fileName");
            return file;
        }
    }
}
