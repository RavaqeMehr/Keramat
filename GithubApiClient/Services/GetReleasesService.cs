using GithubApiClient.Models;
using RestSharp;

namespace GithubApiClient.Services {
    public class GetReleasesService {
        private readonly string owner;
        private readonly string repo;

        private RestClient client;

        public GetReleasesService(
            string owner,
            string repo
            ) {
            this.owner = owner;
            this.repo = repo;

            client = new RestClient();
        }

        public async Task<List<Release>?> Exe() {
            var url = $@"https://api.github.com/repos/{owner}/{repo}/releases";

            var req = new RestRequest(url);
            var res = await client.ExecuteAsync<List<Release>>(req);

            return res.Data;
        }
    }
}
