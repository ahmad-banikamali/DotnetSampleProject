using System.Data.Common;
using System.Diagnostics;
using Application.Product.Command.AddProduct;
using Application.Product.Query.GetAllProducts.Dto;
using Application.Product.Query.GetProduct.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Web.Models;

namespace Web.Controllers;

public class HomeController : Controller
{
    private readonly IMediator _mediator;

    public HomeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var task = await _mediator.Send(new GetAllProductsRequest());
        if (task.Data?.ProductList != null) ViewBag.Data = task.Data.ProductList;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(AddProductRequest request)
    {
        await _mediator.Send(request);

        var task = await _mediator.Send(new GetAllProductsRequest());
        if (task.Data?.ProductList != null) ViewBag.Data = task.Data.ProductList;

        return View();
    }


    public async Task<IActionResult> ProductDetail(Guid id)
    {
        var response = await _mediator.Send(new GetProductRequest(id));

        if (response.Data != null)
        {
            TempData["id"] = response.Data.Id;
        }

        return response.Data != null ? View(response.Data) : Error();
    }

    [HttpPost]
    public async Task<IActionResult> ProductDetail(string price)
    {
        return Error();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}