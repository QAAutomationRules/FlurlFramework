using FakerDotNet;
using FizzWare.NBuilder;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLURLPOC.Data
{
    public class RepositoryBuilder
    {
        public static RepositoryDTO BuildRepository()
        {
            RepositoryDTO repositoryDTO = Builder<RepositoryDTO>.CreateNew()
                    .With(c => c.Name = Faker.Hipster.Word())
                    .With(c => c.Description = Faker.Hipster.Sentence(4, true, 6))
                    .With(c => c.HomePage = "https://github.com")
                    .With(c => c._private = false)
                    .With(c => c.Has_issues = true)
                    .With(c => c.Has_projects = true)
                    .With(c => c.Has_wiki = true)
                    .With(c => c.Is_template = false)
                    .With(c => c.Auto_init = true)
                    .With(c => c.Gitignore_template = "VisualStudio")
                    .With(c => c.License_template = "mit")
                    .With(c => c.Allow_squash_merge = true)
                    .With(c => c.Allow_merge_commit = true)
                    .With(c => c.Allow_rebase_merge = true)
                .Build();

            return repositoryDTO;
        }

        public static PATCHRepositoryDTO BuildPatchRepository()
        {
            PATCHRepositoryDTO repositoryDTO = Builder<PATCHRepositoryDTO>.CreateNew()
                    .With(c => c.Name = Faker.Hipster.Word())
                    .With(c => c.Description = Faker.Hipster.Sentence(4, true, 6))
                    .With(c => c.HomePage = "https://google.com")
                    .With(c => c.Gitignore_template = "Python")
                    .With(c => c.License_template = "mit")
                    .With(c => c.Allow_squash_merge = false)
                    .With(c => c.Allow_merge_commit = true)
                    .With(c => c.Allow_rebase_merge = false)
                .Build();

            return repositoryDTO;
        }
    }
}
