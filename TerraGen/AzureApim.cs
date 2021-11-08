using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TerraGen
{
    public class AzureApim
    {
        [JsonIgnore]
        public string FeatureName { get; init; } = "APIM";

        public List<AzureApiSource> Apis {get;set;}
    }
}
