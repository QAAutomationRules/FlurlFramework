using ApprovalTests;
using ApprovalTests.Reporters;
using FluentAssertions;
using Flurl;
using Flurl.Http;
using FLURLPOC.Data;
using FLURLPOC.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FLURLPOC.Steps
{
    [Binding]
    [UseReporter(typeof(DiffReporter))]
    public sealed class StepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public StepDefinition(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"the user has a Github account")]
        public void GivenTheUserHasAGithubAccount()
        {
            
        }

        [When(@"the user executes a GET User call")]
        public void WhenTheUserExecutesAGETUserCall()
        {
            var userDTO = UserBuilder.BuildUser();

            var result = RESTHelpers.GETRequestAsync<UserResponseDTO>(
                ConfigurationManager.AppSettings["URL"],
                ConfigurationManager.AppSettings["UserResource"],
                HeaderBuilder.BuildHeader(),
                ConfigurationManager.AppSettings["UserName"],
                ConfigurationManager.AppSettings["Password"]).Result;

            context.Add("UserDTO", userDTO);
            context.Add("UserResponseDTO", result);
        }


        [Then(@"the user receives a response with the correct github project details")]
        public void ThenTheUserReceivesAResponseWithTheCorrectGithubProjectDetails()
        {
            var userResponseDTO = context.Get<UserResponseDTO>("UserResponseDTO");
            var userDTO = context.Get<UserDTO>("UserDTO");

            userResponseDTO.Login.Should().BeEquivalentTo(userDTO.Login);
            userResponseDTO.Id.Should().Be(userDTO.Id);
            userResponseDTO.NodeId.Should().BeEquivalentTo(userDTO.NodeId);
            userResponseDTO.AvatarUrl.Should().BeEquivalentTo(userDTO.AvatarUrl);
            userResponseDTO.GravatarId.Should().BeEquivalentTo(userDTO.GravatarId);
            userResponseDTO.Url.Should().BeEquivalentTo(userDTO.Url);

        }

        [When(@"the user Creates a new GitHub Repository")]
        public void WhenTheUserCreatesANewGitHubRepository()
        {

            var repository = RepositoryBuilder.BuildRepository();
            var jobj = JsonConvert.SerializeObject(repository);

            //Create a new repository
            var result = RESTHelpers.POSTRequestAsync<RepositoryResponseDTO>(
                    ConfigurationManager.AppSettings["URL"],
                    ConfigurationManager.AppSettings["RepositoryResource"],
                    HeaderBuilder.BuildHeader(),
                    ConfigurationManager.AppSettings["UserName"],
                    ConfigurationManager.AppSettings["Password"],
                    JObject.Parse(jobj)).Result;

            context.Add("RepositoryDTO", repository);
            context.Add("RepositoryResponseDTO", result);
            
        }

        [Then(@"the github repository is created in the system")]
        public void ThenTheGithubRepositoryIsCreatedInTheSystem()
        {
            var repositoryResponseDTO = context.Get<RepositoryResponseDTO>("RepositoryResponseDTO");
            var repositoryDTO = context.Get<RepositoryDTO>("RepositoryDTO");

            repositoryResponseDTO.Name.Should().BeEquivalentTo(repositoryDTO.Name);
            repositoryResponseDTO.Description.Should().BeEquivalentTo(repositoryDTO.Description);
            repositoryResponseDTO.Homepage.ToString().TrimEnd('/').Should().BeEquivalentTo(repositoryDTO.HomePage.ToString());
            repositoryResponseDTO.Private.Should().Be(repositoryDTO._private);
            repositoryResponseDTO.HasIssues.Should().Be(repositoryDTO.Has_issues);
            repositoryResponseDTO.HasProjects.Should().Be(repositoryDTO.Has_projects);
            repositoryResponseDTO.HasWiki.Should().Be(repositoryDTO.Has_wiki);
            repositoryResponseDTO.AllowSquashMerge.Should().Be(repositoryDTO.Allow_squash_merge);
            repositoryResponseDTO.AllowMergeCommit.Should().Be(repositoryDTO.Allow_merge_commit);
            repositoryResponseDTO.AllowRebaseMerge.Should().Be(repositoryDTO.Allow_rebase_merge);
            
        }

        [When(@"the user Deletes all GitHub Repositories")]
        public void WhenTheUserDeletesAllGitHubRepositories()
        {
            List<string> repoNames = new List<string>();

            var repos = RESTHelpers.GETList(
                   ConfigurationManager.AppSettings["URL"],
                   ConfigurationManager.AppSettings["UsersResource"] + 
                   ConfigurationManager.AppSettings["UserName"] +
                   ConfigurationManager.AppSettings["ReposResource"],
                   HeaderBuilder.BuildHeader(),
                   ConfigurationManager.AppSettings["UserName"],
                   ConfigurationManager.AppSettings["Password"]).Result;


            foreach (var repo in repos)
            {
                HttpResponseMessage result = RESTHelpers.DELETERequestAsync(
                    ConfigurationManager.AppSettings["URL"], 
                    repo.name, 
                    ConfigurationManager.AppSettings["ReposResource"],
                    HeaderBuilder.BuildHeader(),
                    ConfigurationManager.AppSettings["UserName"],
                    ConfigurationManager.AppSettings["Password"]).Result;

                Console.WriteLine(result.StatusCode.ToString());

                result.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }
        }

        [Then(@"the github repositories are Deleted from the system")]
        public void ThenTheGithubRepositoriesAreDeletedFromTheSystem()
        {
            var repos = RESTHelpers.GETList(
                ConfigurationManager.AppSettings["URL"],
                ConfigurationManager.AppSettings["UsersResource"] + 
                ConfigurationManager.AppSettings["UserName"] +
                ConfigurationManager.AppSettings["ReposResource"],
                HeaderBuilder.BuildHeader(),
                ConfigurationManager.AppSettings["UserName"],
                ConfigurationManager.AppSettings["Password"]).Result;

            Assert.IsTrue(repos.Length == 0);
        }


        [When(@"the user Edits a Repository in Github")]
        public void WhenTheUserEditsARepositoryInGithub()
        {
            var repository = RepositoryBuilder.BuildRepository();
            var patchRepository = RepositoryBuilder.BuildPatchRepository();
            var jobj = JsonConvert.SerializeObject(repository);        
            var patchJobj = JsonConvert.SerializeObject(patchRepository);

            //Create a new repository
            var result = RESTHelpers.POSTRequestAsync<RepositoryResponseDTO>(
                    ConfigurationManager.AppSettings["URL"],
                    ConfigurationManager.AppSettings["RepositoryResource"],
                    HeaderBuilder.BuildHeader(),
                    ConfigurationManager.AppSettings["UserName"],
                    ConfigurationManager.AppSettings["Password"],
                    JObject.Parse(jobj)).Result;

            //PATCH a repository
            var patchResult = RESTHelpers.PATCHRequestAsync<RepositoryResponseDTO>(
                   ConfigurationManager.AppSettings["URL"],
                   ConfigurationManager.AppSettings["ReposResource"],
                   repository.Name,
                   HeaderBuilder.BuildHeader(),
                   ConfigurationManager.AppSettings["UserName"],
                   ConfigurationManager.AppSettings["Password"],
                   JObject.Parse(patchJobj)).Result;

            context.Add("PATCHEDRepo", patchResult);
            context.Add("ExpectedPATCHREPO", patchRepository);
        }

        [Then(@"the github repository is edited")]
        public void ThenTheGithubRepositoryIsEdited()
        {
            var pathcedRepositoryResponseDTO = context.Get<RepositoryResponseDTO>("PATCHEDRepo");
            var pacthedRepositoryDTO = context.Get<PATCHRepositoryDTO>("ExpectedPATCHREPO");

            pathcedRepositoryResponseDTO.Name.Should().Be(pacthedRepositoryDTO.Name);
            pathcedRepositoryResponseDTO.Description.Should().Be(pacthedRepositoryDTO.Description);
            pathcedRepositoryResponseDTO.Homepage.Should().Be(pacthedRepositoryDTO.HomePage);
            pathcedRepositoryResponseDTO.AllowSquashMerge.Should().Be(pacthedRepositoryDTO.Allow_squash_merge);
            pathcedRepositoryResponseDTO.AllowMergeCommit.Should().Be(pacthedRepositoryDTO.Allow_merge_commit);
            pathcedRepositoryResponseDTO.AllowRebaseMerge.Should().Be(pacthedRepositoryDTO.Allow_rebase_merge);
        }


    }
}
