using Microsoft.AspNetCore.Mvc;
using Miniprojet.Server.AppDbcontext;
using Miniprojet.Server.Repositories;
using Miniprojet.Shared.DTO;
using Miniprojet.Shared.Entites;
using System.Diagnostics.Contracts;
using System.IO;


namespace Miniprojet.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClient _client;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ClientController(IClient client, IWebHostEnvironment webHostEnvironment)
        {
            _client = client;
            _webHostEnvironment = webHostEnvironment;
        }



        // GET: api/<ClientController>
        [HttpGet]
        public async Task<ActionResult<List<Clients>>> GetAll()
        {
            var clients = await _client.GetClientsAsync();
            return Ok(clients);
        }

        // GET api/<ClientController>/5
        [HttpGet("{Clientid}")]
        public async Task<ActionResult<Clients>> Get(int clientid)
        {
           var client=await _client.GetClientByIdAsync(clientid);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }
        // GET api/<ContactController>/5
        [HttpGet("GetClientinContactdAsync/{clientId}")]
        public async Task<ActionResult<Clients>> GetbyClient(int clientId)
        {
            var client = await _client.GetClientinContactdAsync(clientId);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<int>> AddClient([FromBody] ClientDTO clientdto)
        {

            string ImgName;

            string Fullpath = Path.Combine(_webHostEnvironment.WebRootPath,"Image");

            if (!Directory.Exists(Fullpath))
            {
                Directory.CreateDirectory(Fullpath);
            }

            ImgName = Guid.NewGuid() + "_" + clientdto.ImageUrl;
            string ImgPath = Path.Combine(Fullpath, ImgName);

            await  using var stream = new FileStream(ImgPath, FileMode.Create) ;
            stream.Write(clientdto.NewImg, 0, clientdto.NewImg.Length);
           
            Clients client = new Clients()
            {
                RaisonSociale = clientdto.RaisonSociale,
                Description = clientdto.Description,
                Adresse1 = clientdto.Adresse1,
                Adresse2 = clientdto.Adresse2,
                CodePostal = clientdto.CodePostal,
                Ville = clientdto.Ville,
                Pays = clientdto.Pays,
                TelephoneSecreteriat = clientdto.TelephoneSecreteriat,
                ImageUrl = ImgName
            };
            int clientId = await _client.AddClientAsync(client);

            return Ok(clientId);


        }

        // Update api/<ClientController>/5
        [HttpPut("{clientId}")]
        public async Task<ActionResult> UpdateClient(int clientId, [FromBody] Clients client)
        {
          
            await _client.UpdateClientAsync(clientId,client);
            return NoContent();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{clientId}")]
        public async Task<ActionResult> DeleteClient(int clientId)
        {
            await _client.DeleteClientAsync(clientId);
            return NoContent();
        }
    }
}
