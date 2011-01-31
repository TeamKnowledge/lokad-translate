#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System.Collections.Generic;
using Lokad.Translate.Entities;

namespace Lokad.Translate.ViewModels
{
    public class MappingListViewModel
    {
        public string LanguageCode { get; set; }
        public IList<Mapping> Mappings { get; set; }
        public bool IsManager { get; set; }
    }
}