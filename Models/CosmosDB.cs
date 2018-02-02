using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System.Net;
using System.Linq;
using Newtonsoft.Json;

namespace dotnetcoremvc.Models
{
    public static class CosmosDB
    {
        private static readonly string endPointUrl = "https://micosmos.documents.azure.com:443/";
        private static readonly string authKey = "OKKSsPamNJAlY3i5Fjm2juEKXl6Byb9RHxX4pIZS774qtQWmlrXTjyApmygctd2m4J5eZsLDm5LsoIXH2xZqcg==";
        private static DocumentClient cosmosClient = new DocumentClient(new Uri(endPointUrl),authKey);

        private static string databaseName = "MyCosmosTodoDB";
        private static string collectionName = "MyCosmosToDoCollection";
        public static async Task Initialize(){
            await cosmosClient.CreateDatabaseIfNotExistsAsync(new Database{Id = databaseName});
            await cosmosClient.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(databaseName), new DocumentCollection{Id = collectionName});
        }

        public static async Task<string> CreateToDoTaskAsync(ToDoTasks theTask){
            try{
                await cosmosClient.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName,collectionName,theTask.id));
                //Found
                return "found";
            }
            catch(DocumentClientException de){
                if(de.StatusCode == HttpStatusCode.NotFound){
                    await cosmosClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName,collectionName),theTask);
                }
                else{
                    throw;
                }
                return "created";
            }
        } 

        public static async Task<bool> ReplaceTodoTaskAsync(string id,ToDoTasks theTask){        
            await cosmosClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName,collectionName,id),theTask);
            return true;                      
        }

        public static async Task<bool> DeleteTodoTaskAsync(string id){        
            await cosmosClient.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseName,collectionName,id));
            return true;                      
        }

        public static IQueryable<ToDoTasks> SelectDocuments(){
            FeedOptions queryOptions = new FeedOptions{MaxItemCount = -1};
            //Linq way
             IQueryable<ToDoTasks> toDoQuery = cosmosClient.CreateDocumentQuery<ToDoTasks>(
                UriFactory.CreateDocumentCollectionUri(databaseName,collectionName),
                "SELECT * FROM MyCosmosToDoCollection",
                queryOptions);

            return toDoQuery;
        }

    }
}