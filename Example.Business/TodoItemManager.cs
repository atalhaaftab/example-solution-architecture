using System;
using Example.Data;
using Example.Model;

namespace Example.Business
{
    public class TodoItemManager : ITodoItemManager
    {
        private readonly ITodoItemRepository repository;

        public TodoItemManager(ITodoItemRepository repository)
        {
            this.repository = repository;
        }

        public async Task<TodoItem> CreateAsync(TodoItem item)
        {
            var result = await this.repository.CreateAsync(item);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var result = await this.repository.DeleteAsync(Id);
            return result;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            var result = await this.repository.GetAllAsync();
            return result;
        }

        public async Task<TodoItem> GetByIdAsync(Guid Id)
        {
            var result = await this.repository.GetByIdAsync(Id);
            return result;
        }

        public async Task<TodoItem> UpdateAsync(Guid Id, TodoItem item)
        {
            var result = await this.repository.UpdateAsync(Id, item);
            return result;
        }
    }
}

