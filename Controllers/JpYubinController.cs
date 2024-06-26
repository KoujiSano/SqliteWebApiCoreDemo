using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using SqliteWebApiCoreDemo.Models;

namespace SqliteWebApiCoreDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JpYubinController : ControllerBase
    {

        private readonly ILogger<JpYubinController> _logger;
        private readonly IWebHostEnvironment _env;

        public JpYubinController(ILogger<JpYubinController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        /// <summary>
        /// XÖÔ©çZîñðæ¾·éAPI
        /// </summary>
        /// <param name="id">õ·éXÖÔinCtÈµj</param>
        /// <returns></returns>
        [HttpGet(Name = "GetJpYubinModel")]
        public IEnumerable<JpYubinModel> Get(string id)
        {

            using var connection = new SqliteConnection($@"Data Source={_env.ContentRootPath}\Database\kenall.db");

            var sql = $$"""
        SELECT  field3 AS 'XÖÔ'
        ,       field7 AS 's¹{§¼' 
        ,       field8 AS 'sæ¬º¼' 
        ,       field9 AS '¬æ¼' 
        ,       field4 AS 's¹{§¼Ji' 
        ,       field5 AS 'sæ¬º¼Ji' 
        ,       field6 AS '¬æ¼Ji' 

        FROM utf_ken_all
        WHERE field3 = @id
    """;
            var parameters = new
            {
                id = id
            };

            var command = new CommandDefinition(sql,parameters);

            var result = connection.Query<JpYubinModel>(command);

            return result;

        }
    }
}
