using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlLite_Net6.Data;

namespace SqlLite_Net6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UsersController(DataContext dataContext)
        {
            _dataContext= dataContext;
        }

        [HttpPost]
        [Route("SignUp")]
        public async  Task<IActionResult> SignUpAsync([FromBody]  tbl_User Model)
        {
            try
            {
                if (Model == null)
                    return BadRequest();
                tbl_User objuser = new tbl_User();
                objuser.Email = Model.Email;
                objuser.FirstName = Model.FirstName;
                objuser.LastName = Model.LastName;
                objuser.Password = Model.Password;
                objuser.CreatedDate = DateTime.Now;
                await _dataContext.AddAsync(objuser);
                await _dataContext.SaveChangesAsync();
                return Ok(objuser.ID);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }  

            

        }
    }
}
