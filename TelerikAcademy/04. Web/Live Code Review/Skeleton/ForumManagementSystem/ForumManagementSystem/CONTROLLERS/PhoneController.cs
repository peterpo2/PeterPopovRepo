using ForumManagementSystem.Exceptions;
using ForumManagementSystem.Mappers;
using ForumManagementSystem.Models;
using ForumManagementSystem.services;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagementSystem.CONTROLLERS
{
    [ApiController]
    [Route("api/phonenumbers")]
    public class PhoneController : ControllerBase
    {
        readonly private IPhoneService PHONESERVICE;
        readonly private PhoneMapper PHONEMAPPER;

        public PhoneController(IPhoneService pHONESERVICE, PhoneMapper pHONEMAPPER)
        {
            PHONESERVICE = pHONESERVICE;
            PHONEMAPPER = pHONEMAPPER;
        }

        [HttpGet]
        public List<Phone> getAll()
        {
            return PHONESERVICE.GetAll();
        }

        // TODO
        [HttpPost("/create")]
        public IActionResult create([FromBody] PhoneDto phoneDto)
        {
            try 
            {
                Phone phone = PHONEMAPPER.dtoToObject(phoneDto);
                Phone createdPhone = PHONESERVICE.Create(phone);
                return this.StatusCode(StatusCodes.Status201Created, createdPhone);
            }
            catch (DuplicateEntityException e)
            {
                return this.StatusCode(StatusCodes.Status409Conflict);
            }
        }
    }
}
