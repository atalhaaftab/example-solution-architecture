using System;
using Example.Model;
using Microsoft.EntityFrameworkCore;

namespace Example.Data
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly Context.TodoContext? _context;
        public TodoItemRepository(Context.TodoContext? context)
        {
            this._context = context;
        }

        public async Task<TodoItem?> CreateAsync(TodoItem item)
        {
            _context?.TodoItems.Add(item);
            var response = await _context?.SaveChangesAsync();
            return response > 0 ? item : null;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var todoItem = await _context.TodoItems.FindAsync(Id);

            _=_context.TodoItems.Remove(todoItem);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            var query = from x in _context?.TodoItems
                        select x;
            return await query.ToListAsync();
        }

        public async Task<TodoItem?> GetByIdAsync(Guid Id)
        {
            var todoItem = await _context.TodoItems.FindAsync(Id);
            if (todoItem == null)
                return null;

            return todoItem;
        }

        public async Task<TodoItem?> UpdateAsync(Guid Id, TodoItem item)
        {
            var todoItem = await _context.TodoItems.FindAsync(Id);
            if (todoItem == null)
                return null;
            todoItem.Name = item.Name;
            todoItem.IsComplete = item.IsComplete;
            var result = await _context.SaveChangesAsync();
            return result > 0 ? todoItem : null;
        }
    }
}

