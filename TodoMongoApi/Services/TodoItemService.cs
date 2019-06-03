using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoMongoApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace TodoMongoApi.Services
{
    public class TodoItemService
    {
        private readonly IMongoCollection<TodoItem> _todoItems;

        public TodoItemService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("todoDb"));
            var database = client.GetDatabase("todoDb");
            _todoItems = database.GetCollection<TodoItem>("TodoItem");
        }

        public List<TodoItem> Get()
        {
            return _todoItems.Find(todoItem => true).ToList();
        }

        public TodoItem Get(string id)
        {
            return _todoItems.Find<TodoItem>(todoItem => todoItem.Id == id).FirstOrDefault();
        }

        public TodoItem Create(TodoItem todoItem)
        {
            _todoItems.InsertOne(todoItem);
            return todoItem;
        }

        public void Update(string id, TodoItem todoItemIn)
        {
            _todoItems.ReplaceOne(todoItem => todoItem.Id == id, todoItemIn);
        }

        public void Remove(TodoItem todoItemIn)
        {
            _todoItems.DeleteOne(todoItem => todoItem.Id == todoItemIn.Id);
        }

        public void Remove(string id)
        {
            _todoItems.DeleteOne(todoItem => todoItem.Id == id);
        }
    }
}
