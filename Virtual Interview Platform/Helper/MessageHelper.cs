namespace Virtual_Interview_Platform.Helper
{
    public class MessageHelper
    {
        public static string Success(string entity, string action)
        {
            return $"{entity} has been successfully {action}";
        }

        public static string Failure(string entity, string action)
        {
            return $"An error occured while {action} the {entity}";
        }

        public static string Exception(string entity, string action, string exception)
        {
            return $"An exception occured while {action} the {entity}: {exception}";
        }

        public static string ValidationError(string field)
        {
            return $"The {field} is invalid. Please check the {field}";
        }

        public static string AlredyExists(string field)
        {
            return $"{field} already exists";
        }

        public static string ErrorOccured(string message)
        {
            return $"An unexpected error occured : {message}";
        }

        public static string NotFound(string field)
        {
            return $"{field} not found";
        }

        public static string Message(string message)
        {
            return message;
        }
    }
}
