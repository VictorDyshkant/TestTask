using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Models;

public class AddressModel
{
    public string City { get; set; }

    public string Street { get; set; }

    public string State { get; set; }

    public string ZipPostalCode { get; set; }

    public string Country { get; set; }
}
