using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bank.Controllers
{
    public class ClientController : ApiController
    {
        public ClientController()
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.clients_collection =
                Models.MongoHelper.database.GetCollection<Models.Client>("Clients");
        }

        
        // GET: api/Client
        public List<Models.Client> Get()
        {
            var filter = Builders<Models.Client>.Filter.Ne("_id", "");
            var result = Models.MongoHelper.clients_collection.Find(filter).ToList();
            return result;
        }

        // GET: api/Client/5
        public List<Models.Client> Get(string id)
        {
            var filter = Builders<Models.Client>.Filter.Eq("tel", id);
            var result = Models.MongoHelper.clients_collection.Find(filter).ToList();
            return result;
        }

        private static Random random = new Random();

        private object GenerateRandomID(int v)
        {
            string strarray = "abcdefghijklmnopqrstuvwxyz123456789";
            return new string(Enumerable.Repeat(strarray, v).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // POST: api/Client
        public string Post(Models.ClientInfo ci)
        {
            try
            {
                Object id = GenerateRandomID(24);

                Models.MongoHelper.clients_collection.InsertOneAsync(new Models.Client
                {

                    _id = id,
                    tel = ci.tel,
                    solde_bnq = ci.solde_bnq,
                    historique = ci.historique,
                    credit = ci.credit

                });

                return "Client created succesfully";
            }
            catch
            {
                return "Client not created";
            }
        }

     

        // DELETE: api/Client/5
        public string Delete(string id)
        {
            try
            {

                var filter = Builders<Models.Client>.Filter.Eq("tel", id);
                var result = Models.MongoHelper.clients_collection.DeleteOneAsync(filter);


                return "Client deleted succesfully";
            }
            catch
            {
                return "Problem occured";
            }
        }

       
    }
    
}
