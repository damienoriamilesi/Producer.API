using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace MyFirstApi.Controllers;

public class InvoiceController : ODataController
{
    // GET
    
    public IActionResult Index(ODataQueryOptions<Invoice> options)
    {
        return Ok();
    }
}

public class Invoice
{
    public int Id { get; set; }
    public string Label { get; set; }
}