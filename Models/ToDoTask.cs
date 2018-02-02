using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace dotnetcoremvc.Models
{
    public class ToDoTasks
    {
        //If the app doesn provide an id, cosmosdb assign a GUID automatically
        [JsonProperty(PropertyName = "id")]
        public string id {get;set;}
        [JsonProperty(PropertyName = "nombre")]
        public string name {get;set;}
        [JsonProperty(PropertyName = "descripcion")]
        public string description {get;set;}
        [JsonProperty(PropertyName = "limite")]
        public string limitDate {get;set;}
        [JsonProperty(PropertyName = "completada")]
        public bool completed {get;set;}
    }

}