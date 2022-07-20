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
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _UserDomain;
        private readonly IMapper _mapper;
        private readonly IUserLoginDomain _UserLoginDomain;

        public UserApplication(IUserDomain userDomain,IMapper mapper, IUserLoginDomain userLoginDomain)
        {
            _UserDomain = userDomain;
            _mapper = mapper;
            _UserLoginDomain = userLoginDomain;
        }

        public Response<UserDTO> Autheticate(string username, string password)
        {
           var response = new Response<UserDTO>();
            if (string.IsNullOrEmpty(username)|| string.IsNullOrEmpty(password))
            {
                response.Message = "Parametros vacios";
                return response;
            }
            try
            {
                var user = _UserDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UserDTO>(user);
                response.IsSuccess = true;
                response.Message = "Autenticacion exitosa";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess=false;
                response.Message = "El usuario no existe";
            }
            catch (Exception)
            {
                response.IsSuccess = false;
            }
            return response;
        }

        public Response<int> Insert(UserDTO user)
        {
            var response = new Response<int>();
            try
            {
                var userInsert = _mapper.Map<User>(user);
                UserLogin userLogin = new UserLogin();
                userLogin.UserName = user.Username;
                userLogin.Password = user.Password;

                userInsert.LoginId=_UserLoginDomain.Insert(userLogin);

                response.Data= _UserDomain.Insert(userInsert);
                
                if (response.Data >0)
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
