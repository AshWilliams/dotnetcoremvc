using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;


namespace dotnetcoremvc.Models
{
    public class ToDoTasks
    {
        public string id {get;set;}
        public string name {get;set;}
        public string description {get;set;}
        public string limitDate {get;set;}
    }

}