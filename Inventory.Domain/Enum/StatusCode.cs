namespace Inventory.Domain.Enum
{
    public enum StatusCode
    {
        ComputerAlreadyExists = 1,
        ComputerNotFound = 2,

        Ok = 200,
        InternalServerError = 500
    }
}
