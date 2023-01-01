using Application.Modules.Users.Entities;

namespace Application.Modules.Users.Types;

public sealed class ActiveUserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor
            .Name("ActiveUser")
            .BindFieldsExplicitly();

        descriptor.Field(u => u.Id);

        descriptor.Field(u => u.Username);

        descriptor.Field(u => u.EmailAddress);
    }
}
