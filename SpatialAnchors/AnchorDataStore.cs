using Azure;
using Azure.Data.Tables;

namespace SpatialAnchors
{
    public class AnchorDataStore : IAnchorDataStore
    {
        private static Uri storageUri = new Uri("https://anchorsstorage.table.core.windows.net/");
        private string tableName = "anchors";
        private string accountName;
        private string storageAccountKey;

        private TableClient _tableClient;


        public AnchorDataStore(IConfiguration config)
        {
            accountName = config.GetValue<string>("accountName");
            storageAccountKey = config.GetValue<string>("storageAccountKey");

            _tableClient = new TableClient(
                storageUri,
                tableName,
                new TableSharedKeyCredential(accountName, storageAccountKey));

            // Create the table in the service.
            _tableClient.CreateIfNotExists();
        }

        public void AddAnchorForUser(string userId, AnchorData anchor)
        {
            var entity = new TableEntity(userId, anchor.AnchorId.ToString())
            {
                { "Created", anchor.Created },
                { "Description", anchor.Description },
            };

            // Add the newly created entity.
            _tableClient.AddEntity(entity);
        }

        public IEnumerable<AnchorData> GetAnchors(string userId = "")
        {
            var filter = userId == "" ? string.Empty : $"PartitionKey eq '{userId}'";
            Pageable<TableEntity> queryResultsFilter = _tableClient.Query<TableEntity>(filter: filter);

            var results = new List<AnchorData>();

            // Iterate the <see cref="Pageable"> to access all queried entities.
            foreach (TableEntity qEntity in queryResultsFilter)
            {
                results.Add(new AnchorData 
                    { 
                        Created = qEntity.GetDateTime("Created") ?? default(DateTime), 
                        Description = qEntity.GetString("Description") 
                    });
            }

            return results;
        }
    }
}
