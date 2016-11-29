using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LTF.Interfaces;
using LTF.Models.DomainModel;
using LTF.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LTF.Controllers
{
    [Route("api/[controller]")]
    public class GetTokenController : MasterController
    {
        public GetTokenController(IUserLogic iuserLogic) : base(iuserLogic)
        {
        }

        [AllowAnonymous]
        [HttpPut]
        public dynamic Get([FromBody]User userInfo)
        {
            if (!ModelState.IsValid ||
                !userLogic.IsExists(userInfo.JobNumber, userInfo.Pwd))
            {
                return new Ret
                {
                    ReCode = Models.Enums.ReCodeEnum.Fail,
                    Msg = "请求数据格式不正确 | 用户不存在或密码错误"
                };
            }


            var now = DateTime.UtcNow;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.JobNumber)
            };
            var audienceConfig = Configuration.GetSection("JWT");
            var symmetricKeyAsBase64 = audienceConfig["Secret"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var options = new TokenProviderOptions
            {
                Audience = audienceConfig["Audience"],
                Issuer = audienceConfig["Issuer"],
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
            };

            var jwt = new JwtSecurityToken(
                issuer: options.Issuer,
                audience: options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(options.Expiration),
                signingCredentials: options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);


            return new Ret<Token>
            {
                ReCode = Models.Enums.ReCodeEnum.Success,
                Msg = "成功获取到令牌",
                Data = new Token
                {
                    AccessToken = encodedJwt,
                    ExpiresIn = (int)options.Expiration.TotalSeconds
                }
            };

        }



    }



}
