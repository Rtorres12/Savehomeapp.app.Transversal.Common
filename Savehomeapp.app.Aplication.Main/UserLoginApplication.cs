using AutoMapper;
using Exphadis.app.Application.DTO;
using Exphadis.app.Application.Interface;
using Exphadis.app.Domain.Entity;
using Exphadis.app.Domain.Interface;
using Savehomeapp.app.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Application.Main
{
    public class UserLoginApplication : IUserLoginApplication
    {
        private readonly IUserLoginDomain _UserLoginDomain;
        private readonly IMapper _mapper;
        public UserLoginApplication(IUserLoginDomain userLoginDomain, IMapper mapper)
        {
            _UserLoginDomain = userLoginDomain;
            _mapper = mapper;
        }
        public Response<int> Insert(UserLoginDTO login)
        {
            var response = new Response<int>();
            try
            {
                var userInsert = _mapper.Map<UserLogin>(login);
                response.Data = _UserLoginDomain.Insert(userInsert);
                if (response.Data > 0)
                {
                    response.IsSuccess = true;
                    response.Message = "Inserccion Exitosa";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;

            }
            return response;
        }
    }
}
