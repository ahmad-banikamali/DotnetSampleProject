using System.Diagnostics;
using Application.Auth.Login;
using Application.Auth.Signup;
using Application.PriceHistory.Command;
using Application.PriceHistory.Command.Dto;
using Application.PriceHistory.Query;
using Application.Product.Command.AddProduct;
using Application.Product.Query.GetAllProducts.Dto;
using Application.Product.Query.GetProduct.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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


    [Authorize]
    public async Task<IActionResult> ProductDetail(Guid id)
    {
        var response = await _mediator.Send(new GetProductRequest(id));

        if (response.Data == null)
            return View();

        ViewBag.productId = response.Data.Id;
        ViewBag.productName = response.Data.Name;

        var prices = await _mediator.Send(new GetAllPricesRequest(id));
        ViewBag.prices = prices.Data.PriceHistoryItems;

        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ProductDetail(AddPriceRequest addPriceRequest)
    {
        var productId = addPriceRequest.productId;
        await _mediator.Send(addPriceRequest);
        return RedirectToAction("ProductDetail", new { Guid = productId });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Signup()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Signup(SignupRequest request)
    {
        await _mediator.Send(request);
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}