using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.WebApi.Context;
using Portfolio.WebApi.Models;

namespace Portfolio.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ValuesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateMyInformation(MyInformationDto request)
    {
        MyInformation myInformation = _context.MyInformations.FirstOrDefault();
        if(myInformation is null)
        {
            myInformation = new();
            myInformation.Name = request.Name;
            myInformation.LastName= request.LastName;
            myInformation.Email = request.Email;
            myInformation.Adress = request.Adress;
            myInformation.Description = request.Description;
            _context.Add(myInformation);
        }
        else
        {
            myInformation.Name = request.Name;
            myInformation.LastName = request.LastName;
            myInformation.Email = request.Email;
            myInformation.Adress = request.Adress;
            myInformation.Description = request.Description;
            _context.Update(myInformation);
        }
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IActionResult GetMyInformation()
    {
        var response = _context.MyInformations.FirstOrDefault();
        return Ok(response);    
    }

    [HttpPost]
    public IActionResult CreateMySkills(MySkillDto request)
    {
        MySkill mySkill = _context.MySkills.Where(p=> p.Name == request.Name).FirstOrDefault();
        if(mySkill is not null)
        {
            return BadRequest("This skill already exists");
        }

        mySkill=new MySkill();
        mySkill.Name = request.Name;
        mySkill.Level = request.Level;
        _context.Add(mySkill);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IActionResult GetMySkills()
    {
        var response = _context.MySkills.ToList();
        return Ok(response);
    }
}
