using DiaryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DiaryAPI.ModelConfigurations
{
    public class UserEntityTypeConfiguration:IEntityTypeConfiguration<User>
          
    {
        public void Configure(EntityTypeBuilder<User> builder )
        {
            // Configuring FirstName property
            builder.Property(userProperty => userProperty.FirstName)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasComment("user first name");

            //Configuring LastName property
            builder.Property(userProperty =>
            userProperty.LastName)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasComment("user last name");

            //Configuring RegisteredOn property
            builder.Property(userProperty =>
            userProperty.RegisteredOn)
                .IsRequired(false)
                .HasComment("user registering date and time")
                .HasDefaultValueSql("now()");

            //Configuring Email property
            builder.Property(userProperty =>
            userProperty.Email)
                .IsRequired(true)
                .HasMaxLength(250)
                .HasComment("user email");

            //Configuring Password property
            builder.Property(userProperty =>
            userProperty.Password)
                .IsRequired(true)
                .HasMaxLength(50)
                .HasComment("user password");

            //Configuring Username property
            builder.Property(userProperty =>
            userProperty.Username)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasComment("user username");

            //Configuring Gender property
            builder.Property(userProperty =>
            userProperty.Gender)
                .IsRequired(false)
                .HasMaxLength(10)
                .HasComment("user gender");

            //Configuring IsActive property
            builder.Property(userProperty =>
            userProperty.IsActive)
                .IsRequired(false)
                .HasMaxLength(250)
                .HasComment("user email")
                .HasDefaultValue(true);

        }

    }
}
