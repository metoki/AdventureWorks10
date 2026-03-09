namespace AdventureWorks.Web
{
    public class Settings(string? blobContainerUrl,string? blobToken)
    {
        public string? BlobContainerUrl { get; set; } = blobContainerUrl;
        public string? BlobSASToken { get; set; } = blobToken;
    }
}
