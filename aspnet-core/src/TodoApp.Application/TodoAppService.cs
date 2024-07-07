using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TodoApp
{
    public class TodoAppService : ApplicationService, ITodoAppService
    {

        private readonly IRepository<TodoItem, Guid> _repository;

        public TodoAppService(IRepository<TodoItem, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<TodoItemDto> CreateAsync(string text)
        {
            var todoItem = await _repository.InsertAsync
            (
                new TodoItem { Text = text }
            );

            return new TodoItemDto
            {
                Id = todoItem.Id,
                text = todoItem.Text
            };

        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<TodoItemDto>> GetListAsync()
        {
            var items = await _repository.GetListAsync();
            return items.Select(item => new TodoItemDto
            {
                Id = item.Id,
                text = item.Text
            }).ToList();
        }
    }
}
