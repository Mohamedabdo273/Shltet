using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shelter.Models;
using Shltet.DTO;
using Shltet.Modles;
using Shltet.Services;
using Shltet.Services.IServices;
using Shltet.Utility;

namespace Shltet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles =SD.adminRole)]
    public class AdminController : ControllerBase
    {
        private readonly IShelterService _shelterService;
        private readonly IPetCategoryService _categoryService;
        private readonly IAdoptionRequestService _adoptionService;
        private readonly ISupportRequestService _supportService;
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(
            IShelterService shelterService,
            IPetCategoryService categoryService,
            IAdoptionRequestService adoptionService,
            ISupportRequestService supportService,
            IAccountService accountService,
            UserManager<ApplicationUser> userManager)
        {
            _shelterService = shelterService;
            _categoryService = categoryService;
            _adoptionService = adoptionService;
            _supportService = supportService;
            this._accountService = accountService;
            this._userManager = userManager;
        }

        [HttpPost("register-shelter-staff")]
        public async Task<IActionResult> RegisterShelterStaff([FromBody] ApplicationUserDto userDto,int shelterId)
        {
           var shelter = await _shelterService.GetShelterByIdAsync(userDto.shelterID.Value);
            if (shelter == null)
            {
                return BadRequest("Invalid ShelterId.");
            }

            if (userDto == null)
            {
                return BadRequest("Invalid user data.");
            }
            userDto.shelterID = shelterId;
            var response = await _accountService.RegisterAsync(userDto);

            if (response is not null && response.GetType() == typeof(object) && ((dynamic)response).Errors == null)
            {
                var user = await _userManager.FindByEmailAsync(userDto.Email);

                if (user == null)
                {
                    return BadRequest("User registration failed.");
                }

                var addRoleResult = await _userManager.AddToRoleAsync(user, SD.ShelterStaff);

                if (addRoleResult.Succeeded)
                {
                  
                    return Ok(new { Message = "Shelter Staff registered and role assigned successfully." });
                }
                return BadRequest(new { Message = "Failed to assign ShelterStaff role." });
            }

            
            return BadRequest(response);
        }


        
        [HttpGet("GetAllShelters")]
        public async Task<IActionResult> GetAllShelters()
        {
            try
            {
                var shelters = await _shelterService.GetAllSheltersAsync();
                return Ok(shelters);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving shelters: {ex.Message}");
            }
        }

        [HttpPost("CreateShelter")]
        public async Task<IActionResult> CreateShelter([FromBody] Shltet.Modles.Shelter shelter)
        {
            try
            {
                
                await _shelterService.CreateShelterAsync(shelter);
                return Ok("Shelter created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating shelter: {ex.Message}");
            }
        }

        [HttpPut("UpdateShelter/{id}")]
        public async Task<IActionResult> UpdateShelter(int id, [FromBody] Shltet.Modles.Shelter shelter)
        {
            try
            {
                var existing = await _shelterService.GetShelterByIdAsync(id);
                if (existing == null) return NotFound("Shelter not found.");

                shelter.Id = id;
                await _shelterService.UpdateShelterAsync(shelter);
                return Ok("Shelter updated.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating shelter: {ex.Message}");
            }
        }

        [HttpDelete("shelter/{id}")]
        public async Task<IActionResult> DeleteShelter(int id)
        {
            try
            {
                var shelter = await _shelterService.GetShelterByIdAsync(id);
                if (shelter == null) return NotFound("Shelter not found.");

                await _shelterService.DeleteShelterAsync(shelter);
                return Ok("Shelter deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting shelter: {ex.Message}");
            }
        }

        [HttpGet("categories/{shelterId}")]
        public async Task<IActionResult> GetCategories(int shelterId)
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync(shelterId);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving categories: {ex.Message}");
            }
        }

        [HttpPost("category")]
        public async Task<IActionResult> CreateCategory([FromBody] PetCategory category)
        {
            try
            {
                await _categoryService.CreateCategoryAsync(category);
                return Ok("Category created.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating category: {ex.Message}");
            }
        }

        [HttpPut("category/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] PetCategory category)
        {
            try
            {
                var existing = await _categoryService.GetCategoryByIdAsync(id);
                if (existing == null) return NotFound("Category not found.");

                category.Id = id;
                await _categoryService.UpdateCategoryAsync(category);
                return Ok("Category updated.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating category: {ex.Message}");
            }
        }

        [HttpDelete("category/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                if (category == null) return NotFound("Category not found.");

                await _categoryService.DeleteCategoryAsync(category);
                return Ok("Category deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting category: {ex.Message}");
            }
        }

        // ---------- ADOPTION REQUESTS ----------
        [HttpGet("adoption-requests/{shelterId}")]
        public async Task<IActionResult> GetAdoptionRequests(int shelterId)
        {
            try
            {
                var requests = await _adoptionService.GetAllRequestsAsync(shelterId);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching adoption requests: {ex.Message}");
            }
        }

        // ---------- SUPPORT REQUESTS ----------
        [HttpGet("support-requests/{shelterId}")]
        public async Task<IActionResult> GetSupportRequests(int shelterId)
        {
            try
            {
                var requests = await _supportService.GetAllSupportRequestsAsync(shelterId);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching support requests: {ex.Message}");
            }
        }
    }
}
