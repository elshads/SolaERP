using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SolaERP.Server.ModelService
{
    public class AppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        string? _connectionString;
        public AppUserService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, SqlDataAccess sqlDataAccess)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _connectionString = sqlDataAccess.ConnectionString;
        }

        public async Task <AppUser> GetCurrentUserAsync()
        {
            var result = new AppUser();
            try
            {
                var httpUser = _httpContextAccessor.HttpContext.User;
                result = await _userManager.GetUserAsync(httpUser);
            }
            catch (Exception e)
            {
                result.ReturnMessage = e.Message;
            }
            return result;
        }

        public int GetCurrentUserId()
        {
            var result = 0;
            try
            {
                var httpUser = _httpContextAccessor.HttpContext.User;
                var userId = _userManager.GetUserId(httpUser);
                if (userId != null) { result = int.Parse(userId); }
            }
            catch (Exception e)
            {
                var message = e.Message;
            }
            return result;
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            IEnumerable<AppUser> result = new List<AppUser>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var sql = $"SELECT * FROM Config.AppUser";
                    var _result = await cn.QueryAsync<AppUser>(sql);
                    if (_result != null)
                    {
                        result = _result;
                    }
                }
            }
            catch (Exception e)
            {
                var message = e.Message;
            }
            return result;
        }

        public async Task<AppUser> GetByIdAsync(int id)
        {
            var result = new AppUser();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var sql = $"SELECT * FROM Config.AppUser WHERE Id = {id}";
                    var _result = await cn.QueryAsync<AppUser>(sql);
                    if (_result != null)
                    {
                        result = _result.FirstOrDefault();
                    }
                }
            }
            catch (Exception e)
            {
                result.ReturnMessage = e.Message;
            }
            return result;
        }
    }
}
