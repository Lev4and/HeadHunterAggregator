namespace HeadHunter.HttpClients.Resource.Import
{
    public class ImportHttpClient : ResourceHttpClient
    {
        public ImportHttpClient(string path) : base($"{ImportRoutes.ImportArea}/{path}")
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
        }
    }
}
