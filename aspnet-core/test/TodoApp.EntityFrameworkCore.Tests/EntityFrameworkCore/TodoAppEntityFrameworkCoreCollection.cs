using Xunit;

namespace TodoApp.EntityFrameworkCore;

[CollectionDefinition(TodoAppTestConsts.CollectionDefinitionName)]
public class TodoAppEntityFrameworkCoreCollection : ICollectionFixture<TodoAppEntityFrameworkCoreFixture>
{

}
