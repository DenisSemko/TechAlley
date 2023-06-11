namespace Ordering.Infrastructure.Persistence.EntityConfigurations;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsOne(m => m.BillingDetails, a =>
        {
            a.Property(p => p.FirstName).HasMaxLength(150)
                .HasColumnName("FirstName");
            a.Property(p => p.LastName).HasMaxLength(150)
                .HasColumnName("LastName");
            a.Property(p => p.Country).HasMaxLength(150)
                .HasColumnName("Country");
            a.Property(p => p.Street).HasMaxLength(600)
                .HasColumnName("Street");
            a.Property(p => p.City).HasMaxLength(150)
                .HasColumnName("City");
            a.Property(p => p.State).HasMaxLength(60)
                .HasColumnName("State");
            a.Property(p => p.PostCode).HasMaxLength(12)
                .HasColumnName("PostCode");
            a.Property(p => p.Phone).HasMaxLength(60)
                .HasColumnName("Phone");
            a.Property(p => p.EmailAddress).HasMaxLength(60)
                .HasColumnName("EmailAddress");
            a.WithOwner();
        });
        builder.OwnsOne(m => m.Payment, a =>
        {
            a.Property(p => p.CardName).HasMaxLength(150)
                .HasColumnName("CardName");
            a.Property(p => p.CardNumber).HasMaxLength(50)
                .HasColumnName("CardNumber");
            a.Property(p => p.Expiration).HasMaxLength(50)
                .HasColumnName("Expiration");
            a.Property(p => p.CVV).HasMaxLength(3)
                .HasColumnName("CVV");
            a.Property(p => p.PaymentMethod).HasMaxLength(50)
                .HasColumnName("PaymentMethod");
            a.WithOwner();
        });
    }
}