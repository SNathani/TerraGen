using System.Collections.Generic;

namespace TerraGen.Models
{
    public sealed class TerraGenSource
    {
        public string Version { get; set; } = "1.0.0";

        /// <summary>
        /// Azure connectivity
        /// </summary>
        public AzureConfiguration Azurerm { get; set; }

        /// <summary>
        /// Terraform backend storage connectivity
        /// </summary>
        public StorageConfiguration Storage { get; set; }

        #region Azure Services

        /// <summary>
        /// 
        /// </summary>
        public ApimConfiguration Apim { get; set; }

        #endregion
    }



    public class AzureConfiguration
    {
        public string SubscriptionId { get; set; }
        public string ResourceGroupName { get; set; }
        public string Location { get; set; }
    }

    public class StorageConfiguration
    {
        public string ResourceGroupName { get; set; }
        public string StorageAccountName { get; set; }
        public string ContainerName { get; set; }
        public string Key { get; set; }
    }

    public class ApimConfiguration
    {
        public ApimConfiguration()
        {
            Products = new List<ApimProduct>();
        }

        public string ApimName { get; set; } = "apim";

        /// <summary>
        /// Resource group assciated with APIM service instance
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// No resource creation. Only used to read existing apim instance information.
        /// </summary>
        public bool IsReadOnly { get; set; } = true;


        public List<ApimProduct> Products { get; set; }
        public List<ApimApi> Apis { get; set; }
    }

    public class ApimProduct
    {
        public ApimProduct()
        {
            Tags = new Dictionary<string, string>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string LegalTerms { get; set; }

        public bool IsSubscriptionRequired { get; set; } = false;
        public bool IsApprovalRequired { get; set; } = false;

        public bool IsPublished { get; set; } = true;

        public Dictionary<string, string> Tags { get; set; }
    }

    public class ApimApi
    {
        //NOTE: A API Policy is automatically linked with this id and a seperate policy file is created
        // with Id as the file name in the same folder
        public string Id { get; set; }      

        public string Name { get; set; }
        public string Description { get; set; }

        public string Revision { get; set; }
        public string RevisionDescription { get; set; }


        public string Path { get; set; }

        public string Protocols { get; set; } = "https";

        public string ServiceUrl { get; set; }

        public string Version { get; set; }
        public string VersionSetId { get; set; }
        public string VersionDescription { get; set; }

        /// <summary>
        /// Url for OpenApi+Json or WSDL link
        /// </summary>
        public string DocUrl { get; set; }
    }

    public sealed class TerraGenContext
    {
        //NOTE: The options are stored in .terragen folder om tgoptions.json file

        public TerraGenOptions Options { get; set; }


    }

    public class TerraGenOptions
    {
        /// <summary>
        /// Path relative to the root folder where TerraGen will be executed
        /// blank - will create the policy file in the same location as the api script file
        /// </summary>
        public string PoliciesPath { get; set; }


    }
}
