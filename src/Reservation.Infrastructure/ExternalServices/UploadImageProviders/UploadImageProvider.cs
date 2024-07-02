namespace Reservation.Infrastructure.ExternalServices.UploadImageProviders;

public sealed class UploadImageProvider : IUploadImageProvider
{

    public async Task<string> GetUrl(string objectKey)
    {
        Env.Load();

        // creating AmazonS3Config instance
        AmazonS3Config config = new()
        {
            ServiceURL = Env.GetString("LIARA_ENDPOINT"),
            ForcePathStyle = true,
            SignatureVersion = "4"
        };

        var credentials = new BasicAWSCredentials(Env.GetString("LIARA_ACCESS_KEY"), Env.GetString("LIARA_SECRET_KEY"));
        using var client = new AmazonS3Client(credentials, config);

        ListObjectsV2Request request = new()
        {
            BucketName = Env.GetString("LIARA_BUCKET_NAME"),
        };

        var response = await client.ListObjectsV2Async(request);
        var result = response.S3Objects.Any(s => s.Key == objectKey);
        if (!result)
        {
            return null;
        }

        GetPreSignedUrlRequest urlRequest = new()
        {
            BucketName = Env.GetString("LIARA_BUCKET_NAME"),
            Key = objectKey,
            Expires = DateTime.Now.AddHours(1)
        };

        return await client.GetPreSignedURLAsync(urlRequest);
    }

    public async Task<string> Insert(IFormFile file, Guid subjectId)
    {
        Env.Load();

        // creating AmazonS3Config instance
        AmazonS3Config config = new()
        {
            ServiceURL = Env.GetString("LIARA_ENDPOINT"),
            ForcePathStyle = true,
            SignatureVersion = "4"
        };

        var credentials = new BasicAWSCredentials(Env.GetString("LIARA_ACCESS_KEY"), Env.GetString("LIARA_SECRET_KEY"));
        using var client = new AmazonS3Client(credentials, config);
        var objectKey = $"{Guid.NewGuid()}{file.FileName.Replace(" ", "")}@{subjectId}";

        try
        {

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream).ConfigureAwait(false);

            PutObjectRequest request = new()
            {
                BucketName = Env.GetString("LIARA_BUCKET_NAME"),
                Key = objectKey,
                InputStream = memoryStream,
            };

            // uploading image in bucket
            await client.PutObjectAsync(request);
            Console.WriteLine($"File '{objectKey}' uploaded successfully.");
            return objectKey;
        }
        catch (AmazonS3Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            return null;
        }
    }

    public async Task<string> Remove(string objectKey)
    {
        Env.Load();

        // creating AmazonS3Config instance
        AmazonS3Config config = new()
        {
            ServiceURL = Env.GetString("LIARA_ENDPOINT"),
            ForcePathStyle = true,
            SignatureVersion = "4"
        };

        try
        {
            var credentials = new BasicAWSCredentials(Env.GetString("LIARA_ACCESS_KEY"), Env.GetString("LIARA_SECRET_KEY"));
            using var client = new AmazonS3Client(credentials, config);

            #region Check Exist File
            ListObjectsV2Request request = new()
            {
                BucketName = Env.GetString("LIARA_BUCKET_NAME"),
            };

            var response = await client.ListObjectsV2Async(request);
            var result = response.S3Objects.Any(s => s.Key == objectKey);
            if (!result)
            {
                return null;
            }
            #endregion

            DeleteObjectRequest deleteRequest = new()
            {
                BucketName = Env.GetString("LIARA_BUCKET_NAME"),
                Key = objectKey
            };

            await client.DeleteObjectAsync(deleteRequest);
            return string.Empty;
        }
        catch (AmazonS3Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            return null;
        }
    }
}