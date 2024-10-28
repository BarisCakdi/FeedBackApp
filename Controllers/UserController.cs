// using FeedBackApp.Data;
// using FeedBackApp.DTOs;
// using FeedBackApp.Model;
// using Microsoft.AspNetCore.Mvc;
//
// namespace FeedBackApp.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]/[action]")]
//     public class UserController : ControllerBase
//     {
//         private readonly AppDbContext _context;
//
//         public UserController(AppDbContext context)
//         {
//             _context = context;
//         }
//         [HttpGet]
//         public IActionResult GetClients()
//         {
//             var users = _context.Users.ToList();
//             return Ok(users);  
//         }
//
//         [HttpPost("/SaveUser")]
//         public IActionResult SaveUser(dtoUser model)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(new { message = "Eksik veya hatalı giriş yaptınız." });
//             }
//             var data = new ApplicationUser();
//
//             if (model.Id is not 0)
//             {
//                 data = _context.Users.Find(model.Id);
//                 data.Email = model.Email;
//                 
//                 _context.Users.Update(data);
//             }
//             else
//             {
//                 data.Email = model.Email;
//                 
//                 
//                 _context.Users.Add(data);
//                 
//             }
//
//             _context.SaveChanges();
//
//             return Ok($"Kullanıcı Başarıyla eklendi.");
//         }
//         [HttpDelete("{id}")]
//         public string DeleteClient(int id)
//         {
//             try
//             {
//                 var client = _context.Users.Find(id);
//                 _context.Users.Remove(client);
//                 _context.SaveChanges();
//
//                 return "Silindi";
//             }
//             catch (Exception e)
//             {
//                 return "Silinemedi." + e.Message;
//             }
//         }
//     }
//
// }
