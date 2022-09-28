using AutoMapper;
using System.Linq;
using Codebella.Business.Abstract;
using Codebella.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Codebella.Entity;
using Codebella.Extensions;
using Codebella.WebUI.Models;
using System.Collections.Generic;

namespace Codebella.WebUI.Controllers;

public class ArticleController : Controller
{
    private readonly IArticleService _articleManager;
    private readonly IAuthorService _authorManager;
    private readonly ICategoryService _categoryManager;
    private readonly UserManager<User> _userManager;
    private readonly ITagService _tagManager;
    private readonly IMapper _mapper;
    public ArticleController(IArticleService articleManager, IAuthorService authorManager, ICategoryService categoryManager, UserManager<User> userManager, ITagService tagManager, IMapper mapper)
    {
        _articleManager = articleManager;
        _authorManager = authorManager;
        _userManager = userManager;
        _categoryManager = categoryManager;
        _tagManager = tagManager;
        _mapper = mapper;
    }
    // GET

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> CreateArticle()
    {
        return View(new CreateArticleDto
        {
            Categories = _mapper.Map<IEnumerable<CategoryDto>>((await _categoryManager.GetAllAsync()).Data)
        });
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateArticle(Article article, IEnumerable<string> tags)
    {
        var author = await _userManager.GetAuthorByUserEmailAsync(User.Identity.Name);
        article.AuthorId = author.Id;
        article.Slug = "";
        article.Tags = await HandleTags(tags);

        var articleResult = await _articleManager.AddAsync(article);
        article.Slug = (article.Title + "-" + article.Id).Slugify();
        await _articleManager.UpdateAsync(article);

        if (articleResult.Success)
        {
            this.FlashSuccess($@"Article {article.Id} successfully added");
        }
        else
        {
            this.FlashError($@"Error editing Article {article.Id}: {articleResult.Message}");
        }


        return RedirectToAction("Index", "Dashboard");
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> EditArticle(int id)
    {
        var article = await _articleManager.GetByIdAsync(id);
        var modelArticle = _mapper.Map<EditArticleDto>(article.Data);

        modelArticle.Categories = _mapper.Map<IEnumerable<CategoryDto>>((await _categoryManager.GetAllAsync()).Data);

        return View(modelArticle);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> EditArticle(Article article, IEnumerable<string> tags)
    {

        var articleResult = (await _articleManager.GetByIdAsync(article.Id)).Data;

        articleResult.Title = article.Title;
        articleResult.Content = article.Content;
        articleResult.CategoryId = article.CategoryId;

        articleResult.Tags.Clear();
        articleResult.Tags.AddRange(await HandleTags(tags));

        var result = await _articleManager.UpdateAsync(articleResult);

        if (result.Success)
        {
            this.FlashSuccess($@"Article {articleResult.Id} successfully modified");
        }
        else
        {
            this.FlashError($@"Error editing Article {articleResult.Id}: {result.Message}");
        }

        return RedirectToAction("Index", "Dashboard");
    }
    [Authorize]
    public async Task<IActionResult> DeleteArticle(int id)
    {
        var result = await _articleManager.DeleteByIdAsync(id);

        if (result.Success)
        {
            this.FlashSuccess("Article " + id + " successfully removed");
        }
        else
        {
            this.FlashError("Error on deleting Article " + id + ":<br>" + result.Message);
        };

        return RedirectToAction("Index", "Dashboard");
    }

    public async Task<List<Tag>> HandleTags(IEnumerable<string> tags)
    {
        var tagsList = new List<Tag>();

        foreach (var tag in tags)
        {
            var tagResult = await _tagManager.AddOrGetByNameAsync(tag);


            if (tagResult.Success)
            {
                tagsList.Add(tagResult.Data);
            }

        }

        return tagsList;
    }
}