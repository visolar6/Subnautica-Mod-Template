namespace MODNAME.Config
{
    /// <summary>
    /// This class is used to store any data that you want to persist between game sessions. It will be automatically saved and loaded by Nautilus.
    /// You can add any properties you want to this class, and they will be serialized to a JSON file in the mod's config folder.
    /// You can also create multiple config files by creating multiple classes that inherit from ConfigFile.
    /// </summary>
    /// <remarks>
    /// <see cref="https://subnauticamodding.github.io/Nautilus/api/Nautilus.Json.ConfigFile.html"/>
    /// </remarks>
    public class SomeState : Nautilus.Json.ConfigFile
    {
        public int SomeValue { get; set; } = 0;
    }
}
