#region Copyright (c) Lokad 2009 - 2010
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System.Collections.Generic;
using Lokad.Translate.Entities;

namespace Lokad.Translate.ViewModels
{
    public class PageMappingsViewModel
    {
        public long Id { get; set; }
        public string PageUrl { get; set; }
        public IList<Mapping> Mappings { get; set; }
    }
}