using System.Collections.Generic;
using Lokad.Translate.Entities;

namespace Lokad.Translate.ViewModels
{
    public class MappingListViewModel
    {
        public string LanguageCode { get; set; }
        public IList<Mapping> Mappings { get; set; }
        public IList<Mapping> IgnoredMappings { get; set; }
    }
}