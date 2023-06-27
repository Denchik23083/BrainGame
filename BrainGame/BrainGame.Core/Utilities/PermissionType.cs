namespace BrainGame.Core.Utilities
{
    public enum PermissionType
    {
        //User, Admin, God
        GetQuiz,

        //Admin, God
        EditQuiz,
        RemoveUser,

        //God
        UserToAdmin,
        AdminToUser
    }
}
