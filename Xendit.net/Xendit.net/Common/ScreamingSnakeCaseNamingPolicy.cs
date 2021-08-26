namespace Xendit.net.Common
{
    using System;
    using System.Text.Json;

    public class ScreamingSnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public static ScreamingSnakeCaseNamingPolicy Instance { get; } = new ScreamingSnakeCaseNamingPolicy();

        public override string ConvertName(string name)
        {
            return name.ToScreamingSnakeCase();
        }
    }
}
