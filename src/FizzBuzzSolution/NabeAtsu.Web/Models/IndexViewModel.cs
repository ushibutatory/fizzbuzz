using NabeAtsu.Core;
using NabeAtsu.Web.Models.Abstracts;
using System.Collections.Generic;

namespace NabeAtsu.Web.Models
{
    public class IndexViewModel : BaseViewModel
    {
        public int Start { get; set; }

        public int Count { get; set; }

        public IEnumerable<Result> Results { get; set; }
    }
}
