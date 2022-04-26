using System;
using Example.Model;
namespace Example.Data
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(Guid Id);
        Task<TodoItem> CreateAsync(TodoItem item);
        Task<TodoItem> UpdateAsync(Guid Id, TodoItem item);
        Task<bool> DeleteAsync(Guid Id);
    }
}

