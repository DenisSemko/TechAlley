namespace Catalog.Application.Common;

public class Constants
{
    public class Logs
    {
        public const string CatalogItemUpdated = "Catalog item {0} is successfully updated";
        public const string CatalogWishlistCreated = "Catalog wishlist {0} is successfully created";
        public const string CatalogWishlistUpdated = "Catalog wishlist {0} is successfully updated";
        public const string CatalogWishlistDeleted = "Catalog wishlist {0} is successfully deleted";
    }

    public class Exceptions
    {
        public const string ItemNotFound = "{0} is not found";
    }
}