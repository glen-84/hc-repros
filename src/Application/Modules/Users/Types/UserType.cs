using Application.Modules.Users.Entities;

namespace Application.Modules.Users.Types;

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(u => u.Id);

        descriptor.Field(u => u.EmailAddress)
            .Type<NonNullType<EmailAddressType>>();

        descriptor.Field(u => u.Username);
    }
}
