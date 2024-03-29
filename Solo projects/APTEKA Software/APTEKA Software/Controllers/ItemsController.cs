﻿using APTEKA_Software.Helpers;
using APTEKA_Software.Models;
using APTEKA_Software.Models.Dto;
using APTEKA_Software.Models.ViewModels;
using APTEKA_Software.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APTEKA_Software.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemService itemService;
        private readonly IUserService userService;
        private readonly IMapper modelMapper;
        private readonly AuthManager authManager;

        public ItemsController(IItemService itemService, IMapper modelMapper, IUserService userService, AuthManager authManager)
        {
            this.itemService = itemService;
            this.modelMapper = modelMapper;
            this.userService = userService;
            this.authManager = authManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Item> items = itemService.GetAllItems();
            List<ItemViewModel> itemViewModels = modelMapper.Map<List<ItemViewModel>>(items);

            ViewBag.ItemNames = new List<string> { "Валидол", "NoSpa", "Vitamin C", "Vitamin D" };

            return View(itemViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ItemViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            var user = this.authManager.CurrentUser;
            var createdItem = this.itemService.CreateItem(modelMapper.Map<ItemDto>(viewModel));

            List<string> updatedItemNames = itemService.GetAllItemNames();
            ViewBag.ItemNames = updatedItemNames;

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Item item = itemService.GetItemById(Id);

            if (item == null)
            {
                return RedirectToAction("Index");
            }

            ItemViewModel viewModel = modelMapper.Map<ItemViewModel>(item);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            User currentUser = authManager.CurrentUser;

            Item updatedItem = modelMapper.Map<Item>(viewModel);
            itemService.UpdateItem(id, updatedItem);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            Item item = itemService.GetItemById(id);

            if (item == null)
            {
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id, bool confirm)
        {
            if (confirm)
            {
                itemService.DeleteItem(id);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult FilteredItems(string filterByItem)
        {
            List<string> allItemNames = itemService.GetAllItemNames();
            ViewBag.ItemNames = allItemNames;

            List<Item> items = new List<Item>();

            if (!string.IsNullOrEmpty(filterByItem))
            {
                items = itemService.GetItemsByFilter(filterByItem);
            }
            else
            {
                items = itemService.GetAllItems();
            }

            List<ItemViewModel> itemViewModels = modelMapper.Map<List<ItemViewModel>>(items);
            return View("Index", itemViewModels);
        }

    }
}
