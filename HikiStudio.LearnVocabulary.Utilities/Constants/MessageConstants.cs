namespace HikiStudio.LearnVocabulary.Utilities.Constants
{
    public class MessageConstants
    {
        public static string DoNotHavePermission = "Access Denied, You Don't Have Permission.";

        public static string NotImplemented(string nameFuction, string? condition)
        {
            if (condition != null)
                return nameFuction + " NotImplemented with condition: " + condition;

            return nameFuction + " NotImplemented";
        }

        public static string AnErrorOccurredInFunction(string nameFunction, string message)
        {
            return $"An error occurred in function '{nameFunction}': {message}";
        }

        public static string GetObjectSuccess(string name)
        {
            return $"Retrieved {name} successfully.";
        }

        public static string ObjectNotFound(string name)
        {
            return name + " is not found.";
        }

        public static string ObjectAlreadyExists(string name)
        {
            return name + " already exists";
        }

        public static string ObjectActionSuccess(string name)
        {
            return name + " successfully.";
        }

        public static string CreateSuccess(string name)
        {
            return name + " created successfully.";
        }

        public static string UpdateSuccess(string name)
        {
            return name + " updated successfully.";
        }

        public static string DeleteSuccess(string name)
        {
            return name + " deleted successfully.";
        }

        public static string CurrentObjectDeleted(string name)
        {
            return name + " is deleted.";
        }

        public static string CurrentObjectNotDeleted(string name)
        {
            return name + " is not deleted.";
        }

        public static string TurnOnIsActive(string name)
        {
            return name + " is activated.";
        }

        public static string ModelStateIsNotValid(string name)
        {
            return "ModelState " + name + " is not valid.";
        }

        public static string ModelStateIsNotValid(string nameFunction, string nameModel)
        {
            return nameFunction + " Model State " + nameModel + " is not valid.";
        }

        public static string RestoreObjectSuccess(string name)
        {
            return name + " restored successfully.";
        }
    }
}
