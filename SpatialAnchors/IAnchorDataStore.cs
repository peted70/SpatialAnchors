namespace SpatialAnchors
{
    public interface IAnchorDataStore
    {
        IEnumerable<AnchorData> GetAnchors(string userId);

        void AddAnchorForUser(string userId, AnchorData anchor);
    }
}