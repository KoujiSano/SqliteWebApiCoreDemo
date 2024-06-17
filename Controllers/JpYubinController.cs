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
        /// �X�֔ԍ�����Z�������擾����API
        /// </summary>
        /// <param name="id">��������X�֔ԍ��i�n�C�t���Ȃ��j</param>
        /// <returns></returns>
        [HttpGet(Name = "GetJpYubinModel")]
        public IEnumerable<JpYubinModel> Get(string id)
        {

            using var connection = new SqliteConnection($@"Data Source={_env.ContentRootPath}\Database\kenall.db");

            var sql = $$"""
        SELECT  field3 AS '�X�֔ԍ�'
        ,       field7 AS '�s���{����' 
        ,       field8 AS '�s�撬����' 
        ,       field9 AS '���於' 
        ,       field4 AS '�s���{�����J�i' 
        ,       field5 AS '�s�撬�����J�i' 
        ,       field6 AS '���於�J�i' 

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
