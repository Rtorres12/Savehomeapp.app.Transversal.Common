using AutoMapper;
using Exphadis.app.Application.DTO;
using Exphadis.app.Application.Interface;
using Exphadis.app.Domain.Interface;
using Savehomeapp.app.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Application.Main
{
    public class UserAdminApplication:IUserAdminApplication
    {

        private readonly IUserAdminDomain _UserAdminDomain;
        private readonly IMapper _mapper;
        private readonly IUserAdminLoginDomain _UserAdminLoginDomain;

        public UserAdminApplication(IUserAdminDomain userAdminDomain, IMapper mapper, IUserAdminLoginDomain userLoginDomain)
        {
            _UserAdminDomain = userAdminDomain;
            _mapper = mapper;
            _UserAdminLoginDomain = userLoginDomain;
        }

        public Response<UserAdminDTO> Autheticate(string username, string password)
        {
            var response = new Response<UserAdminDTO>();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "Parametros vacios";
                return response;
            }
            try
            {
                var user = _UserAdminDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UserAdminDTO>(user);
                response.IsSuccess = true;
                response.Message = "Autenticacion exitosa";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = false;
                response.Message = "El usuario no existe";
            }
            catch (Exception)
            {
                response.IsSuccess = false;
            }
            return response;
        }

        //public Response<int> Insert(UserDTO user)
        //{
        //    var response = new Response<int>();
        //    try
        //    {
        //        var userInsert = _mapper.Map<User>(user);
        //        UserLogin userLogin = new UserLogin();
        //        userLogin.UserName = user.Username;
        //        userLogin.Password = user.Password;

        //        userInsert.LoginId = _UserLoginDomain.Insert(userLogin);

        //        response.Data = _UserDomain.Insert(userInsert);

        //        if (response.Data > 0)
        //        {
        //            response.IsSuccess = true;
        //            response.Message = "Inserccion Exitosa";
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        response.Message = e.Message;

        //    }
        //    return response;
        //}

    }
}
