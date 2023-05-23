using GithubApiClient.Models;

namespace GithubApiClient {

    public class GithubApiClient {
        private readonly string owner;
        private readonly string repo;

        public GithubApiClient(
            string owner,
            string repo
            ) {
            this.owner = owner;
            this.repo = repo;
        }


        public async Task<List<Release>?> GetReleases() {
            var service = new Services.GetReleasesService(owner, repo);
            return await service.Exe();
        }

    }
}