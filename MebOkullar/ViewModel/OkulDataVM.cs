using MebOkullar.Models;

namespace MebOkullar.ViewModel
{
    public class OkulDataVM
    {
            public int draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public List<Okul> data { get; set; }
    }
}
