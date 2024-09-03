using Microsoft.EntityFrameworkCore;
using SMSAPIProject.Database_Models;
using SMSAPIProject.Models.ResponseModel;
using SMSAPIProject.Models.ResponseModel.Master;
using SMSAPIProject.Services.IServices;

namespace SMSAPIProject.Services
{
    public class MasterService : IMasterService
    {
        private readonly SMS_Dev_DbContext _context;
        public MasterService(SMS_Dev_DbContext context)
        {
            _context = context;
        }

        public async Task<MasterRes> GetMasterData()
        {
            try
            {
                // Classes
                var classes = await _context.MstClasses.
                    Where(x => x.IsActive == true)
                    .Select(y => new DropdownResponseData()
                    {
                        Text = y.ClassName,
                        Value = y.Id.ToString()
                    }).ToListAsync();

                // Sections
                var sections = await _context.MstSections.
                    Where(x => x.IsActive == true)
                    .Select(y => new DropdownResponseData()
                    {
                        Text = y.SectionName,
                        Value = y.Id.ToString()
                    }).ToListAsync();

                // Roles
                var roles = await _context.MstRoles.
                    Where(x => x.IsActive == true)
                    .Select(y => new DropdownResponseData()
                    {
                        Text = y.RoleName,
                        Value = y.Id.ToString()
                    }).ToListAsync();

                // Salutations
                var salutations = await _context.MstSalutations.
                    Where(x => x.IsActive == true)
                    .Select(y => new DropdownResponseData()
                    {
                        Text = y.SalutationName,
                        Value = y.Id.ToString()
                    }).ToListAsync();

                return new MasterRes()
                {
                    Status = true,
                    Message = "Success",
                    Data = new MasterData()
                    {
                        Classes = classes,
                        Sections = sections,
                        Roles = roles,
                        Salutations = salutations
                    }
                };
            }
            catch (Exception ex)
            {
                return new MasterRes()
                {
                    Status = false,
                    Message = "Error",
                    Error = new ErrorModel()
                    {
                        StatusCode = "400",
                        ErrorDescryption = ex.Message
                    }
                };
            }
        }
    }
}
