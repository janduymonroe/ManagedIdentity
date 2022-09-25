using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Azure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagedIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobStorageController : ControllerBase
    {
        private readonly BlobServiceClient _blobServiceClient;
        public BlobStorageController()
        {
            _blobServiceClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=wizstorage001;AccountKey=wcCOYAef4fnafUFsROqPxPyvJhy/LGzv+udMpV5JcN+ufV0uY3zBMqTBZ60Aa9lIieolrC1wGh50+AStfOOKEQ==;EndpointSuffix=core.windows.net"); ;
        }

        [HttpGet("Storage")]
        public Pageable<BlobContainerItem> GetAccessStorage()
        {

            var container = _blobServiceClient.GetBlobContainers();

            return container;
        }

        [HttpGet("{containerName}")]
        public IActionResult Get(string containerName)
        {
      
            var container = _blobServiceClient.GetBlobContainers().FirstOrDefault(cont => cont.Name == containerName);
                        
            if(container is null) return NotFound("Container não encontrado.");

            return Ok(container);  

        }

        [HttpPost]
        public IActionResult Post([FromBody] string containerName)
        {
            try
            {
                _blobServiceClient.CreateBlobContainer(containerName);
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{containerName}")]
        public IActionResult Delete(string containerName)
        {
            try
            {
                _blobServiceClient.DeleteBlobContainer(containerName);
                return Ok("Excluído com Sucesso");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
