namespace ReimaginedAdventure.Shared
{
    public static class LocalStorageKeys
    {
        private static readonly string _keyPrefix = typeof(LocalStorageKeys).FullName;
        public static readonly string UserData = $"{_keyPrefix}.{nameof(UserData)}";
    }
}