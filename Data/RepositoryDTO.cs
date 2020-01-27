using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLURLPOC.Data
{
    public class RepositoryDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("homepage")]
        public string HomePage { get; set; }
        [JsonProperty("_private")]
        public bool _private { get; set; }
        [JsonProperty("has_issues")]
        public bool Has_issues { get; set; }
        [JsonProperty("has_projects")]
        public bool Has_projects { get; set; }
        [JsonProperty("has_wiki")]
        public bool Has_wiki { get; set; }
        [JsonProperty("is_template")]
        public bool Is_template { get; set; }
        [JsonProperty("team_id")]
        public int Team_id { get; set; }
        [JsonProperty("auto_init")]
        public bool Auto_init { get; set; }
        [JsonProperty("gitignore_template")]
        public string Gitignore_template { get; set; }
        [JsonProperty("license_template")]
        public string License_template { get; set; }
        [JsonProperty("allow_squash_merge")]
        public bool Allow_squash_merge { get; set; }
        [JsonProperty("allow_merge_commit")]
        public bool Allow_merge_commit { get; set; }
        [JsonProperty("allow_rebase_merge")]
        public bool Allow_rebase_merge { get; set; }
    }
}
