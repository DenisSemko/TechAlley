namespace FilesHub.API.Controllers;

/// <summary>
/// Controller for Catalog Items operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FilesHubController : ControllerBase
{
    #region PrivateFields

    private readonly IBucketService _bucketService;
    private readonly ILogger<FilesHubController> _logger;

    #endregion

    #region ctor

    public FilesHubController(IBucketService bucketService, ILogger<FilesHubController> logger)
    {
        _bucketService = bucketService ?? throw new ArgumentNullException(nameof(bucketService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    #endregion

    #region ControllerMethods
    /// <summary>
    /// Gets Catalog Items.
    /// </summary>
    /// <returns>
    /// Returns a List of Catalog Items.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetByFileName(string fileName)
    {
        _logger.Log(LogLevel.Information, "Executing CatalogItem Get");
        
       byte[] file = await _bucketService.DownloadFileAsync(fileName);

       return Ok(Convert.ToBase64String(file));
    }
    
    /// <summary>
    /// Uploads a new File to the AWS S3 bucket.
    /// </summary>
    /// <param name="command">
    /// Command for adding a new Catalog Item.
    /// </param>
    /// <returns>
    /// Returns newly created Catalog Item.
    /// </returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> UploadFile(IFormFile file)
    {
        _logger.Log(LogLevel.Information, "Uploading file to the bucket");
        
        bool result = await _bucketService.UploadFileAsync(file);
        return CreatedAtAction(nameof(UploadFile), result);
    }
    
    /// <summary>
    /// Delete Catalog Item.
    /// </summary>
    /// <param name="id">
    /// Catalog Item's ID to delete it.
    /// </param>
    /// <returns>
    /// Returns No content.
    /// </returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(string fileName)
    {
        _logger.Log(LogLevel.Information, "Executing CatalogItem Delete");
        
        await _bucketService.DeleteFileAsync(fileName);
        return NoContent();
    }
    #endregion
}