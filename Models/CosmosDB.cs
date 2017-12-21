using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace dotnetcoremvc.Models
{
    public static class CosmosDB
    {
        private static readonly string endPointUrl = "https://micosmos.documents.azure.com:443/";
        private static readonly string authKey = "OKKSsPamNJAlY3i5Fjm2juEKXl6Byb9RHxX4pIZS774qtQWmlrXTjyApmygctd2m4J5eZsLDm5LsoIXH2xZqcg==";
        private static DocumentClient cosmosClient = new DocumentClient(new Uri(endPointUrl),authKey);

        private static string databaseName = "MyCosmosDB";
        private static string collectionName = "MyCosmosCollection";
        public static async Task Initialize(){
            await cosmosClient.CreateDatabaseIfNotExistsAsync(new Database{Id = databaseName});
            await cosmosClient.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(databaseName), new DocumentCollection{Id = collectionName});
        }

        public static async Task<int> CreateToDoTaskAsync(){
            try{

            }
            catch(DocumentClientException de){

            }
        } 

    }
}