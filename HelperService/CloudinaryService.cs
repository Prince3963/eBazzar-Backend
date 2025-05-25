
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

public interface ICloudinaryService
{
    Task<string> uploadImages(IFormFile file);
}

public class CloudinaryService : ICloudinaryService
{
    private readonly Cloudinary cloudinary;
    public CloudinaryService(IConfiguration configuration)
    {
        var cloudName = configuration["Cloudinary:CloudName"];
        var apiKey = configuration["Cloudinary:ApiKey"];
        var apiSecret = configuration["Cloudinary:ApiSecret"];

        var account = new Account(cloudName, apiKey, apiSecret);
        cloudinary = new Cloudinary(account);
    }
    public async Task<string> uploadImages(IFormFile file)
    {
        if (file == null)
        {
            Console.WriteLine("ERROR: No file was received.");
            return "Error: No file was received.";
        }

        if (file.Length == 0)
        {
            Console.WriteLine("ERROR: Uploaded file is empty.");
            return "Error: Uploaded file is empty.";
        }

        // Check file type
        if (!file.ContentType.StartsWith("image"))
        {
            Console.WriteLine("ERROR: Invalid file type.");
            return "Error: Invalid file type.";
        }

        try
        {
            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Width(250).Height(250).Crop("fill")
                };

                var uploadResult = await cloudinary.UploadAsync(uploadParams);

                if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine("ERROR: Cloudinary upload failed. Status: " + uploadResult.StatusCode);
                    Console.WriteLine("Error message: " + uploadResult.Error?.Message);
                    return "Error: Cloudinary upload failed.";
                }

                return uploadResult.SecureUrl?.ToString() ?? "Error: Secure URL is empty.";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception in uploadImages: " + ex.Message);
            return "Error: Exception occurred during upload - " + ex.Message;
        }
    }


}